using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{
	public class TimerTestUtil
    { 
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random Timer Tester for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
					string data = getRandomValue(dataList);
					int? intValue = parseInteger(data);

					Thread.Sleep(intValue.Value);
				}
				catch (Exception e)
				{
					//log the exception and keep chugging
					log.Error(e.Message);
				}
			}
		}

		/*
		 * Better way of checking if a string is a number that doesn't create exceptions that eat CPU cycles
		 */
		private static int? parseInteger(string data)
		{
			object @object = data;
			if (@object is int?)
			{
				return (int?) @object;
			}
			else
			{
				log.ErrorFormat("{} is NOT a number", data);
			}
			return 0;
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static String getRandomValue(java.util.List<String> dataList) throws Exception
		private static string getRandomValue(IList<string> dataList)
		{
			string returnString = (string) RandomUtil.getRandomObjectFromList(dataList);
			return returnString;
		}

		private static IList<string> setupData()
		{
			IList<string> dataList = new List<string>();
			dataList.Add("1000");
			dataList.Add("100");
			dataList.Add("20");
			dataList.Add("50");
			dataList.Add("300");
			dataList.Add("40");
			dataList.Add("501");
			dataList.Add("11");
			dataList.Add("68");

			return dataList;
		}
	}

}