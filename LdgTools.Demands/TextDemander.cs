using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands
{
    public class TextDemander<T> : IDemander<T>
    {
        public T CheckValue { get; set; }
        public string ValueName { get; set; }
        public string ContainingClass { get; set; }
        Dictionary<string, string> Errors;

        public void AddError(string error)
        {
            Errors.Add(ValueName, error);
        }

        public Dictionary<string, string> GetErrors()
        {
            return Errors;
        }
    }
}
