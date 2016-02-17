using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Providers
{
    /// <summary>
    /// Retrive data from the File System and format it appropriately as input for an analyzer
    /// </summary>
    public class FileSystemInputProvider : IInputProvider
    {
        public Foundation.AnalyzerInput Input { get; private set; } = new Foundation.AnalyzerInput();
        public FileSystemInputProvider(string fileName)
        {
            if (fileName == null)
                throw new ArgumentNullException(nameof(fileName));
            Input.Source = fileName;
            Input.SourceType = "FileSystem";
            Input.MimeType = "text/html";
            Input.Content = System.IO.File.ReadAllBytes(fileName);
        }
        IInput IInputProvider.Input
        {
            get
            {
                return this.Input;
            }
        }
    }
}
