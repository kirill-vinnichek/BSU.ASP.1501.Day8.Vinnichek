using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public static class MatrixExtension<T>
    {
        static Func<T, T, T> add_d;

        static MatrixExtension()
        {
            ParameterExpression paramA = Expression.Parameter(typeof(T), "a"),
                paramB = Expression.Parameter(typeof(T), "b");
            BinaryExpression body = Expression.Add(paramA, paramB);
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramA, paramB).Compile();
            add_d = add;
        }
        public static Matrix<T> Add(Matrix<T> a, Matrix<T> b)
        {

            if (a == null)
                throw new ArgumentNullException();
            if (b == null)
                throw new ArgumentNullException();
            if (a.Dimension != b.Dimension)
                throw new InvalidOperationException();

            var size = a.Dimension;
            T[][] values = new T[size][];
            for (int i = 0; i < size; i++)
            {
                values[i] = new T[size];
                for (int j = 0; j < size; j++)
                    values[i][j] = MatrixExtension<T>.add_d(a[i, j], b[i, j]);
            }
            return GetMatrix<T>(values);
        }




        public static Matrix<T>  GetMatrix<T>(T[][] array)
        {
            if (array.IsSquare())
            {
                if (array.IsDiagonal())
                    return new DiagonalMatrix<T>(array);
                if (array.IsSymmetry())
                    return new SymmetricMatrix<T>(array);
                return new SquareMatrix<T>(array);
            }
            return null;
        }




    }
}
