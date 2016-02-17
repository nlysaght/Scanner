using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Analyzers
{
    public enum CartTypeEnum
    {
        None, Custom, Volusion, MagicCart
    }
    public class CartAnalyserOutput : Foundation.AnalyzerOutputBase
    {
        public CartAnalyserOutput()
            : base(AnalyzerTypeEnum.Cart)
        {
        }
        public CartTypeEnum CartType { get; set; }
    }

    public class CartAnalyzer : IAnalyzer<CartAnalyserOutput>
    {
        public AnalyzerTypeEnum AnalyzerType { get { return AnalyzerTypeEnum.Cart; } }
        public CartAnalyserOutput Analyse(IInput inputs)
        {
            var output = new CartAnalyserOutput() { CartType = CartTypeEnum.None };
            var content = inputs.ContentAsString;
            if(content.IndexOf("volusion", StringComparison.InvariantCultureIgnoreCase) != -1)
            { 
                output.CartType = CartTypeEnum.Volusion;
            }
            if (content.IndexOf("magic-cart", StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                output.CartType = CartTypeEnum.MagicCart;
            }

            output.Success = output.CartType != CartTypeEnum.None;
            return output;
        }

    }
}
