using System;
using System.Collections.Generic;
using System.Text;

namespace LdgTools.Demands
{
    public static class StringDemands
    {
        const string NULL_WHITESPACE_STRING_ERROR = "The value of [{0}] can not be null, empty, or whitespace.";
        const string NULL_EMPTY_STRING_ERROR = "The value of [{0}] can not be null, empty.";
        const string MAX_STRING_LENGTH_ERROR = "The value of [{0}] can not be more than {1} characters long.";
        const string MIN_STRING_LENGTH_ERROR = "The value of [{0}] can not be less than {1} characters long.";

        const string FIRST_CHAR_IS_NUM_ERROR = "The first character must not be a number.";
        const string FIRST_CHAR_IS_NOT_NUM_ERROR = "The first character must be a number.";
        const string CONTAINS_NUMBER_ERROR = "This parameter can not contain a number.";
        const string CONTAINS_LETTER_ERROR = "This parameter can not contain a letter.";
        const string FIRST_CHAR_IS_NOT_LETTER = "This parameter must start with a letter.";
         

        public static IDemander<string> IsNotNullOrWhitespace(this IDemander<string> demand)
        {
            if (string.IsNullOrWhiteSpace(demand.CheckValue))
            {
                demand.AddError(string.Format(NULL_WHITESPACE_STRING_ERROR, demand.ValueName));
            }
            return demand;
        }
        public static TextDemander<string> IsNotNullOrEmpty(this TextDemander<string> demand)
        {
            if (string.IsNullOrEmpty(demand.CheckValue))
            {
                demand.AddError(string.Format(NULL_EMPTY_STRING_ERROR, demand.ValueName));
            }
            return demand;
        }
        public static IDemander<string> IsMaxLength(this IDemander<string> demand, int max)
        {
            if (demand.CheckValue.Length > max)
            {
                demand.AddError(string.Format(MAX_STRING_LENGTH_ERROR, demand.ValueName, max));
            }
            return demand;
        }

        public static IDemander<string> IsMinLength(this IDemander<string> demand, int max)
        {
            if (demand.CheckValue.Length > max)
            {
                demand.AddError(string.Format(MAX_STRING_LENGTH_ERROR, demand.ValueName, max));
            }
            return demand;
        }

        public static IDemander<string> StartsWithNumber(this IDemander<string> demand)
        {
            if (!char.IsNumber(demand.CheckValue[0]))
            {
                demand.AddError(FIRST_CHAR_IS_NOT_NUM_ERROR);
            }
            return demand;
        }

        public static IDemander<string> StartsWithLetter(this IDemander<string> demand)
        {
            if (!char.IsLetter(demand.CheckValue[0]))
            {
                demand.AddError(FIRST_CHAR_IS_NOT_NUM_ERROR);
            }
            return demand;
        }

        public static IDemander<string> ConatinsLower(this IDemander<string> demand)
        {
            var result = false;

            foreach (var s in demand.CheckValue)
            {
                if (char.IsLower(s)) result = true;
            }

            if (!result)
            {
                demand.AddError(FIRST_CHAR_IS_NOT_NUM_ERROR);
            }
            return demand;
        }
    }
}
