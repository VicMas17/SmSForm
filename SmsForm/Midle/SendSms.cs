using System;
using System.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using Twilio.Exceptions;


namespace SmsForm.Midle
{
   public static class SendSms
    {
        public static string send(Sms objectSms)
        {


            TwilioClient.Init(ConfigurationManager.AppSettings["AcountId"].ToString(), ConfigurationManager.AppSettings["authtoken"].ToString());
            try
            {
                var mess = MessageResource.Create(
                    to: new PhoneNumber(objectSms.to),
                    from: new PhoneNumber(ConfigurationManager.AppSettings["myphoneNumber"].ToString()),
                    body: objectSms.message + " De:" + objectSms.from.ToUpper());
                return $"Sms Enviado al #{objectSms.to}, Operadora Destino {FindCarrier.carrier(objectSms.to.Substring(4, 4))}";
            }
           catch(TwilioException ex)
            {
                
                return $" {ex.Message}  {FindCarrier.carrier(objectSms.to.Substring(4, 4))}"; 

            }
            
           
        }
    }
}
