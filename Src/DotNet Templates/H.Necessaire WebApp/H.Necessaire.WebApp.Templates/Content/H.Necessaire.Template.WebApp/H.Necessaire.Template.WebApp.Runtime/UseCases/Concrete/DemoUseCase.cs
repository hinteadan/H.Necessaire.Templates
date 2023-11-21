using H.Necessaire;
using H.Necessaire.Runtime;
using System.Threading.Tasks;

namespace H.Necessaire.Template.WebApp.Runtime.UseCases.Concrete
{
    internal class DemoUseCase : UseCaseBase, ImADemoUseCase
    {
        #region Construct
        ImALogger logger;
        public override void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            base.ReferDependencies(dependencyProvider);
            logger = dependencyProvider.GetLogger<DemoUseCase>();
        }
        #endregion

        public async Task<string> RunDemo()
        {
            //(await EnsureAuthentication()).ThrowOnFailOrReturn();

            await logger.LogWarn("Demo stuff goes here");

            return "Demo";
        }
    }
}
