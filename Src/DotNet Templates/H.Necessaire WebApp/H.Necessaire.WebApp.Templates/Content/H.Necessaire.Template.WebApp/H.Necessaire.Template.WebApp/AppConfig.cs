using H.Necessaire;

namespace H.Necessaire.Template.WebApp
{
    internal class AppConfig
    {
        public static readonly RuntimeConfig Default = new RuntimeConfig
        {
            Values = new[] {
                "App".ConfigWith(
                    "Title".ConfigWith("H.Necessaire.Template.WebApp")
                    , "Copyright".ConfigWith("Copyright &copy; {year}. H.Necessaire.Template.WebApp. All rights reserved. {version}")
                )

                //, "BaseUrl".ConfigWith("https://localhost")
                //, "BaseApiUrl".ConfigWith("https://localhost")

                , "Formatting".ConfigWith(
                      "DateAndTime".ConfigWith("ddd, MMM dd, yyyy 'at' HH:mm 'UTC'")
                    , "Date".ConfigWith("ddd, MMM dd, yyyy")
                    , "Time".ConfigWith("HH:mm")
                    , "Month".ConfigWith("yyyy MMM")
                    , "DayOfWeek".ConfigWith("dddd")
                    , "TimeStampThisYear".ConfigWith("MMM dd 'at' HH:mm")
                    , "TimeStampOtherYear".ConfigWith("MMM dd, yyyy 'at' HH:mm")
                    , "TimeStampIdentifier".ConfigWith("yyyyMMdd_HHmmss")
                )

                , "PageTitlePrefix".ConfigWith("H.Necessaire.Template.WebApp")
                , "HomePagePath".ConfigWith("/welcome")
                , "IsHomePageSecured".ConfigWith(false.ToString())
                , "Security".ConfigWith(
                      "LoginUrl".ConfigWith("/Security/Login")
                    , "RefreshUrl".ConfigWith("/Security/Refresh")
                )
                , "BffApiSyncRegistryRelativeUrl".ConfigWith("/sync/sync")
                , "SyncIntervalInSeconds".ConfigWith(10.ToString())
                , "AnimationDurationInMilliseconds".ConfigWith(200.ToString())
                , "SecurityContextCheckIntervalInSeconds".ConfigWith(30.ToString())
            },
        };
    }
}
