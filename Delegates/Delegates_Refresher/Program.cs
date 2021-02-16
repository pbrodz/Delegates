using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multicast_Delegates
{
    class PaulsDelegate
    {
        public delegate void CalculateSquare(double numberToSquare);
        public void SquareOnce(double numberToUse)
        {
            Console.WriteLine(Math.Pow(numberToUse, 2.0));
        }
        public void SquareTwice(double numberToUse)
        {
            Console.WriteLine(Math.Pow(numberToUse, 4.0));
        }
    }
    class TestDeleGate
    {
        public delegate void ShowMessage(string s);
        public void message1(string msg)
        {
            Console.WriteLine("1st Message is : {0}", msg);
        }
        public void message2(string msg)
        {
            Console.WriteLine("2nd Message is : {0}", msg);
        }
        public void message3(string msg)
        {
            Console.WriteLine("3rd Message is : {0}", msg);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TestDeleGate td = new TestDeleGate();
            TestDeleGate.ShowMessage message = null;
            message += new TestDeleGate.ShowMessage(td.message1);
            message += new TestDeleGate.ShowMessage(td.message2);
            message += new TestDeleGate.ShowMessage(td.message3);
            message("Hello Multicast Delegates");
            message -= new TestDeleGate.ShowMessage(td.message2);
            Console.WriteLine("----------------------");
            message("Message 2 Removed");
            Console.ReadKey();

            Console.WriteLine("--------------------------------------------------------");
            // Create an instance of the class in which the delegate lived
            PaulsDelegate paulsDelegate = new PaulsDelegate();
            // Create an empty delegate "chain" - this is an instance of the delegate in the class you created above
            PaulsDelegate.CalculateSquare outputNumber = null;
            // So, lets add a "new" delegate into the "chain". Here we need to instantiate another new delegate to add to your existing delegate - adding to the chain, so to speak
            outputNumber += new PaulsDelegate.CalculateSquare(paulsDelegate.SquareOnce);
            // Now lets add another delegate into the chain, shall we?
            outputNumber += new PaulsDelegate.CalculateSquare(paulsDelegate.SquareTwice);
            // And let's invoke that, shall we?
            outputNumber(5.0);
            // What you'll then see is that both outputs get spat out! The delegates are called one after another
            Console.ReadKey();

            // Now lets remove one of the delegates - say the first one?
            outputNumber -= new PaulsDelegate.CalculateSquare(paulsDelegate.SquareOnce);

            // and see that we only get the second one
            outputNumber(5.0);
            Console.ReadKey();
        }
    }
}