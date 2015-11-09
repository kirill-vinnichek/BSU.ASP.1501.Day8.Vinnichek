using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {

        public SymmetricMatrix(T[][] array)
            : base(array.Length)
        {
            if (array == null)
                throw new ArgumentNullException();
            if (!array.IsSquare())
                throw new ArgumentException("Array is not Square");
            if (!array.IsSquare())
                throw new ArgumentException("Martix has to be symmetrical");
            Initialize(array);

        }


       

        public override T this[int i, int j]
        {
            get
            {
               return base[i, j];
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
                old = array[j][i];
                array[j][i] = value;
                OnChange(this, new MatrixEventArgs<T>(j, i, old, array[i][j]));
            }
        }

    }
}
