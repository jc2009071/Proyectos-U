using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using GoldParser;
using com.calitha.goldparser;

namespace Compilador
{
    public partial class GUI : Form
    {
        string titulo = "Compilador WiikDS";
        string nombreArchivo = "nuevo", pathArchivo = @"C:\Users\Public\Compiladores\";

        public GUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Abrir_Click(object sender, EventArgs e)
        {
            OpenFileDialog browser = new OpenFileDialog();
            StreamReader reader;
            Stream myStream = null;

            browser.Title = "Compilador WiikDS";
            browser.InitialDirectory = @"C:\Users\Public\Compiladores\";
            browser.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            browser.RestoreDirectory = true;


            if(browser.ShowDialog() == DialogResult.OK) {

                try
                {
                    if ((myStream = browser.OpenFile()) != null)
                    {

                        nombreArchivo = System.IO.Path.GetFileName(browser.FileName);
                        pathArchivo = System.IO.Path.GetDirectoryName(browser.FileName);
                        //MessageBox.Show(pathArchivo + "\t" + nombreArchivo, "Path y Archivo");

                        using (myStream)
                        {
                            reader = new StreamReader(myStream);
                            TextArea.Text = reader.ReadToEnd();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
                
            }

            this.Text = pathArchivo + "\\" + nombreArchivo + " | " + titulo;

        }

        private void Guardar_Click(object sender, EventArgs e)
        {
            if (nombreArchivo == "nuevo") {

                Stream myStream;
                StreamWriter writer;
                SaveFileDialog browser = new SaveFileDialog();

                browser.Title = "Guardar Archivo | Compilador WiikDS";
                browser.InitialDirectory = @"C:\Users\Public\Compiladores\";
                browser.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                browser.DefaultExt = "txt";
                browser.AddExtension = true;
                browser.RestoreDirectory = true;

                if (browser.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = browser.OpenFile()) != null)
                    {
                        // Code to write the stream goes here.
                        writer = new StreamWriter(myStream);
                        writer.Write(TextArea.Text);
                        writer.Close();
                        myStream.Close();
                    }
                }
            }
        }

        private void Nuevo_Click(object sender, EventArgs e)
        {
            TextArea.Text = "";
            
            nombreArchivo = "nuevo"; 
            pathArchivo = @"C:\Users\Public\Compiladores\";
            ///MessageBox.Show(pathArchivo + "\t" + nombreArchivo, "Path y Archivo");

            this.Text = nombreArchivo + "(1) | " + titulo;
        }

        private void Compilar_Click(object sender, EventArgs e)
        {

            MyParser parser = new MyParser(pathArchivo + "\\DecafGP.cgt"); 


            TreeNode tree = parser.Parse(TextArea.Text);

            treeView1.Nodes.Clear();
            if (tree != null)
            {
                treeView1.Nodes.Add(tree);
                //statusLabel.Text = @"Success";
            }
            else
            {
                //statusLabel.Text = parser.ErrorMessage;
            }
            
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
