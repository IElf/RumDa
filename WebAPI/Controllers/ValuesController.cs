using System.Collections.Generic;
using System.Web.Http;
using Elf;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

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
        public DBList<DataBase> Get(string name, bool look)
        {

            //var result=Iris.GetDataBases(look, name);
            //var json=JsonConvert.SerializeObject(result);
            //return json;
            var dbs = Iris.GetDataBases(look, name);
            return dbs;
        }
        //[HttpGet]
        //public IEnumerable<DataBase> Get(bool look)
        //{
        //    var dbs = Iris.GetDataBases(look, "");
        //    return dbs;
        //}
        //[HttpGet]
        //public IEnumerable<DataBase> Get()
        //{
        //    var dbs = Iris.GetDataBases(false, "");
        //    return dbs;
        //}
    }
}