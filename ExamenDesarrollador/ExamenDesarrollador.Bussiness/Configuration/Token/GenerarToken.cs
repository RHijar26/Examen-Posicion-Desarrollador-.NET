using DuvezApi.Aplicacion.Configuración.Token;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Text;

namespace DuvezApi.Aplicacion.Configuration.Token
{
    public class GenerarToken
    {
        private readonly IConfiguration _configuration;

        public GenerarToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //public async Task<TokenModel> CreateToken(Usuarios usuario)
        //{
        //    if (usuario == null)
        //    {
        //        return null;
        //    }
        //    TokenModel generatedToken;
        //    //var tokenHandler = new JwtSecurityTokenHandler();
        //    try
        //    {
        //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtToken:Key"]));
        //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //        List<Claim> listaClaims = new List<Claim>();
        //        listaClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
        //        listaClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //        listaClaims.Add(new Claim("Id", usuario.Id.ToString()));
        //        listaClaims.Add(new Claim(ClaimTypes.Name, usuario.Usuario));
        //        listaClaims.Add(new Claim(ClaimTypes.Email, usuario.Email));
        //        //listaClaims.Add(new Claim(JwtRegisteredClaimNames.Sub, usuario.Id.ToString()));
        //        //listaClaims.Add(new Claim(ClaimTypes.Name, usuario.NombreUsuario));
        //        //listaClaims.Add(new Claim(ClaimTypes.Email, usuario.Correo));
        //        //listaClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //        //listaClaims.Add(new Claim(ClaimTypes.Role, usuario.RolId.ToString()));

        //        //if (permisosUsuario != null && permisosUsuario.Count() > 0)
        //        //{
        //        //    foreach (ObtenerUsuariosPermisosDTO permiso in permisosUsuario)
        //        //    {
        //        //        var auxPermiso = permiso.Descripcion;
        //        //        if (permiso.TipoPermisoId == 1)
        //        //        {
        //        //            auxPermiso += "Modulo";
        //        //        }
        //        //        else if (permiso.TipoPermisoId == 2)
        //        //        {
        //        //            auxPermiso += "Pagina";
        //        //        }
        //        //        //listaClaims.Add(new Claim("Permisos", permiso.Id.ToString()));
        //        //        listaClaims.Add(new Claim("Permisos", auxPermiso));
        //        //    }
        //        //}

        //        //if (permisosRol != null && permisosRol.Count() > 0)
        //        //{
        //        //    foreach (Permisos permiso in permisosRol)
        //        //    {
        //        //        var auxPermiso = permiso.Descripcion;
        //        //        if (permiso.TipoPermisoId == 1)
        //        //        {
        //        //            auxPermiso += "Modulo";
        //        //        }
        //        //        else if (permiso.TipoPermisoId == 2)
        //        //        {
        //        //            auxPermiso += "Pagina";
        //        //        }
        //        //        if (!listaClaims.Select(c => c.Value).Contains(auxPermiso))
        //        //        {
        //        //            listaClaims.Add(new Claim("Permisos", auxPermiso));
        //        //        }
        //        //    }
        //        //}
        //        var expiry = DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["TokenExpiry"]));
        //        var issuer = _configuration["JwtToken:Issuer"];
        //        var audience = _configuration["JwtToken:Audience"];
        //        var signingCredentials = credentials;


        //        var token = new JwtSecurityToken(
        //            audience,
        //            issuer,
        //            listaClaims,
        //            expires: DateTime.Now.AddMinutes(Convert.ToInt32(_configuration["TokenExpiry"])),
        //            signingCredentials: credentials
        //        );

        //        generatedToken = new TokenModel()
        //        {
        //            Token = new JwtSecurityTokenHandler().WriteToken(token)
        //        };
        //        //authenticationResult.IsSuccess = true;
        //        //return generatedToken;
        //        if (generatedToken != null)
        //        {
        //            var aux = Convert.ToInt32(_configuration["TokenExpiry"]);
        //            generatedToken.ExpiryMinutes = Convert.ToInt32(_configuration["TokenExpiry"]);
        //            return generatedToken;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var auxException = ex.Message;
        //        return null;
        //    }
        //}
    }
}
