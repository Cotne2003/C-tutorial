using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace RegisterLoginJWT.Filter
{
    public class ExecutionTimeFilter : IActionFilter
    {

        private Stopwatch _stopwatch;

        public ExecutionTimeFilter()
        {
            _stopwatch = new Stopwatch();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ExecutionTimeLog.txt");

            File.WriteAllTextAsync(filePath, $"Action {context.ActionDescriptor.DisplayName} executed in {_stopwatch.ElapsedMilliseconds}");
        }
    }
}
