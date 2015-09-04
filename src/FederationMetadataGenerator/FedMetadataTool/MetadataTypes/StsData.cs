using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Configuration;

namespace CedarLogic.Identity
{
    public class StsData : MetadataDescriptor
    {
        public StsData()
            : base()
        {
            this.Protocols = new Protocol[] 
            { 
                new Protocol(Microsoft.IdentityModel.Protocols.WSFederation.WSFederationConstants.Namespace)
            };
        }

        [CustomCategory("catCertificateInformation")]
        [Description("Enter the CN of the certifcate - eg. \"CN=mycert.abc.com\"")]
        [TypeConverter(typeof(LocalCertificatesConverter))]
        public string SigninCertificateCn { get; set; }

        [Description("Claim items")]
        public ClaimItem[] Claims { get; set; }

        [CustomDescription("txtPassiveEndpointDescription")]
        public string PassiveRequestorEndpoint { get; set; }
        public string ActiveStsEndpoint { get; set; }

        public Protocol[] Protocols { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ClaimItem
    {
        [TypeConverter(typeof(ClaimTypesConverter))]
        public string ClaimType { get; set; }
        public string DisplayTag { get; set; }
        public bool Optional { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return ClaimType;
        }
    }

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Protocol
    {
        [TypeConverter(typeof(ProtocolTypeConverter))]
        public string ProtocolNamespace { get; set; }
        public Protocol()
        {
        }
        public Protocol(string ns)
        {
            ProtocolNamespace = ns;
        }
        public override string ToString()
        {
            return ProtocolNamespace;
        }
    }


}
