using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analyzer.Foundation
{
    public class AnalyzerInput : IInput
    {
        public byte[] Content { get; internal set; }
        public string ContentAsString
        {
            get
            {
                return System.Text.Encoding.UTF8.GetString(Content);
            }
            set
            {
                this.Content = System.Text.Encoding.UTF8.GetBytes(value);
            }
        }
        public string Source { get; internal set; }
        public string SourceType { get; internal set; }
        public string MimeType { get; internal set; }
    }
}
