using System;
using System.IO;
using System.Web.Http.Description;
using System.Xml.Linq;
using ApiDiscloser.Specs;
using Newtonsoft.Json;

namespace ApiDiscloser
{
    public class ApiDiscloserFactory
    {
        // http://geekswithblogs.net/BlackRabbitCoder/archive/2010/05/19/c-system.lazylttgt-and-the-singleton-design-pattern.aspx
        private static readonly Lazy<ApiDiscloserFactory> Instance = new Lazy<ApiDiscloserFactory>(() => new ApiDiscloserFactory());
        
        private ApiDiscloserSpecification _apiSpecification;
        private XDocument XmlDocumentation { get; set; }

        private ApiDiscloserFactory()
        {
        }

        public static void Configure(Action<ApiDiscloserFactory> configure)
        {
            if (Instance.IsValueCreated)
            {
                throw new InvalidOperationException("Api discloser is already configured. Make sure to not call the configure method twice");
            }

            configure(Instance.Value);

            try
            {
                Instance.Value.XmlDocumentation = XDocument.Load(Instance.Value.XmlDocumentationPath);
            }
            catch (Exception exception)
            {
                throw new FileLoadException("Unable to load XML documentation. Make sure to enable XML documentation in the build properties of your API project and specifiy the correct path to the XML file when configuring ApiDiscloser.", Instance.Value.XmlDocumentationPath , exception);
            }
        }

        public static ApiDiscloserSpecification GetApiSpecification(IApiExplorer apiExplorer)
        {
            if (!Instance.IsValueCreated)
            {
                throw new InvalidOperationException("Api discloser has not been configured. Make sure to configure Api Discloser once during application start.");
            }

            return Instance.Value._apiSpecification ?? (Instance.Value._apiSpecification = new ApiDiscloserSpecification(apiExplorer, Instance.Value.XmlDocumentation));
        }

        public string ApiVersion { get; set; }
        public string XmlDocumentationPath { get; set; }
    }
}
