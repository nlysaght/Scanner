using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Analyzers
{
    public class FacebookAnalyserOutput : Foundation.AnalyzerOutputBase
    {
        public FacebookAnalyserOutput()
            : base(AnalyzerTypeEnum.Facebook)
        {
        }
        public string FacebookAddress { get; set; }
    }

    public class FacebookAnalyzer : IAnalyzer<FacebookAnalyserOutput>
    {
        public AnalyzerTypeEnum AnalyzerType { get { return AnalyzerTypeEnum.Facebook; } }
        public FacebookAnalyserOutput Analyse(IInput inputs)
        {
            throw new NotImplementedException();
        }
    }
}
