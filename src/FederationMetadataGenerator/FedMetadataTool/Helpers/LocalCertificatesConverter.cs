using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using CedarLogic.Identity.Configuration;

namespace CedarLogic.Identity
{
    //http://msdn.microsoft.com/en-us/library/aa302326.aspx
    public class LocalCertificatesConverter : TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            string[] rv = CertificateHelper.GetCertificateNames();
            return new System.ComponentModel.TypeConverter.StandardValuesCollection(rv);
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }
    }

}
