using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class Delegates
    {
        /// <summary>
        /// So, this is a delegate declaration. These determine the methods that can be
        /// referenced by the delegate.
        /// This method here can be used to reference any method that has a single string parameter
        /// and returns an int type variable
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public delegate int MyDelegate(string s);

        // Multicase delegate example
        public delegate int NumberChanger(int n);
    }
}
