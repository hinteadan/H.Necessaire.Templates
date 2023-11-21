using H.Necessaire;

namespace H.Necessaire.Template.WebApp
{
    internal static class WellKnownAppTypography
    {
        public static readonly Typography AdobeAssistantFromGoogleFonts
            = new Typography(
                fontFamily: "'Assistant', 'Fira Sans', Helvetica, Calibri, Arial, Sans-Serif",
                fontSize: new TypographySize(fontSizeInPoints: 10),
                fontFamilyUrls: new string[] {
                    "https://fonts.googleapis.com/css2?family=Assistant:wght@200;300;400;500;600;700;800&display=swap",
                    "https://fonts.googleapis.com/css2?family=Fira+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;0,800;0,900;1,100;1,200;1,300;1,400;1,500;1,600;1,700;1,800;1,900&display=swap",
                }
            );
    }
}
