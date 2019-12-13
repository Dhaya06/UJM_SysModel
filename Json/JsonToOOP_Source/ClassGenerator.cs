using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Xamasoft.JsonClassGenerator.CodeWriters;
using System.Diagnostics;


namespace Xamasoft.JsonClassGenerator.UI
{
    public partial class ClassGenerator : Form
    {
        public ClassGenerator()
        {
            InitializeComponent();
            CenterToScreen();
            initiate();
            label1.Visible = true;
            cmbLanguage.Visible = false;
        }

        private void HideCompletionMessage()
        {

            lnkOpenFolder.Visible = false;
            lblDone.Visible = false;
            lblDoneClipboard.Visible = false;
        }
        private JsonClassGenerator Prepare()
        {
            
            var gen = new JsonClassGenerator();
            gen.Example = edtJson.Text;
            gen.InternalVisibility = true;
            //gen.CodeWriter = (ICodeWriter)cmbLanguage.SelectedItem;
            gen.CodeWriter = (ICodeWriter)cmbLanguage.Items[0];
            //gen.ExplicitDeserialization = chkExplicitDeserialization.Checked && gen.CodeWriter is CSharpCodeWriter;
            gen.Namespace = string.IsNullOrEmpty(edtNamespace.Text) ? null : edtNamespace.Text;
            gen.NoHelperClass = true;
            gen.SecondaryNamespace = "SystemModelingNameSpace";
            //gen.TargetFolder = edtTargetFolder.Text;
            gen.TargetFolder = desitinationPath;
            gen.UseProperties = false;
            gen.MainClass = edtMainClass.Text;
            gen.UsePascalCase = false;
            gen.UseNestedClasses = false;
            gen.ApplyObfuscationAttributes = false;
            gen.SingleFile = true;
            gen.ExamplesInDocumentation = false;
            return gen;
        }


        private void initiate()
        {
          

            cmbLanguage.Items.AddRange(CodeWriters);


        }

        private string lastGeneratedString;

        
        private readonly static ICodeWriter[] CodeWriters = new ICodeWriter[] {
            new CSharpCodeWriter()
            
        };
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (desitinationPath == "" || string.IsNullOrEmpty(desitinationPath))
            {
                MessageBox.Show("Please select a target folder to store your generated class file");
                return;
            }

            HideCompletionMessage();
            
            var gen = Prepare();
            if (gen == null) return;
            try
            {
                gen.GenerateClasses();
              
                lblDone.Visible = true;
                lnkOpenFolder.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Unable to generate the code: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start(desitinationPath);
            }
            catch (Exception)
            {
            }
        }
        string desitinationPath = "";
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Select a location to store decoded image file");
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && fbd.SelectedPath !="")
                {
                    desitinationPath = fbd.SelectedPath;
                }
            }
        }
    }
}
