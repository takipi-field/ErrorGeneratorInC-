namespace com.overops.errors
{

	using TimerTestUtil = com.overops.util.TimerTestUtil;

	public class TimerTest : BaseError
	{

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private void timerTest(int numberOfErrors)
		{
			log.Debug("Executing Timer Test");
			TimerTestUtil.testErrors(numberOfErrors);
		}

		public virtual void executeError()
		{
			timerTest(10);
		}
	}

}