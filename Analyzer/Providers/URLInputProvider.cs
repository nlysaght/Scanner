using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Providers
{
    /// <summary>
    /// Retrive data from a URL and format it appropriately as input for an analyzer
    /// </summary>
    public class URLInputProvider : IInputProvider
    {
        protected Foundation.AnalyzerInput input { get; private set; } = new Foundation.AnalyzerInput();
        protected Uri source { get; }
        public URLInputProvider(Uri source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            this.source = source;
            input.Source = source.ToString();
            input.SourceType = "FileSystem";
            input.MimeType = "text/html";
        }

        public IInput Input
        {
            get
            {
                if(input.Content == null)
                {
                    input.Content = UriReader(source);
                }
                return input;
            }
        }
        private byte[] UriReader(Uri uri)
        {
            throw new NotImplementedException();
        }
    }
}
