using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCriticalPath
{
    class Entrada
    {

        int id, cantConn;
        string nombre, conn;
        bool valor, setV;

        public Entrada(int ID, string Nombre, string Conn) {

            id = ID;
            nombre = Nombre;
            conn = Conn;
            cantConn = 0;

            valor = false;
            setV = false;
        }

        public bool getValor() {

            return valor;
        }

        public void setValor(bool value) {

            valor = value;
            setV = true;
        }

        public void clearValor() {

            valor = false;
            setV = false;
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

        public int getCantConn() {

            return cantConn;
        }

        public bool connect() {

            bool problem = false;

            string[] temp = conn.Split('|');
            string[] array;

            foreach (string temp1 in temp) {

                array = temp1.Split(',');

                try {

                    Program.matriz[id - 1][int.Parse(array[0]) - 1] = int.Parse(array[1]);
                }
                catch (FormatException) {

                    problem = true;
                }
                catch (IndexOutOfRangeException) {

                    problem = true;
                }
                        
            }
            cantConn++;
            return problem;
        }
    }
}
