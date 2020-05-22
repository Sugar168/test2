using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiTestClient.Controllers
{
    /// <summary>
    /// 测试API Test Client
    /// </summary>
    public class TestController : ApiController
    {

        /// <summary>
        /// 得到所有数据
        /// </summary>
        /// <returns>返回数</returns>
        // GET: api/Test
        public IEnumerable<string> Get()
            {
                return new string[] { "value1", "value2" };
            }

            /// <summary>
            /// 根据当前ID得到所有数据
            /// </summary>
            /// <param name="id"></param>
            /// <returns></returns>
            // GET: api/Test/5
            public string Get(int id)
            {
                return "value" + id.ToString();
            //分支提交test2
            }

            /// <summary>
            /// POST
            /// </summary>
            /// <param name="value"></param>
            // POST: api/Test
            public bool Post([FromBody]string value)
            {
                return true;

               //再次测试 ，提交，推送

            //
            }

            /// <summary>
            /// PUT
            /// </summary>
            /// <param name="id"></param>
            /// <param name="value"></param>
            // PUT: api/Test/5
            public int Put(int id, [FromBody]string value)
            {
                return id;
            }

            /// <summary>
            /// DEL
            /// </summary>
            /// <param name="id"></param>
            // DELETE: api/Test/5
            public int Delete(int id)
            {
                return id;
            }
        
    }
}
