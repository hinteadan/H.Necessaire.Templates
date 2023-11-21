using H.Necessaire.Runtime;
using H.Necessaire.Runtime.Integration.NetCore;

namespace H.Necessaire.Template.WebApp.AspNetRuntime
{
    public class AppWireup : NetCoreApiWireupBase
    {
        public override ImAnApiWireup WithEverything()
        {
            return
                base
                .WithEverything()
                .With(x => x.Register<H.Necessaire.Template.WebApp.Runtime.DependencyGroup>(() => new H.Necessaire.Template.WebApp.Runtime.DependencyGroup()))
                ;
        }
    }
}
