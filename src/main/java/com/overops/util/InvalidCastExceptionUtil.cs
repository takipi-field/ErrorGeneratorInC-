using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{

	public class InvalidCastExceptionUtil
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random InvalidCast Error generation for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
					Thread.Sleep(100);
					string data = getRandomValue(dataList);
					long? value2 = Convert.ToInt64(data);

				}
				catch (Exception e)
				{
					//log the exception and keep chugging
					log.Error(e.Message);
				}
			}
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
			dataList.Add("12344");
			dataList.Add("3234");
			dataList.Add("356");
			dataList.Add("9449");
			dataList.Add("4565");
			dataList.Add("33445");
			dataList.Add("-54433");
			dataList.Add("333");
			dataList.Add("777");
			dataList.Add("2012-10-10");
			dataList.Add("#WhoKnows");

			return dataList;
		}
	}

}