using System;

using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Codility
{
    struct Swapper
    {
        public int ID;
        public int pet;
        public int toy;
        public bool match;
        public List<int> prospect;

    };
    class Pets_Toys
    {
        static void Main(string[] args)
        {

            ////CASE 1
            //int[] petArray = new int[] { 1, 1, 2 };
            //int[] toyArray = new int[] { 2, 1, 1 };
            //int[] aArray = new int[] { 0, 2 };
            //int[] bArray = new int[] { 1, 1 };

            //CASE 2
            //int[] petArray = new int[] { 2, 2, 1, 1, 1 };
            //int[] toyArray = new int[] { 1, 1, 1, 2, 2 };
            //int[] aArray = new int[] { 0, 1, 2, 3 };
            //int[] bArray = new int[] { 1, 2, 0, 4 };


            //CASE 3
            //int[] petArray = new int[] { 1, 1, 2, 2, 1, 1, 2, 2 };
            //int[] toyArray = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 };
            //int[] aArray = new int[] { 0, 2, 4, 6 };
            //int[] bArray = new int[] { 1, 3, 5, 7 };

            //////CASE 4
            //int[] petArray = new int[] { 2, 2, 2, 2, 1, 1, 1, 1 };
            //int[] toyArray = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 };
            //int[] aArray = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            //int[] bArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            //CASE 5
            //int[] petArray = new int[] { 2, 2, 1, 1, 1 };
            //int[] toyArray = new int[] { 1, 1, 1, 2, 2 };
            //int[] aArray = new int[] { 0, 1, 2, 3 };
            //int[] bArray = new int[] { 1, 2, 3, 4 };

            ////CASE 6
            int[] petArray = new int[] { 2, 2, 1, 1, 1 };
            int[] toyArray = new int[] { 1, 1, 1, 2, 2 };
            int[] aArray = new int[] { 0, 1, 2, 4 };
            int[] bArray = new int[] { 3, 2, 3, 1 };

            //CASE 7
            //int[] petArray = new int[] { 2, 2, 2, 2, 1, 1, 1, 1 };
            //int[] toyArray = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 };
            //int[] aArray = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            //int[] bArray = new int[] { 1, 2, 3, 4, 5, 6, 7 };


            if (solution(petArray, toyArray, aArray, bArray))
            { Console.WriteLine("Pathexists: "); }
            else
            { Console.WriteLine("Path doesnt exist for swap: "); }
            }//Main
    
        public static bool solution(int[] P, int[] T, int[] A, int[] B)
        {
            bool fnretvalue = false;
            int matchlesscount = 0;
            //load struct objects
            //assume pet,toy combo stays same
            Swapper[] swapArray = new Swapper[P.Length];
            //  Swapper[] swapArray = new Swapper[P.Length];
        
            

            for (int i = 0; i < swapArray.Length; i++)
            {
                swapArray[i].prospect = new List<int>();
            }
            for (int i = 0; i < P.Length; i++)
            {
                swapArray[i].ID = i;
                swapArray[i].pet = P[i];
                swapArray[i].toy = T[i];
                if (P[i] == T[i]) { swapArray[i].match = true; } else { swapArray[i].match = false; matchlesscount++; }
                //swapArray[i].prospect has to be done later
            }//for

            //try direct swaps first


            int swapcount = 0;
            //check swap possibilty
            //replace with function to call whenever you can
            swapcount= prospectcheck(ref swapArray);
            if (((swapcount * 2) == matchlesscount) || (swapcount == matchlesscount) || ((swapcount / 2) == matchlesscount))
            {

                fnretvalue = true;
                Console.WriteLine("Swap possiblity exists");
                Console.WriteLine("Swapcount, Matchcount, Proscont: " + swapcount + " " + matchlesscount + " " );
            }//if
            else if (matchlesscount > 0)
            {
                fnretvalue = false;
                Console.WriteLine("Swap pair isnt complete: Swapcount, Matchcount, Proscont: " + swapcount + " " + matchlesscount + " " );
                return fnretvalue;
            }//if

            //------------------------------------------------------------------------------------------


            int[,] patharray = new int[P.Length, T.Length];

            for (int i = 0; i < A.Length; i++)
            {
                patharray[A[i], B[i]] = 1;
                patharray[B[i], A[i]] = 1;

                Console.WriteLine("Path set: S,D : " + A[i] + "->" + B[i] + " : " + patharray[A[i], B[i]]);

            }//fori

            //------------------------------------------------------------------------------
            //pathexists
            bool switchhappened;
            int source = 0;
            int dest = 0;
            bool SDpathExist = false;

            //checkpatharray
            for(int i=0;i<P.Length; i++)
            {
                switchhappened = false;
                for (int j = 0; j < P.Length; j++)
                {
                    
                    if (patharray[i,j] ==1)
                    {
                        Console.WriteLine("Patharray : " + i + " " + j);
                        if ((swapArray[i].toy == swapArray[j].pet) && (swapArray[j].toy == swapArray[i].pet) && (!swapArray[i].match ) && (!swapArray[j].match))
                        {
                            switchhappened = toyswap(ref swapArray[i], ref swapArray[j]); break;
                        }//if
                    }
                }
                //if (switchhappened) { break; }
            }//for

            prospectcheck(ref swapArray);

            for (int i = 0; i < swapArray.Length; i++)
            {

                if (!swapArray[i].match)
                {
                    SDpathExist = false;
                    source = swapArray[i].ID;
                    dest = swapArray[i].prospect[0];
                    int sfront = 0;
                    int dback = 0;
                    int sprev = 0;
                    int dprev = 0;
                    int counter = 0;
                    int acounter = P.Length - 1;
                    sfront = source;
                    dback = swapArray[i].prospect[0];
                    sprev = 0;
                    dprev = 0;
                    do
                    {
                        if (patharray[sfront, counter] == 1)
                        {
                            sprev = sfront;
                            sfront = counter;

                            //snext = i;
                        }//if

                        if (patharray[acounter, dback] == 1)
                        {
                            dprev = dback;
                            dback = acounter;

                        }//if

                        if (((sfront == dprev) || (sfront == dback)) && (patharray[sprev, sfront] == 1) && (patharray[dback, dprev] == 1))
                        {
                            switchhappened = toyswap(ref swapArray[source], ref swapArray[dest]);
                            prospectcheck(ref swapArray);
                            break;
                        }
                        counter++; acounter--;
                    } while ((counter <= acounter) || (((sfront <= dback) && (acounter > -1))));//for isntead while (sfront <= dback);//while loop

                }//if
            }//for
            foreach (Swapper swapper in swapArray)
            {
                if (!swapper.match) { fnretvalue = false; }

                //Console.WriteLine(swapper);
                Console.WriteLine("swapper deatils : "+ swapper.ID + swapper.match+ swapper.pet+swapper.toy );
                foreach (var item in swapper.prospect)
                {
                    Console.Write(item + ",");
                }
                Console.WriteLine("\n");
            }//foreach swapper arrary
             
            return fnretvalue;
        }//solution

        public static int  prospectcheck(ref Swapper[] swapperArray)
        {
            int cunt = 0;
            
            foreach (Swapper srey in swapperArray)
            {
                srey.prospect.Clear();
                //clearprospects
            }
            for (int i = 0; i < swapperArray.Length; i++)
            {
                //swapperArray[i].prospect.Clear();
                for (int j = i; j < swapperArray.Length; j++)
                {
                    if ((swapperArray[i].ID != swapperArray[j].ID) &&
                        (swapperArray[i].pet == swapperArray[j].toy) &&
                         (swapperArray[i].toy == swapperArray[j].pet) &&
                        (!swapperArray[i].match) && (!swapperArray[j].match))
                    {

                        swapperArray[i].prospect.Add(swapperArray[j].ID);
                        swapperArray[j].prospect.Add(swapperArray[i].ID);
                        cunt++;
                    }//if
                }//forj
            }//fori

            return cunt;
        }//prospectcheck


        public static bool toyswap(ref Swapper S, ref Swapper D)
        {
            bool status = false;
            //check whether path exists between prospect if so switch
            int tempa = D.ID;
            int tempb = S.ID;
            int temp;
          if ((!S.match) && (!D.match))
            {
                //swap and make match true
                temp = S.toy;
                S.toy = D.toy;
                D.toy = temp;
                if (D.pet == D.toy) { D.match = true; } else { D.match = false; }
                if (S.pet == S.toy) { S.match = true; } else { S.match = false; }
                S.prospect.Clear();
                D.prospect.Clear();
                status = true;
            }

            Console.WriteLine("SwapperID , SwapeeID" + S.ID + D.ID);            return status;

        }//toyswap

    }
}
