using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{

	public class IndexOutOfBoundsErrorUtil
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random IndexOutOfBounds Error generation for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
					Thread.Sleep(100);
					int data = RandomUtil.generateRandom(10);
					string returnString = dataList[data];

				}
				catch (Exception e)
				{
					//log the exception and keep chugging
					log.Error(e.Message);
				}
			}
		}

		private static IList<string> setupData()
		{
			IList<string> dataList = new List<string>();
			dataList.Add("1");
			dataList.Add("2");
			dataList.Add("3");
			dataList.Add("4");
			dataList.Add("5");
			dataList.Add("6");
			dataList.Add("7");
			dataList.Add("8");
			dataList.Add("9");
			dataList.Add("10");

			return dataList;
		}
	}

}