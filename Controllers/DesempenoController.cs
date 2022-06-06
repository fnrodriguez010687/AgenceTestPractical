using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgenceTestPractical.Models;
namespace AgenceTestPractical.Controllers
{
    [Route("api/[controller]")]
    public class DesempenoController : Controller
    {
        // GET api/sync
        [HttpGet]
        public IActionResult ObtenerConsultores()
        {
            using (var db = new AppDb())
            {
                db.Connection.Open();
                var query = new UsuarioQuery(db);
                var result = query.CosultoresActivos();
                return new OkObjectResult(result);
            }
        }

        // GET api/sync/5
         [HttpGet("search")]
        public IActionResult ObtenerReceitasXConsultores()
        {
            string datein = HttpContext.Request.Query["datein"];
            string dateend = HttpContext.Request.Query["dateend"];
            string consultores="";
            foreach(var value in  HttpContext.Request.Query["consultores"])
            {
                if(consultores.Equals(""))
                 consultores="\""+value+"\"";
                else 
                 consultores+=", \""+value+"\"";
            }
            using (var db = new AppDb())
            {
                db.Connection.Open();
                var query = new ReceitaQuery(db);
                var result = query.ReceitasXCosultores(Convert.ToDateTime(datein),Convert.ToDateTime(dateend),consultores);
                if (result == null)
                    return new NotFoundResult();
                return new OkObjectResult(result);
            }
        } 
       

       
        
       
    }
}