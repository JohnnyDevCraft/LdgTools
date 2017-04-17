using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands
{
    public interface IDemander<T>
    {
        T CheckValue { get; set; }
        string ValueName { get; set; }
        string ContainingClass { get; set; }

        void AddError(string error);
        Dictionary<string, string> GetErrors();

    }
}
