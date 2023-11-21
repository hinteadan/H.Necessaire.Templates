using System.Threading.Tasks;
using System;
using H.Necessaire;
using H.Necessaire.CLI;
using H.Necessaire.Runtime.CLI;

namespace H.Necessaire.Template.WebApp.CLI
{
    internal class Program
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            await
                new CliApp()
                .WithEverything()
                .With(x => x.Register<RuntimeConfig>(() => new RuntimeConfig
                {
                    Values = new[] {
                        "App".ConfigWith(
                            "Title".ConfigWith("H.Necessaire.Template.WebApp.CLI")
                            , "Copyright".ConfigWith($"Copyright &copy; {DateTime.Today.Year}. H.Necessaire.Template.WebApp.CLI. All rights reserved.")
                        ),
                    }
                }))
                .With(x => x.Register<Runtime.DependencyGroup>(() => new Runtime.DependencyGroup()))
                .With(x => x.Register<DependencyGroup>(() => new DependencyGroup()))
                .Run(askForCommandIfEmpty: true)
                ;
        }
    }
}