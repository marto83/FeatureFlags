using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FeatureFlags.Features
{
    public static class FeatureExtensions
    {
        public static bool IsEnabled<T>(this HtmlHelper helper) where T : Feature
        {
            return Feature.Enabled<T>();
        }
    }
}
