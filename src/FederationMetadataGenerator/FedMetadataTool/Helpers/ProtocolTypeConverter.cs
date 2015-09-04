using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CedarLogic.Identity.Configuration;

namespace CedarLogic.Identity
{
    public class ProtocolTypeConverter : TypeConverter
    {
        public ProtocolTypeConverter() : base(){}


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
            List<Protocol> rv = new List<Protocol>();
            rv.Add(new Protocol(Microsoft.IdentityModel.Protocols.WSFederation.WSFederationConstants.Namespace));

            FederationMetadataSection config =
                (FederationMetadataSection)(System.Configuration.ConfigurationManager.GetSection("metadataToolDefaults"));

            foreach (NamespaceTypeElement item in config.ProtocolSupport)
            {
                rv.Add(new Protocol() { ProtocolNamespace = item.Namespace.AbsoluteUri });
            }

            return new System.ComponentModel.TypeConverter.StandardValuesCollection(rv.ToArray());
        }
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

    }
}
