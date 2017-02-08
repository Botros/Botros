using System;
using System.Linq;

namespace ExercisePlugin.Result
{
    public class DoubleOrNullResult : IResult
    {
        public double? Value { get; set; }
        public double? Epsilon { get; set; } = 0.00001;
        public double? Min { get; set; }
        public double? Max { get; set; }
        public InputStatus Compare(string input)
        {
            if (Value == null && string.IsNullOrEmpty(input))
                return InputStatus.Correct;
            else if (Value == null && !string.IsNullOrEmpty(input))
                return InputStatus.Wrong;
            else if (string.IsNullOrEmpty(input))
                return InputStatus.Wrong;

            double solution = 0;
            input = PrepareInput(input);
            bool success = double.TryParse(input, out solution);
            if (!success)
                return InputStatus.SyntaxError;

            if (Min != null && solution < Min)
                return InputStatus.SyntaxError;
            if (Max != null && solution > Max)
                return InputStatus.SyntaxError;

            if (Value != null && Math.Abs((double)(solution - Value)) <= Epsilon)
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
            if (input.Contains(',') && !input.Contains('.'))
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
