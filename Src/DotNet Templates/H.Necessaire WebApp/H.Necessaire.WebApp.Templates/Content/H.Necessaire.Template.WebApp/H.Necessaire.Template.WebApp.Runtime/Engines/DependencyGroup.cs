﻿using H.Necessaire;

namespace H.Necessaire.Template.WebApp.Runtime.Engines
{
    internal class DependencyGroup : ImADependencyGroup
    {
        public void RegisterDependencies(ImADependencyRegistry dependencyRegistry)
        {
            //dependencyRegistry
            //    .Register<ImAnEngine>(() => new Concrete.Engine())
            //    ;
        }
    }
}
