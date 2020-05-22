using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SwaggerTest.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
        }

       
          
        /// <summary>
        /// 多值传参
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
      
        public string Post( test model)
        {
            return model.Name;
        }
        //public string Post([FromBody]  test model)
        //{
        //    return model.Name;
        //}

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        /// <summary>
        /// 根据id 删除接口
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
        }
    }
    /// <summary>
    /// 新建一个类 包含所有参数
    /// </summary>
    public class test
    {
        private string name;
        private string phone;
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
    }
}
