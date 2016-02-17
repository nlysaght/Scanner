using Analyzer.Analyzers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    //public interface IOutputDataHolder
    //{
    //}
    public interface IOutput<out T> //where T : IOutputDataHolder
    {
        bool Success { get; }
        Exception Exception { get; }
        AnalyzerTypeEnum AnalyzerType { get; }
        T Output { get; }
    }
}
