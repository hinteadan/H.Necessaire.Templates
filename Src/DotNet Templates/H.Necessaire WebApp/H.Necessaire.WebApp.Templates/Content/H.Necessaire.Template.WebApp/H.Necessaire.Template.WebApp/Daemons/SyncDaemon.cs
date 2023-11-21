using Bridge.Html5;

namespace H.Necessaire.Template.WebApp.Daemons
{
    internal class SyncDaemon : H.Necessaire.BridgeDotNet.Runtime.ReactApp.SyncDaemon
    {
        public SyncDaemon()
            : base(
                () => new AppWireup(),
                Window.Location.Origin + "/H.Necessaire.Template.WebApp.js",
                Window.Location.Origin + "/H.Necessaire.Template.WebApp.meta.js"
            )
        { }
    }
}
