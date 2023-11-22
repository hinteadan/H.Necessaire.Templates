using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;

namespace H.Necessaire.Template.WebApp.Daemons
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry

                .Register<SyncDaemon>(() => new SyncDaemon())

                .Register<SecurityContextUpdateDaemon>(() => new SecurityContextUpdateDaemon())
                .Register<SecurityContextUpdateDaemon.Worker>(() => new SecurityContextUpdateDaemon.Worker())

                .Register<ImADaemon[]>(() =>
                    new ImADaemon[] {
                        dependencyRegistry.Get<SecurityContextUpdateDaemon>(),
                        dependencyRegistry.Get<SyncDaemon>(),
                    }
                );
        }
    }
}
