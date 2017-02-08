using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class StringListResult : IResult
    {
        public List<string> Expected { get; set; }
        public string DisplayedExpected { get; set; }
        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;

            input = input.Trim();
            foreach (var item in Expected)
            {
                if (item.ToUpperInvariant() == input.ToUpperInvariant())
                    return InputStatus.Correct;
            }
            return InputStatus.Wrong;
        }

        public string GetExpected()
        {
            if (Expected == null || Expected.Count < 1)
                throw new ArgumentNullException("Expected");

            if (string.IsNullOrEmpty(DisplayedExpected))
                return Expected.First();
            else
                return DisplayedExpected;
        }
    }
}
