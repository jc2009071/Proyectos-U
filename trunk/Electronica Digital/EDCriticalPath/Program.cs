using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace EDCriticalPath
{
    class Program
    {
        public static List<Compuerta> compuertas = new List<Compuerta>();
        public static List<Entrada> entradas = new List<Entrada>();
        public static int compuertaFinal;
        public static int[][] matriz;
        
        static void Main(string[] args) {

            configs();
            initializeM();
        }

        public static void initializeM() { 
        
            matriz = new int[compuertas.Count][];

            for (int i = 0; i < matriz.Length; i++)
                matriz[i] = new int[(compuertas.Count + entradas.Count)];

            //TODO llamar a metodos en compuertas y entradas para llenar
        }

        public static void showMatriz() {
            
            //TODO deplegar matriz
            foreach (int[] a in matriz) 
                foreach (int i in a) {

                    Console.Write("");
                }
        }


        public static void configs() {

            XmlTextReader reader = new XmlTextReader(@"C:\Users\Public\ED\circuito1.xml");

            while (reader.Read()) {

                switch (reader.NodeType) {

                    case XmlNodeType.Element:

                        switch (reader.Name) {

                            case "Compuertas":

                                compuertaFinal = int.Parse(reader.GetAttribute("CompuertaFinal"));
                                break;

                            case "compuerta":

                                int id = int.Parse(reader.GetAttribute("id"));
                                string name, delayP1, delayP2, conn;
                                name = reader.GetAttribute("name");
                                delayP1 = reader.GetAttribute("delayP1");
                                delayP2 = reader.GetAttribute("delayP2");
                                conn = reader.GetAttribute("conn");
                                Compuerta temp = new Compuerta(id, name, delayP1, delayP2, conn);
                                compuertas.Add(temp);
                                break;

                            case "entrada":

                                int id1 = int.Parse(reader.GetAttribute("id"));
                                string nombre1, conn1;
                                nombre1 = reader.GetAttribute("name");
                                conn1 = reader.GetAttribute("conn");
                                Entrada temp1 = new Entrada(id1, nombre1, conn1);
                                entradas.Add(temp1);
                                break;
                        }

                        break;
                }
            }
        }
    }
}
