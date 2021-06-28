using System;
using System.Collections.Generic;

namespace PairUpDivisibleNumber
{
    struct Pair
    {
        public int firstArrayElement { get; set; }
        public int secondArrayElement { get; set; }

    
    }

    class DivisblePairArray
    {

        public static List<Pair> CreateDivisblePairArray(int[,] arraysToCheck,int number)
        {
         
            List<Pair> PairList = new List<Pair>();

            try
            {
                for (int i = 0; i < arraysToCheck.GetLength(1); i++)
                {

                    if (arraysToCheck[0, i] % number == 0 && arraysToCheck[1, i] % number == 0)
                    {
                        PairList.Add(new Pair()
                        {
                            firstArrayElement = arraysToCheck[0, i],
                            secondArrayElement = arraysToCheck[1, i]

                        });
                    }


                }
            }
            catch (IndexOutOfRangeException io)
            {
                throw new IndexOutOfRangeException("Error occured in processing!! " + io.Message);
            }

            return PairList;
        }

       

    }


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[,] arrays = new int[2,5] { { 10, 20, 30, 40, 50 }, { 12, 24, 40, 90, 200 } };
            List<Pair> resultPairArr = new List<Pair>();
            try
            {
               resultPairArr = DivisblePairArray.CreateDivisblePairArray(arrays, 10);
                Console.WriteLine("Processing Successful!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Processing failed!!" + ex.Message);
            }

            Pair maxPair = new Pair();
            int maxPairSum = 0;
            if (resultPairArr.Count > 0)
            {
                foreach (var arr in resultPairArr)
                {
                    Console.Write("("+arr.firstArrayElement + "," + arr.secondArrayElement+") ,");

                    if (maxPairSum < arr.firstArrayElement + arr.secondArrayElement)
                    {
                        maxPairSum = arr.firstArrayElement + arr.secondArrayElement;
                        maxPair = arr;
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Array with max value {0},{1}" , maxPair.firstArrayElement, maxPair.secondArrayElement);
            }

        }
    }
}
