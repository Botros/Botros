using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class IntegerResult : IResult
    {
        public int Value { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }

        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;

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
            return Value.ToString();
        }
    }
}
