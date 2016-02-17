using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Analyzer.Foundation;

namespace Analyzer
{
    /// <summary>
    /// Executes the analyzers in sequence.
    /// </summary>
    public class AnalyzerExecutor 
    {
        private List<Func<Foundation.AnalyzerOutputBase>> executors = new List<Func<AnalyzerOutputBase>>();
        public void AddToRunner<T_OUTPUT>(IAnalyzer<T_OUTPUT> analyzer, IInputProvider inputProvider) where T_OUTPUT : Foundation.AnalyzerOutputBase
        {
            Func<Foundation.AnalyzerOutputBase> executor = () =>
            {
                try
                {
                    var analyzerOutput = analyzer.Analyse(inputProvider.Input);
                    return analyzerOutput;
                }
                catch (Exception ex)
                {

                    var analyzerOutput = new Foundation.FailedAnalyzerOutput(analyzer.AnalyzerType);
                    analyzerOutput.Success = false;
                    analyzerOutput.Exception = ex;
                    return analyzerOutput;
                }
            };

            executors.Add(executor);
        }
        public List<Foundation.AnalyzerOutputBase> ExecuteSequentially()
        {
            // Use an array and size appropriately as this means we don't need any synchronisation locks in Lists, or other collection types.
            var outputList = new List<Foundation.AnalyzerOutputBase>();
            foreach(var executor in executors)
            {
                outputList.Add(executor());
            }
            return outputList;
        }
        public List<Foundation.AnalyzerOutputBase> ExecuteInParallel()
        {
            // Use an array and size appropriately as this means we don't need any synchronisation locks in Lists, or other collection types.
            var outputList = new Foundation.AnalyzerOutputBase[executors.Count];
            Parallel.ForEach(executors, (executor, state, i) =>
            {
                outputList[i] = executor();
            });
            return outputList.ToList();
        }
    }
}
