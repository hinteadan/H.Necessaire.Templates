using H.Necessaire;

namespace H.Necessaire.Template.WebApp.Runtime
{
    public class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry

                .Register<Resources.DependencyGroup>(() => new Resources.DependencyGroup())
                .Register<Engines.DependencyGroup>(() => new Engines.DependencyGroup())
                .Register<Managers.DependencyGroup>(() => new Managers.DependencyGroup())

                .Register<UseCases.DependencyGroup>(() => new UseCases.DependencyGroup())

                ;
        }
    }
}
