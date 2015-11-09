using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SquareMatrix<T> : Matrix<T>
    {
        

        protected readonly T[][] array;

        public SquareMatrix(int size)
        {           
            
            if (size > 0)
                array = new T[size][];
            else
                throw new ArgumentOutOfRangeException();
        }

        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if(!array.IsSquare())
                throw new ArgumentException("Array is not Square");
            this.array = new T[array.Length][];
            Initialize(array);
        }

        public override T this[int i, int j]
        {
            get
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                return array[i][j];
            }
            set
            {
                if (!IsIndexRigth(i))
                    throw new ArgumentOutOfRangeException();
                if (!IsIndexRigth(j))
                    throw new ArgumentOutOfRangeException();
                var old = array[i][j];
                array[i][j] = value;
                OnChange(this, new MatrixEventArgs<T>(i, j, old, array[i][j]));
            }
        }

        public override int Dimension
        {
            get { return array.Length; }
        }

        protected void Initialize(T[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = new T[array.Length];
                Array.Copy(array[i], this.array[i], array.Length);
            }
        }

     

    }
}
