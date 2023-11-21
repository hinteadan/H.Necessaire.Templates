using H.Necessaire;
using H.Necessaire.Models.Branding;

namespace H.Necessaire.Template.WebApp
{
    internal class AppBrandingStyle : BrandingStyle
    {
        public static AppBrandingStyle DefaultBrandingStyle { get; } = new AppBrandingStyle();

        public override int SizingUnitInPixels => 10;

        public override Typography Typography => WellKnownAppTypography.AdobeAssistantFromGoogleFonts;

        public override ColorPalette Colors => WellKnownAppColorPalette.LightAzure;

        public override ColorInfo HighlightTextColor => Colors.Primary.Darker();
    }
}
