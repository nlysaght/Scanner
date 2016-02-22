using EPocalipse.IFilter;
using HtmlAgilityPack;
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
            var captures = GetCapturesFromPlainText(Properties.Resources.MCLDirect);
        }
        [Fact]
        public void CanGetPhoneFromSalesOptimize()
        {
            var captures = GetCapturesFromPlainText(Properties.Resources.SalesOptimize);
        }
        [Fact]
        public void CanGetPhoneFromMicksGarage()
        {
            var captures = GetCapturesFromPlainText(Properties.Resources.MicksGarage);
        }
        [Fact]
        public void CanGetPhoneFromZarion()
        {
            var captures = GetCapturesFromPlainText(Properties.Resources.Zarion);
        }
        private IList<string> GetCapturesFromPlainText(string htmlContent)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(htmlContent);

            var plainText = new StringBuilder();
            foreach (HtmlNode node in doc.DocumentNode.SelectNodes("//text()"))
            {
                plainText.AppendLine(node.InnerText);
            }
            var a = new Analyzer.PhoneAnalyzer();
            var plain = plainText.ToString();
            var captures = a.Capture(plain);
            return captures;

            //var tempHtml = System.IO.Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "temp.html");
            //System.IO.File.WriteAllText(tempHtml, htmlContent);
            //using (var reader = new FilterReader(tempHtml))
            //{
            //    var content = reader.ReadToEnd();
            //    var a = new Analyzer.PhoneAnalyzer();
            //    var captures = a.Capture(content);
            //    return captures;
            //}
        }
    }
}
