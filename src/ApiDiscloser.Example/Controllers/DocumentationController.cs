using System.Web.Http;
using ApiDiscloser.Specs;

namespace ApiDiscloser.Example.Controllers
{
    /// <summary>
    /// Get API documentation
    /// </summary>
    /// <remarks>Use this method to retrieve the documentation in the Api Disclose format. This output can be used to generate the user interface.</remarks>
    public class DocumentationController : ApiController
    {
        /// <summary>
        /// Retrieve documentation
        /// </summary>
        /// <returns></returns>
        public ApiDiscloserSpecification Get()
        {
            return ApiDiscloserFactory.GetApiSpecification(Configuration.Services.GetApiExplorer());
        }
    }
}