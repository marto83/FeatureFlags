using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace FeatureFlags.Features
{
    public class FeatureSetting
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class FeatureConfig
    {
        public static Dictionary<string, bool> flagSettings = new Dictionary<string, bool>();

        public static IEnumerable<FeatureSetting> GetFeatures()
        {
            var features = typeof(FeatureConfig).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(Feature)));
            foreach (var featureType in features)
            {
                var feature = Activator.CreateInstance(featureType) as Feature;
                yield return new FeatureSetting { Name = featureType.Name, Description = feature.Description, IsActive = IsActive(featureType.Name) };
            }
        }

        public static void Initialise()
        {
            foreach (string key in ConfigurationManager.AppSettings.AllKeys)
            {
                if (key.StartsWith("Feature."))
                {
                    var flagName = key.Substring(key.IndexOf('.') + 1) ;
                    flagSettings[flagName.ToLower()] = ConfigurationManager.AppSettings[key] == "on";
                }
            }
        }

        public static bool IsActive(string flagName)
        {
            return flagSettings.ContainsKey(flagName.ToLower()) ? flagSettings[flagName.ToLower()] : false;
        }


    }
}
