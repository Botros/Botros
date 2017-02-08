using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class CorrectIncorrectListResult : IResult
    {
        public List<string> Correct { get; set; }
        public string Expected { get; set; }
        public List<string> Incorrect { get; set; }

        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;
            input = input.Trim();
            foreach (var item in Incorrect)
            {
                if (item.ToUpperInvariant() == input.ToUpperInvariant())
                    return InputStatus.Wrong;
            }

            foreach (var item in Correct)
            {
                if (item.ToUpperInvariant() == input.ToUpperInvariant())
                    return InputStatus.Correct;
            }

            return InputStatus.SyntaxError;
        }

        public string GetExpected()
        {
            if (Correct == null || Correct.Count < 1)
                throw new ArgumentNullException("Expected");

            if (string.IsNullOrEmpty(Expected))
                return Correct.First();
            else
                return Expected;
        }
    }
}
