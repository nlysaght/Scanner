using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Analyzer;

namespace AnalyzerTests
{
    public class TestRunners
    {
        [Fact, Trait("Runners","Sequential")]
        public void TestSequentialRunner()
        {
            var executor = new Analyzer.AnalyzerExecutor ();
            var cartAnalyzer = new Analyzer.Analyzers.CartAnalyzer();
            var addressAnalyzer = new Analyzer.Analyzers.AddressAnalyzer();

            executor.AddToRunner(cartAnalyzer, new FakeVolusionCartProvider());
            executor.AddToRunner(addressAnalyzer, new FakeNoelAddressProvider());
            executor.AddToRunner(cartAnalyzer, new FakeMagicCartProvider());
            executor.AddToRunner(addressAnalyzer, new FakeNoneAddressProvider());
            executor.AddToRunner(cartAnalyzer, new FakeNoneCartProvider());

            var results = executor.ExecuteSequentially();
        }

        public class FakeNoelAddressProvider : Analyzer.IInputProvider
        {
            public IInput Input
            {
                get
                {
                    var mockInput = new Mock<Analyzer.IInput>();
                    mockInput.Setup(i => i.ContentAsString).Returns("this HTML contains Noel's address");
                    return mockInput.Object;
                }
            }
        }
        public class FakeNoneAddressProvider : Analyzer.IInputProvider
        {
            public IInput Input
            {
                get
                {
                    var mockInput = new Mock<Analyzer.IInput>();
                    mockInput.Setup(i => i.ContentAsString).Returns("this HTML contains no address information.");
                    return mockInput.Object;
                }
            }
        }

        public class FakeVolusionCartProvider : Analyzer.IInputProvider
        {
            public IInput Input
            {
                get
                {
                    var mockInput = new Mock<Analyzer.IInput>();
                    mockInput.Setup(i => i.ContentAsString).Returns("this is the HTML for a Volusion cart page");
                    return mockInput.Object;
                }
            }
        }
        public class FakeMagicCartProvider : Analyzer.IInputProvider
        {
            public IInput Input
            {
                get
                {
                    var mockInput = new Mock<Analyzer.IInput>();
                    mockInput.Setup(i => i.ContentAsString).Returns("this is the HTML for a magic-cart page");
                    return mockInput.Object;
                }
            }
        }
        public class FakeNoneCartProvider : Analyzer.IInputProvider
        {
            public IInput Input
            {
                get
                {
                    var mockInput = new Mock<Analyzer.IInput>();
                    mockInput.Setup(i => i.ContentAsString).Returns("This is the HTML for a page without any cart");
                    return mockInput.Object;
                }
            }
        }
    }


}
