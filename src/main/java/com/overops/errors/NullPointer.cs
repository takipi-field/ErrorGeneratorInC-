using System;

namespace com.overops.errors
{

	using NullErrorUtil = com.overops.util.NullErrorUtil;

	public class NullPointer : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void nullPointerTest(int numberOfErrors)
		{
			log.Debug("Executing NullPointer Errors");
			NullErrorUtil.testErrors(numberOfErrors);
		}

		public virtual void executeError()
		{
            Console.WriteLine("Running NullPointerException Test");
            nullPointerTest(10);
		}
	}

}