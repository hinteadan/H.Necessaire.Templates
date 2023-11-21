using H.Necessaire;

namespace H.Necessaire.Template.WebApp.Runtime.UseCases
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            dependencyRegistry
                .RegisterAlwaysNew<ImADemoUseCase>(() => new Concrete.DemoUseCase())
                ;
        }
    }
}
