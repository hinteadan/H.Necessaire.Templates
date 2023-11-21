using H.Necessaire;
using System;
using System.Threading.Tasks;

namespace HNecessaireRootNamespace.HNecessaireRelativeNamespace
{
    internal class HNecessaireDependency : ImADependency
    {
        #region Construct
        ImALogger logger;
        //ImAnotherDependency anotherDependency;
        //ImATaggedDependency taggedDependency;
        public void ReferDependencies(ImADependencyProvider dependencyProvider)
        {
            logger = dependencyProvider.GetLogger<HNecessaireDependency>();
            //anotherDependency = dependencyProvider.Get<ImAnotherDependency>();
            //taggedDependency = dependencyProvider.Build<ImATaggedDependency>("TagID");
        }
        #endregion
    }
}