namespace CedarLogic.Identity 
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGenerateXml = new System.Windows.Forms.Button();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.txtOutFile = new System.Windows.Forms.TextBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.txtSettings = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rbSamlIdp = new System.Windows.Forms.RadioButton();
            this.rbSamlSp = new System.Windows.Forms.RadioButton();
            this.btnPickSettings = new System.Windows.Forms.Button();
            this.metadataEditor1 = new CedarLogic.Identity.MetadataEditor();
            this.rbSts = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnGenerateXml
            // 
            this.btnGenerateXml.Location = new System.Drawing.Point(121, 158);
            this.btnGenerateXml.Name = "btnGenerateXml";
            this.btnGenerateXml.Size = new System.Drawing.Size(144, 23);
            this.btnGenerateXml.TabIndex = 0;
            this.btnGenerateXml.Text = "Generate XML";
            this.btnGenerateXml.UseVisualStyleBackColor = true;
            this.btnGenerateXml.Click += new System.EventHandler(this.btnGenerateXml_Click);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Location = new System.Drawing.Point(12, 158);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(103, 23);
            this.btnChooseFile.TabIndex = 2;
            this.btnChooseFile.Text = "Pick out file";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.btnChooseFile_Click);
            // 
            // txtOutFile
            // 
            this.txtOutFile.Location = new System.Drawing.Point(12, 132);
            this.txtOutFile.Name = "txtOutFile";
            this.txtOutFile.Size = new System.Drawing.Size(646, 20);
            this.txtOutFile.TabIndex = 3;
            this.txtOutFile.Text = "FederationMetadata.xml";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(230, 87);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(116, 23);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // txtSettings
            // 
            this.txtSettings.Location = new System.Drawing.Point(15, 51);
            this.txtSettings.Name = "txtSettings";
            this.txtSettings.Size = new System.Drawing.Size(643, 20);
            this.txtSettings.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 118);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Output File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Settings File";
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(121, 87);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(103, 23);
            this.btnLoadSettings.TabIndex = 8;
            this.btnLoadSettings.Text = "Load Settings";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "xml";
            this.saveFileDialog1.OverwritePrompt = false;
            // 
            // rbSamlIdp
            // 
            this.rbSamlIdp.AutoSize = true;
            this.rbSamlIdp.Location = new System.Drawing.Point(96, 9);
            this.rbSamlIdp.Name = "rbSamlIdp";
            this.rbSamlIdp.Size = new System.Drawing.Size(75, 17);
            this.rbSamlIdp.TabIndex = 9;
            this.rbSamlIdp.Tag = "SamlIdpData";
            this.rbSamlIdp.Text = "SAML IDP";
            this.rbSamlIdp.UseVisualStyleBackColor = true;
            this.rbSamlIdp.CheckedChanged += new System.EventHandler(this.rbSamlIdp_CheckedChanged);
            // 
            // rbSamlSp
            // 
            this.rbSamlSp.AutoSize = true;
            this.rbSamlSp.Location = new System.Drawing.Point(194, 9);
            this.rbSamlSp.Name = "rbSamlSp";
            this.rbSamlSp.Size = new System.Drawing.Size(71, 17);
            this.rbSamlSp.TabIndex = 10;
            this.rbSamlSp.Tag = "SamlSpData";
            this.rbSamlSp.Text = "SAML SP";
            this.rbSamlSp.UseVisualStyleBackColor = true;
            this.rbSamlSp.CheckedChanged += new System.EventHandler(this.rbSamlIdp_CheckedChanged);
            // 
            // btnPickSettings
            // 
            this.btnPickSettings.Location = new System.Drawing.Point(15, 87);
            this.btnPickSettings.Name = "btnPickSettings";
            this.btnPickSettings.Size = new System.Drawing.Size(100, 23);
            this.btnPickSettings.TabIndex = 11;
            this.btnPickSettings.Text = "Pick settings file";
            this.btnPickSettings.UseVisualStyleBackColor = true;
            this.btnPickSettings.Click += new System.EventHandler(this.btnPickSettings_Click);
            // 
            // metadataEditor1
            // 
            this.metadataEditor1.Location = new System.Drawing.Point(12, 187);
            this.metadataEditor1.MetaData = null;
            this.metadataEditor1.Name = "metadataEditor1";
            this.metadataEditor1.Size = new System.Drawing.Size(760, 511);
            this.metadataEditor1.TabIndex = 1;
            // 
            // rbSts
            // 
            this.rbSts.AutoSize = true;
            this.rbSts.Checked = true;
            this.rbSts.Location = new System.Drawing.Point(24, 9);
            this.rbSts.Name = "rbSts";
            this.rbSts.Size = new System.Drawing.Size(46, 17);
            this.rbSts.TabIndex = 12;
            this.rbSts.TabStop = true;
            this.rbSts.Tag = "StsData";
            this.rbSts.Text = "STS";
            this.rbSts.UseVisualStyleBackColor = true;
            this.rbSts.CheckedChanged += new System.EventHandler(this.rbSamlIdp_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 721);
            this.Controls.Add(this.rbSts);
            this.Controls.Add(this.btnPickSettings);
            this.Controls.Add(this.rbSamlSp);
            this.Controls.Add(this.rbSamlIdp);
            this.Controls.Add(this.btnLoadSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSettings);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.txtOutFile);
            this.Controls.Add(this.btnChooseFile);
            this.Controls.Add(this.metadataEditor1);
            this.Controls.Add(this.btnGenerateXml);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Federation data generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerateXml;
        private MetadataEditor metadataEditor1;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.TextBox txtOutFile;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.TextBox txtSettings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RadioButton rbSamlIdp;
        private System.Windows.Forms.RadioButton rbSamlSp;
        private System.Windows.Forms.Button btnPickSettings;
        private System.Windows.Forms.RadioButton rbSts;
    }
}

