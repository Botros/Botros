using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public class ExerciseValidation
    {
        public static ValidationResult ValidateExercise(IExerciseContract exercise, string testSeed = "testuser@provider.com")
        {
            if (string.IsNullOrEmpty(exercise.Name))
                return ValidationResult.MISSING_EXERCISE_NAME;
            if (string.IsNullOrEmpty(exercise.FileName))
                return ValidationResult.MISSING_EXERCISE_FILE_NAME;

            //Validate ViewModel
            try
            {
                var viewModel = exercise.GetViewModel(testSeed);
            }
            catch (Exception)
            {
                return ValidationResult.VIEW_MODEL_ERROR;
            }

            //Input Definition
            Dictionary<Cell, InputDefinition> inputDefinitions;
            try
            {
                inputDefinitions = exercise.GetInputDefiniton();
                if (inputDefinitions.Count < 1)
                    return ValidationResult.NO_INPUT_DEFINITION_FOUND;
            }
            catch (Exception)
            {
                return ValidationResult.INPUT_DEFINITION_ERROR;
            }

            //Solution
            try
            {
                var solution = exercise.GenerateSolution(testSeed);
                foreach (var item in solution)
                {
                    if (!inputDefinitions.ContainsKey(item.Key))
                        return ValidationResult.INPUT_MISSING_FOR_SOLUTION;
                }
            }
            catch (Exception)
            {
                return ValidationResult.SOLUTION_ERROR;
            }


            return ValidationResult.VALID;
        }
    }
}
