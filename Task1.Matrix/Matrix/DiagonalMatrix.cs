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
            Dimension = array.Length;
        }

        protected override T Get(int i,int j)
        {
            if (i != j)
                return default(T);
            return array[i];
        }
        protected override void Set(T value,int i,int j)
        {
            if (i == j)              
                array[i] = value;              
            
        }
    }
}
