using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCriticalPath
{
    class Compuerta
    {

        int id, valorP1, valorP2, delayP1R, delayP1F, delayP2R, delayP2F;
        string nombre, conn;

        public Compuerta() { }

        public Compuerta(int ID, string Nombre, string DelayP1, string DelayP2, string Conn) {

            id = ID;
            valorP1 = -1;
            valorP2 = -1;
            nombre = Nombre;
            string[] temp;

            temp = DelayP1.Split('/');
            if(temp.Length==2)
                try {
                    
                    delayP1R = int.Parse(temp[0]);
                    delayP1F = int.Parse(temp[1]);
                }
                catch (FormatException) {

                    Console.WriteLine("Error al parsear delay P1 compuerta " + id);
                }

            temp = DelayP2.Split('/');
            if (temp.Length == 2)
                try {

                    delayP2R = int.Parse(temp[0]);
                    delayP2F = int.Parse(temp[1]);
                }
                catch (FormatException) {

                    Console.WriteLine("Error al parsear delay P2 compuerta " + id);
                }

            conn = Conn;
        }


        public int getId() {

            return id;
        }

        public int getDelayP1R() {

            return delayP1R;
        }

        public int getDelayP1F() {

            return delayP1F;
        }

        public int getDelayP2R() {

            return delayP2R;
        }

        public int getDelayP2F() {

            return delayP2F;
        }

        public int getValorP1() {

            return valorP1;
        }

        public int getValorP2() {

            return valorP2;
        }

        public void setValorP1(int valor) {

            valorP1 = valor;
        }

        public void setValorP2(int valor) {

            valorP2 = valor;
        }

        public void clearValores() {

            valorP1 = -1;
            valorP2 = -1;
        }

        public string getNombre() {

            return nombre;
        }

        public string getConn() {

            return conn;
        }

        public bool connect() {

            //TODO llenar matriz de adyacencia compuertas

            bool problem = false;
            int posEntradas = Program.entradas.Count - 1;
            string[] temp = conn.Split('|');
            string[] array;

            foreach (string temp1 in temp)
            {

                array = temp1.Split(',');

                try {

                    Program.matriz[int.Parse(array[0]) - 1][posEntradas + id - 1] = int.Parse(array[1]);
                }
                catch (FormatException) {

                    problem = true;
                }
                catch (IndexOutOfRangeException) {

                    problem = true;
                }

            }

            return problem;
        }

    }
}
