using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    public interface IInput
    {
        #region "Base Properties - Can be extended in specialised sub classes"
        byte[] Content { get; }
        string ContentAsString { get; }
        string Source { get;  }
        string SourceType { get;  }
        string MimeType { get;  }
        #endregion
    }
}
