using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public class InputDefinitionHelper
    {
        public Dictionary<Cell, InputDefinition> Definition { get; set; } = new Dictionary<Cell, InputDefinition>();

        public void AddInteger(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.INT);
        }

        public void AddDouble(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.DOUBLE);
        }

        public void AddFraction(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.FRACTION);
        }

        public void AddText(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.TEXT);
        }

        public void AddTrueFalse(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.TRUE_FALSE);
        }

        public void AddLabel(int row, int column, string label)
        {
            Add(row, column, label, InputTypes.LABEL_ONLY);
        }

        public void Add(int row, int column, string label, InputTypes inputType)
        {
            Cell cell = new Cell(row, column);
            InputDefinition definiton = new InputDefinition()
            {
                InputType = inputType,
                Label = label
            };
            Definition.Add(cell, definiton);
        }

    }
}
