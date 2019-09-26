using System;

namespace com.overops.errors
{

	using InvalidCastExceptionUtil = com.overops.util.InvalidCastExceptionUtil;

	public class InvalidCastException : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void classCastExceptionTest(int numberOfErrors)
		{
			log.Debug("Executing InvalidCastException Errors");
			InvalidCastExceptionUtil.testErrors(numberOfErrors);
		}

		public virtual void executeError() { 

            Console.WriteLine("Running InvalidCastException Test");
			classCastExceptionTest(10);
		}
	}

}