using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin.Result
{
    public class TrueFalseResult : IResult
    {
        private const string TRUE = "true";
        private const string FALSE = "false";
        public bool Answer { get; set; }
        public InputStatus Compare(string input)
        {
            if (string.IsNullOrEmpty(input))
                return InputStatus.Missing;
            if (input == TRUE)
                if (Answer)
                    return InputStatus.Correct;
                else
                    return InputStatus.Wrong;
            else if (input == FALSE)
                if (!Answer)
                    return InputStatus.Correct;
                else
                    return InputStatus.Wrong;
            return InputStatus.SyntaxError;

                
        }

        public string GetExpected()
        {
            if (Answer)
                return TRUE;
            else
                return FALSE;
        }
    }
}
