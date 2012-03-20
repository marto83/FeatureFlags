using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace FeatureFlags.Features
{
    public abstract class QueryStringFeature : Feature
    {
        protected NameValueCollection QueryString
        {
            get { return HttpContext.Current.Request.QueryString; }
        }
    }
}
