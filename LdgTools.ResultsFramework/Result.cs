using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.ResultsFramework
{
    public class Result<T>
    {        
        public bool Success { get; set; }
        public T Value { get; set; }
        public Dictionary<string, string> Errors { get; set; }
    }
}
