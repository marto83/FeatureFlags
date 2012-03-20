using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureFlags.Features
{
    public class DebugFeature : QueryStringFeature
    {
        public override string Description
        {
            get { return "Used for all debug features on the website"; }
        }

        public override bool IsFeatureEnabled()
        {
            return QueryString.AllKeys.Contains("debug") && QueryString["debug"] == "true";
        }
    }
}
