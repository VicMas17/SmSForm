using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SmsForm.Midle
{
    public static class FindCarrier
    {
         static XDocument document;

        internal static void load()
        {
       
             document = XDocument.Load(@"C:\MyProyects\WebApi2Book\src\SmsForm\SmsForm\Midle\Prefixes.xml");
        }
        public static bool Validar(string prefix)
        {

          
            var query =  (from element in document.Element("prefixes")?.Elements("segment") ?? Enumerable.Empty<XElement>()
                             where Convert.ToInt32(prefix) >= Convert.ToInt32(element.Attribute("from").Value)
                             && Convert.ToInt32(prefix) <= Convert.ToInt32(element.Attribute("to").Value)
                             select element).ToList();



            return query.Count > 0 ? true : false;
        }

        public static string carrier(string prefix)
        {
         

            string res = "";  
            var query = from element in document.Element("prefixes")?.Elements("segment") ?? Enumerable.Empty<XElement>()
                        where Convert.ToInt32(prefix) >= Convert.ToInt32(element.Attribute("from").Value) 
                        && Convert.ToInt32(prefix)<= Convert.ToInt32(element.Attribute("to").Value) 
                        select element;

            foreach (var res1 in query)
            {
                res = res1.Attribute("carrier").Value.ToString();

            }
            
            return res;
        }
        
    }
}
