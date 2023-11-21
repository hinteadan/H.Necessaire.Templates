using Bridge;
using Bridge.Html5;
using Bridge.React;
using HNecessaireWebAppRootNamespace.BLL.Managers;
using HNecessaireWebAppRootNamespace.Components.Chrome;
using HNecessaireWebAppRootNamespace.Pages.Abstract;
using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


namespace HNecessaireWebAppRootNamespace.HNecessaireWebAppRelativeNamespace
{
    internal class HNecessaireWebAppPage : AppPageBase<HNecessaireWebAppPage.Props, HNecessaireWebAppPage.State>
    {
        #region Construct
        //MyManager myManager;
        public HNecessaireWebAppPage(Props props, params Union<ReactElement, string>[] children) : base(props, children) { }

        protected override void EnsureDependencies()
        {
            base.EnsureDependencies();
            //myManager = Get<MyManager>();
        }

        public override async Task RunAtStartup()
        {
            await base.RunAtStartup();
            //using (new ScopedRunner(
            //    onStart: () => DoAndSetState(x => x.IsRefreshing = true),
            //    onStop: () => DoAndSetState(x => x.IsRefreshing = false)
            //    ))
            //{
            //    await DoAndSetStateAsync(async state =>
            //    {
            //        state.Company = await companyManager.LoadCurrentCompanyInfo();
            //    });
            //}
        }
        #endregion

        public override ReactElement Render()
        {
            return
                new AppStandardPageChrome(
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
                    )
                );
        }



        public class State : PageStateBase
        {
        }

        public class Props : PagePropsBase
        { 
        }
    }
}