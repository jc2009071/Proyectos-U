using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCriticalPath
{
    class Entrada
    {

        int id;
        string nombre, conn;

        public Entrada(int ID, string Nombre, string Conn) {

            id = ID;
            nombre = Nombre;
            conn = Conn;
        }

        public int getId() {

            return id;
        }

        public string getNombre() {

            return nombre;
        }

        public string getConn() {

            return conn;
        }

        public bool connect() {

            //TODO revisar llenado matriz de adyacencia entradas

            bool problem = false;

            string[] temp = conn.Split('|');
            string[] array;

            foreach (string temp1 in temp) {

                array = temp1.Split(',');

                try {

                    Program.matriz[int.Parse(array[0])- 1][id - 1] = int.Parse(array[1]);
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
