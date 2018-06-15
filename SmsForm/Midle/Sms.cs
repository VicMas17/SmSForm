using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmsForm.Midle
{
  public class Sms
    {
        public string from { get; set; }
        public string to { get; set; }
        public string  message { get; set; }

        public Sms(string f, string t, string msg)
        {
            from = f;
            to = t;
            message = msg;                
        }

        public string send(Sms obj)
        {
           return SendSms.send(obj);           

        }
    }
}
