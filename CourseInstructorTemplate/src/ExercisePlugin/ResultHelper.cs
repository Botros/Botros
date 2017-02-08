using ExercisePlugin.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public class ResultHelper
    {
        public Dictionary<Cell, IResult> Results { get; set; } = new Dictionary<Cell, IResult>();
        
        public void AddInteger(int row, int column, int expected, int? min = null, int? max = null)
        {
            IntegerResult result = new IntegerResult()
            {
                Value = expected,
                Min = min,
                Max = max
            };
            Add(row, column, result);
        }

        public void AddIntegerOrNull(int row, int column, int? expected, int? min = null, int? max = null)
        {
            IntegerOrNullResult result = new IntegerOrNullResult()
            {
                Value = expected,
                Min = min,
                Max = max
            };
            Add(row, column, result);
        }

        public void AddDouble(int row, int column, double expected, double epsilon, double? min = null, double? max = null)
        {
            DoubleResult result = new DoubleResult()
            {
                Epsilon = epsilon,
                Value = expected,
                Min = min,
                Max = max
            };

            Add(row, column, result);
        }

        public void AddDoubleOrNull(int row, int column, double? expected, double? epsilon, double? min = null, double? max = null)
        {
            DoubleOrNullResult result = new DoubleOrNullResult()
            {
                Epsilon = epsilon,
                Value = expected,
                Min = min,
                Max = max
            };

            Add(row, column, result);
        }

        public void AddFraction(int row, int column, double expected, double epsilon, int? numerator =null, int? denominator = null)
        {
            FractionResult result = new FractionResult()
            {
                Epsilon = epsilon,
                Value = expected,
                Numerator = numerator,
                Denominator = denominator
            };
            Add(row, column, result);
        }

        public void AddSimpleText(int row, int column, string expected)
        {
            SimpleTextResult result = new SimpleTextResult()
            {
                Value = expected
            };
            Add(row, column, result);
        }

        public void AddTrueFalse(int row, int column, bool expected)
        {
            TrueFalseResult result = new TrueFalseResult()
            {
                Answer = expected
            };
            Add(row, column, result);
        }

        public void AddStringList(int row,int column, List<string> expected, string displayedExpected = null)
        {
            StringListResult result = new StringListResult()
            {
                Expected = expected,
                DisplayedExpected = displayedExpected
            };
            Add(row, column, result);
        }

        public void AddCorrectIncorrectList(int row, int column, List<string> correct, List<string> incorrect, string expected = null)
        {
            CorrectIncorrectListResult result = new CorrectIncorrectListResult()
            {
                Correct = correct,
                Incorrect = incorrect,
                Expected = expected
            };
            Add(row, column, result);
        }

        public void AddFractionOrNull(int row, int column, double? expected, double epsilon, int? numerator = null, int? denominator = null)
        {
            FractionOrNullResult result = new FractionOrNullResult()
            {
                Epsilon = epsilon,
                Value = expected,
                Numerator = numerator,
                Denominator = denominator
            };
            Add(row, column, result);
        }

        public void Add(Cell cell, IResult result)
        {
            Results.Add(cell, result);
        }

        public void Add(int row, int column, IResult result)
        {
            Cell cell = new Cell(row, column);
            Results.Add(cell, result);
        }
    }
}
