using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class DoubleResult : IResult
    {
        public double Value { get; set; }
        public double Epsilon { get; set; } = 0.00001;
        public double? Min { get; set; }
        public double? Max { get; set; }
        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;
            double solution = 0;
            input = PrepareInput(input);
            bool success = double.TryParse(input, out solution);
            if (!success)
                return InputStatus.SyntaxError;

            if (Min != null && solution < Min)
                return InputStatus.SyntaxError;
            if (Max != null && solution > Max)
                return InputStatus.SyntaxError;

            if (Math.Abs(solution - Value) <= Epsilon)
                return InputStatus.Correct;
            else
                return InputStatus.Wrong;
        }

        public string GetExpected()
        {
            return Value.ToString();
        }

        public string PrepareInput(string input)
        {
            if(input.Contains(',') && !input.Contains('.'))
            {
                input = input.Replace(',', '.');
            }
            else if (input.Contains(',') && 
                input.Contains('.') && 
                input.LastIndexOf(',') > input.LastIndexOf('.'))
            {
                input = input.Replace(".", "");
                input = input.Replace(',', '.');
            }

            return input;
        }
        
    }
}
