using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VMT_Fixer
{
    public partial class Form1 : Form
    {
        private string folderName;

        public Form1()
        {
            InitializeComponent();
        }

        private bool fixFile(string filePath)
        {
            List<string> _keyWords = new List<string>()
            {
                "\"character\"",
                "\"vertexlitgeneric\""
            };
            var _lines = File.ReadAllLines(filePath);
            if (_keyWords.Contains(_lines[0])) {
                _lines[0] = "\"VertexLitGeneric\"";
            }
            else
            {
                return false;
            }
            try
            {
                File.WriteAllLines(filePath, _lines);
            }
            catch (Exception)
            {
                MessageBox.Show($"Error writing {filePath}.", @"VMT Error");
                return false;
            }
            return true;
        } 

        private string[] getFiles(string path)
        {
            string[] _filesPaths = Directory.GetFiles(path, "*.vmt", SearchOption.AllDirectories);
            return _filesPaths;
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderName;
            }
        }

        private void fixButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(folderName))
            {
                MessageBox.Show(@"Please select working directory.", @"VMT Dialog");
                return;
            }
            var result = MessageBox.Show(@"Now gonna start fixing VMT files", @"VMT Dialog");
            if (result == DialogResult.OK)
            {
                var files = getFiles(folderName);
                foreach (var file in files)
                {
                    fixFile(file);
                    // Do smthing 
                }
                MessageBox.Show(@"Done!", @"VMT Dialog");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "Select folder";
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/user/jzteVo");
        }
    }
}
