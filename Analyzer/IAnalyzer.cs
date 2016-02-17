using Analyzer.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analyzer
{
    public interface IAnalyzer<T> where T : Foundation.AnalyzerOutputBase
    {
        AnalyzerTypeEnum AnalyzerType { get; }
        T Analyse(IInput inputs);
    }
}
