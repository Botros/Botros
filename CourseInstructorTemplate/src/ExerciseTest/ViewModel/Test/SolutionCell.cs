using ExercisePlugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTest.ViewModel.Test
{
    public class SolutionCell
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public string Input { get; set; }
        public string Label { get; set; }
        public InputTypes InputType { get; set; }
        public InputStatus? State { get; set; }
    }
}
