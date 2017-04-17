using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands
{
    public class ValidationException : Exception
    {
        public ValidationException(string name, string error) : base($"VALIDATION ERROR: {name} - {error}")
        {
            
        }
    }
}
