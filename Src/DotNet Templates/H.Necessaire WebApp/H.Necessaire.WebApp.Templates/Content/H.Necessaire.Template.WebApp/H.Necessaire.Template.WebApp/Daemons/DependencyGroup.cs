using H.Necessaire;

namespace H.Necessaire.Template.WebApp.Daemons
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry

                .Register<SyncDaemon>(() => new SyncDaemon())

                .Register<ImADaemon[]>(() =>
                    new ImADaemon[] {
                        dependencyRegistry.Get<SyncDaemon>(),
                    }
                );
        }
    }
}
