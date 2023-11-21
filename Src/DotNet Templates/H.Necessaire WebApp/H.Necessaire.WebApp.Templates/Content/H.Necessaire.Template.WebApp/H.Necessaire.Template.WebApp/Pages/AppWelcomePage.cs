using Bridge;
using Bridge.Html5;
using Bridge.React;
using H.Necessaire.Template.WebApp.BLL.Managers;
using H.Necessaire.Template.WebApp.Components.Chrome;
using H.Necessaire.Template.WebApp.Pages.Abstract;
using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;


namespace H.Necessaire.Template.WebApp.Pages
{
    internal class AppWelcomePage : AppPageBase<AppWelcomePage.Props, AppWelcomePage.State>
    {
        #region Construct
        //MyManager myManager;
        public AppWelcomePage(Props props, params Union<ReactElement, string>[] children) : base(props, children) { }

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
                        "Hello, H.Necessaire WebApp!"
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