using System;

namespace com.overops.errors
{

	using IndexOutOfBoundsErrorUtil = com.overops.util.IndexOutOfBoundsErrorUtil;

	public class IndexOutOfBounds : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
               (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void indexOutOfBoundsTest(int numberOfErrors)
		{
			log.Debug("Executing IndexOutOfBounds Errors");
			IndexOutOfBoundsErrorUtil.testErrors(numberOfErrors);
		}

		public virtual void executeError()
		{
            Console.WriteLine("Running IndexOutOfBoundsException Test");
            indexOutOfBoundsTest(10);
		}
	}

}