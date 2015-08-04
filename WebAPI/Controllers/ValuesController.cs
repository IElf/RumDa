using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using Elf;

namespace WebAPI.Controllers
{

    public class ValuesController : ApiController
    {

        // POST api/values
        public void Post([FromBody]string value)
        {

        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
        [HttpGet]
        public IEnumerable<DataBase> Get(string name, bool look)
        {
            return Iris.GetDataBases(look, name);
        }
        [HttpGet]
        public IEnumerable<DataBase> Get(bool look)
        {
            return Iris.GetDataBases(look, "");
        }
        [HttpGet]
        public IEnumerable<DataBase> Get()
        {
            return Iris.GetDataBases(false, "");
        }
    }
}