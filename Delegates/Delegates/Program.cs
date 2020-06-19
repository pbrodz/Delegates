using System;
using System.Net.NetworkInformation;

/// <summary>
/// Delegates are reference types that hold a reference to a method.
/// They are especially useful in Events where - "if something happens, call <this delegate> method
/// They are all implicitly derived from System.Delegate
/// 
/// The fun with delegates is e.g.
/// - You want to output something to Console
/// - You want to output something to File
/// - Just create Methods for both with the same signature
/// - Then create a delegate with the same signature
/// - Then you can instantiate each and optionally multi-cast a third delegate to output to each sequentially
/// - COOL, eh?
/// </summary>
namespace Delegates
{
    class Program
    {
        // For use in multi-sync example
        private static int numToUse;

        static void Main(string[] args)
        {
            // When we want to use our delegates - you "new up" an instance and pass in a method (defined below)
            // The magic here is that your're instantiating the SAME delegate type but with different methods that could do drastically different things
            Delegates.MyDelegate myFirst = new Delegates.MyDelegate(DoSomething);
            Delegates.MyDelegate mySecond = new Delegates.MyDelegate(DoSomethingElse);

            // Then you can simply call your instances that will in turn invoke the method you instantiated them with
            Console.WriteLine($"output:{myFirst("potato")}");
            Console.WriteLine($"output:{mySecond("potato")}");

            // Now lets do multicast delegates
            Delegates.NumberChanger nc;
            Delegates.NumberChanger addNum = new Delegates.NumberChanger(AddNum);
            Delegates.NumberChanger multiplyNum = new Delegates.NumberChanger(MultiplyNum);

            // So here, you are multicasting these delegate (have to be the same type)
            // What this means is that it will call addNum first, then multiplyNum
            // If we pass in 5 as we do - it will add the 5 to 0 = 5
            // Then it will multiply that by another 5 = 25
            // Neat eh?
            nc = addNum + multiplyNum;

            nc(5);
            Console.WriteLine($"value of num is:{numToUse}");

        }

        public static int DoSomething(string inputString)
        {
            return 1;
        }

        public static int DoSomethingElse(string inputString)
        {
            return 2;
        }

        public static int AddNum(int n)
        {
            numToUse += n;
            return numToUse;
        }
        public static int MultiplyNum(int n)
        {
            numToUse *= n;
            return numToUse;
        }
    }
}
