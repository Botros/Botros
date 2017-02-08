using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class FractionOrNullResult : IResult
    {
        public double? Value { get; set; }
        public int? Numerator { get; set; }
        public int? Denominator { get; set; }
        public double Epsilon { get; set; } = 0.01;


        public InputStatus Compare(string input)
        {
            input = input.Trim();
            //If null is expected and nothin is entered, return correct
            if (Value == null && (input == "/" || input=="-/-"))
                return InputStatus.Correct;
            else
            {
                string[] values = input.Split('/');
                if (values.Count() != 2)
                    return InputStatus.SyntaxError;
                int inputDenominator = 0;
                bool success = Int32.TryParse(values[1], out inputDenominator);
                if (!success)
                    return InputStatus.SyntaxError;
                int inputNumerator = 0;
                success = Int32.TryParse(values[0], out inputNumerator);
                if (!success)
                    return InputStatus.SyntaxError;

                double solution = inputNumerator / (double)inputDenominator;

                if (Value == null)
                    return InputStatus.Wrong;

                if (Math.Abs(solution - (double)Value) <= Epsilon)
                    return InputStatus.Correct;
                else
                    return InputStatus.Wrong;
            }
                
        }

        public string GetExpected()
        {
            if (Value == null)
                return "/";
            if (Numerator != null && Denominator != null)
                return $"{Numerator}/{Denominator}";
            else
                return $"{Value}/{1}";
        }
    }
}
