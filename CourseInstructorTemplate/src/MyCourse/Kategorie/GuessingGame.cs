using ExercisePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCourse.Kategorie
{
    public class GuessingGame : IExerciseContract
    {
        public string FileName
        {
            get
            {
                return "GuessingGame.cshtml";
            }
        }

        public string Name
        {
            get
            {
                return "Guessing Game";
            }
        }

        public Dictionary<Cell, IResult> GenerateSolution(string userName)
        {
            Values values = Values.Get(userName);
            ResultHelper helper = new ResultHelper();
            helper.AddInteger(0, 0, values.Value);
            return helper.Results;
        }

        public Dictionary<Cell, InputDefinition> GetInputDefiniton()
        {
            InputDefinitionHelper helper = new InputDefinitionHelper();
            helper.AddInteger(0, 0, @"\( X \)");
            return helper.Definition;
        }

        public ExerciseViewModel GetViewModel(string userName)
        {
            return new ExerciseViewModel();
        }

        public class Values
        {
            public int Value { get; set; }
            public static Values Get(string userName)
            {
                Random rnd = new Random();
                return new Values()
                {
                    Value = rnd.Next(0, 100)
                };
            }
        }
    }
}
