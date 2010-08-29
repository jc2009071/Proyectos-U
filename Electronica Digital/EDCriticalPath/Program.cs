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
        public static List<List<Compuerta>> paths = new List<List<Compuerta>>();
        public static List<Compuerta> pathTemp = new List<Compuerta>();
        public static int compuertaFinal, cantCompuertas, cantEntradas;
        public static int[][] matriz;
        
        static void Main(string[] args) {

            configs();
            initializeM();
            showMatriz();

            generatePaths();
            main();
            //TODO llamar sensibilizar
            //TODO llamar justificar

            Console.Read();
        }

        public static void main(){
        
            foreach(List<Compuerta> ruta in paths){

                sensibilizarRuta(ruta);
                //showSensibilizacion();
                //borrarValores();

                //TODO justificar, calcular delay y comparar critical/shortest
                //justificatRuta(ruta);
            }
        }

        public static bool sensibilizarRuta(List<Compuerta> ruta) {

            bool problem = false;

            for (int j = 0; j < ruta.Count; j++) {

                if (j == 0) {

                    int idTemp = ruta.ElementAt(j).getId();
                    int entrada = 0;

                    for (int i = 0; i < matriz.Length; i++) {

                        if (matriz[i][idTemp - 1] > 0) {

                            entrada = i;
                            break;
                        }
                    }

                    ruta.ElementAt(j).sensibilizar(matriz[entrada][idTemp - 1]);
                }
                else {

                    ruta.ElementAt(j).sensibilizar(matriz[entradas.Count + ruta.ElementAt(j - 1).getId() - 1][ruta.ElementAt(j).getId() - 1]);
                }
            }
            return problem;
        }

        public static void showSensibilizacion() {

            foreach (List<Compuerta> ruta in paths) {
                foreach (Compuerta comp in ruta) {

                    Console.Write(comp.getNombre() + "[" + comp.getValorP1() + "(" + comp.getSetP1() + ")" + "," + comp.getValorP2() + "(" + comp.getSetP2() + ")" + "]");
                }
                Console.WriteLine();
            }
        }

        public static bool justificarRuta(List<Compuerta> ruta) {

            bool problem = false;


            return problem;
        }

        public static void borrarValores() {

            foreach (Compuerta c in compuertas)
                c.clearValores();

            foreach (Entrada e in entradas)
                e.clearValor();
        }

        public static void generatePaths(){

            //calcula rutas
            int cont = 0;
            foreach (Entrada e in entradas) {

                cont = 0;
                int[] entr = matriz[e.getId() - 1];

                for (int i = 0; i < entr.Length; i++){

                    pathTemp = new List<Compuerta>();
                    if (entr[i] != 0) {

                        pathTemp.Add(compuertas.ElementAt(i));
                        copiarPath(pathTemp);
                        cont++;
                        calculatePath(compuertas.ElementAt(i).getId());
                    }
                }
            }

            evaluarPaths();
            showPaths();
        }

        // calcula las diferentes rutas a partir de una compuerta
        public static void calculatePath(int idCompuerta){
        
            int[] conexiones = matriz[cantEntradas + idCompuerta - 1];
            //Compuerta[] copia = new Compuerta[pathTemp.Count + 1];

            for (int i = 0; i < conexiones.Length; i++) {//agregar siguiente compuerta a pathTemp

                if (conexiones[i] != 0) {

                    pathTemp.Add(compuertas.ElementAt(i));
                    copiarPath(pathTemp);
                    
                    // llamando al metodo recursivo
                    calculatePath(compuertas.ElementAt(i).getId());
                }
                
                //obtener ultima copia donde compuerta actual es la ultima en la lista
                getPath(idCompuerta);
            }
        }

        //copia lista de parametro a la lista de paths
        public static void copiarPath(List<Compuerta> lista_a_copiar) {

            Compuerta[] copia = new Compuerta[lista_a_copiar.Count];

            try {
                lista_a_copiar.CopyTo(copia);
            }
            catch (ArgumentException) {

                Console.WriteLine("largo pathTemp" + lista_a_copiar.Count + ", largo copia:" + copia.Length);
            }

            paths.Add(copia.ToList<Compuerta>());
        }

        //regresa ultima lista que termina con compuerta dada
        public static List<Compuerta> getPath(int idCompuerta) { 
        
            List<Compuerta> temp = new List<Compuerta>();

            foreach (List<Compuerta> lista in paths)
                if (lista.ElementAt(lista.Count - 1).getId() == idCompuerta)
                    temp = lista;

            return temp;
        }

        //elimina paths que no terminan con la compuertaFinal
        private static void evaluarPaths() {

            List<List<Compuerta>> pathsVerdaderos = new List<List<Compuerta>>();

            for (int i = 0; i < paths.Count; i++) {
                if (paths.ElementAt(i).ElementAt(paths.ElementAt(i).Count - 1).getId() == compuertaFinal) {
                    
                    pathsVerdaderos.Add(paths.ElementAt(i));
                    //i--;
                }
                else
                    Console.WriteLine("path invalido termina en: " + paths.ElementAt(i).ElementAt(paths.ElementAt(i).Count - 1).getId());
            }

            paths = pathsVerdaderos;
        }

        //inicializa matriz de adyacencia
        private static void initializeM()
        { 
        
            matriz = new int[(compuertas.Count + entradas.Count)][];

            for (int i = 0; i < matriz.Length; i++)
                matriz[i] = new int[compuertas.Count];

            foreach (Entrada e in entradas)
                e.connect();

            foreach (Compuerta c in compuertas)
                c.connect();

            cantCompuertas = compuertas.Count;
            cantEntradas = entradas.Count;
        }
        
        // muestra todas las rutas del circuito
        private static void showPaths() {

            string display = "";
            Console.WriteLine("\nCantidad de paths: " + paths.Count);
            int cont = 1;
            foreach (List<Compuerta> p in paths) {

                display = cont + ". ";
                foreach (Compuerta c in p) {

                    display += c.getId();
                }
                Console.WriteLine(display);
                cont++;
            }
        }

        // muestra la matriz de adyacencia
        private static void showMatriz() {
            
            Console.WriteLine("Matriz:");
            string display = "";
            for (int i = 0; i < matriz.Length; i++) {
                display = "";
                for (int j = 0; j < matriz[1].Length; j++) {

                    display += matriz[i][j] + "|";
                }
                Console.WriteLine(display);
            }
        }

        //lee xml, llena lista de compuertas y entradas
        private static void configs() {

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
                                int salida = int.Parse(reader.GetAttribute("salida"));
                                Compuerta temp = new Compuerta(id, name, delayP1, delayP2, conn, salida);
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
