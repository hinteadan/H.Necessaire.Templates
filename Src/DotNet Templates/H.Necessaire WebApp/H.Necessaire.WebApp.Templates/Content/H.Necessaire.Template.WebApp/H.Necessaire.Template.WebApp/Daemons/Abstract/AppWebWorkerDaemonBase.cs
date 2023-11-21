using Bridge.Html5;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using System;

namespace H.Necessaire.Template.WebApp.Daemons.Abstract
{
    internal abstract class AppWebWorkerDaemonBase : WebWorkerDaemonBase
    {
        protected AppWebWorkerDaemonBase(
            Func<ImAWebWorkerDaemonAction> workerFactory
            )
            : base(
                  workerFactory,
                  () => new AppWireup(),
                  Window.Location.Origin + "/H.Necessaire.Template.WebApp.js",
                  Window.Location.Origin + "/H.Necessaire.Template.WebApp.meta.js"
            )
        {
        }
    }
}
