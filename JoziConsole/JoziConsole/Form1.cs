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

namespace JoziConsole
{
    public partial class Form1 : Form
    {
        public List<String> filesList;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.filesList = new List<String>();
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.ShowDialog();
            foreach(String fileName in fd.FileNames)
            {
                filesList.Add(fileName);
                listBox1.Items.Add(fileName);
            };
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String path = null;
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    path = fbd.SelectedPath;
                }
                else
                {
                    path = "C:\\";
                }
            }
            String csvName = "\\myCSV.csv";
            StringBuilder csv = new StringBuilder();
            foreach(String fileName in filesList)
            {
                csv.AppendLine(fileName);
            }
            File.AppendAllText(path + csvName, csv.ToString());

            // Lahko zrihtaš še tti popup
            var formPopup = new Form();
            //formPopup.Show(PopUpForm1);
        }
    }
}
