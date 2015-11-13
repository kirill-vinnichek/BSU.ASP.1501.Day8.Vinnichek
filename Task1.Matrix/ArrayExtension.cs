using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Matrix
{
    public static class ArrayExtension
    {

        public static bool IsDiagonal<T>(this T[][] array)
        {
            int size = array.Length;
            var comparer = Comparer<T>.Default;
            var d = default(T);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    if (i != j && comparer.Compare(array[i][j], d) != 0)
                        return false;
            return true;
        }
        public static bool IsSquare<T>(this T[][] array)
        {
            int size = array.Length;
            for (int i = 0; i < size; i++)
            {
                if (size != array[i].Length)
                    return false;
            }
            return true;
        }
      
        public static bool IsSymmetry<T>(this T[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (!array[i][j].Equals(array[j][i]))
                        return false;
                }
            }
            return true;
        }
    }
}
