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
        public int Dimension
        {
            get;
            protected set;
        }

        protected virtual void OnChange(object sender, MatrixEventArgs<T> e)
        {
            var t = Change;
            if (t != null)
                t(sender, e);
        }
        public T this[int i, int j]
        {
            get
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                return Get(i,j);
            }
            set
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                var old = this[i, j];
                Set(value,i,j);               
                OnChange(this, new MatrixEventArgs<T>(i, j, old, this[i,j]));
            }
        }

        protected abstract T Get(int i, int j);
        protected abstract void Set(T value,int i,int j);

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
