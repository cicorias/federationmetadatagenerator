using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CedarLogic.Identity.Configuration
{

    public class NamespaceTypeElement : ConfigurationElement
    {
        public NamespaceTypeElement() { }

        public NamespaceTypeElement(string name, Uri ns)
        {
            this.Name = name;
            this.Namespace = ns;
        }

        [ConfigurationProperty("name", DefaultValue = "_", IsKey = true, IsRequired = true)]
        [StringValidator(InvalidCharacters = "~!@#$%^&()[]{}/;'\"|\\", MinLength = 1, MaxLength = 260)]
        public string Name
        {
            get
            { return (string)this["name"]; }
            set
            { this["name"] = value; }
        }

        [ConfigurationProperty("namespace", IsKey = false, IsRequired = true)]
        public Uri Namespace
        {
            get
            { return (Uri)this["namespace"]; }
            set
            { this["namespace"] = value; }
        }

    }
}
