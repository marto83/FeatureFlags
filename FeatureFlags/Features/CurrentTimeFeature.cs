using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureFlags.Features
{
    public class CurrentTimeFeature : Feature
    {
        public override string Description
        {
            get { return "Display the current time"; }
        }
    }
}
