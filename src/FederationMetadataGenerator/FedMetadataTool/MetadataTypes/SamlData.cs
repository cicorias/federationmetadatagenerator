using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CedarLogic.Identity
{
    public class SamlData : MetadataDescriptor
    {
        public SamlData()
            : base()
        {
            this.BindingType = TypeDescriptor.GetProperties(this)["BindingType"].Attributes.OfType<DefaultValueAttribute>().First().Value.ToString();
            this.NameIdType = (Constants.NameIdType)Enum.Parse(typeof(Constants.NameIdType), TypeDescriptor.GetProperties(this)["NameIdType"].Attributes.OfType<DefaultValueAttribute>().First().Value.ToString(), true);
        }

        Constants.NameIdType _nameIdType;
        [Category("Attribute Information")]
        [DefaultValue(Constants.NameIdType.NA)]
        [Description("Choose if using NameID in the Saml - otherwise, leave as \"NA\"")]
        public Constants.NameIdType NameIdType
        {
            get { return _nameIdType; }
            set
            {
                _nameIdType = value;
            }
        }

        string _bindingType;
        [Category("Binding Information")]
        [DefaultValue("urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST")]
        [Description("Binding type is a valid Uri")]
        public string BindingType
        {
            get
            {
                return _bindingType;
            }
            set
            {
                if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                    _bindingType = value;
                else
                    throw new ApplicationException("invalid URI for BindingType");
            }
        }


        string _bindingLocation;
        [Category("Binding Information")]
        [Description("Binding Location is the valid Web Url of the Idp")]
        public string BindingLocation
        {
            get
            {
                return _bindingLocation;
            }
            set
            {
                try
                {
                    Uri t = new Uri(value);
                    _bindingLocation = value;
                }
                catch
                {
                    throw new ApplicationException("invalid URI for BindingLocation");
                }
            }
        }


        public override void Validate()
        {
            throw new NotImplementedException();
        }


    }
}
