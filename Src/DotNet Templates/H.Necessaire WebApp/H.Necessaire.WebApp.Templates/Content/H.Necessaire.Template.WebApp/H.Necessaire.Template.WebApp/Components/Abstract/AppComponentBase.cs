using Bridge;
using Bridge.React;
using H.Necessaire.Template.WebApp.Components.Contract;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;

namespace H.Necessaire.Template.WebApp.Components.Abstract
{
    internal abstract class AppComponentBase<TProps, TState>
        : ComponentBase<TProps, TState>
        , ImAnAppComponent
        where TState : ImAUiComponentState, new()
    {
        protected AppComponentBase(TProps props, params Union<ReactElement, string>[] children) : base(props, children) { }
    }
}
