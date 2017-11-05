using System;

namespace _1
{
    
    enum Direction
    {
        North = 0,
        East = 1,
        South = 2,        
        West = 3
    }
    
    class Program
    {
        static Direction dir = 0;
        static int horizontal = 0;
        static int vertical = 0;        

        static void Main(string[] args)
        {            
            
            string inputtext = System.IO.File.ReadAllText(@"input.txt");
            
            //string inputtext = @"L4, L1, R4, R1, R1, L3, R5, L5, L2, L3, R2, R1, L4, R5, R4, L2, R1, R3, L5, R1, L3, L2, R5, L4, L5, R1, R2, L1, R5, L3, R2, R2, L1, R5, R2, L1, L1, R2, L1, R1, L2, L2, R4, R3, R2, L3, L188, L3, R2, R54, R1, R1, L2, L4, L3, L2, R3, L1, L1, R3, R5, L1, R5, L1, L1, R2, R4, R4, L5, L4, L1, R2, R4, R5, L2, L3, R5, L5, R1, R5, L2, R4, L2, L1, R4, R3, R4, L4, R3, L4, R78, R2, L3, R188, R2, R3, L2, R2, R3, R1, R5, R1, L1, L1, R4, R2, R1, R5, L1, R4, L4, R2, R5, L2, L5, R4, L3, L2, R1, R1, L5, L4, R1, L5, L1, L5, L1, L4, L3, L5, R4, R5, R2, L5, R5, R5, R4, R2, L1, L2, R3, R5, R5, R5, L2, L1, R4, R3, R1, L4, L2, L3, R2, L3, L5, L2, L2, L1, L2, R5, L2, L2, L3, L1, R1, L4, R2, L4, R3, R5, R3, R4, R1, R5, L3, L5, L5, L3, L2, L1, R3, L4, R3, R2, L1, R3, R1, L2, R4, L3, L3, L3, L1, L2";            
           //string inputtext = "R2, L3";
           //string inputtext = "R2, R2, R2";
           //string inputtext = "R5, L5, R5, R3";                      

            string[] inputs = inputtext.Split(new[] { ", " }, StringSplitOptions.None);

            for(int i=0; i<inputs.Length; i++)
            {
                Go(inputs[i]);
            }                                    

            Console.WriteLine("Horizontal: " + horizontal);
            Console.WriteLine("Vertical: " + vertical);

            Console.WriteLine(Math.Abs((horizontal) + Math.Abs(vertical)) + " blocks away" );
        }

        private static void Go(string input)
        {
            var a = input.Substring(0, 1);
            var b = int.Parse(input.Substring(1));

            if(a == "R")
            {
                R(b);                
            }

            if(a == "L")
            {
                L(b);                
            }
        }


        private static void R(int steps)
        {            
            if(dir == Direction.West)
            {
                dir = Direction.North;
            }else
            {
                dir++;
            }

            Move(dir, steps);
        }        

        private static void L(int steps)
        {            
            if(dir == Direction.North)
            {
                dir = Direction.West;
            }else
            {
                dir--;
            }

            Move(dir, steps);
        }        


        private static void Move(Direction direction, int steps)
        {
            switch(dir)
            {
                case Direction.East : 
                    horizontal += steps;
                    break;
                case Direction.West : 
                    horizontal -= steps;
                    break;

                case Direction.North : 
                    vertical += steps;
                    break;
                case Direction.South : 
                    vertical -= steps;
                    break;
            }
        }
    }
}