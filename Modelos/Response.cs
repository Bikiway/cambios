using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cambios.Modelos
{
    public class Response
    {
        public bool IsSuccess { get; set; } //Se tenho internet ou não, se consigo carregar a API, Gravou bem na BD ou não.

        public string Message { get; set; } //Não gravou bem

        public object Result { get; set; } //Se sim, grava o objeto. Objeto Main e todos herdam este objeto.
    }
}
