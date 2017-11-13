using System.Web.Http;
using System.Web.Mvc;

namespace FirstREST.Controllers
{
    public class AuditFileController : ApiController
    {
        [System.Web.Mvc.HttpPost]
        public JsonResult Index(string msg)
        {
            // Read XML file and add all the appropriate rows to the DB
            var result = new JsonResult();
            result.Data = "Hello Word";
            return result;
        }
    }
}
