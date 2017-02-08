using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class SimpleTextResult : IResult
    {
        public string Value { get; set; }
        public InputStatus Compare(string input)
        {
            //Check if the expected value is null
            if (string.IsNullOrEmpty(input) && !string.IsNullOrEmpty(Value))
                return InputStatus.Missing;

            if (string.IsNullOrEmpty(Value) && string.IsNullOrEmpty(input))
                return InputStatus.Correct;

            input = input.Trim();


            if (string.Equals(input, Value, StringComparison.OrdinalIgnoreCase))
                return InputStatus.Correct;
            else
                return InputStatus.Wrong;

        }

        public string GetExpected()
        {
            return Value;
        }
    }
}
