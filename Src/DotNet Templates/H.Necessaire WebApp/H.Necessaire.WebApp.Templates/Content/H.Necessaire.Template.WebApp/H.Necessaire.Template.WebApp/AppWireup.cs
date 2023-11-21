using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;

namespace H.Necessaire.Template.WebApp
{
    internal class AppWireup : AppWireupBase
    {
        public override ImAnAppWireup WithEverything()
        {
            return
                base
                .WithEverything()
                .With(x => x.Register<RuntimeConfig>(() => AppConfig.Default))
                .With(x => x.Register<BLL.DependencyGroup>(() => new BLL.DependencyGroup()))
                .With(x => x.Register<Daemons.DependencyGroup>(() => new Daemons.DependencyGroup()))
                ;
        }
    }
}
