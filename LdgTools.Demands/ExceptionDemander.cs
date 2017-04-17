using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands
{
    public class ExceptionDemander<T> : IDemander<T>
    {
        public T CheckValue { get; set; }
        public string ValueName { get; set; }
        public string ContainingClass { get; set; }

        public void AddError(string error)
        {
            throw new ValidationException(ValueName, error);
        }

        public Dictionary<string, string> GetErrors()
        {
            return new Dictionary<string, string>();
        }
    }
}
