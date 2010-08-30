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
        public static List<int[]> vectores = new List<int[]>();
        public static List<Compuerta> pathTemp = new List<Compuerta>();
        public static int compuertaFinal, cantCompuertas, cantEntradas;
        public static int[][] matriz;
        public static int[][] vectoresPrueba;
        // [0] = valorDelay, [1] = pos de path en paths, [2]: Rising = 1 y falling = 0
        public static int[] critical = {-1, -1, -1};
        public static int[] shortest = {-1, -1, -1};
        
        static void Main(string[] args) {

            configs();
            initializeM();
            showMatriz();
            inicializarVectoresPrueba();

            generatePaths();
            main();

            Console.Read();
        }

        public static void main(){

            for (int i = 0; i < paths.Count; i++) {

                sensibilizarRuta(paths.ElementAt(i));

                justificarRuta(paths.ElementAt(i), i);
                //showJustificacion();

                calcularDelayR(i);
                calcularDelayF();

                borrarValores();
            }
        }

        public static void calcularDelayF(int pos) {

            int delayTemp = 0;
            int[] vector = vectores.ElementAt(pos); 
            for (int i = 0; i < paths.Count; i++) {

                delayTemp = 0;
                for (int j = 0; j < paths.ElementAt(i).Count; j++) {


                }
            }


            if (delayTemp > critical[0]) {

                //poner delay, pos path, Falling = 0
                critical[0] = delayTemp;
                critical[1] = pos;
                critical[2] = 0;
            }

            if (shortest[0] != -1)
                if (delayTemp < shortest[0]) {

                    shortest[0] = delayTemp;
                    shortest[1] = pos;
                    shortest[2] = 0;
                }
        }

        public static void calcularDelayR(int pos) {

            int delayTemp = 0;
            for (int i = 0; i < paths.Count; i++) {

                delayTemp = 0;
                for (int j = 0; j < paths.ElementAt(i).Count; j++) {
                

                }
            }

            if (delayTemp > critical[0]) { 
            
                //poner delay, pos path, Rising = 1
                critical[0] = delayTemp;
                critical[1] = pos;
                critical[2] = 1;
            }

            if (shortest[0] != -1)
                if (delayTemp < shortest[0]) {

                    shortest[0] = delayTemp;
                    shortest[1] = pos;
                    shortest[2] = 1;
                }
        }

        public static void justificarRuta(List<Compuerta> ruta, int pos)
        {

            int entradaConstante = getEntradaPath(ruta);
            int cont = 0;
            bool conflicto = false;
            for (int j = 0; j < vectoresPrueba.Length; j++) {

                cont = 0;
                //assignar valores a probar
                for (int i = 0; i < entradas.Count; i++) {

                    if (entradas.ElementAt(i).getId() != (entradaConstante + 1)) {

                        if (vectoresPrueba[j][cont] == 1)
                            entradas.ElementAt(i).setValor(true);
                        else
                            entradas.ElementAt(i).setValor(false);

                        cont++;
                    }
                }

                //comprobar si valores crean conflictos
                for (int path = 0; path < paths.Count; path++) {

                    int entrada = getEntradaPath(paths.ElementAt(path));
                    int pata = 0;
                    bool valor = false, setear = true;

                    if (entrada == entradaConstante)
                        continue;

                    if (pos == path)
                        continue;

                    //por cada compuerta en cada ruta
                    for (int i = 0; i < paths.ElementAt(path).Count; i++) {

                        //calcular pata
                        pata = getPata(paths.ElementAt(path), i);

                        // calcular valor
                        if (i == 0)
                            valor = entradas.ElementAt(entrada).getValor();
                        else {

                            if (paths.ElementAt(path).ElementAt(i - 1).seteable()) {

                                paths.ElementAt(path).ElementAt(i - 1).setSalida();
                                valor = paths.ElementAt(path).ElementAt(i - 1).getSalida();
                                setear = true;
                            }
                            else
                                setear = false;
                        }


                        if (setear)
                            conflicto = paths.ElementAt(path).ElementAt(i).justificar(pata, valor);
                        else
                            continue;

                        if (conflicto)
                            break;
                        
                    }
                    //TODO donde c verifica esto?

                    //verificar si hubo coflicto
                    if (conflicto)
                        break;
                    else //vector valido
                        continue;
                }

                if (conflicto)
                    continue;
                else {

                    //guardar vector y path en el q no genera conflictos
                    // terminar ciclos de prueba
                    vectores.Insert(pos, vectoresPrueba[j]);
                    break;
                } 
            }
        }

        public static void showJustificacion() {

            foreach (Compuerta comp in compuertas) {

                Console.WriteLine(comp.getId() + ". " + comp.getNombre() + "[" + comp.getValorP1() + "(" + comp.getSetP1() + ")" + "," + comp.getValorP2() + "(" + comp.getSetP2() + ")" + "]");
            }

            foreach (int[] a in vectores) {

                foreach (int b in a) {

                    Console.Write(b + ", ");
                }
                Console.WriteLine();
            }
        }

        // devuelve para en la q tiene la coneccion
        public static int getPata(List<Compuerta> ruta, int pos) {

            int x = ruta.ElementAt(pos).getId() - 1;
            int y;

            if (pos < 1)
                //esta conectado con una entrada
                y = getEntradaPath(ruta);
            else
                y = entradas.Count + ruta.ElementAt(pos - 1).getId() - 1;

            return matriz[y][x];
        }

        //devuelve la entrada que esta conectada a la primera compuerta de la ruta
        public static int getEntradaPath(List<Compuerta> ruta) {

            int idTemp = ruta.ElementAt(0).getId();
            int entrada = 0;

            for (int i = 0; i < matriz.Length; i++) {

                if (matriz[i][idTemp - 1] > 0) {

                    entrada = i;
                    break;
                }
            }

            return entrada;
        }

        //reinicia valores de las entradas
        public static void reiniciarEntradas() {

            foreach (Entrada e in entradas)
                e.clearValor();
        }

        public static void inicializarVectoresPrueba() {

            vectoresPrueba = new int[32][];

            for (int i = 0; i < vectoresPrueba.Length; i++)
                vectoresPrueba[i] = new int[5];

            // 0,1,0,1,0,1...
            for (int i = 0; i < vectoresPrueba.Length; i++) {

                if ((i % 2) == 0) {

                    vectoresPrueba[i][0] = 0;
                }
                else {

                    vectoresPrueba[i][0] = 1;
                }
            }

            //0,0,1,1,0,0,1,1...
            int cont = 1;
            for (int i = 0; i < vectoresPrueba.Length; i++) {

                if (cont == 1 || cont == 2) {

                    vectoresPrueba[i][1] = 0;
                    cont++;
                }
                else if (cont == 3 || cont == 4){

                    vectoresPrueba[i][1] = 1;

                    if (cont == 4)
                        cont = 1;
                    else
                        cont++;
                }
            }

            // 0,0,0,0,1,1,1,1,0,0,0,0,1,1,1,1...
            cont = 1;
            for (int i = 0; i < vectoresPrueba.Length; i++) {

                if (cont >0 && cont < 5) {

                    vectoresPrueba[i][2] = 0;
                    cont++;
                }
                else if (cont > 4 || cont < 9)
                {

                    vectoresPrueba[i][2] = 1;

                    if (cont == 8)
                        cont = 1;
                    else
                        cont++;
                }
            }


            // 8 veces 0, 8 veces 1,...
            cont = 1;
            for (int i = 0; i < vectoresPrueba.Length; i++) {

                if (cont > 0 && cont < 9) {

                    vectoresPrueba[i][3] = 0;
                    cont++;
                }
                else if (cont > 4 || cont < 17) {

                    vectoresPrueba[i][3] = 1;

                    if (cont == 16)
                        cont = 1;
                    else
                        cont++;
                }
            }

            // 16 veces 0, 16 veces 1,...
            cont = 1;
            for (int i = 0; i < vectoresPrueba.Length; i++) {

                if (cont > 0 && cont < 17) {

                    vectoresPrueba[i][4] = 0;
                    cont++;
                }
                else if (cont > 4 || cont < 33) {

                    vectoresPrueba[i][4] = 1;

                    if (cont == 32)
                        cont = 1;
                    else
                        cont++;
                }
            }
        }


        //muestra vectores de prueba
        public static void showVectoresPrueba() {

            Console.WriteLine("vectores:");
            string display = "";
            for (int i = 0; i < vectoresPrueba.Length; i++)
            {
                display = "";
                for (int j = 0; j < vectoresPrueba[1].Length; j++)
                {

                    display += vectoresPrueba[i][j] + "|";
                }
                Console.WriteLine(display);
            }
        }

        // sensibiliza la ruta dada
        public static bool sensibilizarRuta(List<Compuerta> ruta)
        {

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

        // muestra valores de las entradas para verificar sensibilizacion
        public static void showSensibilizacion() {

            foreach (List<Compuerta> ruta in paths) {
                foreach (Compuerta comp in ruta) {

                    Console.Write(comp.getNombre() + "[" + comp.getValorP1() + "(" + comp.getSetP1() + ")" + "," + comp.getValorP2() + "(" + comp.getSetP2() + ")" + "]");
                }
                Console.WriteLine();
            }
        }

        //reinicia todos los valores de las entradas y compuertas
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
