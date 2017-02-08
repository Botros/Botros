using ExercisePlugin;
using ExerciseTest.ViewModel.Test;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTest.Controllers
{
    
    public class TestController : Controller
    {
        [HttpGet("[controller]/{course}/{exercise}")]
        public IActionResult Test(string course, string exercise,string seed, bool getSolution)
        {
            IExerciseContract contract = GetExercise(course, exercise);
            if (contract != null)
            {
                TestViewModel model = new TestViewModel()
                {
                    CourseName = course,
                    ExerciseName = contract.Name,
                    ExerciseFileName = contract.FileName,
                    ExerciseViewModel = contract.GetViewModel(seed),
                    SolutionCells = GetSolutionCell(contract)
                };
                if(getSolution)
                    foreach (var item in GetSolutionCells(contract,seed))
                    {
                        int cell = model.SolutionCells.IndexOf(model.SolutionCells.Where(x => x.Row == item.Row && x.Column == item.Column).Single());
                        model.SolutionCells[cell] = item;
                    }
                model.SolutionCells = model.SolutionCells.OrderBy(x => x.Column).ToList();
                model.SolutionCells = model.SolutionCells.OrderBy(x => x.Row).ToList();
                return View(model);
            }
            return View("Error");
        }

        

        [HttpPost("[controller]/{course}/{exercise}")]
        public IActionResult Test(TestViewModel model)
        {
            IExerciseContract contract = GetExercise(model.CourseName, model.ExerciseName);
            if (contract != null)
            {
                var solution = contract.GenerateSolution(model.Seed);
                model.SolutionCells = ValidateSolution(solution, model.SolutionCells);
                model.ExerciseViewModel = contract.GetViewModel(model.Seed);
                return View(model);
            }

            return View("Error");
        }

        private List<SolutionCell> GetSolutionCell(IExerciseContract contract)
        {
            List<SolutionCell> solutions = new List<SolutionCell>();
            foreach (var item in contract.GetInputDefiniton())
            {
                solutions.Add(new SolutionCell()
                {
                    Row = item.Key.Row,
                    Column = item.Key.Column,
                    InputType = item.Value.InputType,
                    Label = item.Value.Label
                });
            }

            return solutions;
        }

        private List<SolutionCell> GetSolutionCells(IExerciseContract contract, string seed)
        {
            List<SolutionCell> solutions = new List<SolutionCell>();
            var definitions = contract.GetInputDefiniton();
            foreach (var item in contract.GenerateSolution(seed))
            {
                solutions.Add(new SolutionCell()
                {
                    Row = item.Key.Row,
                    Column = item.Key.Column,
                    Input = item.Value.GetExpected(),
                    InputType = definitions[item.Key].InputType,
                    Label = definitions[item.Key].Label,
                    State = InputStatus.Correct
                });
            }

            return solutions;
        }

        private List<SolutionCell> ValidateSolution(Dictionary<Cell,IResult> solution, List<SolutionCell> inputs)
        {
            foreach (var item in solution)
            {
                SolutionCell input = inputs.Where(x => x.Row == item.Key.Row && x.Column == item.Key.Column).Single();
                input.State = item.Value.Compare(input.Input);
            }
            return inputs;
        }

        private IExerciseContract GetExercise(string course, string exercise)
        {
            var deps = DependencyContext.Default;
            foreach (var compilationLibrary in deps.CompileLibraries)
            {
                if (compilationLibrary.Name.Contains(course))
                {
                    var assembly = Assembly.Load(new AssemblyName(compilationLibrary.Name));
                    foreach (var item in assembly.ExportedTypes)
                    {
                        if (typeof(IExerciseContract).IsAssignableFrom(item))
                        {
                            IExerciseContract contract = Activator.CreateInstance(item) as IExerciseContract;
                            if(contract.Name == exercise)
                                return contract;
                            
                        }
                    }
                }
            }

            return null;
        }
    }
}
