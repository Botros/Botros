using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class FractionResult : IResult
    {
        public double Value { get; set; }
        public int? Numerator { get; set; }
        public int? Denominator { get; set; }
        public double Epsilon { get; set; } = 0.01;
        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;
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

            if (Math.Abs(solution - Value) <= Epsilon)
                return InputStatus.Correct;
            else
                return InputStatus.Wrong;
        }

        public string GetExpected()
        {           
            if(Numerator!=null && Denominator!=null)
                return $"{Numerator}/{Denominator}";
            else
                return $"{Value}/{1}";
        }
    }
}
