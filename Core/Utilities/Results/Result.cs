using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {

        public bool Succes { get; }

        public string Message { get; }
    }
}
