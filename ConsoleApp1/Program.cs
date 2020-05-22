using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebApiTestClient.App_Start;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            RestClient client = new RestClient("http://localhost:51571/");

            string result = client.Get("api/Values");

            Console.WriteLine(result);
            Console.ReadKey();


        }

        ////client接收处理（都是异步的处理）
        //static async void Run(HttpClient client)
        //{
        //    //post 请求插入数据
        //    var result = await AddPerson(client);
        //    Console.WriteLine($"添加结果：{result}"); //添加结果：true

        //    //get 获取数据
        //    var person = await GetPerson(client);
        //    //查询结果：Id=1 Name=test Age=10 Sex=F
        //    Console.WriteLine($"查询结果：{person}");

        //    //put 更新数据
        //    result = await PutPerson(client);
        //    //更新结果：true
        //    Console.WriteLine($"更新结果：{result}");

        //    //delete 删除数据
        //    result = await DeletePerson(client);
        //    //删除结果：true
        //    Console.WriteLine($"删除结果：{result}");
        //}

        ////post
        //static async Task<bool> AddPerson(HttpClient client)
        //{
        //    //向Person发送POST请求，Body使用Json进行序列化

        //    return await client.PostAsync("api/Person", new Person() { Age = 10, Id = 1, Name = "test", Sex = "F" })
        //                        //返回请求是否执行成功，即HTTP Code是否为2XX
        //                        .ContinueWith(x => x.Result.IsSuccessStatusCode);
        //}

        ////get
        //static async Task<Person> GetPerson(HttpClient client)
        //{
        //    //向Person发送GET请求
        //    return await await client.GetAsync("api/Person/1")
        //                             //获取返回Body，并根据返回的Content-Type自动匹配格式化器反序列化Body内容为对象
        //                             .ContinueWith(x => x.Result.Content.ReadAsAsync<Person>(
        //            new List<MediaTypeFormatter>() {new JsonMediaTypeFormatter()/*这是Json的格式化器*/
        //                                            ,new XmlMediaTypeFormatter()/*这是XML的格式化器*/}));
        //}

        ////put
        //static async Task<bool> PutPerson(HttpClient client)
        //{
        //    //向Person发送PUT请求，Body使用Json进行序列化
        //    return await client.PutAsJsonAsync("api/Person/1", new Person() { Age = 10, Id = 1, Name = "test1Change", Sex = "F" })
        //                        .ContinueWith(x => x.Result.IsSuccessStatusCode);  //返回请求是否执行成功，即HTTP Code是否为2XX
        //}
        ////delete
        //static async Task<bool> DeletePerson(HttpClient client)
        //{
        //    return await client.DeleteAsync("api/Person/1") //向Person发送DELETE请求
        //                       .ContinueWith(x => x.Result.IsSuccessStatusCode); //返回请求是否执行成功，即HTTP Code是否为2XX
        //}

    }

}


   
