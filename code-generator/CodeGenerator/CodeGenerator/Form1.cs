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
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\default.txt"))
            {
                var path = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\default.txt");
                if (!string.IsNullOrWhiteSpace(path))
                {
                    txtProjectPath.Text = path;
                    RefreshDomain();

                    return;
                }
            }

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
            txtSavePath.Text = GetFileName(comboBox1.Text);
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

            RefreshDomain();
        }

        private void RefreshDomain()
        {
            if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;

            var domainPath = txtProjectPath.Text + "\\List\\Hris.List.Business\\Domains\\";

            var files = Directory.GetFiles(domainPath);

            cboDomain.Items.Clear();
            cboDomain.Items.AddRange(files.Select(x => x.Replace(domainPath, "").Replace(".cs", "")).ToArray());
        }

        private string GetFileName(string type)
        {
            string path;
            string file;
            switch (type)
            {
                case "ModelDatabase":
                    path = "\\Hris.Database\\Entities\\List\\";
                    file = "MD" + cboDomain.Text + ".cs";
                    break;
                case "ModelApi":
                    path = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    file = cboDomain.Text + "Model.cs";
                    break;
                case "Api":
                    path = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    file = cboDomain.Text + "Api.cs";
                    break;
                case "Component":
                    path = "\\HrisWebMain\\src\\app\\list\\" + cboDomain.Text.ToLower();
                    file = cboDomain.Text.ToLower() + ".component.ts";
                    break;
                case "Controller":
                    path = "\\HrisWebMain\\Controllers\\List";
                    file = cboDomain.Text + "Controller.cs";
                    break;
                case "Html":
                    path = "\\HrisWebMain\\src\\app\\list\\" + cboDomain.Text.ToLower();
                    file = cboDomain.Text.ToLower() + ".html";
                    break;
                case "IApi":
                    path = "\\List\\Hris.List.Api\\" + cboDomain.Text;
                    file = "I" + cboDomain.Text + "Api.cs";
                    break;
                case "IRepository":
                    path = "\\List\\Hris.List.Business\\Repositories";
                    file = "I" + cboDomain.Text + "Repository.cs";
                    break;
                case "IService":
                    path = "\\List\\Hris.List.Business\\Services\\Interfaces";
                    file = "I" + cboDomain.Text + "Service.cs";
                    break;
                case "Repository":
                    path = "\\List\\Hris.List.Persistence";
                    file = cboDomain.Text + "Repository.cs";
                    break;
                case "Service":
                    path = "\\List\\Hris.List.Business\\Services\\Implementations";
                    file = cboDomain.Text + "Service.cs";
                    break;
                case "TypescriptModel":
                    path = "\\HrisWebMain\\src\\app\\shared\\datamodel\\list";
                    file = cboDomain.Text.ToLower() + ".ts";
                    break;
                default:
                    MessageBox.Show(@"This template not set directory to save file.", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    path = file = null;
                    return null;
            }

            path = txtProjectPath.Text + path;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            file = path + "\\" + file;

            return file;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (comboBox1.SelectedIndex < 0) return;
            if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;

            var saveFile = GetFileName(comboBox1.SelectedItem.ToString());

            if (string.IsNullOrWhiteSpace(saveFile)) return;


            if (File.Exists(saveFile))
            {
                var result = MessageBox.Show($"File {comboBox1.SelectedItem} is Exists. Do you want overwrite it?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No) return;
            }

            File.WriteAllText(saveFile, txtResult.Text, Encoding.UTF8);

            MessageBox.Show(@"File was saved.", @"Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDomain();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (string.IsNullOrWhiteSpace(txtProjectPath.Text)) return;

            if (MessageBox.Show("Save all?", "save all", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            foreach (var item in comboBox1.Items)
            {
                var saveFile = GetFileName(item.ToString());

                var template = File.ReadAllText(TemplateDirectory + item + ".txt");

                var result = template.Replace("{0}", cboDomain.Text).Replace("{1}", cboDomain.Text.ToLower());

                File.WriteAllText(saveFile, result, Encoding.UTF8);
            }

            MessageBox.Show("Saved all.");
        }

    }
}
