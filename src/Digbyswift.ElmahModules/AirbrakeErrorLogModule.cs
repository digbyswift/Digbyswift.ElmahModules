using System;
using System.Diagnostics;
using System.Web;
using Elmah;
using SharpBrake;

namespace Digbyswift.ElmahModules
{

    public class AirbrakeErrorLogModule : ErrorLogModule
    {

        protected override void LogException(Exception e, HttpContext context)
        {
            if (e == null)
                throw new ArgumentNullException("e");

            var args = new ExceptionFilterEventArgs(e, context);
            OnFiltering(args);

            if (args.Dismissed)
                return;

            try
            {
                e.SendToAirbrake();
            }
            catch (Exception localException)
            {
                Trace.WriteLine(localException);
            }
        }

    }

}
