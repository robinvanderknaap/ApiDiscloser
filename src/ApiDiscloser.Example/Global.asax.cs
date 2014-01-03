using System;
using System.Web.Http;
using ApiDiscloser.Example.App_Start;

namespace ApiDiscloser.Example
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            ApiDiscloserConfig.Configure();
        }
    }
}