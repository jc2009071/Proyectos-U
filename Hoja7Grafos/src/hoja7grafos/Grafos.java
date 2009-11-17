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
public class Grafos<E> {
    
    
    protected LinkedList<E> MapaAdyacencia;
    protected LinkedList<LinkedList<Nodo<Integer>>> enlacesLista;

    public Grafos(){
        MapaAdyacencia = new LinkedList<E>();
        enlacesLista = new LinkedList<LinkedList<Nodo<Integer>>>();
    }

    public void setAdjacency_map(LinkedList<E> adjacency_map){
        this.MapaAdyacencia = adjacency_map;
    }

    public LinkedList<E> getAdjacency_map(){
        return MapaAdyacencia;
    }

    public LinkedList<LinkedList<Nodo<Integer>>> getEdges_list(){
        return enlacesLista;
    }

    public void setEnlaceslista(LinkedList<LinkedList<Nodo<Integer>>> enlacesListaTemp) {
        enlacesLista = enlacesListaTemp;
    }

    public boolean agregarVertice(E Nombre) {
        if(getAdjacency_map().contains(Nombre))
            return false;
        else{
            MapaAdyacencia.add(Nombre);
            enlacesLista.add(new LinkedList<Nodo<Integer>>());
            return true;
        }

    }

    public void agregarEnlace(E fuente, E destino, Integer peso) {

        agregarVertice(fuente);
        agregarVertice(destino);
        int temp = getAdjacency_map().indexOf(fuente);

        enlacesLista.get(temp).add(new Nodo<Integer>(destino.toString(),peso));
    }


    /*public String toString(){
    String temp="";
    for(int i=0;i<super.adjacency_map.size();i++){
    temp+=i+"- "+super.adjacency_map.get(i)+" ->\t";
    for(int j=0;j<super.edges_list.get(i).size();j++){
    temp+=super.edges_list.get(i).get(j)+" ";
    }
    temp+="\n";
    }
    return temp;
    }*/



    public String shortestPath(E inicial) {

        valores_minimos = null;
        nodos_pasados = null;

        valores_minimos = new int[MapaAdyacencia.size()];
        viene_de = new Object[MapaAdyacencia.size()];

        nodos_pasados = new boolean[MapaAdyacencia.size()];

        for(int i=0;i<valores_minimos.length;i++){
            valores_minimos[i]=100000000;
            nodos_pasados[i]=false;
            viene_de[i]=null;
        }

        this.nodo_inicial=inicial;
        int posicion_del_nodo_inicial = MapaAdyacencia.indexOf(nodo_inicial);

        valores_minimos[posicion_del_nodo_inicial]=0;//desde si hasta si mismo es cero
        viene_de[posicion_del_nodo_inicial] = MapaAdyacencia.get(posicion_del_nodo_inicial);

        for(int i=0;i<valores_minimos.length;i++){

            calcular_minimo_a_todos(posicion_del_nodo_inicial);
            posicion_del_nodo_inicial = proxima_iteracion();
        }

        String resultado="";
        /*resultado+="------------------------------------------------------------\n";
        resultado+="|\tNodo ==>  ruta más corta para llegar a él ==> Viene de\n";*/

        for(int a=0;a<this.valores_minimos.length;a++){
            if(valores_minimos[a]==100000000){
                resultado+="|\t"+MapaAdyacencia.get(a)+" ==> No es posible llegar.\n";
            }
            else
                resultado+="|\t"+MapaAdyacencia.get(a)+" ==> "+this.valores_minimos[a]+" ==> "+this.viene_de[a]+"\n";
        }
        resultado+="------------------------------------------------------------\n";
        return resultado;
    }

    private void calcular_minimo_a_todos(int posicionInicial) {
        LinkedList<Nodo<Integer>> lista = this.enlacesLista.get(posicionInicial);
        //System.out.println("Lista de "+this.adjacency_map.get(posicion_del_nodo_inicial)+": "+lista);

        this.nodos_pasados[posicionInicial]=true;

        for(int j=0;j<lista.size();j++){
            int posicion = MapaAdyacencia.indexOf(lista.get(j).getNombre());
            int valor = lista.get(j).getPeso()+valores_minimos[posicionInicial];

            //comparar si es menor al que tiene
            if (valor < this.valores_minimos[posicion]){
                valores_minimos[posicion]=valor;
                viene_de[posicion] = MapaAdyacencia.get(posicionInicial);
            }
            //sino lo ignora
        }
    }

    private E nodo_inicial;
    private int[] valores_minimos;
    private boolean[] nodos_pasados;
    private Object [] viene_de;

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
