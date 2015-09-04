using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CedarLogic.Identity
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class AttributeName
    {
        [Description("Enter the name of the assertion attribute")]
        public string Name { get; set; }
    }

}
