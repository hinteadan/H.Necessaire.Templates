using H.Necessaire;

namespace HNecessaireRootNamespace.HNecessaireRelativeNamespace
{
    internal class HNecessaireDependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            //dependencyRegistry
            //    .Register<Other.DependencyGroup>(() => new Other.DependencyGroup())
            //    ;
        }
    }
}
