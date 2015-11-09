using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public sealed class DiagonalMatrix<T> : Matrix<T>
    {
        private readonly T[] array;

        public DiagonalMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("Array is not square");
            this.array = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
                this.array[i] = array[i][i];
        }


        public override T this[int i, int j]
        {
            get
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                if (i != j)
                    return default(T);
                return array[i];
            }
            set
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                if (i == j)
                {
                    var old = array[i];
                    array[i] = value;
                    OnChange(this, new MatrixEventArgs<T>(i, j, old, array[i]));
                }
            }
        }

        public override int Dimension
        {
            get
            {
                return array.Length;
            }
        }



    }
}
