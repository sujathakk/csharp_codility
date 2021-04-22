using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    class Matrix
    {

        public static void Main(String[] args)
        {
            int fnretvalue = 0;
            //int[] argA;
            //CASE1
            //int[] argA = { 1, 2, 5, 3, 1, 3 };
            //case 2
            //int[] argA = { 3, 3, 3, 5, 4 };
            //CASE 3
            //int[] argA = { 6, 5, 5, 6, 2, 2 };
            //CASE 4
            //int[] argA = { 1};
            //case 5
            int[] argA = { 16, 5, 15, 6, 12, 2,12,3,12,14,14,16,1,16,1,16 };
            //case 6 - pyramid
            //argA = {4,12,5,11,5,12,5,10,5,11,1,9,1};
            //case 6 - codility failed alternate test
            //argA = { 4, 12, 3,7, 4, 11, 10, 12, 5, 11, 8, 9, 1 };
            //case 7 - local maximum
            //argA = { 1 };
            //case 8-local minimum
            //int[] argA = { 13,13,13,13,13,13,13,13,13,13,13,13,13,13 };
            //
            //int[] argA = { 4, 4, 4, 4};

            fnretvalue = solution(argA);
            Console.WriteLine("\nReturned value: " + fnretvalue);

        }//Main
        public static int solution(int[] A)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)
            int retvalue = 0;
            //char opval = 'O'; 
            int aSize = A.Length;
            char[,] square;
             square = new char[aSize, aSize];
            //FILL SQUARE
            Console.WriteLine("Array size: " + aSize);
            for (int x = 0; x <aSize; x++)
            {
                for (int k = A[x]; k < aSize; k++)
                {
                   
                   square[x, k] = ' '; 
                    Console.WriteLine("Cell filled with space [x,k]" + x + k + square[x, k]);
                }

                for (int y = 0; y < A[x]; y++)
                {
                    square[x, y] = 'B';
                    Console.WriteLine("Cell filled with B[R,C]" + x + y);
                }//for j
                 //Console.WriteLine("\n");

                //if (A[x] == (aSize - 1))
                //{
                //    square[x, A[x]] = 'B';
                //    Console.WriteLine("If special [x,k]" + x + A[x]+ square[x, A[x]]);
                //}

            }//for i

            //Console.ReadLine();

            //print square
            for (int y = (aSize - 1); y >= 0; y--)
            {
                Console.Write("---------------\n");
                for (int x = 0; x < aSize; x++)
                {
                    Console.Write("|" + square[x, y]);
                }//for
                Console.Write("|\n");
            }
            Console.Write("\n_________________\n");
            ///

            //checkvertices
            //check vertices first
            int fnvalue = A.Length;
            int vercheck = fnvalue;
            bool vercheckpass = false;
            int iterationCount = fnvalue;

            do
            {

                vercheck--;
                iterationCount = fnvalue - vercheck;
                vercheckpass = false;
                for (int i = 0; i < iterationCount; i++)
                {

                    if ((square[i, 0] == 'B') && (square[vercheck + i, 0] == 'B') && (square[vercheck + i, vercheck] == 'B') && (square[i, vercheck] == 'B'))
                    //valid to make assumption that no floating squares
                    //   if ((square[i, i] == 'B') && (square[vercheck+i, i] == 'B') && (square[vercheck+i,vercheck] == 'B') && (square[i, vercheck] == 'B'))
                    {
                        vercheckpass = true;

                        ////check all rows and all columns values
                        for (int y = 0; y <= (vercheck); y++)
                        {

                            for (int x = i; x <= (vercheck + i); x++)
                            {

                                if (square[x, y] != 'B')
                                {
                                    vercheckpass = false;
                                    break;
                                }//if 

                            }//for
                             //  Console.Write("\n");
                            if (!vercheckpass) { break; } //if 
                        }//for


                        if (vercheckpass)
                        {
                            retvalue = vercheck + 1; //should also be vercheck-i
                            return retvalue;
                        }
                        //else
                        //{
                        //    break; 
                        //}
                        ////return retvalue ;
                        // break;
                    }//fnvalue                   
                }//for
            } while (vercheck > 0);
            //retvalue = Math.Abs(vercheck - iterationCount)+1;
            retvalue = vercheck + 1; //should also be vercheck-i
            return retvalue;
        }//solution
    }//Matric
}//codility

