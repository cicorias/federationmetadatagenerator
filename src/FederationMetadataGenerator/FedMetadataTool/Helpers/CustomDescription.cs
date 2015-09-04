using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Resources;
using System.Globalization;
using System.Configuration;

namespace CedarLogic.Identity
{
    /// <summary>
    /// Localized description attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All, AllowMultiple = false, Inherited = true)]
    public class CustomDescriptionAttribute : DescriptionAttribute
    {
        /// <summary>
        /// Construct the description attribute
        /// </summary>
        /// <param name="text"></param>
        public CustomDescriptionAttribute(string text)
            : base(text)
        {
            _localized = false;
        }

        /// <summary>
        /// Override the return of the description text to localize the text
        /// </summary>
        public override string Description
        {
            get
            {
                if (!_localized)
                {
                    _localized = true;
                    this.DescriptionValue=  CustomResources.ResourceManager.GetString(this.DescriptionValue);
                }

                return base.Description;
            }
        }

        /// <summary>
        /// Store a flag indicating whether this has been localized
        /// </summary>
        private bool _localized;
    }


    /// <summary>
    /// Localized version of the Category attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.All,AllowMultiple=false,Inherited=true)]
    public class CustomCategoryAttribute : CategoryAttribute
    {
        /// <summary>
        /// Construct the attribute
        /// </summary>
        /// <param name="name"></param>
        public CustomCategoryAttribute ( string name ) : base ( name ) { }

        /// <summary>
        /// Return the localized version of the passed string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override string GetLocalizedString ( string value )
        {
            return CustomResources.ResourceManager.GetString ( value ) ;
        }
    }

    
}
