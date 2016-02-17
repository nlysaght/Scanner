using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
namespace AnalyzerTests
{
    public class TestCartAnalyzer
    {
        [Fact]
        public void Can_Create_Cart_Analyzer()
        {
            var analyzer = new Analyzer.Analyzers.CartAnalyzer();
            Assert.NotNull(analyzer);
        }

        /// <summary>
        /// See can the cart analyzer find a volusion site, if we pass in the expected content.
        /// </summary>
        [Fact]
        public void Can_Find_Volusion_Cart()
        {
            var analyzer = new Analyzer.Analyzers.CartAnalyzer();
            var inputMoq = new Mock<Analyzer.IInput>();
            inputMoq.Setup(i => i.ContentAsString).Returns("this is a Volusion cart site");

            var cartOutput = analyzer.Analyse(inputMoq.Object);
            Assert.True(cartOutput.Success);
            Assert.Equal(Analyzer.Analyzers.CartTypeEnum.Volusion, cartOutput.CartType);
        }
        /// <summary>
        /// Passing in a unknown cart should return back false for success and None for Carttype.
        /// </summary>
        [Fact]
        public void Unknown_Cart_Returns_Failure()
        {
            var analyzer = new Analyzer.Analyzers.CartAnalyzer();
            var inputMoq = new Mock<Analyzer.IInput>();
            inputMoq.Setup(i => i.ContentAsString).Returns("xxxxxx xxxxxxx xxxxxxx");

            var cartOutput = analyzer.Analyse(inputMoq.Object);
            Assert.False(cartOutput.Success);
            Assert.Equal(Analyzer.Analyzers.CartTypeEnum.None, cartOutput.CartType);
        }
    }
}
