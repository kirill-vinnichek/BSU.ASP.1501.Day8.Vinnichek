using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[][] array;
       
        public SymmetricMatrix(T[][] array)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("Array is not square");
            this.array = new T[array.Length][];
            for (int i = 0; i < array.Length; i++)
            {
                this.array[i] = new T[i+1];
                Array.Copy(array[i], this.array[i], i+1);
            }
            Dimension = array.Length;
        }


        protected override T Get(int i, int j)
        {
            return j > i ? array[j][i] : array[i][j];            
        }

        protected override void Set(T value, int i, int j)
        {
            if (j > i)
                array[j][i] = value;
            else
                array[i][j] = value;
        }

       
       


       
    }
}
