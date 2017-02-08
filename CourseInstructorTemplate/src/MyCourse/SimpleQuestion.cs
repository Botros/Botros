using ExercisePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCourse
{
    public class SimpleQuestion : IExerciseContract
    {
        //asd
        public string FileName
        {
            get
            {
                return "SimpleQuestion.cshtml";
            }
        }

        public string Name
        {
            get
            {
                return "SimpleQuestion";
            }
        }

        public Dictionary<Cell, IResult> GenerateSolution(string userName)
        {
            ResultHelper helper = new ResultHelper();
            helper.AddInteger(0, 0, 1);
            helper.AddDouble(0, 1, 1.5, 0);
            helper.AddFraction(0, 2, 1.5, 0);
            helper.AddTrueFalse(0, 3, true);
            helper.AddSimpleText(0, 4, "test");

            helper.AddInteger(2, 1, 1);
            helper.AddDouble(2, 2, 1.5, 0);
            helper.AddFraction(2, 3, 1.5, 0);
            helper.AddTrueFalse(2, 4, false);

            helper.AddDouble(3, 1, 1.5, 0);
            helper.AddFraction(3, 2, 1.5, 0);
            helper.AddTrueFalse(3, 3, true);
            helper.AddSimpleText(3, 4, "test");

            helper.AddFraction(4, 1, 1.5, 0);
            helper.AddTrueFalse(4, 2, true);
            helper.AddDouble(4, 3, 1.5, 0);
            helper.AddSimpleText(4, 4, "test");
            return helper.Results;
        }

        public Dictionary<Cell, InputDefinition> GetInputDefiniton()
        {
            InputDefinitionHelper helper = new InputDefinitionHelper();
            helper.AddInteger(0, 0, "Int");
            helper.AddDouble(0, 1, "Double");
            helper.AddFraction(0, 2, "Fraction");
            helper.AddTrueFalse(0,3, "TrueFalse");
            helper.AddText(0, 4, "Text");

            helper.AddLabel(1, 0, null);
            helper.AddLabel(1, 1, "One");
            helper.AddLabel(1, 2, "Two");
            helper.AddLabel(1, 3, "Three");
            helper.AddLabel(1, 4, "Four");

            helper.AddLabel(2, 0, "A");
            helper.AddInteger(2, 1, "Int");
            helper.AddDouble(2, 2, "Double");
            helper.AddFraction(2,3, "Fraction");
            helper.AddTrueFalse(2, 4, "TrueFalse");

            helper.AddLabel(3, 0, "B");
            helper.AddDouble(3, 1, "Double");
            helper.AddFraction(3, 2, "Fraction");
            helper.AddTrueFalse(3, 3, "TrueFalse");
            helper.AddText(3, 4, "Text");

            helper.AddLabel(4, 0, "C");
            helper.AddFraction(4, 1, null);
            helper.AddTrueFalse(4, 2, null);
            helper.AddDouble(4, 3, null);
            helper.AddText(4, 4, null);
            return helper.Definition;
        }

        public ExerciseViewModel GetViewModel(string userName)
        {
            return new ExerciseViewModel();
        }
    }
}
