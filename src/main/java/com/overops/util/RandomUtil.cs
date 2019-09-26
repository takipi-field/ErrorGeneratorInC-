using System;
using System.Collections.Generic;
using System.Text;

namespace com.overops.util
{

    /// <summary>
    ///Does not create a static class as you must utilize a single seed in subsequent
    /// calls to insure unique randomness
    /// 
    /// </summary>
    public class RandomUtil
    {
        private static Random hdrRndm = new Random();

        internal static long convertDate(string dateString)
        {
            DateTime date = DateTime.Parse(dateString);
            long number = Convert.ToInt64(date);
            return number;
        }


    /// <summary>
    ///Returns a string of randomly generate alpha numeric characters. This string
    /// will be the length specified by the input parameter. </summary>
    /// <param name="length"> the total length of random characters you wish returned </param>
    /// <returns> <b>string</b> a randomly generated string of alphanumeric characters only </returns>

    public static int getRandomNumberInRange(int low, int high)
        {
            return hdrRndm.Next(high - low) + low;
        }



        public static int generateRandom(int length)
        {
            int value = hdrRndm.Next(length);
            return value;
        }


        //JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
        //ORIGINAL LINE: public static Object getRandomObjectFromList(java.util.List objList)throws Exception
        public static object getRandomObjectFromList(IList<string> dataList)
        {
            if (dataList == null || dataList.Count == 0)
            {
                return null;
            }
            else if (dataList.Count == 1)
            {
                return dataList[0];
            }
            int lGetObjIndex = generateRandom(dataList.Count);
            return (object)dataList[lGetObjIndex];
        }
 
    }
}