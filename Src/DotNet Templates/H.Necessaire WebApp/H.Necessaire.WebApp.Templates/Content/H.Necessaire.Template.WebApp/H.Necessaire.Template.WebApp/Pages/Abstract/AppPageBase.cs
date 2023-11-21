using Bridge;
using Bridge.React;
using H.Necessaire.Template.WebApp.Pages.Contract;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;

namespace H.Necessaire.Template.WebApp.Pages.Abstract
{
    internal abstract class AppPageBase<TProps, TState>
        : PageBase<TProps, TState>
        , ImAPage
        where TState : ImAUiComponentState, new()
        where TProps : ImPageProps
    {
        protected AppPageBase(TProps props, params Union<ReactElement, string>[] children) : base(props, children) { }
    }
}
