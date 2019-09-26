using System;

namespace com.overops.errors
{

	using DateParsingErrorUtil = com.overops.util.DateParsingErrorUtil;

	public class DateParsingError : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public virtual void executeError()
		{
			log.Debug("Executing Date Parsing Error");
			dateParsingErrorTest(10);
		}

		private void dateParsingErrorTest(int numberOfErrors)
		{
            Console.WriteLine("Running DateParsingException Test");
            DateParsingErrorUtil.testErrors(numberOfErrors);
		}

	}

}