using System;
// you can also use other imports, for example:
// using System.Collections.Generic;

// you can write to stdout for debugging purposes, e.g.
// Console.WriteLine("this is a debug message");

class Solution
{
    public int solution(int[] A)
    {
        // write your code in C# 6.0 with .NET 4.5 (Mono)
        int retvalue = 0;
        //char opval = 'O'; 
        int aSize = A.Length;
        char[,] square = new char[aSize, aSize];
        //FILL SQUARE
        for (int x = 0; x < A.Length; x++)
        {
            for (int y = 0; y < A[x]; y++)
            {
                square[x, y] = 'B';
                // Console.WriteLine("Cell filled with B[R,C]" + x + y);
            }//for j
             //Console.WriteLine("\n");
            for (int k = A[x] + 1; k < A.Length; k++)
            {
                square[x, k] = ' ';
                //  Console.Write("Cell filled with space [R,C]" + x + k);
            }

        }//for i

        //Console.ReadLine();

        ////print square
        //for (int x = (aSize - 1); x >= 0; x--)
        //{
        //    Console.Write("---------------\n");
        //    for (int y = 0; y < aSize; y++)
        //   {
        //        Console.Write("|" + square[x,y]);
        //    }//for
        //    Console.Write("|\n");
        //}
        //Console.Write("\n_________________\n");
        /////

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
    }
}