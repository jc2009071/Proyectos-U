/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hoja7grafos;

import java.util.LinkedList;

/**
 *
 * @author Luis C
 */
public class Dijkstra<E> {

    private E nodo_inicial;
    private int[] valores_minimos;
    private boolean[] nodos_pasados;
    private Object [] viene_de;

    public String shortestPath(Grafos grafo, E inicial) {

        valores_minimos = null;
        nodos_pasados = null;

        valores_minimos = new int[grafo.MapaAdyacencia.size()];
        viene_de = new Object[grafo.MapaAdyacencia.size()];

        nodos_pasados = new boolean[grafo.MapaAdyacencia.size()];

        for(int i=0;i<valores_minimos.length;i++){
            valores_minimos[i]=100000000;
            nodos_pasados[i]=false;
            viene_de[i]=null;
        }

        this.nodo_inicial=inicial;
        int posicionInicial = grafo.MapaAdyacencia.indexOf(nodo_inicial);

        valores_minimos[posicionInicial]=0;//desde si hasta si mismo es cero
        viene_de[posicionInicial] = grafo.MapaAdyacencia.get(posicionInicial);

        for(int i=0;i<valores_minimos.length;i++){

            calcular_minimo_a_todos(grafo, posicionInicial);
            posicionInicial = proxima_iteracion();
        }

        String resultado="";
        /*resultado+="-------------------------- ----------------------------------\n";
        resultado+="|\tNodo ==>  ruta más corta para llegar a él ==> Viene de\n";*/

        for(int a=0;a<this.valores_minimos.length;a++){
            if(valores_minimos[a]==100000000){
                resultado+="|\t"+grafo.MapaAdyacencia.get(a)+" ==> No es posible llegar.\n";
            }
            else
                resultado+="|\t"+grafo.MapaAdyacencia.get(a)+" ==> "+this.valores_minimos[a]+" ==> "+this.viene_de[a]+"\n";
        }
        resultado+="------------------------------------------------------------\n";
        return resultado;
    }

    private void calcular_minimo_a_todos(Grafos grafo, int posicionInicial) {
        LinkedList<Nodo<Integer>> lista = (LinkedList<Nodo<Integer>>) grafo.enlacesLista.get(posicionInicial);
        //System.out.println("Lista de "+this.adjacency_map.get(posicion_del_nodo_inicial)+": "+lista);

        this.nodos_pasados[posicionInicial]=true;

        for(int j=0;j<lista.size();j++){
            int posicion = grafo.MapaAdyacencia.indexOf(lista.get(j).getNombre());
            int valor = lista.get(j).getPeso()+valores_minimos[posicionInicial];

            //comparar si es menor al que tiene
            if (valor < this.valores_minimos[posicion]){
                valores_minimos[posicion]=valor;
                viene_de[posicion] = grafo.MapaAdyacencia.get(posicionInicial);
            }
            //sino lo ignora
        }
    }



    private int proxima_iteracion() {
        //encontrar el nodo por el que no se haya pasado y que tenga el minimo peso

        int minimo = 999999999;
        int posicion_minimo=0;

        for(int k=0;k<valores_minimos.length;k++){
            if(this.nodos_pasados[k]==false){
                if(this.valores_minimos[k]<minimo){
                    minimo=valores_minimos[k];
                    posicion_minimo=k;
                }
            }
        }

        return posicion_minimo;
    }


}
