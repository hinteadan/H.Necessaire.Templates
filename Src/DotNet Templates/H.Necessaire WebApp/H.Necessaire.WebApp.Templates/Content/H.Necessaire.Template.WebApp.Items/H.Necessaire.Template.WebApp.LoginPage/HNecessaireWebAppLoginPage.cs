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
using H.Necessaire.UI;
using H.Necessaire.BridgeDotNet.Runtime.ReactApp.Components.Elements;


namespace HNecessaireWebAppRootNamespace.HNecessaireWebAppRelativeNamespace
{
    internal class HNecessaireWebAppLoginPage : AppPageBase<HNecessaireWebAppLoginPage.Props, HNecessaireWebAppLoginPage.State>
    {
        #region Construct
        SecurityManager securityManager;
        public HNecessaireWebAppLoginPage(Props props, params Union<ReactElement, string>[] children) : base(props, children) { }

        protected override void EnsureDependencies()
        {
            base.EnsureDependencies();
            securityManager = Get<SecurityManager>();
        }

        public override async Task RunAtStartup()
        {
            await base.RunAtStartup();

            if (SecurityContext?.User == null)
            {
                using (BusyFlag())
                {
                    state.ReturnTo = props?.NavigationParams?.GetValue<string>();
                }
            }

            if (SecurityContext?.User != null && !string.IsNullOrWhiteSpace(state.ReturnTo))
            {
                FlySafe(() => Navi.Go(state.ReturnTo));
                return;
            }
        }
        #endregion

        public override ReactElement Render()
        {
            if (IsBusy)
                return null;

            return
                new AppStandardPageChrome(
                    new CenteredContent(
                        new FormLayout(
                            new FormLayout.Props
                            {
                                LayoutMode = FormLayoutMode.OnePerRowSmall,
                            }
                            ,
                            new Elevation(
                                new Elevation.Props
                                {
                                    Depth = ElevationDepthLevel.High,
                                    StyleDecorator = _ => _.FlexNode(isVerticalFlow: true).And(x =>
                                    {
                                        x.Padding = Branding.SizingUnitInPixels;
                                        x.BackgroundColor = Branding.Colors.Primary.Lighter(5).Clone().And(c => c.Opacity = .13f).ToCssRGBA();
                                    }),
                                }
                                ,
                                (
                                    SecurityContext?.User != null
                                    ? RenderLoggedInForm()
                                    : RenderLoginForm()
                                )
                            )
                        )
                    )
                );
        }

        private ReactElement RenderLoginForm()
        {
            return
                DOM.Form(
                    new FormAttributes
                    {
                        Style = new ReactStyle
                        {
                            Margin = 0,
                            Padding = 0,
                        }
                        .FlexNode(isVerticalFlow: true),
                        OnSubmit = async ev =>
                        {
                            ev.PreventDefault();
                            ev.StopPropagation();
                            await TriggerLoginAuthentication();
                        },
                    }
                    ,
                    new FormLayout(
                        new FormLayout.Props
                        {
                            LayoutMode = FormLayoutMode.OnePerRowFill,
                            RowSpacing = Branding.SizingUnitInPixels,
                        }
                        ,
                        new Title(
                            new Title.Props
                            {
                                StyleDecorator = _ => _.And(s =>
                                {
                                    s.Color = Branding.HighlightTextColor.ToCssRGBA();
                                })
                            }
                            ,
                            DOM.Div(
                                new Attributes
                                {
                                    Style = new ReactStyle
                                    {
                                        JustifyContent = JustifyContent.Center,
                                    }
                                    .FlexNode()
                                }
                                ,
                                "Login"
                            )
                        )
                        ,
                        DOM.Div(
                            new Attributes
                            {

                            }
                            ,
                            new TextInput(new TextInput.Props
                            {
                                Label = "Username",
                                Placeholder = "Username",
                                Width = "100%",
                                UserInputValidator = (v, ct) => ValidateUsername(v).AsTask(),
                                Decorator = _ => _.And(x =>
                                {
                                    Action<FormEvent<HTMLInputElement>> baseOnChange = x.OnChange;
                                    x.AutoFocus = true;
                                    x.MaxLength = 450;
                                    x.Type = InputType.Text;
                                    x.OnChange = ev =>
                                    {
                                        state.LoginCommand.Username = ev.CurrentTarget.Value;
                                        baseOnChange(ev);
                                    };
                                }),
                            })
                        )
                        ,
                        DOM.Div(
                            new Attributes
                            {

                            }
                            ,
                            new TextInput(new TextInput.Props
                            {
                                Label = "Password",
                                Placeholder = "Password",
                                Width = "100%",
                                UserInputValidator = (v, ct) => ValidatePassword(v).AsTask(),
                                Decorator = _ => _.And(x =>
                                {
                                    x.MaxLength = 450;
                                    x.Type = InputType.Password;
                                    Action<FormEvent<HTMLInputElement>> baseOnChange = x.OnChange;
                                    x.OnChange = ev =>
                                    {
                                        state.LoginCommand.Password = ev.CurrentTarget.Value;
                                        baseOnChange(ev);
                                    };
                                }),
                            })
                        )
                        ,
                        DOM.Div(
                            new Attributes
                            {
                                Style = new ReactStyle
                                {
                                    Display = Display.Flex,
                                    JustifyContent = JustifyContent.Center,
                                    PaddingTop = Branding.SizingUnitInPixels,
                                    PaddingBottom = Branding.SizingUnitInPixels,
                                    FlexDirection = FlexDirection.Column,
                                }
                            }
                            ,
                            new Button(
                                new Button.Props
                                {
                                    Role = ButtonRole.Default,
                                    Decorator = _ => _.And(x =>
                                    {
                                        x.Type = ButtonType.Submit;
                                    }),
                                    IsDisabled = state.IsAuthenticating,
                                }
            ,
            (
                                    state.IsAuthenticating
                                    ? DOM.Em("Authenticating...")
                                    : DOM.Span("Authenticate")
                                )
                            )
                        )
                        ,
                        RenderReturnToIfNecessary()
                        ,
                        RenderValidationIfNecessary()
                    )
                );
        }

        private ReactElement RenderLoggedInForm()
        {
            return
                DOM.Div(
                    new Attributes
                    {
                        Style = new ReactStyle
                        {
                            Margin = 0,
                            Padding = 0,
                        }
                        .FlexNode(isVerticalFlow: true),
                    }
                    ,
                    new FormLayout(
                        new FormLayout.Props
                        {
                            LayoutMode = FormLayoutMode.OnePerRowFill,
                            RowSpacing = Branding.SizingUnitInPixels,
                        }
                        ,
                        new Title(
                            new Title.Props
                            {
                                StyleDecorator = _ => _.And(s =>
                                {
                                    s.Color = Branding.HighlightTextColor.ToCssRGBA();
                                })
                            }
                            ,
                            DOM.Div(
                                new Attributes
                                {
                                    Style = new ReactStyle
                                    {
                                        JustifyContent = JustifyContent.Center,
                                    }
                                    .FlexNode()
                                }
                                ,
                                DOM.Div(
                                    new Attributes
                                    {
                                        Style = new ReactStyle
                                        {
                                            Display = Display.InlineFlex,
                                            FlexDirection = FlexDirection.Column,
                                            JustifyContent = JustifyContent.Center,
                                            FontSize = Branding.Typography.FontSizeLarge.EmsCss,
                                        }
                                    }
                                    ,
                                    DOM.Strong(
                                        SecurityContext.User.DisplayName
                                        ?? SecurityContext.User.Username
                                        ?? SecurityContext.User.ID.ToString()
                                    )
                                )
                            )
                        )
                        ,
                        DOM.Div(
                            new Attributes
                            {
                                Style = new ReactStyle
                                {
                                    Display = Display.Flex,
                                    JustifyContent = JustifyContent.Center,
                                    PaddingTop = Branding.SizingUnitInPixels,
                                    PaddingBottom = Branding.SizingUnitInPixels,
                                }
                            }
                            ,
                            new Button(
                                new Button.Props
                                {
                                    Role = ButtonRole.Negative,
                                    Decorator = _ => _.And(x =>
                                    {
                                        x.Type = ButtonType.Button;
                                    }),
                                    IsDisabled = state.IsAuthenticating,
                                    OnClick = async () => await TriggerLogout(),
                                }
                                ,
            (
                                    state.IsAuthenticating
                                    ? DOM.Em("Logging out...")
                                    : DOM.Span("Log Out")
                                )
                            )
                        )
                    )
                );
        }

        private ReactElement RenderReturnToIfNecessary()
        {
            if (string.IsNullOrWhiteSpace(state.ReturnTo))
                return null;

            return
                DOM.Div(
                    new Attributes
                    {
                        Style = new ReactStyle
                        {
                            FontSize = Branding.Typography.FontSizeSmall.EmsCss,
                            TextAlign = TextAlign.Center,
                        }
                    }
                    ,
            $"_Will navigate to **{state.ReturnTo}** after login_".PrintMarkdownInline()
                );
        }

        private ReactElement RenderValidationIfNecessary()
        {
            if (state.ValidationResult?.IsSuccessful != false)
                return null;

            return
                DOM.Div(
                    new Attributes
                    {
                        Style = new ReactStyle
                        {

                        }
                        .FlexNode(isVerticalFlow: true)
                    }
                    ,
                    new ValidationResultDisplay(new ValidationResultDisplay.Props
                    {
                        TextAlign = TextAlign.Center,
                        Width = "100%",
                        ValidationResult = state.ValidationResult,
                    })
                );
        }

        private async Task TriggerLoginAuthentication()
        {
            if (state.IsAuthenticating)
                return;

            using (new ScopedRunner(
                onStart: async () => await DoAndSetStateAsync(x => x.IsAuthenticating = true),
                onStop: async () => await DoAndSetStateAsync(x => x.IsAuthenticating = false)
            ))
            {
                state.ValidationResult = ValidateLoginCommand(state.LoginCommand);
                if (state.ValidationResult?.IsSuccessful == false)
                    return;

                state.ValidationResult
                    = await securityManager.AuthenticateCredentials(state.LoginCommand.Username, state.LoginCommand.Password);
                if (state.ValidationResult?.IsSuccessful == false)
                    return;

                FlySafe(() =>
                {
                    if (string.IsNullOrWhiteSpace(state.ReturnTo))
                        Navi.GoHome();
                    else
                        Navi.Go(state.ReturnTo);
                });
            }
        }

        private async Task TriggerLogout()
        {
            if (state.IsAuthenticating)
                return;

            if (await Confirm("Are you sure you want to log out?") != true)
                return;

            using (new ScopedRunner(
                onStart: async () => await DoAndSetStateAsync(x => x.IsAuthenticating = true),
                onStop: async () => await DoAndSetStateAsync(x => x.IsAuthenticating = false)
            ))
            {
                await securityManager.Logout();

                FlySafe(() => Navi.GoHome());
            }
        }

        private static OperationResult ValidateUsername(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return OperationResult.Fail("Username is empty");

            return OperationResult.Win();
        }

        private static OperationResult ValidatePassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return OperationResult.Fail("Password is empty");

            return OperationResult.Win();
        }

        private static OperationResult ValidateLoginCommand(LoginCommand loginCommand)
        {
            return
                new OperationResult[]
                {
                        ValidateUsername(loginCommand?.Username),
                        ValidatePassword(loginCommand?.Password),
                }
                .Merge(globalReasonIfNecesarry: "Login details invalid or incomplete. Details below.")
                ;
        }


        public class State : PageStateBase
        {
            public LoginCommand LoginCommand { get; set; } = new LoginCommand();
            public bool IsAuthenticating { get; set; } = false;
            public OperationResult ValidationResult { get; set; } = null;
            public string ReturnTo { get; set; } = null;
        }

        public class Props : PagePropsBase
        {
        }
    }
}