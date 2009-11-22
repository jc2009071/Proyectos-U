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

    Integer[] vertices;
    Integer[][] matriz;

    public Grafo(){
        
        vertices = new Integer[10];
        for(int i=0;i<vertices.length;i++)
            vertices[i]=0;
        
        matriz = new Integer[10][10];
        for(int i=0;i<matriz.length;i++)
            for(int j=0; j<matriz.length;j++)
                matriz[i][j]=1000;
    }

    public boolean agregarNodo(int nodo){

        for(int i=0;i<vertices.length;i++){

            if(vertices[i]==nodo)
                return false;
        }

        for(int i=0;i<vertices.length;i++){

            if(vertices[i]==null)
                vertices[i]=nodo;
        }
        return true;
    }

    public boolean agregarEnlace(int nodo1, int nodo2, int peso){

        agregarNodo(nodo1);
        agregarNodo(nodo2);
        int indice1=getPos(nodo1);
        int indice2=getPos(nodo2);

        if(indice1 == -1 || indice2 == -1)
            return false;

        matriz[indice1][indice2]=peso;

        return true;
    }

    public int getPos(int nodo){

        for(int i=0;i<vertices.length;i++){

            if(vertices[i]==nodo)
                return i;
        }

        return -1;
    }

    @Override
    public String toString(){

        return vertices.toString();
    }

    public String mostrar(){

        return matriz.toString();
    }
}
