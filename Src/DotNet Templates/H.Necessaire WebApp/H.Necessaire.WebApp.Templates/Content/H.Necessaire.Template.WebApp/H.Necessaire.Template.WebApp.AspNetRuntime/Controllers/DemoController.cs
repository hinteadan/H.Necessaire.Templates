using H.Necessaire.Template.WebApp.Runtime.UseCases;
using H.Necessaire;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace H.Necessaire.Template.WebApp.AspNetRuntime.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DemoController : ControllerBase, ImADemoUseCase
    {
        #region Construct
        readonly ImADemoUseCase useCase;
        public DemoController
            (
            ImADemoUseCase useCase
            )
        {
            this.useCase = useCase;
        }
        #endregion

        [Route(nameof(RunDemo)), HttpGet]
        public async Task<string> RunDemo() => await useCase.RunDemo();
    }
}
