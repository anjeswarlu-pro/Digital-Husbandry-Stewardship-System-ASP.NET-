using Python.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Main_Project
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Environment.SetEnvironmentVariable("PYTHONHOME", @"C:\Users\91984\AppData\Local\Programs\Python\Python311");
            Environment.SetEnvironmentVariable("PYTHONPATH", @"C:\Users\91984\AppData\Local\Programs\Python\Python311\Lib");
            Environment.SetEnvironmentVariable("PYTHONNET_PYDLL", @"C:\Users\91984\AppData\Local\Programs\Python\Python311\python311.dll");
            PythonEngine.Initialize();

        }

    }
}