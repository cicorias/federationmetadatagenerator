 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using CedarLogic.Identity.Configuration;

namespace CedarLogic.Identity
{
    public partial class Form1 : Form
    {
        string _currentType = null;
        public Form1()
        {
            InitializeComponent();
            metadataEditor1.MetaData = new StsData();
            _currentType = "StsData";

            saveFileDialog1.InitialDirectory = Application.StartupPath;

        }


        private void btnGenerateXml_Click(object sender, EventArgs e)
        {
            string fileName = string.IsNullOrEmpty(txtSettings.Text) ? "FederationMetadata.xml" : txtOutFile.Text;
            txtOutFile.Text = fileName;
            MetadataDescriptor md = metadataEditor1.MetaData;
            MetadataHelper.CreateMetaData(md, fileName, Encoding.ASCII);
        }

        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            string fileName = string.IsNullOrEmpty(txtSettings.Text) ? "settings.xml" : txtSettings.Text;
            txtSettings.Text = fileName;
            metadataEditor1.MetaData.ToXml(fileName);
        }

        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = string.IsNullOrEmpty(txtSettings.Text) ? "settings.xml" : txtSettings.Text;
                txtSettings.Text = fileName;

                if (rbSamlIdp.Checked)
                    metadataEditor1.MetaData = metadataEditor1.MetaData.ToObject<SamlIdpData>(fileName);

                if (rbSamlSp.Checked)
                    metadataEditor1.MetaData = metadataEditor1.MetaData.ToObject<SamlSpData>(fileName);

                if (rbSts.Checked)
                    metadataEditor1.MetaData = metadataEditor1.MetaData.ToObject<StsData>(fileName);
            }
            catch (Exception ex)
            {
                string s = FormatException(ex, "Failed to load settings - check if correct type", true);
                MessageBox.Show(s, "Failed to Load", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            var rslt = saveFileDialog1.ShowDialog();
            if (rslt == DialogResult.OK)
            {
                txtOutFile.Text = saveFileDialog1.FileName;
            }
        }

        private void rbSamlIdp_CheckedChanged(object sender, EventArgs e)
        {
            metadataEditor1.MetaData = GetCurrentType();
        }


        MetadataDescriptor GetCurrentType()
        {
            if (rbSamlIdp.Checked)
                return new SamlIdpData();
            if (rbSamlSp.Checked)
                return (MetadataDescriptor)new SamlSpData();
            if (rbSts.Checked)
                return (MetadataDescriptor)new StsData();

            return null;
        }



        string FormatException(Exception ex, string message, bool withStack)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(message))
                sb.AppendFormat("{0}\n", message);

            if (ex != null && withStack)
            {
                sb.AppendFormat("{0}\n", ex.Message);
                sb.AppendFormat(ex.StackTrace);
            }

            if (ex.InnerException != null)
                sb.AppendFormat(FormatException(ex.InnerException, null, false));

            return sb.ToString();
        }

        private void btnPickSettings_Click(object sender, EventArgs e)
        {
            var rslt = saveFileDialog1.ShowDialog();
            if (rslt == DialogResult.OK)
            {
                txtSettings.Text = saveFileDialog1.FileName;
                SetType(txtSettings.Text);
            }
        }


        void SetType(string fileName)
        {
            XDocument doc = XDocument.Load(fileName);
            var root = doc.Root.Name.LocalName;

            if (root != _currentType)
            {
                MessageBox.Show("Invalid Type in Xml - ensure correct type selected", "Invalid type", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSettings.Text = "";
            }

        }


    }
}
