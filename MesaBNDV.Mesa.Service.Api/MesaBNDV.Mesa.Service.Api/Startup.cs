using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MesaBNDV.Mesa.Service.Api.Startup))]

namespace MesaBNDV.Mesa.Service.Api
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
            ConfigureAuth(app);
           
        }
    }
}
