using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CedarLogic.Identity.Configuration
{
    public class FederationMetadataSection : ConfigurationSection
    {
        [ConfigurationProperty("claimTypes")]
        public NamespaceTypeCollection ClaimTypes
        {
            get
            {
                return ((NamespaceTypeCollection)(base["claimTypes"]));
            }
        }

        [ConfigurationProperty("protocolSupport")]
        public NamespaceTypeCollection ProtocolSupport
        {
            get
            {
                return ((NamespaceTypeCollection)(base["protocolSupport"]));
            }
        }

    }

}
