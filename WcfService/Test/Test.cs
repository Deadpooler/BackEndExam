using System.Net;
using NUnit.Framework;
using System.Threading.Tasks;
using System;
using System.Web.Configuration;
using WcfService.Exceptions;

namespace WcfService.Test
{
    public class Test
    {
        [TestFixture]
        public class When_calling_a_restful_service
        {
            private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            [Test]
            public void Should_get_proper_HTTP_codes_and_headers()
            {
                var options = new ParallelOptions { MaxDegreeOfParallelism = 100 };

                Parallel.For(0, 100, options, item =>
                 {
                     try
                     {
                         Random rnd = new Random();
                         var url = "http://localhost:49619/Controllers/Service.svc/GetValues/" + rnd.Next(0, Int32.Parse(WebConfigurationManager.AppSettings["max"]));
                         var request = (HttpWebRequest)WebRequest.Create(url);
                         var response = (HttpWebResponse)request.GetResponse();

                         Assert.AreEqual(200, (int)response.StatusCode);
                     }
                     catch (CustomException ex)
                     {
                         log.Error(ex.Message);
                     }
                 });

            }

        }
    }
}