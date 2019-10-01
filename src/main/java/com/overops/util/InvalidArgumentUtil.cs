using System;
using System.Collections.Generic;

namespace com.overops.util
{

	public class InvalidArgumentUtil
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random InvalidArgument Error generation for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
                    String number = getRandomValue(dataList);
                    long data = Convert.ToInt64(number);
					if (i % 2 == 0)
					{
						checkPercentage(data);
					}
					else
					{
						percentValidator(data);
					}
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

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void checkPercentage(System.Nullable<long> value) throws IllegalArgumentException
		private static void checkPercentage(long data)
		{
			if (data < 0 || data > 100)
			{
				throw new System.ArgumentException("Invalid Percentage");
			}
		}

//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in C#:
//ORIGINAL LINE: private static void percentValidator(System.Nullable<long> value) throws IllegalArgumentException
		private static void percentValidator(long data)
		{
			checkPercentage(data);
		}

		private static IList<string> setupData()
		{
			IList<string> dataList = new List<string>();
			dataList.Add("3");
			dataList.Add("78");
			dataList.Add("34");
			dataList.Add("0");
			dataList.Add("99");
			dataList.Add("100");
			dataList.Add("-3");
			dataList.Add("202");
			dataList.Add("33");
			dataList.Add("O");

			return dataList;
		}
	}

}