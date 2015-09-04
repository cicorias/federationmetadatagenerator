using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CedarLogic.Identity
{

    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class Contact
    {
        [Description("Given name of the human contact at issuing organization")]
        public string GivenName { get; set; }
        [Description("Surname of the human contact at issuing organization")]
        public string SurName { get; set; }
        [Description("Email address of the human contact at issuing organization")]
        public string Email { get; set; }
        [Description("Phone of the human contact at the issuing organization")]
        public string Phone { get; set; }
        [Description("Company name of the issuing organization.")]
        public string Company { get; set; }

        public override string ToString()
        {
            return GivenName + " " + SurName;
        }
    }

}
