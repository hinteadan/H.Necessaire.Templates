using Bridge.React;
using H.Necessaire.Template.WebApp.Pages;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using ProductiveRage.Immutable;
using ProductiveRage.ReactRouting;
using ProductiveRage.ReactRouting.Helpers;

namespace H.Necessaire.Template.WebApp
{
    internal class AppNavigationRegistry : AppNavigationRegistryBase
    {
        #region Construct
        public AppNavigationRegistry(IDispatcher dispatcher) : base(dispatcher) { }

        protected override bool IsDefaultLoginRouteEnabled => false;
        #endregion

        protected override NavigateActionMatcher RegisterPageRoutes()
        {
            NavigateActionMatcher result = base.RegisterPageRoutes();

            #region Welcome
            result = result.AddFor<AppPageDispatcherAction<AppWelcomePage>>(x => new AppWelcomePage(new AppWelcomePage.Props { NavigationParams = x.NavigationParams }));
            AddRelativeRoute(
                segments: new NonNullList<string>(AppBase.BaseHostPathParts).Add("welcome"),
                routeAction: new AppPageDispatcherAction<AppWelcomePage>(),
                urlGenerator: () => GetPath("welcome")
            );
            #endregion

            //#region Security
            //result = result.AddFor<AppPageDispatcherAction<Pages.LoginPage>>(x => new Pages.LoginPage(new Pages.LoginPage.Props { NavigationParams = x.NavigationParams }));
            //AddRelativeRoute(
            //    segments: new NonNullList<string>(AppBase.BaseHostPathParts).Add("login"),
            //    routeActionGenerator: queryString => new AppPageDispatcherAction<Pages.LoginPage>(
            //        !queryString.String("returnTo").IsDefined
            //        ? UiNavigationParams.None
            //        : new UiNavigationParams(
            //                Bridge.Html5.Window.DecodeURIComponent(
            //                    queryString.String("returnTo").ToString()
            //                )
            //            )
            //        ),
            //    urlGenerator: () => GetPath("login")
            //);
            //#endregion

            //#region Dashboard
            //result = result.AddFor<AppPageDispatcherAction<DashboardPage>>(x => new DashboardPage(new DashboardPage.Props { NavigationParams = x.NavigationParams }));
            //AddRelativeRoute(
            //    segments: new NonNullList<string>(AppBase.BaseHostPathParts).Add("dash"),
            //    routeAction: new AppPageDispatcherAction<DashboardPage>(),
            //    urlGenerator: () => GetPath("dash")
            //);
            //#endregion

            //#region Company Info
            //result = result.AddFor<AppPageDispatcherAction<CompanyPage>>(x => new CompanyPage(new CompanyPage.Props { NavigationParams = x.NavigationParams }));
            //AddRelativeRoute(
            //    segments: new NonNullList<string>(AppBase.BaseHostPathParts).Add("company"),
            //    routeAction: new AppPageDispatcherAction<CompanyPage>(),
            //    urlGenerator: () => GetPath("company")
            //);
            //#endregion

            return result;
        }
    }
}
