using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsAppApi;
using WhatsAppApi.Parser;
using WhatsAppApi.Register;

namespace PesquisasNet.Util
{
    public class WhatsApp
    {
        public bool Registrar(string phoneNumber)
        {
            var code = WhatsRegisterV2.RegisterCode(phoneNumber, "code", null);
            return true;
        }

        public void EnviarMensagem(string mensagem)
        {
            
        }

        public string RequestCode(string phoneNumber)
        {
            var cc = "55";
            var phone = new PhoneNumber(cc + phoneNumber);

            string token = System.Uri.EscapeDataString(WhatsRegisterV2.GetToken(phone.Number));

            var password = string.Empty;

            if (WhatsRegisterV2.RequestCode(phoneNumber, out password, "sms", "123456"))
	        {

	        }

            //var request = string.Format("https://v.whatsapp.net/v2/code?cc={0}&in={1}&to={0}{1}&method={2}&mcc={3}&mnc={4}&token={5}&id={6}&lg={7}&lc={8}", pn.CC, pn.Number, method, pn.MCC, pn.MNC, token, id, pn.ISO639, pn.ISO3166);

            var code = Guid.NewGuid().ToString();

            return code;
        }
    }
}
