﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace com.overops.util
{

	public class NumberFormatUtil
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void testErrors(int numOfIterations)
		{
			IList<string> dataList = setupData();
			log.DebugFormat("Random Parse Integer Error generation for {} iterations ", numOfIterations);
			for (int i = 0; i < numOfIterations; i++)
			{
				try
				{
					Thread.Sleep(100);
					string value = getRandomValue(dataList);
					if (i % 2 == 0)
					{
						parseIntegerOld(value);
					}
					else
					{
						parseIntegerNew(value);
					}
				}
				catch (Exception e)
				{
					//log the exception and keep chugging
					log.Error(e.Message);
				}
			}
		}

		/*
		 * try catch method of testing if a string is a number
		 */
		private static void parseIntegerOld(string value)
		{
			try
			{
				int.Parse(value);
				log.InfoFormat("{} is a number", value);
			}
			catch (System.FormatException)
			{
				log.ErrorFormat("{} is NOT a number", value);
			}
		}

		/*
		 * Better way of checking if a string is a number that doesn't create exceptions that eat CPU cycles
		 */
		private static void parseIntegerNew(string value)
		{
			object objectValue = value;
			if (objectValue is int)
			{
				int integer = (int) objectValue;
				log.InfoFormat("{} is a number", value);
			}
			else
			{
				log.ErrorFormat("{} is NOT a number", value);
			}
		}

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