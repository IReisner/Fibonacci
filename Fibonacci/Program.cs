using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Fibonacci
{
    public class DI
    {
        public UnityContainer container;
        public DI()
        {
            container = new UnityContainer();
            container.RegisterType<IFibonacci, FibIt>();
        }
        public IFibonacci Resolve<GenFib>() 
        {
            return container.Resolve<IFibonacci>();
        }
    }

    public class GenFib
    {
        IFibonacci _fib = null;

        public GenFib(IFibonacci fib)
        {
            _fib = fib;
        }
        public int compute  (int final)
        {
            return _fib.ComputeFibonacci(final);
        }
    }

    public interface IFibonacci
    {
        int ComputeFibonacci(int place);
    }

    public class FibRec : IFibonacci
    {
        public int ComputeFibonacci(int place)
        {
            return Fib(place);
        }

        int Fib(int place)
        {
            int val;
            if (place == 0)
            {
                val = 0;
            }
            else if (place == 1)
            {
                val = 1;
            }
            else
            {
                val = Fib(place - 1) + Fib(place - 2);
            }
            return val;
        }
    }


    public class FibIt : IFibonacci
    {
        public int ComputeFibonacci(int place)
        {
            if (place == 0) { return 0; }
            if (place == 1) { return 1; }
            int A = 0;
            int B = 1;
            int C = 0;
            for (int loop = 2; loop <= place; loop++)
            {
                C = A + B;
                A = B;
                B = C;
            }
            return C;
        }
    }

        public class Program
        {
            public static void Main(string[] args)
            {
            int final = 9;
            DI di = new DI();
            GenFib genFib = new GenFib(di.Resolve<GenFib>());

            for (int loop = 0; loop <= final; loop++)
            {
                Console.Write("{0} ", genFib.compute(loop));
            }
            Console.ReadKey();
            }

        }


}
