using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class IntegerOrNullResult : IResult
    {
        public int? Value { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }

        public InputStatus Compare(string input)
        {
            if (Value == null && string.IsNullOrEmpty(input))
                return InputStatus.Correct;
            else if (Value == null && !string.IsNullOrEmpty(input))
                return InputStatus.Wrong;
            else if (string.IsNullOrEmpty(input))
                return InputStatus.Wrong;

            int solution = 0;
            bool success = Int32.TryParse(input, out solution);
            if (!success)
                return InputStatus.SyntaxError;

            if (Min != null && solution < Min)
                return InputStatus.SyntaxError;
            if (Max != null && solution > Max)
                return InputStatus.SyntaxError;

            if (Value == solution)
                return InputStatus.Correct;
            else
                return InputStatus.Wrong;

        }

        public string GetExpected()
        {
            if(Value==null)
            {
                return string.Empty;
            }
            else
            {
                return Value.ToString();
            }
        }
    }
}
