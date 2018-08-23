using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iteration_ThroughGS
{
    class Program
    {
        public void CreateFormulaTournament()
        {
            double x, y;
            

            x = 1;
            y = 2;


            for (int i = 0; i < 10; i++)
            {

                x += 10;
                y *= 2;
                Console.WriteLine(x);
                Console.WriteLine(y);
            }

            Console.WriteLine(x + y);
        }
        void Main(string[] args)
        {
            CreateFormulaTournament();
        }
    }
}
