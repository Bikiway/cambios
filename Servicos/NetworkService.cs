using cambios.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace cambios.Servicos
{
    public class NetworkService
    {
        //Disponibilizar a ligação à internet

        public async Task <Response> CheckConnection()
        {
            var client = new HttpClient(); //Testar se tem ligação à net

            try
            {
                using (client.GetAsync("http://client3.google.com/generate_204"))
                {
                    return new Response
                    {
                        IsSuccess = true,
                        //Message = "Correu Tudo Bem",
                    };
                }
            }
            catch
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = "Configure a sua ligação à internet",
                };
            }
        }
    }
}
