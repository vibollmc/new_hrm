using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class Form1 : Form
    {
        private string TemplateDirectory => AppDomain.CurrentDomain.BaseDirectory + "Templates\\";

        public Form1()
        {
            InitializeComponent();
            LoadTemplate();
            SelectFolder();
        }

        private void LoadTemplate()
        {
            var files = Directory.GetFiles(TemplateDirectory);
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(files.Select(x => x.Replace(TemplateDirectory, "").Replace(".txt", "")).ToArray());
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateCommon();
        }

        private void GenerateCommon()
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (comboBox1.SelectedIndex < 0) return;

            var template = File.ReadAllText(TemplateDirectory + comboBox1.SelectedItem + ".txt");

            txtResult.Text = template.Replace("{0}", cboDomain.Text).Replace("{1}", cboDomain.Text.ToLower());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(txtResult.Text);
        }

        private void cboDomain_TextChanged(object sender, EventArgs e)
        {
            GenerateCommon();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SelectFolder();
        }

        private void SelectFolder()
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();

            txtProjectPath.Text = folderBrowserDialog.SelectedPath;

            if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;

            var domainPath = txtProjectPath.Text + "\\List\\Hris.List.Business\\Domains\\";

            var files = Directory.GetFiles(domainPath);

            cboDomain.Items.Clear();
            cboDomain.Items.AddRange(files.Select(x => x.Replace(domainPath, "").Replace(".cs", "")).ToArray());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (comboBox1.SelectedIndex < 0) return;
            if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;

            string savePath;
            string saveFile;

            switch (comboBox1.SelectedItem.ToString())
            {
                case "ModelDatabase":
                    savePath = "\\Hris.Database\\Entities\\List\\";
                    saveFile = "MD" + cboDomain.Text + ".cs";
                    break;
                case "ModelApi":
                    savePath = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    saveFile = cboDomain.Text + "Model.cs";
                    break;
                case "Api":
                    savePath = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    saveFile = cboDomain.Text + "Api.cs";
                    break;
                case "Component":
                    savePath = "\\HrisWebMain\\src\\app\\list\\" + cboDomain.Text.ToLower();
                    saveFile = cboDomain.Text.ToLower() + ".component.ts";
                    break;
                case "Controller":
                    savePath = "\\HrisWebMain\\Controllers";
                    saveFile = cboDomain.Text + "Controller.cs";
                    break;
                case "Html":
                    savePath = "\\HrisWebMain\\src\\app\\list\\" + cboDomain.Text.ToLower();
                    saveFile = cboDomain.Text.ToLower() + ".html";
                    break;
                case "IApi":
                    savePath = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    saveFile = "I" + cboDomain.Text + "Api.cs";
                    break;
                case "IRepository":
                    savePath = "\\List\\Hris.List.Business\\Repositories";
                    saveFile = "I" + cboDomain.Text + "Repository.cs";
                    break;
                case "IService":
                    savePath = "\\List\\Hris.List.Business\\Services\\Interfaces";
                    saveFile = "I" + cboDomain.Text + "Service.cs";
                    break;
                case "Repository":
                    savePath = "\\List\\Hris.List.Persistence";
                    saveFile = cboDomain.Text + "Repository.cs";
                    break;
                case "Service":
                    savePath = "\\List\\Hris.List.Business\\Services\\Implementations";
                    saveFile = cboDomain.Text + "Service.cs";
                    break;
                case "TypescriptModel":
                    savePath = "\\HrisWebMain\\src\\app\\shared\\datamodel\\list";
                    saveFile = cboDomain.Text.ToLower() + ".ts";
                    break;
                default:
                    MessageBox.Show(@"This template not set directory to save file.", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
            }

            savePath = txtProjectPath.Text + savePath;

            if (!Directory.Exists(savePath))
                Directory.CreateDirectory(savePath);

            saveFile = savePath + "\\" + saveFile;

            if (File.Exists(saveFile))
            {
                var result = MessageBox.Show($"File {comboBox1.SelectedItem} is Exists. Do you want overwrite it?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No) return;
            }

            File.WriteAllText(saveFile, txtResult.Text, Encoding.UTF8);

            MessageBox.Show(@"File was saved.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
