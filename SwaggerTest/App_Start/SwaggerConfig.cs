using System.Web.Http;
using WebActivatorEx;
using SwaggerTest;
using Swashbuckle.Application;
using System;
using System.Reflection;
using System.IO;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace SwaggerTest
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            //��ȡ��Ŀ�ļ�·��
            //var baseDirectory = System.Web.HttpContext.Current.Server.MapPath("~/bin");
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\";
            var commentsFileName = Assembly.GetExecutingAssembly().GetName().Name + ".XML";
            var commentsFile = Path.Combine(baseDirectory, commentsFileName); 
            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {                       
                        c.SingleApiVersion("v1", "SwaggerTest");
                        c.IncludeXmlComments(commentsFile);


                        c.IncludeXmlComments(Path.Combine(baseDirectory, "SwaggerTest.XML"));
                    })
                .EnableSwaggerUi(c =>
                    {
                        //��������UI�����ϵĶ�����
                        //���غ�����js�ļ���ע�� swagger.js�ļ����Ա�������Ϊ��Ƕ�����Դ���� APIUI.Scripts.swagger.js�����ǣ���Ŀ����->�ļ���->js�ļ��� 
                        c.InjectJavaScript(Assembly.GetExecutingAssembly(), "SwaggerTest.SwaggerUI.swagger.js");
                   
                    });
        }

      

    }
}
