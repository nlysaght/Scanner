﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzer.Providers
{
    /// <summary>
    /// Retrive data from a SQL database and format it appropriately as input for an analyzer
    /// </summary>
    public class SQLInputProvider : IInputProvider
    {
        public IInput Input
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
