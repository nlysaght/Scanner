using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Analyzers
{
    public class AddressAnalyserOutput : Foundation.AnalyzerOutputBase
    {
        public AddressAnalyserOutput()
            : base(AnalyzerTypeEnum.Address)
        {
        }
        public string Name { get; set; }
        public string Company { get; set; }
        public string DeliveryAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }

    public class AddressAnalyzer : IAnalyzer<AddressAnalyserOutput>
    {
        public AnalyzerTypeEnum AnalyzerType { get { return AnalyzerTypeEnum.Address; } }
        public AddressAnalyserOutput Analyse(IInput inputs) 
        {
            var content = inputs.ContentAsString;
            var output = new AddressAnalyserOutput();
            if(content.Contains("Noel"))
            {
                output.Name = "Noel Lysaght";
                output.Company = "Sales Optimize";
                output.City = "Dublin";
                output.DeliveryAddress = "NCI Research Centre Ireland";
                output.Success = true;
            }
            else
            {
                output.Success = false;
            }
            return output;
        }
    }
}
