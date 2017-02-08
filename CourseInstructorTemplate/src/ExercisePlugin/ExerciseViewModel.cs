using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public class ExerciseViewModel
    {
        public List<string> Output { get; set; } = new List<string>();
        public List<int> Integers { get; set; }
        public Dictionary<string, string> Dict { get; set; } = new Dictionary<string, string>();
        public static ExerciseViewModel Generate(params object[] values)
        {
            ExerciseViewModel model = new ExerciseViewModel();
            model.Output = new List<string>();
            foreach (var item in values)
                model.Output.Add(item.ToString());

            return model;
        }
    }

    public class ExerciseViewModel<T> : ExerciseViewModel
    {
        public T Values { get; set; }
    }
}
