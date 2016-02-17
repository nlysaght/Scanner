using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer
{
    /// <summary>
    /// Gets the inputs from whereever is required. URL, Database, File system etc.
    /// </summary>
    public interface IInputProvider
    {
        IInput Input { get; }
    }
}
