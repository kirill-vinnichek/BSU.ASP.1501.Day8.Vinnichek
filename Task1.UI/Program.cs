using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Matrix;
namespace Task1.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new int[3][];
            v[0] = new[] { 1, 2, 3 };
            v[1] = new[] { 1, 2, 3 };
            v[2] = new[] { 1, 2, 3 };
            var a = new DiagonalMatrix<int>(v);
            var b = new DiagonalMatrix<int>(v);
            var c = MatrixExtension<int>.Add(a, b);
            Console.WriteLine(c);
        
            c.Change = OnChange;
            c[1, 1] = 17;
            var array = new int[2][];
            array[0]= new[]{1,2};
            array[1] = new[]{2,1};
            var sm = new SymmetricMatrix<int>(array);
            Console.WriteLine(sm);
            Console.ReadKey();
        }

        static void OnChange(object sender, MatrixEventArgs<int> e)
        {
            Console.WriteLine("Element [{0},{1}] has been Changed. {2} ---> {3}", e.i, e.j, e.OldElement, e.NewElement);
        }
    }
}
