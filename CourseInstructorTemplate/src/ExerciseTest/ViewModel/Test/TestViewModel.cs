using ExercisePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTest.ViewModel.Test
{
    public class TestViewModel
    {
        public ExerciseViewModel ExerciseViewModel { get; set; }

        public string ExerciseName { get; set; }
        public string ExerciseFileName { get; set; }
        public string CourseName { get; set; }
        public string Seed { get; set; }


        public List<SolutionCell> SolutionCells { get; set; }
        public SolutionCell GetSolutionCell(Cell cell)
        {
            return SolutionCells.SingleOrDefault(x => x.Row == cell.Row && x.Column == cell.Column);
        }
    }
}
