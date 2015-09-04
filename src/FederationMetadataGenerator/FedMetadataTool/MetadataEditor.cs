using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CedarLogic.Identity
{
    public partial class MetadataEditor : UserControl
    {
        MetadataDescriptor _metadata = null;

        public MetadataEditor()
        {
            InitializeComponent();
        }

        public MetadataDescriptor MetaData
        {
            get
            {
                return _metadata;
            }
            set
            {
                _metadata = value;
                this.propertyGrid1.SelectedObject = _metadata;
            }

        }
    }

}

