/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo8;

/**
 *
 * @author Luis C
 */
public class Grafo {

    Integer[] vertices; //contiene todos los vertices
    Integer[][] matriz; //matriz de adyacencia

    public Grafo(){
        //inicializa los vertices en 0
        vertices = new Integer[10];
        for(int i=0;i<vertices.length;i++)
            vertices[i]=0;

        //inicializa en 1000 (valor muy grande)
        matriz = new Integer[10][10];
        for(int i=0;i<matriz.length;i++)
            for(int j=0; j<matriz.length;j++)
                matriz[i][j]=1000;
    }

    //agrega nodo a arreglo de vertices
    public boolean agregarNodo(int nodo){

        for(int i=0;i<vertices.length;i++){
            //si ya existe devuelve false
            if(vertices[i]==nodo)
                return false;
        }

        for(int i=0;i<vertices.length;i++){
            //si no existe lo agrega y devuelve true
            if(vertices[i]==0){
                vertices[i]=nodo;
                return true;
            }
        }
        return true;
        
    }

    public boolean agregarEnlace(int nodo1, int nodo2, int peso){
        //agrega nodos en caso que no existan
        agregarNodo(nodo1);
        agregarNodo(nodo2);
        int indice1=getPos(nodo1);
        int indice2=getPos(nodo2);

        if(indice1 == -1 || indice2 == -1)
            return false;
        //agrega peso a la matriz
        matriz[indice1][indice2]=peso;

        return true;
    }

    //devuelve posicion del vertice
    public int getPos(int nodo){

        for(int i=0;i<vertices.length;i++){

            if(vertices[i]==nodo)
                return i;
        }

        return -1;
    }

    //muestra arreglo de vertices
    public String toString(){
        String cosa="";
        for(int i=0;i<vertices.length;i++)
            cosa+=vertices[i]+",";
        return cosa;
    }

    //muestra matriz de adyacencia
    public String mostrar(){
        String cosa="";

        for(int i=0; i<matriz.length;i++){
            for(int j=0; j<matriz.length;j++){
                cosa+=matriz[i][j]+",";
            }
            cosa+="\n";
        }
        return cosa;
    }

    /*
     * Encuentra el camino mas corto, modifica la matriz de adyacencia
     */
    public void path(){

        int iteracion=0,valor,valor1,valor2;

        //por iteraciones
        while (iteracion<10){
            //recorre toda la matriz
            for(int i=0;i<matriz.length;i++){
                for(int j=0;j<matriz.length;j++){
                    valor1=matriz[i][iteracion];
                    valor2=matriz[iteracion][j];
                    valor=valor1+valor2;

                    //si esta en la diagonal no cambia valores
                    if(i!=j && j!=iteracion)
                        //si es menor, lo cambia
                        if(valor<matriz[i][j])
                            matriz[i][j]=valor;
                }
            }
            iteracion++;
        }
    }
}
