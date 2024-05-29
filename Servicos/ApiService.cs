using cambios.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambios.Servicos
{
    public class ApiService
    {
        public async Task<Response> GetRates(string urlBase, string controller) //Objeto do tipo Response.
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(urlBase);//Dizer onde o endereço base da API

                var response = await client.GetAsync(controller);// Dizer onde está o controlador API

                var result = await response.Content.ReadAsStringAsync();// Guardar e Carregar em string para o objeto result

                if (!response.IsSuccessStatusCode)//Se alguma coisa correu mal
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                var rates = JsonConvert.DeserializeObject<List<Rate>>(result);//Agarrar o json e mete numa lista e guarda o tipo Rate.

                return new Response
                {
                    IsSuccess = true,
                    Result = rates,
                };
            }
            catch(Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
            }

        }
    }
}
