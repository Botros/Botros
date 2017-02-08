using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercisePlugin
{
    public class Cell : IEquatable<Cell>
    {
        public int Row { get; private set; }
        public int Column { get; private set; }
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override bool Equals(object obj)
        {
            Cell compare = obj as Cell;
            if (compare == null)
                return false;
            return Equals(compare);

        }
        public override int GetHashCode()
        {
            return Row.GetHashCode() ^ Column.GetHashCode();
        }

        public bool Equals(Cell other)
        {
            if (other.Row == Row && other.Column == Column)
                return true;
            return false;
        }
    }
}
