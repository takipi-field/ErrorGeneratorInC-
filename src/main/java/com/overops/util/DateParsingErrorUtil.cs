using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{

	public class DateParsingErrorUtil
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random DateParsing Error generation for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
					Thread.Sleep(100);
					long value = RandomUtil.convertDate(getRandomDate(dataList));

					if (value > 0)
					{
						long value2 = RandomUtil.convertDate(getRandomDate(dataList));
					}

				}
				catch (Exception e)
				{
					//log the exception and keep chugging
					log.ErrorFormat("Error converting date, " + (e.Message));
				}
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static String getRandomDate(java.util.List<String> dataList) throws Exception
		private static string getRandomDate(IList<string> dataList)
		{
			string returnString = (string) RandomUtil.getRandomObjectFromList(dataList);
			return returnString;
		}

		private static IList<string> setupData()
		{
			IList<string> dataList = new List<string>();
			dataList.Add("#NotADate");
			dataList.Add("02/12/2017");
			dataList.Add("2012-10-10");
			dataList.Add("03/10/2010");
			dataList.Add("04/23/2012");
			dataList.Add("05/23/2012");
			dataList.Add("06/23/2013");
			dataList.Add("07/23/2015");
			dataList.Add("08/23/2017");
			dataList.Add("09/23/1999");

			return dataList;
		}
	}

}