using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Compilador
{
    static class Program
    {
        public static Dictionary<string, Nodo> symbolTable = new Dictionary<string, Nodo>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(){
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GUI());

            symbolTable.Add("var1", new Tipo());
        }
    }
}
