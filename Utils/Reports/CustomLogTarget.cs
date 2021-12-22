using System;
using NLog;
using NLog.Targets;

namespace IFlow.Testing.Utils.Reports
{
    [Target("CustomLog")]
    public class CustomLogTarget : TargetWithLayout
    {
        private static string Store { get; set; }

        public CustomLogTarget()
        {
        }

        protected override void Write(LogEventInfo logEvent)
        {
            var logMessage = this.Layout.Render(logEvent);
            Store += $"{logMessage}{Environment.NewLine}";
        }

        public static string GetDetails()
        {
            return $"<details><div class='pre'>{Store}</div></details>";
        }

        public static void Clear() => Store = String.Empty;
    }
}
