using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreFiltersExamples.Infrastructure
{
    public class TimeFilter : IAsyncActionFilter, IAsyncResultFilter
    {
        private Stopwatch timer;
        private IFilterDiagnostics diagnostics;

        public TimeFilter(IFilterDiagnostics diags)
        {
            diagnostics = diags;
        }

        //来到Action时的过滤
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            timer = Stopwatch.StartNew();
            await next();
            diagnostics.AddMessage($@"Action time: {timer.Elapsed.TotalMilliseconds}");
        }

        //Action产生结果时的过滤
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            await next();
            timer.Stop();
            diagnostics.AddMessage($@"Result time: {timer.Elapsed.TotalMilliseconds}");
        }
    }
}
