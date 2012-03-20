using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace FeatureFlags.Features
{
    public abstract class ConfigurationFeature : Feature
    {
        protected abstract string Key { get; }
        protected abstract string ExpectedValue { get; }

        public override bool IsFeatureEnabled()
        {
            return ConfigurationManager.AppSettings[Key] == ExpectedValue;
        }
    }
}
