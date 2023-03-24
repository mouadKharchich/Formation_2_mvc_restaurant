using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace Restaurant_MVC.Controllers
{
    public class ResponseHeaderAttribut : ActionFilterAttribute
    {

        private readonly string _name;
        private readonly string _value;
        private readonly Stopwatch _stopwatch;

        //public ResponseHeaderAttribut(string name, string value) => (_name, _value) = (name, value);

        public ResponseHeaderAttribut(string name,string value)
        {
            this._name = name;
            this._value = value;
            _stopwatch=new Stopwatch();
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _stopwatch.Start();

            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            _stopwatch.Stop();

            base.OnActionExecuted(context);
        }

        public override void OnResultExecuting(ResultExecutingContext context)
        {
            //_timeRes = (_time1 - _time2).TotalMilliseconds;

            var responseTime = _stopwatch.ElapsedMilliseconds;

            TimeSpan timeTaken = _stopwatch.Elapsed;
            string foo = "Time taken: " + timeTaken.ToString(@"m\:ss\.fff");

            context.HttpContext.Response.Headers.Add(_name, _value);
            context.HttpContext.Response.Headers.Add("ResponseTime", responseTime.ToString());
            context.HttpContext.Response.Headers.Add("Timers", foo);
            base.OnResultExecuting(context);
        }

    }
}
