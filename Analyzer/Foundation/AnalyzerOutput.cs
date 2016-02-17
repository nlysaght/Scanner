using Analyzer.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Foundation
{
    public abstract class AnalyzerOutputBase
    {
        public AnalyzerOutputBase(AnalyzerTypeEnum analyzerType)
        {
            this.AnalyzerType = analyzerType;
        }
        public AnalyzerTypeEnum AnalyzerType { get; internal set; }
        public Exception Exception {get; internal set;}
        public bool Success { get; internal set; }
    }

    public class FailedAnalyzerOutput : Foundation.AnalyzerOutputBase
    {
        public FailedAnalyzerOutput(AnalyzerTypeEnum analyzerType) : base(analyzerType)
        {
        }
        public bool Failed { get { return true; } }
    }
}
