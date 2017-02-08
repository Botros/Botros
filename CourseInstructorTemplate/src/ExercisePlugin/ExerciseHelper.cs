using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public static class ExerciseHelper
    {
        
        public static Dictionary<Cell,InputStatus> ValidateSolution(Dictionary<Cell,IResult> expected, Dictionary<Cell,string> inputs)
        {
            Dictionary<Cell, InputStatus> states = new Dictionary<Cell, InputStatus>();
            foreach (var result in expected)
            {
                string input = null;
                if(inputs.ContainsKey(result.Key))
                {
                    input = inputs[result.Key];
                }
                states.Add(result.Key, result.Value.Compare(input));

            }
            return states;
        }
    }
}
