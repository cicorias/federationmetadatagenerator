using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace CedarLogic.Identity.Configuration
{
    [ConfigurationCollection(typeof(NamespaceTypeElement))]
    public class NamespaceTypeCollection : ConfigurationElementCollection
    {

        protected override ConfigurationElement CreateNewElement()
        {
            return new NamespaceTypeElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((NamespaceTypeElement)(element)).Name;
        }

        public void Add(NamespaceTypeElement element)
        {
            this.BaseAdd(element);
        }

        public void Remove(string key)
        {
            this.BaseRemove(key);
        }

        public void Clear()
        {
            this.BaseClear();
        }

        public NamespaceTypeElement this[int idx]
        {
            get { return (NamespaceTypeElement)this[idx]; }
        }
    }

}
