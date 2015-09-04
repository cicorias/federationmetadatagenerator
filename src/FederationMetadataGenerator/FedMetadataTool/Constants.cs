using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.IdentityModel.Tokens.Saml2;

namespace CedarLogic.Identity
{
    public class Constants
    {
        public const string Saml20AttributeNameFormat = "urn:oasis:names:tc:SAML:2.0:attrname-format:basic";
        public const string Saml20Protocol = "urn:oasis:names:tc:SAML:2.0:protocol";

        public const string Saml20ProtocolHttpPost = "urn:oasis:names:tc:SAML:2.0:bindings:HTTP-POST";
        public enum NameIdType : int { NA=0, Saml11=1, Saml20=2 }

        //public const string WsTrustNamespace = "http://docs.oasis-open.org/ws-sx/ws-trust/200512";
        //public const string WsTrustSoapNs = "http://schemas.xmlsoap.org/ws/2005/02/trust";

    }
}
