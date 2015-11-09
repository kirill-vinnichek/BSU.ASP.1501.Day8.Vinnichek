using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public abstract class Matrix<T>
    {
        public EventHandler<MatrixEventArgs<T>> Change = delegate { };

        protected virtual void OnChange(object sender, MatrixEventArgs<T> e)
        {
            var t = Change;
            if (t != null)
                t(sender, e);
        }
        public abstract T this[int i, int j] { get; set; }
        public abstract int Dimension { get; }
        protected bool IsIndexRigth(int i)
        {
            if (i < 0 && i >= Dimension)
                return false;
            return true;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                    sb.Append(this[i, j] + " ");
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
