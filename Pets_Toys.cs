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

       // public override String ToString()
       public string dispString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id - ");
            sb.Append(ID);
            sb.Append(", ");
            sb.Append("pet - ");
            sb.Append(pet);
            sb.Append(",");
            sb.Append("toy - ");
            sb.Append(toy);
            sb.Append(",");
            sb.Append("match - ");
            sb.Append(match);
            
            
            return sb.ToString();
        }
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
            int[] petArray = new int[] { 1, 1, 2, 2, 1, 1, 2, 2 };
            int[] toyArray = new int[] { 1, 1, 1, 1, 2, 2, 2, 2 };
            int[] aArray = new int[] { 0, 2, 4, 6 };
            int[] bArray = new int[] { 1, 3, 5, 7 };

            ////CASE 4
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
            //int[] petArray = new int[] { 2, 2, 1, 1, 1 };
            //int[] toyArray = new int[] { 1, 1, 1, 2, 2 };
            //int[] aArray = new int[] { 0, 1, 2, 4 };
            //int[] bArray = new int[] { 3, 2, 3, 1 };

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
            for(int i =0;i<swapArray.Length;i++)
            {
                swapArray[i].prospect  = new List<int>();
            }
            for (int i=0;i<P.Length;i++)
            {
                swapArray[i].ID = i;
                swapArray[i].pet= P[i];
                swapArray[i].toy = T[i];
                if (P[i] == T[i]) { swapArray[i].match = true; } else { swapArray[i].match = false; matchlesscount++; } 
                //swapArray[i].prospect has to be done later
            }//for
       
            int swapcount=0;
            int proscnt = 0;


            //check swap possibilty
            //replace with function to call whenever you can
            prospectcheck(ref swapArray, out  proscnt, out  swapcount);
           if( ((swapcount*2)==matchlesscount) || (swapcount == matchlesscount) || ((swapcount/2) == matchlesscount))
            {
                
                fnretvalue = true;
                Console.WriteLine("Swap possiblity exists");
                Console.WriteLine("Swapcount, Matchcount, Proscont: "+ swapcount +  " " + matchlesscount + " "+ proscnt.ToString());
            }//if
            else if(matchlesscount>0)
            {
                fnretvalue = false;                
                Console.WriteLine("Swap pair isnt complete: Swapcount, Matchcount, Proscont: " + swapcount + " " + matchlesscount + " " + proscnt.ToString());
                return fnretvalue;
            }//if

            //------------------------------------------------------------------------------------------


            int[,] patharray = new int[P.Length, T.Length];

            for (int i=0; i<A.Length; i++)
            {
                patharray[A[i], B[i]]=1;
                patharray[B[i], A[i]]=1;

                Console.WriteLine("Path set: S,D : " + A[i] + "->" + B[i] + " : " + patharray[A[i],B[i]]);

            }//fori

            //------------------------------------------------------------------------------
            //pathexists
            int dumb; 
            bool switchhappened;
            int source=0;
            int dest=0;
            bool SDpathExist = false;

            //finish directswaps first
            for (int i = 0; i < A.Length; i++)
            {

                for (int j = i; j < A.Length; j++)


                    if(((patharray[i, j] == 1) || (patharray[i, j] == 1)) && 
                        ((swapArray[i].toy) == (swapArray[j].pet)) && ((swapArray[i].pet) == (swapArray[j].toy)))
                       {
                    switchhappened = toyswap(patharray, ref swapArray[i], ref swapArray[j]);
                        Console.WriteLine("Direct swap");
                    }
                  

            }//fori


            for (int i=0;i<swapArray.Length;i++)
            {

                    if (!swapArray[i].match)
                {
                    
                    SDpathExist = false;
                    source = swapArray[i].ID;
                    dest = swapArray[i].prospect[0];
                    prospectcheck(ref swapArray, out dumb, out dumb);

                    //firsttry, id and first prospect path exists
                    if ((patharray[source, dest] == 1) || (patharray[dest, source] == 1))
                    {

                        SDpathExist = true;
                        switchhappened = toyswap(patharray, ref swapArray[source], ref swapArray[dest]);
                        if (switchhappened)
                        {
                         //   prospectcheck(ref swapArray, out dumb, out dumb);

                            break;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < swapArray[i].prospect.Count; j++) //check prospects
                        {
                            //source = swapArray[i].ID;
                            dest = swapArray[i].prospect[j];
                            if ((patharray[source, dest] == 1) || (patharray[dest, source] == 1))
                            {
                                SDpathExist = true;
                                switchhappened = toyswap(patharray, ref swapArray[source], ref swapArray[dest]);
                                if (switchhappened)
                                {
//                                    prospectcheck(ref swapArray, out dumb, out dumb);
                                    break;
                                }
                            }//ifswitchhappened
                        }//forprospects
                         //checkpatharray for next available link
                    }

                    //-----------------------------------------------------------
                    if (!SDpathExist)
                    {
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
                                SDpathExist = true; break;
                            }

                            //    //if s exists in patharray and dest isnt 
                            //    if (patharray[sfront, snext] == 1)  && (patharray[dback,dprev]==1) &&  
                            //if ( (patharray[sfront, snext] == 1) && (patharray[dback,dprev]==1))


                            //    //if (((patharray[sfront, p] == 1) && (patharray[p, dback] == 1)) ||
                            //    //    ((patharray[p, sfront] == 1) && (patharray[dback, p] == 1)) 
                            //    //    ||((patharray[sfront,dback] == 1) && (patharray[dback,sfront] == 1)) ||
                            //    //    ((patharray[sfront, p] == 1) && (patharray[p, dback] == 1))
                            //    //    )
                            //        //&& ((patharray[sfront, (sfront-1)] == 1) && (patharray[dback, (dback+1)] == 1))                                        )
                            //    {
                            //        SDpathExist = true; break;
                            //        dest = swapArray[i].prospect[0];
                            //    }//ifcheck
                            ////}//for patharray level check
                            //if (SDpathExist) { break; }
                            //sfront++;
                            //dback--;
                            counter++; acounter--;
                            //    } while ((sfront <= dback) && (counter<=acounter ) );//for isntead while (sfront <= dback);//while loop
                        } while ((counter <= acounter)||  (((sfront<=dback) && (acounter>-1)))) ;//for isntead while (sfront <= dback);//while loop
                }//if SDpathexist
                     if (SDpathExist)
                    {
                        switchhappened = toyswap(patharray, ref swapArray[source], ref swapArray[dest]);
                        if (switchhappened)
                        {
                    //        prospectcheck(ref swapArray, out dumb, out dumb);
                        //break;
                        }
                    }

                }//if
                //if (SDpathExist)
                //{
                //    //dest = swapArray[source].prospect[0];
                //    switchhappened = toyswap(patharray, ref swapArray[source], ref swapArray[dest]);
                //    if (switchhappened)
                //    {
                //        prospectcheck(ref swapArray, out dumb, out dumb);
                //        //    break;
                //    }
                //}
            }//forloop
            ////-----------------------------------------------------------------------------------check entries before return the value
           // fnretvalue =
                 foreach (Swapper swapper in swapArray)
            {
                if (!swapper.match){ fnretvalue = false;}
                
                //Console.WriteLine(swapper);
                Console.WriteLine(swapper.dispString());
                foreach (var item in swapper.prospect)
                {
                    Console.Write(item + ",");
                }
                Console.WriteLine("\n");
            }//foreach swapper arrary
             //prospectcheck(ref swapArray, out dumb, out dumb);


            return fnretvalue;
        }//solution

        public static void prospectcheck(ref Swapper[] swapperArray, out int proscount, out int swapcnt)  
        {
            int cunt=0;
            bool retstatus =false;
            foreach(Swapper srey in swapperArray)
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
        
            proscount = cunt;
            swapcnt = cunt;

           
            //return retstatus;
        }//prospectcheck


       // public static bool toyswap(int[,] pArray, ref Swapper S, ref Swapper D, int aEntryCnt)
       public static bool toyswap(int[,] pArray, ref Swapper S, ref Swapper D)
        {
            bool status = false;
            //check whether path exists between prospect if so switch

            //for (int k = 0; k <= aEntryCnt; k++)
            //{
                int tempa = D.ID;
                int tempb = S.ID;
                int temp;
                //Console.WriteLine("S and D" + S.ID + " " + D.ID);
                //if ((pArray[tempa, tempb] == 1) || (pArray[tempb, tempa] == 1) && ((!S.match)&&(!D.match)))
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

            Console.WriteLine("SwapperID , SwapeeID" + S.ID + D.ID);

            //}
            return status;
        }//toyswap

    }
}
