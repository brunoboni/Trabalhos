using MesaBNDV.Mesa.Service.Api.Providers;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MesaBNDV.Mesa.Service.Api
{
	public partial class Startup
	{
        /// <summary>
        /// Metodo responsavel porvalidar usuario e senha e retornar um token de acesso
        /// </summary>
        /// <param name="app"></param>
        public void ConfigureAuth(IAppBuilder app)
        { 
         // Para utilizar o Header "Authorization" nas requisições
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
 
            // Ativar o método para gerar o OAuth Token
            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions()
        {
            TokenEndpointPath = new PathString("/api/v1/Token"),
                Provider = new ApplicationOAuthProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(14),
                AllowInsecureHttp = true
            });
        }
}
}