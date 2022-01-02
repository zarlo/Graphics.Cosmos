using System;

namespace Graphics
{
    public static class Math
    {

        public static int Factorial(int f)
        {
            if(f == 0)
                return 1;

            else if(f == 1)
                return 0;
            
            else if(f == 2)
                return 2;
            else
            {
                var output = 1;
                var index = 2;
                Factorial(f, ref index, ref output);
                return output;
            }
        }
        static void Factorial(int f, ref int index, ref int output)
        {
            if(index == f) return;
            if(f == 2)
                output *= 2;
            else
            {
                output *= index; 
                index++;
                Factorial(f, ref index, ref output);
            }
        }
        
    }
}
