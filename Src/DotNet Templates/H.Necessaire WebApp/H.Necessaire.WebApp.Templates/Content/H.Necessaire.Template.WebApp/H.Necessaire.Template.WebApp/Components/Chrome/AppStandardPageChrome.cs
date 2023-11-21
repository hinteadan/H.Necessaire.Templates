using Bridge;
using Bridge.Html5;
using Bridge.React;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp;
using H.Necessaire.Template.WebApp.Components.Abstract;

namespace H.Necessaire.Template.WebApp.Components.Chrome
{
    internal class AppStandardPageChrome : AppComponentBase<AppStandardPageChrome.Props, AppStandardPageChrome.State>
    {
        public AppStandardPageChrome(Props props, params Union<ReactElement, string>[] children) : base(props, children) { }
        public AppStandardPageChrome(params Union<ReactElement, string>[] children) : base(new Props(), children) { }

        public override ReactElement Render()
        {
            return
                DOM.Div(
                    new Attributes
                    {
                        Style = new ReactStyle
                        {
                            Width = "100%",
                            Height = "100%",
                            Display = Display.Flex,
                            FlexDirection = FlexDirection.Column,
                        },
                        ClassName = "animate morph-in",
                    },

                    new BrandingHeader(
                        new BrandingHeader.Props
                        {
                            OnClick = () => FlySafe(() => Navi.GoHome())
                        },
                        Config?.Get("App")?.Get("Title")?.ToString() ?? "H.Necessaire"
                    ),

                    new MainLayout(
                        new ScrollableContent(
                            Children
                        )
                    )
                );
        }

        public class State : ComponentStateBase { }

        public class Props : ComponentPropsBase { }
    }
}
