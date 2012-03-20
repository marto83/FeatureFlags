using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;
using System.Configuration;

namespace FeatureFlags.Features
{
    public abstract class Feature
    {
        public abstract string Description { get; }

        public virtual bool IsFeatureEnabled()
        {
            return true;
        }

        public static bool Enabled<T>() where T : Feature
        {
            var feature = Activator.CreateInstance<T>();
            return FeatureConfig.IsActive(GetFeatureName(typeof(T))) && feature.IsFeatureEnabled();
        }
        private static string GetFeatureName(Type featureType)
        {
            return featureType.Name.Replace("Feature", "");
        }
    }

    
}