﻿using System;
using System.Web;
using Microsoft.Practices.Unity;

namespace Queryable.Web.Infrastructure
{
    public class PerHttpRequestLifetimeManager : LifetimeManager
    {
        private readonly Guid _key = Guid.NewGuid();

        public override object GetValue()
        {
            return HttpContext.Current.Items[_key];
        }

        public override void SetValue(object newValue)
        {
            HttpContext.Current.Items[_key] = newValue;
        }

        public override void RemoveValue()
        {
            var obj = GetValue();
            HttpContext.Current.Items.Remove(obj);
        }
    }
}