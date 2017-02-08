using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public enum ValidationResult
    {
        VALID,
        DOUBLE_EXERCISE_NAMES,
        INVALID_ASSEMBLY_NAME,
        UNKNOWN_ERROR,
        MISSING_EXERCISE_NAME,
        MISSING_EXERCISE_FILE_NAME,
        VIEW_MODEL_ERROR,
        NO_INPUT_DEFINITION_FOUND,
        INPUT_DEFINITION_ERROR,
        SOLUTION_ERROR,
        INPUT_MISSING_FOR_SOLUTION,
        INVALID_PATH,
        CANNOT_DELETE_OLD_FILE
    }
}
