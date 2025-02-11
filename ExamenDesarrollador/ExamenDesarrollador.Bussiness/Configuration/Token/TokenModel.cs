using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DuvezApi.Aplicacion.Configuración.Token
{
    public class TokenModel
    {

        [JsonPropertyName("token")]
        public string Token { get; set; }
        public int ExpiryMinutes { get; set; }
    }
}
