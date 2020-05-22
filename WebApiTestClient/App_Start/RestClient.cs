﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace WebApiTestClient.App_Start
{
    public class RestClient
    {
        private string BaseUrl;

        public RestClient(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }

        #region Get 请求

        public string Get(string url)
        {
            //先根据用户请求url构造请求地址

            string serviceUrl = string.Format("{0}/{1}",this.BaseUrl,url);
            //创建web访问对象

            HttpWebRequest myRequest =(HttpWebRequest) WebRequest.Create(serviceUrl);

            // 通过web 访问对象获取响应内容

            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流 创建streamReader 对象，因为 streamReader 更高级更快

            StreamReader reader = new StreamReader(myResponse.GetResponseStream(),Encoding.UTF8);

            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            //利用streamReader 从响应头内容读到尾
            string returnXml = reader.ReadToEnd();

            reader.Close();
            myResponse.Close();
            return returnXml;
        }
        #endregion

        #region Post请求

        public string Post(string data, string url)
        {
            //想根据用户请求的 url构造请求地址

            string serviceUrl = string.Format("{0}/{1}", this.BaseUrl, url);
            //创建Web访问对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            //把用户传过来的数据，转换成“UTF-8”字节流
            //byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data );
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);

            myRequest.Method = "put";
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;

            //发送请求
            Stream stream = myRequest.GetRequestStream();
            stream.Write(buf, 0, buf.Length);
            stream.Close();

            //获取接口返回值
            //通过Web访问对象获取响应内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
            reader.Close();
            myResponse.Close();
            return returnXml;
        }

        #endregion

        #region Delete请求
        public string Delete(string data, string uri)
        {
            //先根据用户请求的uri构造请求地址
            string serviceUrl = string.Format("{0}/{1}", this.BaseUrl, uri);
            //创建Web访问对象
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
            //把用户传过来的数据转成“UTF-8”的字节流
            byte[] buf = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(data);

            myRequest.Method = "DELETE";
            myRequest.ContentLength = buf.Length;
            myRequest.ContentType = "application/json";
            myRequest.MaximumAutomaticRedirections = 1;
            myRequest.AllowAutoRedirect = true;
            //发送请求
            Stream stream = myRequest.GetRequestStream();
            stream.Write(buf, 0, buf.Length);
            stream.Close();

            //获取接口返回值
            //通过Web访问对象获取响应内容
            HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
            //通过响应内容流创建StreamReader对象，因为StreamReader更高级更快
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            //string returnXml = HttpUtility.UrlDecode(reader.ReadToEnd());//如果有编码问题就用这个方法
            string returnXml = reader.ReadToEnd();//利用StreamReader就可以从响应内容从头读到尾
            reader.Close();
            myResponse.Close();
            return returnXml;

        }
        #endregion
    }

}