using Bridge.Html5;
using Bridge.jQuery2;
using H.Necessaire.Template.WebApp.BLL.Managers;
using H.Necessaire;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using System.Threading.Tasks;

namespace H.Necessaire.Template.WebApp
{
    internal class App : AppBase
    {
        public static void Main()
        {
            Initialize(
                appWireup: new AppWireup(),
                navigationRegistryFactory: x => new AppNavigationRegistry(x),
                appInitializer: Run,
                branding: AppBrandingStyle.DefaultBrandingStyle,
                extraLibs: new string[] {
                    //"/apexcharts.js"
                }
            );
            MainAsync();
        }

        static async Task Run()
        {
            using (new TimeMeasurement(x => AppLogger.LogInfo($"DONE including custom CSS for H.Necessaire.Template.WebApp in {x}")))
            {
                await IncludeCustomCss();
            }

            using (new TimeMeasurement(x => AppLogger.LogInfo($"DONE restoring security context for H.Necessaire.Template.WebApp in {x}")))
            {
                await RestoreSecurityContextFromSessionIfAny();
            }

            await AppLogger.LogTrace("DONE H.Necessaire.Template.WebApp Initialize");
        }

        private static Task IncludeCustomCss()
        {
            Document.Head.AppendChild(new HTMLStyleElement
            {
                InnerHTML = @"",
            });

            return true.AsTask();
        }

        private static async Task RestoreSecurityContextFromSessionIfAny()
        {
            jQuery appContainer = jQuery.Select("#AppContainer");

            using (new ScopedRunner(
                onStart: () => appContainer.Hide(),
                onStop: () => appContainer.Show()
                ))
            {
                //await Get<AuthenticationManager>().RestoreSecurityContextIfPossible();
                Navi.GoHome();
            }
        }
    }
}
