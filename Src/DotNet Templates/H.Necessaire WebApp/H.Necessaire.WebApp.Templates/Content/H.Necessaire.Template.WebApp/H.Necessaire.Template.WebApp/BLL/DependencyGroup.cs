using H.Necessaire;

namespace H.Necessaire.Template.WebApp.BLL
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry

                .Register<Resources.DependencyGroup>(() => new Resources.DependencyGroup())
                .Register<Engines.DependencyGroup>(() => new Engines.DependencyGroup())
                .Register<Managers.DependencyGroup>(() => new Managers.DependencyGroup())

                ;
        }
    }
}
