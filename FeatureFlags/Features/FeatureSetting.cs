using System;
using System.Collections.Generic;
using System.Linq;

namespace FeatureFlags.Features
{
    public class FeatureSetting
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
