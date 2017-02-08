using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public interface IExerciseContract
    {
        string Name { get; }
        string FileName { get; }
        Dictionary<Cell,IResult> GenerateSolution(string userName);
        Dictionary<Cell, InputDefinition> GetInputDefiniton();
        ExerciseViewModel GetViewModel(string userName);
    }

}
