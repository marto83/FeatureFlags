using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Mvc;

namespace FeatureFlags.Features
{
    public abstract class Feature
    {
        public abstract string Description { get; }

        public static bool Enabled<T>() where T:Feature
        {
            return FeatureConfig.IsActive(typeof(T).Name);
        }
    }

    public class MartinsNewFeature : Feature
    {
        public override string Description { get { return "Martin's new feature which will be enabled soon"; } }
    }

    public class CurrentTimeFeature : Feature
    {
        public override string Description
        {
            get { return "Display the current time"; }
        }
    }
}