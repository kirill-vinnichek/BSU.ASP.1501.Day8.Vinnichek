using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class MatrixEventArgs<T> : EventArgs
    {
        public int i { get; private set; }
        public int j { get; private set; }
        public T OldElement { get; private set; }
        public T NewElement { get; private set; }
        public MatrixEventArgs(int i, int j, T old, T @new)
        {
            this.i = i;
            this.j = j;
            this.OldElement = old;
            this.NewElement = @new;
        }
    }
}
