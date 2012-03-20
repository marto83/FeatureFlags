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
            string featureName = typeof(T).Name;
            var feature = Activator.CreateInstance<T>();
            return FeatureConfig.IsActive(featureName) && feature.IsFeatureEnabled();
        }
    }

    
}