using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using WcfService.Exceptions;
using System.Threading.Tasks;

namespace WcfService.Views
{
    public class ValuesView
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static ValuesView GetInstance()
        {
            return new ValuesView();
        }
        public string GetValues(string id)
        {
            string res = "";
            try
            {
                log.Info("Start of function");
                if (id == null)
                    throw new CustomException("NULL FOUND");
                if (WebConfigurationManager.AppSettings["max"] == null)
                    throw new CustomException("NULL FOUND");
                int value = Int32.Parse(id);
                int maxValue = Int32.Parse(WebConfigurationManager.AppSettings["max"]);
                while (value != maxValue)
                {
                    log.Debug("Current Value: " + value);
                    if (value % 5 == 0 && value % 3 == 0)
                        res += "fizzbuzz, ";
                    else if (value % 3 == 0)
                        res += "fizz, ";
                    else if (value % 5 == 0)
                        res += "buzz, ";
                    else
                        res += value + ", ";
                    value++;
                };
                res = res.Remove(res.Length - 2);
                if (WebConfigurationManager.AppSettings["filepath"] == null)
                    throw new CustomException("NULL FOUND");
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string path = AppDomain.CurrentDomain.BaseDirectory + WebConfigurationManager.AppSettings["filepath"] + "_" + timestamp + ".txt";
                log.Debug("Pathfile: " + path);
                File.WriteAllText(path, res);
                File.SetLastWriteTime(path,DateTime.Today);
                log.Debug("Date of writing: " + DateTime.Today);
               
                log.Info("End of function");
            }
            catch (CustomException ex)
            {
                log.Error(ex.Message);
            }



            return res;
        }
    }
}