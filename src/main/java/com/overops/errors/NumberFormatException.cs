using System;

namespace com.overops.errors
{

	using NumberFormatUtil = com.overops.util.NumberFormatUtil;

	public class NumberFormatException : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void classCastExceptionTest(int numberOfErrors)
		{
			log.Debug("Executing NumberFormatException Errors");
			NumberFormatUtil.testErrors(numberOfErrors);
		}

		public virtual void executeError()
		{
            Console.WriteLine("Running NumberFormatException Test");
			classCastExceptionTest(10);
		}
	}

}