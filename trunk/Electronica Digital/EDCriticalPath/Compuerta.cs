using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EDCriticalPath
{
    class Compuerta
    {

        int id, delayP1R, delayP1F, delayP2R, delayP2F, cantConn;
        string nombre, conn;
        bool salida, valorP1, valorP2, setP1, setP2, setS;

        public Compuerta() { }

        public Compuerta(int ID, string Nombre, string DelayP1, string DelayP2, string Conn, int Salida) {

            id = ID;
            cantConn = 0;

            if (Salida == 1)
                salida = true;
            else
                salida = false;

            valorP1 = false;
            valorP2 = false;
            setP1 = false;
            setP2 = false;
            setS = false;
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

        public bool getValorP1() {

            return valorP1;
        }

        public bool getValorP2() {

            return valorP2;
        }

        public void setValorP1(bool valor) {

            valorP1 = valor;
            setP1 = true;
        }

        public bool getSetP1() {

            return setP1;
        }

        public void setValorP2(bool valor) {

            valorP2 = valor;
            setP2 = true;
        }

        public bool getSetP2()
        {

            return setP2;
        }

        public void clearValores() {

            valorP1 = false;
            valorP2 = false;
            salida = false;
            setS = false;
            setP1 = false;
            setP2 = false;
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

        public bool getSalida() {

            return salida;
        }

        public void setSalida(bool valor) {

            salida = valor;
            setS = true;
        }

        public void setSalida() {

            switch (nombre) {

                case "AND":
                    setSalida(valorP1 && valorP2);
                    break;

                case "NAND":
                    setSalida(!(valorP1 && valorP2));
                    break;

                case "OR":
                    setSalida(valorP1 || valorP2);
                    break;

                case "NOR":
                    setSalida(!(valorP1 || valorP2));
                    break;

                case "NOT":
                    setSalida(!valorP1);
                    break;

                default:
                    Console.WriteLine("Compuerta erronea.");
                    break;
            }
        }

        public bool seteable() {

            if (setP1 && setP2)
                return true;
            else
                return false;
        }

        public bool connect() {

            bool problem = false;
            int posEntradas = Program.entradas.Count - 1;
            string[] temp = conn.Split('|');
            string[] array;

            foreach (string temp1 in temp)
            {

                array = temp1.Split(',');

                try {

                    Program.matriz[posEntradas + id][int.Parse(array[0]) - 1] = int.Parse(array[1]);
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

        public bool sensibilizar(int pata_constante, bool valor_entrada){

            switch (nombre) { 
            
                case "AND":
                    if (pata_constante == 1)
                        setValorP2(true);
                    else
                        setValorP1(true);

                    break;

                case "NAND":
                    if (pata_constante == 1)
                        setValorP2(false);
                    else
                        setValorP1(false);

                    break;

                case "OR":
                    if (pata_constante == 1)
                        setValorP2(false);
                    else
                        setValorP1(false);

                    break;

                case "NOR":
                    if (pata_constante == 1)
                        setValorP2(true);
                    else
                        setValorP1(true);

                    break;

                case "NOT":
                    setValorP1(valor_entrada);

                    setSalida(!valor_entrada);
                    return salida;

                default:
                    Console.WriteLine("Compuerta erronea.");
                    break;
            }

            setSalida(valor_entrada);
            return salida;
        }

        public void sensibilizar(int pata_constante) {

            switch (nombre)
            {

                case "AND":
                    if (pata_constante == 1)
                        setValorP2(true);
                    else
                        setValorP1(true);

                    break;

                case "NAND":
                    if (pata_constante == 1)
                        setValorP2(false);
                    else
                        setValorP1(false);

                    break;

                case "OR":
                    if (pata_constante == 1)
                        setValorP2(false);
                    else
                        setValorP1(false);

                    break;

                case "NOR":
                    if (pata_constante == 1)
                        setValorP2(true);
                    else
                        setValorP1(true);

                    break;

                case "NOT":
                    setP2 = true;
                    break;

                default:
                    Console.WriteLine("Compuerta erronea.");
                    break;
            }
        }


        public bool justificar(int pata, bool valor) {

            switch (nombre) {

                case "AND":
                    if (pata == 1) {

                        if (!setP1)
                            setValorP1(valor);
                        else if (valorP1 == valor)
                            return false;
                        else 
                            return true;
                    }
                    else if (pata == 2) {
                        if (!setP2)
                            setValorP2(valor);
                        else if (valorP2 == valor)
                            return false;
                        else
                            return true;
                    }
                    else {

                        return true; //hay problema
                    }

                    break;

                case "NAND":
                    

                    break;

                case "OR":
                    

                    break;

                case "NOR":
                    

                    break;

                case "NOT":
                    

                    break;

                default:
                    Console.WriteLine("Compuerta erronea.");
                    break;
            }

            return false;
        }
    }
}
