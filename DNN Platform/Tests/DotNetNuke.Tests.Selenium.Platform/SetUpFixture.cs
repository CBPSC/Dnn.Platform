﻿using System;
using System.Diagnostics;
using System.IO;
using DNNSelenium.Common.BaseClasses;
using NUnit.Framework;

namespace DNNSelenium.Platform
{
	[SetUpFixture]
	class SetUpFixture
	{
		private const string LogFile = "DnnTest.log";
		private const string ExFile = "DnnSoftAssert.log";

		[SetUp]
		public void GlobalSetup()
		{
			File.Delete(LogFile);
			File.Delete(ExFile);

			Trace.Listeners.Add(new TextWriterTraceListener(LogFile));

			Trace.AutoFlush = true;

			Trace.WriteLine(BasePage.TraceLevelComposite + "Global Setup");
		}

		[TearDown]
		public void GlobalTearDown()
		{
			if (Utilities.ExceptionList.Count > 0)
			{
				Trace.Listeners.Add(new TextWriterTraceListener(ExFile));

				Trace.WriteLine("");
				Trace.Write("========> EXCEPTION SUMMARY:");
				Trace.WriteLine("");

				foreach (Exception e in Utilities.ExceptionList)
				{
					Trace.WriteLine("Assert Failed =>" + e.Message + e.StackTrace);
					Trace.WriteLine("");
				}
			}

			Trace.Flush();

			Trace.WriteLine(BasePage.TraceLevelComposite + "Global Teardown");
		}
	}
}
