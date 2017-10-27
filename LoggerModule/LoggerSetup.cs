using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using UnityLog4NetExtension;
using log4net.Repository.Hierarchy;
using log4net.Core;
using log4net.Layout;
using log4net.Appender;

namespace LoggerModule
{
    public static class LoggerSetup
    {
        private static bool VerboseLogging;

        static LoggerSetup() {
                       
        }

        public static void Setup() {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            var level = hierarchy.LevelMap["Debug"] ?? Level.Off; 

            var patternLayout = new PatternLayout { ConversionPattern = "%date [%thread] %-6level %logger [%M] - %message%exception%newline" };
            patternLayout.ActivateOptions();

            var roller = new RollingFileAppender { 
                File="EmbeddedDesignerStudio.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Composite,
                DatePattern = ".yyyyMMdd",
                MaxSizeRollBackups = 10,
                StaticLogFileName = true,
                LockingModel = new FileAppender.MinimalLock(),
                Layout = patternLayout
            };

            roller.ActivateOptions();

            hierarchy.Root.AddAppender(roller);
            hierarchy.Root.Level = Level.Debug;
            hierarchy.Configured = true;
        }
    }
}
