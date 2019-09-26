using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{
	public class NullErrorUtil
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random NullPointer Error generation for {} iterations ", numOfIterations);

			for (int i = 0; i < numOfIterations; i++)
			{
				sleep();
				int value = RandomUtil.generateRandom(4);
				log.DebugFormat("Case number is {}", value);
				switch (value)
				{
					case 0 :
						testCaughtNulls(getRandomString(dataList));
						break;
					case 1 :
						try
						{
							testUncaughtNulls(getRandomString(dataList));
						}
						catch (Exception e)
						{
							log.ErrorFormat("This error was uncaught", e.Message);
						}
						break;
					case 2 :
						testSwallowedNulls(getRandomString(dataList));
						break;
					case 3 :
						intermediateMethod(getRandomString(dataList));
						break;
				}
			}
		}

		private static void intermediateMethod(string value)
		{
			testCaughtNulls(value);
		}
		/*
		 * This creates a null pointer that is caught and logged
		 */
		private static void testCaughtNulls(string value)
		{
			try
			{
				if (value.Equals("hello", StringComparison.OrdinalIgnoreCase))
				{
					//matching logic would go here
				}
			}
			catch (Exception e)
			{
				log.Error(e.Message);
			}
		}

		/*
		 * This creates a null pointer that is caught and not logged
		 */
		private static void testSwallowedNulls(string value)
		{
			try
			{
				if (value.Equals("hello", StringComparison.OrdinalIgnoreCase))
				{
					//matching logic would go here
				}
			}
			catch (Exception)
			{
				// TODO: handle exception
				//EAT it
			}
		}

		/*
		 * This creates a null pointer that is caught and not logged
		 */
		private static void testUncaughtNulls(string value)
		{
			if (value.Equals("hello", StringComparison.OrdinalIgnoreCase))
			{
				//matching logic would go here
			}
		}

		private static void sleep()
		{
			try
			{
				Thread.Sleep(200);
			}
			catch (Exception)
			{
				// TODO: handle exception
			}
		}

		private static string getRandomString(IList<string> dataList)
		{
			string returnString = null;
			try
			{
				returnString = (string) RandomUtil.getRandomObjectFromList(dataList);
			}
			catch (Exception e)
			{
				log.ErrorFormat("Unable to get random value from dataList, " + e);
			}

			return returnString;
		}

		private static IList<string> setupData()
		{
			IList<string> dataList = new List<string>();
			dataList.Add("hello");
			dataList.Add(null);
			dataList.Add("#NoNullHere");
			dataList.Add("It is a value");
			dataList.Add("Word");
			dataList.Add("Not Null");
			dataList.Add("Null");
			dataList.Add("Chaching");
			dataList.Add("Yup");
			dataList.Add("This is it");

			return dataList;
		}

	}

}