using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class Form2 : Form
    {
        private string TemplateDirectory => AppDomain.CurrentDomain.BaseDirectory + "Templates2\\";
        private string Module => txtPath.Text?.Substring(txtPath.Text.LastIndexOf("\\") + 1);
        private string ProjectPath => txtPath.Text?.Substring(0, txtPath.Text.LastIndexOf("\\Hris.Database"));
        public Form2()
        {
            InitializeComponent();
            LoadTemplate();
        }

        private void LoadTemplate()
        {
            var files = Directory.GetFiles(TemplateDirectory);
            cboTemplate.Items.Clear();
            cboTemplate.Items.AddRange(files.Select(x => x.Replace(TemplateDirectory, "").Replace(".txt", "")).ToArray());
        }

        private void SelectFolder()
        {
            string path = null;
            if (File.Exists(AppDomain.CurrentDomain.BaseDirectory + "\\default.txt"))
            {
                path = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "\\default.txt");
                if (!string.IsNullOrWhiteSpace(path)) path += "\\Hris.Database\\Entities";
            }

            var folderBrowserDialog = new FolderBrowserDialog
            {
                SelectedPath = path
            };

            folderBrowserDialog.ShowDialog();

            txtPath.Text = folderBrowserDialog.SelectedPath;

            RefreshDomain();
        }

        private string GetFileName(string template)
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return null;
            if (cboDomain.SelectedIndex < 0) return null;
            if (cboTemplate.SelectedIndex < 0) return null;

            var projectPath = ProjectPath;
            var module = Module;

            if (module == "System") module = "Common";

            var domain = cboDomain.Text.Substring(2);
            var type = template;

            string path;
            string file;

            switch (type)
            {
                case "ModelDomain":
                    path = $"\\{module}\\Hris.{module}.Business\\Domains\\";
                    file = domain + ".cs";
                    break;
                case "ModelApi":
                    path = $"\\{module}\\Hris.{module}.Api\\" + domain;
                    file = domain + "Model.cs";
                    break;
                case "Api":
                    path = $"\\{module}\\Hris.{module}.Api\\" + domain;
                    file = domain + "Api.cs";
                    break;
                case "Component":
                    path = $"\\HrisWebMain\\src\\app\\{module.ToLower()}\\" + domain.ToLower();
                    file = domain.ToLower() + ".component.ts";
                    break;
                case "Controller":
                    path = $"\\HrisWebMain\\Controllers\\{module}";
                    file = domain + "Controller.cs";
                    break;
                case "Html":
                    path = $"\\HrisWebMain\\src\\app\\{module}\\" + domain.ToLower();
                    file = cboDomain.Text.ToLower() + ".html";
                    break;
                case "IApi":
                    path = $"\\{module}\\Hris.{module}.Api\\" + domain;
                    file = "I" + domain + "Api.cs";
                    break;
                case "IRepository":
                    path = $"\\{module}\\Hris.{module}.Business\\Repositories";
                    file = "I" + domain + "Repository.cs";
                    break;
                case "IService":
                    path = $"\\{module}\\Hris.{module}.Business\\Services\\Interfaces";
                    file = "I" + domain + "Service.cs";
                    break;
                case "Repository":
                    path = $"\\{module}\\Hris.{module}.Persistence";
                    file = domain + "Repository.cs";
                    break;
                case "Service":
                    path = $"\\{module}\\Hris.{module}.Business\\Services\\Implementations";
                    file = domain + "Service.cs";
                    break;
                case "TypescriptModel":
                    path = $"\\HrisWebMain\\src\\app\\shared\\datamodel\\{module.ToLower()}";
                    file = domain.ToLower() + ".ts";
                    break;
                case "TypescriptService":
                    path = $"\\HrisWebMain\\src\\app\\{module.ToLower()}\\" + domain.ToLower();
                    file = domain.ToLower() + ".service.ts";
                    break;
                case "TypescriptModelService":
                    path = $"\\HrisWebMain\\src\\app\\{module.ToLower()}\\" + domain.ToLower();
                    file = domain.ToLower() + ".model.ts";
                    break;
                default:
                    MessageBox.Show(@"This template not set directory to save file.", @"Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    path = file = null;
                    return null;
            }

            path = projectPath + path;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            file = path + "\\" + file;

            return file;
        }

        private string RenderCode(string template)
        {
            if (cboTemplate.SelectedIndex < 0) return null;
            if (cboDomain.SelectedIndex < 0) return null;

            var module = Module;

            if (module == "System") module = "Common";

            var fileTemplate = File.ReadAllText(TemplateDirectory + template + ".txt");

            var domain = cboDomain.Text.Substring(2);

            if (template != "ModelApi" && template != "ModelDomain" && template != "TypescriptModel")
            {

                var result = fileTemplate
                    .Replace("{0}", module)
                    .Replace("{1}", domain)
                    .Replace("{2}", domain.ToLower())
                    .Replace("{3}", module.ToLower());

                return result;
            }

            var entity = File.ReadAllLines($"{txtPath.Text}\\{cboDomain.Text}.cs");

            var usingLines = entity.Where(x => x.StartsWith("using"));
            var propeties = entity.Where(x => x.Trim().StartsWith("public") && !x.Contains("class"));

           

            if (template != "TypescriptModel")
            {
                return fileTemplate
                    .Replace("{using}", string.Join(Environment.NewLine, usingLines))
                    .Replace("{properties}", string.Join(Environment.NewLine, propeties))
                    .Replace("{0}", module)
                    .Replace("{1}", domain);
            }

            var typescriptProperties = string.Empty;

            foreach (var propety in propeties)
            {
                var arr = propety.Trim().Split(' ');
                var p = arr[2];
                string datatype;
                if (arr[1].StartsWith("int") || arr[1].StartsWith("real") || arr[1].StartsWith("decimal") || arr[1].StartsWith("double")) datatype = "number";
                else if (arr[1].StartsWith("DateTime")) datatype = "date";
                else datatype = arr[1];
                typescriptProperties += $"{Environment.NewLine}  {p.Substring(0, 1).ToLower()}{p.Substring(1)}: {datatype};";
            }

            return fileTemplate.Replace("{properties}", typescriptProperties).Replace("{1}", domain);
        }

        private void RefreshDomain()
        {
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return;

            var domainPath = txtPath.Text;

            var files = Directory.GetFiles(domainPath);

            cboDomain.Items.Clear();
            cboDomain.Items.AddRange(files.Select(x => x.Replace(domainPath + "\\", "").Replace(".cs", "")).ToArray());
        }

        private void cboDomain_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = RenderCode(cboTemplate.Text);
            txtSavePath.Text = GetFileName(cboTemplate.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshDomain();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return;

            var file = GetFileName(cboTemplate.Text);

            if (string.IsNullOrWhiteSpace(file)) return;

            if (File.Exists(file))
            {
                var result = MessageBox.Show($"File {cboTemplate.Text} is Exists. Do you want overwrite it?",
                    "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (result == DialogResult.No) return;
            }

            var code = RenderCode(cboTemplate.Text);

            File.WriteAllText(file, code, Encoding.UTF8);

            MessageBox.Show("Saved.");
        }

        private void btnSaveAll_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cboDomain.Text)) return;
            if (string.IsNullOrWhiteSpace(txtPath.Text)) return;

            if (MessageBox.Show("Save all?", "save all", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            foreach (var item in cboTemplate.Items)
            {
                var saveFile = GetFileName(item.ToString());

                var result = RenderCode(item.ToString());

                File.WriteAllText(saveFile, result, Encoding.UTF8);
            }

            MessageBox.Show("Saved all.");
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox1.Text);
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            SelectFolder();
        }
    }
}
