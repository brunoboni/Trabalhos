using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MesaBNDV.Mesa.Service.Api.Providers
{
    public class ApplicationOAuthProvider : OAuthAuthorizationServerProvider
    {
        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext c)
        {
            c.Validated();

            return Task.FromResult<object>(null);
        }

        public override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext c)
        {

            // Aqui você deve implementar sua regra de autenticação
            if (validarUsuario(c).Item4)
            {
                Claim claim1 = new Claim(ClaimTypes.Name, c.UserName);
                Claim[] claims = new Claim[] { claim1 };
                ClaimsIdentity claimsIdentity =
                    new ClaimsIdentity(
                       claims, OAuthDefaults.AuthenticationType);
                c.Validated(claimsIdentity);
            }

            return Task.FromResult<object>(null);
        }

        private Tuple<string,string,int,bool> validarUsuario(OAuthGrantResourceOwnerCredentialsContext c)
        {
            //Conectar com o Repositorio
            if (c.UserName == "Bruno" && c.Password == "123456")
                return Tuple.Create("Bruno", "Boni", 28, true);

            return Tuple.Create("Bruno", "Boni", 00, false);
        }
    }
}