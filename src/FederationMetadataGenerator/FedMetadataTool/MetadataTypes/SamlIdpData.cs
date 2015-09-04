using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Xml.Serialization;

namespace CedarLogic.Identity 
{
    public class SamlIdpData : SamlData
    {
        //public SamlIdpData() {}

        public SamlIdpData() : base()
        {
        }

        [Category("Certificate Information")]
        [DefaultValue("testing")]
        [Description("Enter the CN of the certifcate - eg. \"CN=mycert.abc.com\"")]
        [TypeConverter(typeof(LocalCertificatesConverter))]
        public string SigninCertificateCn { get; set; }


        [Category("Attribute Information")]
        [Description("Attribte names that are provided by this IdP")]
        public AttributeName[] AttributeNames { get; set; }

    }






}
