using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avromark.Exceptions
{
    public class CommandLineArgumentException : Exception
    {
        public CommandLineArgumentException(string? message) : base(message)
        {
        }
    }
}
