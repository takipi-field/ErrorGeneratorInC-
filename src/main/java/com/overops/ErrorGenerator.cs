using System;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;

namespace com.overops
{
	using BaseError = com.overops.errors.BaseError;
	using RandomUtil = com.overops.util.RandomUtil;

    public class ErrorGenerator
	{
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static IDictionary<string, string> classMap = new Dictionary<string, string>();
		private static IList<string> classList = new List<string>();

		/// <summary>
		/// runTime is the length of time you want the error generator to run in minutes
		/// errorType options are "all", "NP" for null pointer, "CCE" for class cast exception, "DP" for date parsing errors </summary>
		/// <param name="args"> </param>
		public static void Main(string[] args)
		{
			int runTime = int.Parse(args.Length == 0 ? "120": args[0]);
			string errorType = args.Length == 0 ? "ALL": args[1];
            Console.WriteLine("ErrorGenerator is starting....");
            log.Info("Logging, what up!!!");

			setupClasses();
			warmUp();
			classList = setupErrors(errorType);
			generateErrors(runTime, errorType);
		}

		/// <summary>
		/// Execute errors for a given length of time </summary>
		/// <param name="runTime"> </param>
		private static void generateErrors(int runTime, string errorType)
		{
			long endTime = DateTimeHelper.CurrentUnixTimeMillis() + (runTime * 1000 * 60);
            log.InfoFormat("Executing error generator for Error Type {} starting at {} for {} minute(s)", errorType, DateTime.Now, runTime);

			while (DateTimeHelper.CurrentUnixTimeMillis() < endTime)
			{

				for (System.Collections.IEnumerator iterator = classList.GetEnumerator(); iterator.MoveNext();)
				{
					string className = (string) iterator.Current;
					try
					{
						log.DebugFormat("Find class for name: {}", className);
                        Type cls = Type.GetType(className);
						object classInstance = System.Activator.CreateInstance(cls);
						System.Reflection.MethodInfo method = cls.GetMethod("executeError");
						method.Invoke(classInstance, null);
					}
					catch (ArgumentNullException)
					{
						log.ErrorFormat("Class {} not found", className);
					}
					catch (TypeLoadException)
					{
						log.ErrorFormat("{} method not found", "executeError");
					}
					catch (TargetInvocationException ex)
					{
						log.Error(ex.Message);
					}
					catch (ArgumentException ex)
					{
						log.Error(ex.Message);
					}
				}
			}

			//give the JVM some time to finish up before shutting down
			warmUp();
			log.InfoFormat("Exectution complete - end time {}", DateTime.Now);
		}

		/// <summary>
		/// setup the classes used for error generation </summary>
		/// <param name="errorType">
		/// @return </param>
		private static IList<string> setupErrors(string errorType)
		{
			IList<string> classList = null;

			if (errorType.Equals("all", StringComparison.OrdinalIgnoreCase))
			{
				classList = new List<string>(classMap.Values);
			}
			else
			{
				classList = new List<string>();
				classList.Add(classMap[errorType]);
			}

			return classList;
		}

		/// <summary>
		/// need 10 seconds for OverOps to warm up before starting to generate errors
		/// </summary>
		private static void warmUp()
		{
			log.Debug("Wait 10 seconds for OverOps to connect to collector and get ready to insert tiny link");
			try
			{
				//Sleep for 10 seconds to allow OverOps to warm up
				Thread.Sleep(10000);
			}
			catch (Exception e)
			{
				log.Error(e.Message);
			}
		}

		/// <summary>
		/// list of classes used for error testing
		/// </summary>
		private static void setupClasses()
		{
			log.Debug("Setting up classes for Error Engine");
			classMap["NP"] = "com.overops.errors.NullPointer";
			classMap["DP"] = "com.overops.errors.DateParsingError";
			classMap["IOOB"] = "com.overops.errors.IndexOutOfBounds";
			classMap["CCE"] = "com.overops.errors.InvalidCastException";
			classMap["IA"] = "com.overops.errors.InvalidArgument";
			classMap["NFE"] = "com.overops.errors.NumberFormatException";
			classMap["TT"] = "com.overops.errors.TimerTest";
			classMap["UK"] = "com.overops.errors.IllegalError";
		}
	}

}