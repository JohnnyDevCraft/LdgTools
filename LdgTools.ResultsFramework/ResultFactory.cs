using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.ResultsFramework
{
    public static class ResultFactory<T>
    {
        public static Result<T> CreateSuccess()
        {
            return new Result<T>()
            {
                Success = true
            };
        }

        public static Result<T> CreateSuccess(T obj)
        {
            return new Result<T>()
            {
                Success = true,
                Value = obj
            };
        }

        public static Result<T> CreateFailed()
        {
            return new Result<T>()
            {
                Success = false
            };
        }

        public static Result<T> CreateFailed(string error)
        {
            var result = new Result<T>()
            {
                Success = false,
                Errors = new Dictionary<string, string>()
            };

            result.Errors.Add("Class", error);

            return result;
        }

        public static Result<T> CreateFailed(string prop, string error)
        {
            var result = new Result<T>()
            {
                Success = false,
                Errors = new Dictionary<string, string>()
            };

            result.Errors.Add(prop, error);

            return result;

        }

        public static Result<T> CreateFailed(Exception exception)
        {
            var result = new Result<T>()
            {
                Success = false,
                Errors = new Dictionary<string, string>()
            };

            string error = exception.Message;

            error = SetInnerException(exception.InnerException, error, 0);

            result.Errors.Add("Exception",error);

            return result;
        }

        private static string SetInnerException(Exception exception, string error, int level)
        {
            var text = $"{error}\n";
            
            for(var i=0; i<level+1;)
            {
                text = $"{text}\t";
            }

            text = $"{text}-{exception.Message}";
            text = $"{text}{SetInnerException(exception.InnerException, text, level + 1)}";
            return text;
        }

    }
}
