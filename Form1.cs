using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Linter_Tester
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            GetPath();
        }
        string startupPath;
        string pathPhp;
        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                pathPhp = "";
                // this open the file explorer, this let's the user select a file
                OpenFileDialog pathTo = new OpenFileDialog();
                // you can only select php files nothing else
                pathTo.Filter = "PHP file | *.php;";
                pathTo.FilterIndex = 1;
                // you only can select 1 fil
                pathTo.Multiselect = false;

                if (pathTo.ShowDialog() == DialogResult.OK)
                {
                     pathPhp = pathTo.FileName;
                     txtFilePath.Text = pathPhp;
                }
                //this if can't really break the program
            }
            catch (Exception) { 
            
            }
        }

        //get path to the root file of the Project
        private void GetPath()
        {
            startupPath = Application.StartupPath;
            startupPath = startupPath.Substring(0, startupPath.Length - 9);
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            string strCmdText;
            //the command \" adds a " to the command for the file path
            strCmdText = "/K php \"" + startupPath + "XML/phpcs.phar\" " + "--standard=\"" + startupPath +"XML/PHP_lenient.xml\" "+ "\"" + pathPhp + "\"" + " && pause";
             
            //starts CMD and auto executes the command
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);

            //resets the path to nothing so the user can test another file
            pathPhp = "";
        }
    }
       
}

