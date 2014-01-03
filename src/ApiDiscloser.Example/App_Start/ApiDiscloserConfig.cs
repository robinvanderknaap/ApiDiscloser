using System.Web;

namespace ApiDiscloser.Example.App_Start
{
    public static class ApiDiscloserConfig
    {
        public static void Configure()
        {
            ApiDiscloserFactory.Configure(c =>
            {
                c.ApiVersion = "1.0";
                c.XmlDocumentationPath = HttpContext.Current.Server.MapPath("~/bin/ApiDiscloser.Example.XML");
            });
        }
    }
}
