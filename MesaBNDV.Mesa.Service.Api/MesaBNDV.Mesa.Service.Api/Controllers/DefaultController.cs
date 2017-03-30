using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace MesaBNDV.Mesa.Service.Api.Controllers
{
    /// <summary>
    /// Para ter acesso a estas requisições é necessario um token de autenticação via usuario e senha
    /// </summary>
    [RoutePrefix("api/v1")]
    public class DefaultController : ApiController
    {
        // Retorna Nosso Authentication Manager
        private IAuthenticationManager Authentication
        {
            get { return HttpContext.Current.GetOwinContext().Authentication; }
        }

        /// <summary>
        /// Necessario autenticação para acessar o conteudo
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [Route("autorizado")]
        public string Get()
        {
            return this.Authentication.User.Identity.Name;
        }
    }
}