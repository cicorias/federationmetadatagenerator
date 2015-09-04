using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CedarLogic.Identity.Configuration;
using System.Reflection;

namespace CedarLogic.Identity
{
    public class ClaimTypesConverter : TypeConverter
    {
        static List<ClaimItem> s_standardClaims = null;

        static ClaimTypesConverter()
        {
            s_standardClaims = new List<ClaimItem>();

            foreach (var item in ReflectionHelper.GetClaimTypes(typeof(Microsoft.IdentityModel.Claims.ClaimTypes)))
            {
                ClaimItem ci = new ClaimItem();
                ci.DisplayTag = item.Key;
                ci.ClaimType = item.Value;
                s_standardClaims.Add(ci);
            }

            foreach (var item2 in ReflectionHelper.GetClaimTypes(typeof(Microsoft.IdentityModel.Claims.ClaimTypes.Prip)))
            {
                ClaimItem ci = new ClaimItem();
                ci.DisplayTag = item2.Key;
                ci.ClaimType = item2.Value;
                s_standardClaims.Add(ci);
            }


        }

        public ClaimTypesConverter()
            : base()
        {

        }
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string)) return true;
            return base.CanConvertFrom(context, sourceType);
        }

        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType == typeof(string)) return true;
            return base.CanConvertTo(context, destinationType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (value is string)
                return (string)value;

            return base.ConvertFrom(context, culture, value);
        }

        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            List<ClaimItem> rv = new List<ClaimItem>();
            FederationMetadataSection config =
                (FederationMetadataSection)(System.Configuration.ConfigurationManager.GetSection("metadataToolDefaults"));

            foreach (NamespaceTypeElement item in config.ClaimTypes)
            {
                rv.Add(new ClaimItem() { ClaimType = item.Namespace.AbsoluteUri });
            }

            rv.AddRange(s_standardClaims);

            return new System.ComponentModel.TypeConverter.StandardValuesCollection(rv.ToArray());
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }


    }

}
