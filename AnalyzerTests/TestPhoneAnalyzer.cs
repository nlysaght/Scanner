using EPocalipse.IFilter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AnalyzerTests
{
    public class TestPhoneAnalyzer
    {
        [Fact]
        public void CanGetPhoneFromMCLDirect()
        {
            var tempHtml = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "temp.html");
            System.IO.File.WriteAllText(tempHtml,Properties.Resources.MCLDirect);
            using (var reader = new FilterReader(tempHtml))
            {
                var content = reader.ReadToEnd();
                var a = new Analyzer.PhoneAnalyzer();
                var captures = a.Capture(content);

            }
        }
        [Fact]
        public void CanGetPhoneFromSalesOptimize()
        {
            var a = new Analyzer.PhoneAnalyzer();
            var captures = a.Capture(Properties.Resources.SalesOptimize);
        }
        [Fact]
        public void CanGetPhoneFromMicksGarage()
        {
            var a = new Analyzer.PhoneAnalyzer();
            var captures = a.Capture(Properties.Resources.MicksGarage);
        }
        [Fact]
        public void CanGetPhoneFromZarion()
        {
            var tempHtml = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "temp.html");
            System.IO.File.WriteAllText(tempHtml, Properties.Resources.Zarion);
            using (var reader = new FilterReader(tempHtml))
            {
                var content = reader.ReadToEnd();
                var a = new Analyzer.PhoneAnalyzer();
                var captures = a.Capture(content);

            }
        }
    }
}
