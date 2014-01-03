using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Description;
using System.Xml.Linq;

namespace ApiDiscloser.Specs
{
    public class ApiDiscloserSpecification
    {
        private readonly List<Api> _apis = new List<Api>();

        public ApiDiscloserSpecification(IApiExplorer apiExplorer, XDocument xmlDocumentation)
        {
            // Group by controller name. Each controller will be a different API
            var apiDescriptionGroups = apiExplorer.ApiDescriptions.GroupBy(x=>x.ActionDescriptor.ControllerDescriptor.ControllerName);

            foreach (var apiDescriptionGroup in apiDescriptionGroups)
            {
                Apis.Add(new Api(apiDescriptionGroup, xmlDocumentation));
            }
        }

        public List<Api> Apis
        {
            get { return _apis; }
        }
    }

    public class Api
    {
        private readonly IGrouping<string, ApiDescription> _apiDescriptionGroup;
        private readonly XDocument _xmlDocumentation;
        private readonly List<ApiMethod> _apiMethods = new List<ApiMethod>();

        public Api(IGrouping<string, ApiDescription> apiDescriptionGroup, XDocument xmlDocumentation)
        {
            _apiDescriptionGroup = apiDescriptionGroup;
            _xmlDocumentation = xmlDocumentation;

            Name = GetControllerInfo("summary") ?? apiDescriptionGroup.Key;
            Description = GetControllerInfo("remarks");

            foreach (var apiDescripion in apiDescriptionGroup)
            {
                _apiMethods.Add(new ApiMethod(apiDescripion, xmlDocumentation));
            }
        }

        public string Name { get; set; }
        public string Description { get; set; }

        public List<ApiMethod> ApiMethods
        {
            get { return _apiMethods; }
        }

        public string GetControllerInfo(string elementName)
        {
            var controller = _apiDescriptionGroup.First().ActionDescriptor.ControllerDescriptor.ControllerType.FullName;
            var controllerElement = _xmlDocumentation.Descendants("member").FirstOrDefault(x => x.Attribute("name").Value == string.Format("T:{0}", controller));

            if (controllerElement == null) return null;

            var element = controllerElement.Descendants(elementName).FirstOrDefault();

            return element != null ? element.Value.Trim() : null;
        }
    }

    public class ApiMethod
    {
        public ApiMethod(ApiDescription apiDescription, XDocument xmlDocumentation)
        {
            Name = apiDescription.ActionDescriptor.ActionName;
            Description = apiDescription.Documentation;
            Url = apiDescription.RelativePath;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}
