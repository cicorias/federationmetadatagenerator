using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CedarLogic.Identity
{
    public abstract class MetadataDescriptor
    {

        public MetadataDescriptor()
        {
            MainContact = new Contact();
        }

        string _entityId;
        [Category("Entity Information")]
        [Description("Enter a valid Uri such as \"yourplace.abc.com:saml2.0:entityId\" - this is used uniquely describe this IdP")]
        public string EntityId
        {
            get
            {
                return _entityId;
            }
            set
            {
                if (Uri.IsWellFormedUriString(value, UriKind.RelativeOrAbsolute))
                    _entityId = value;
                else
                    throw new ApplicationException("invalid URI for EntityId");
            }
        }

        [Category("Entity Information")]
        [Description("Enter the contact information (technical) for this IdP")]
        public Contact MainContact { get; set; }



        [Browsable(false)]
        [XmlIgnore]
        public bool SettingsChanged { get; set; }



        public abstract void Validate();


    }
}
