using System;
using System.Collections.Generic;
using System.Text;

namespace Codility
{
    class Cakelayer
    {
        //    //variables declaration
        //    public int flavor;
        //    public int fl;
        //    public int ll;

        //    public int N_formCnt;
        //    public int K_layerCnt;

      


        public static void Main(String[] args)
        {
            int fnretvalue = 0;
            //CASE 1
            //int argN = 5;
            //int argK = 3;
            //int[] argA = new int[] { 1, 1, 4, 1, 4 };
            //int[] argB = new int[] { 5, 2, 5, 5, 4 };
            //int[] argC = new int[] { 1, 2, 2, 3, 3 };

            ////CASE 2
            //// N = 6, K = 4, A = [1, 2, 1, 1], B = [3, 3, 6, 6] and C = [1, 2, 3, 4],
            //int argN = 6;
            //int argK = 4;
            //int[] argA = new int[] { 1, 2, 1, 1 };
            //int[] argB = new int[] { 3, 3, 6, 6 };
            //int[] argC = new int[] { 1, 2, 3, 4 };

            //CASE 3
            //N = 3, K = 2, A = [1, 3, 3, 1, 1], B = [2, 3, 3, 1, 2] and C = [1, 2, 1, 2, 2],
            //int argN = 3;
            //int argK = 2;
            //int[] argA = new int[] { 1, 3, 3, 1, 1 };
            //int[] argB = new int[] { 2, 3, 3, 1, 2 };
            //int[] argC = new int[] { 1, 2, 1, 2, 2 };

            ////CASE 4
            ////Given N = 5, K = 2, A = [1, 1, 2], B = [5, 5, 3] and C = [1, 2, 1],
            //int argN = 5;
            //int argK = 2;
            //int[] argA = new int[] { 1,1,2 };
            //int[] argB = new int[] {5,5,3 };
            //int[] argC = new int[] { 1, 2, 1 };


            fnretvalue = solution(argN, argK, argA, argB, argC);
            Console.WriteLine ("\n Returned function value: " + fnretvalue);
        }

        public static int solution(int N, int K, int[] A, int[] B, int[] C)
        {
            int flavor;
            int firstForm;
            int lastForm;

            bool success;

            //List<List<string>> lists = new List<List<string>>();

            List<int>[] forms = new List<int>[N];

            for (int i = 0; i < N; i++)
            {
                forms[i] = new List<int>();
            }

            int retvalue =0;
            //check for all forms also number of cakes
            //N or C could be same
            for(int i=0; i<C.Length;i++)
            {
                flavor = C[i];
                firstForm = A[i];
                lastForm = B[i];

                do
                {
                    forms[(firstForm - 1)].Add(flavor);
                    firstForm++;
                } while (firstForm <= lastForm);
            }//for fill layers

            Console.WriteLine("-----------------------------------------");
            foreach(List<int> cake in forms)
            {
                Console.WriteLine(String.Join(',',cake.ToArray()));
            }
            //Console.Write(cake.Length);
            Console.Write("---------------------------------------------");

          
            foreach(List<int> cake in forms)
            {
                success = false;
                //K-assumption need to have all layers
                if (cake.Count == K)
                {
                    for (int i = 0; i < cake.Count; i++)
                    {
                        if (cake[i] ==( i+1))
                        {
                            success = true;
                        }
                        else
                        {
                            success = false;
                            break;
                        }
                    }//forlist data check
                    if (success) { retvalue++; }
                }//if for K layer to match 
                  
            }//list everything in cake Array
            return retvalue;
        }//solution

    }
}
