using Bridge;
using Bridge.Html5;
using Bridge.React;
using HNecessaireWebAppRootNamespace.Components.Abstract;
using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using System.Threading.Tasks;

namespace HNecessaireWebAppRootNamespace.HNecessaireWebAppRelativeNamespace
{
    internal class HNecessaireWebAppComponent : AppComponentBase<HNecessaireWebAppComponent.Props, HNecessaireWebAppComponent.State>
    {
        #region Construct
        public HNecessaireWebAppComponent(Props props, params Union<ReactElement, string>[] children) : base(props, children) { }
        #endregion

        public override ReactElement Render()
        {
            return
                DOM.Div(
                    new Attributes
                    {
                        Style = new ReactStyle
                        {

                        }
                        .FlexNode(isVerticalFlow: true),
                    }
                    ,
                    "Content Goes here"
                );
        }



        public class State : ComponentStateBase
        { 
        }

        public class Props : ComponentPropsBase
        {
        }
    }
}