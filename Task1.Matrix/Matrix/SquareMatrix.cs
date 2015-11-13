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


        public SquareMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("Array is not square");
            this.array = new T[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = new T[array.Length];
                Array.Copy(array[i], this.array[i], array.Length);
            }
            Dimension = array.Length;
        }

        protected override T Get(int i, int j)
        {
            return array[i][j];
        }

        protected override void Set(T value, int i, int j)
        {
            array[i][j] = value;
        }
       

        



      
    }
}
