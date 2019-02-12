using GameQuakeAPI.Infrastructure;
using GameQuakeAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace GameQuakeAPI.Controllers
{
    public class QuakeController : ApiController
    {
        [Route("api/game/quakelog")]
        [HttpGet]
        public IHttpActionResult quakelog()
        {
            try
            {
                var reader = new QuakeReader();
                var caminho = ConfigurationManager.AppSettings["QuakeLog"];
                var pathToFiles = HttpContext.Current.Server.MapPath(caminho);
                var readerLog = new StreamReader(pathToFiles, Encoding.UTF8);
                var games = reader.ProcessRows(readerLog);
                var jsonGames = JsonConvert.SerializeObject(games, Formatting.None);
                return Ok(jsonGames);
            }
            catch (Exception ex)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "An error has occurred." + ex.Message));
            }
        }
    }
}
