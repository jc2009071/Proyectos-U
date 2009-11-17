/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hoja7grafos;

import java.util.HashMap;
import java.util.LinkedList;

/**
 *
 * @author Luis C
 */
public class Grafo<E> {

    HashMap MapaAdyacencia;

    public Grafo(){

        MapaAdyacencia = new HashMap();
    }

    public int getCuantaArcos(){

        int cuenta = 0;
        for(int i =0; i<MapaAdyacencia.capacity; i++){

            if(MapaAdyacencia.keySet()[i] != null){

                LinkedList arcos = (LinkedList) MapaAdyacencia.get(MapaAdyacencia.keySet[i]);
                cuenta += arcos.size();
            }
        }
        return cuenta;
    }

    public boolean agregarVertice(E vertice){

        if(MapaAdyacencia.containsKey(vertice))
            return false;

        MapaAdyacencia.put(vertice, new LinkedList());
        return true;
    }

    public boolean agregarArco(E vertice1, E vertice2){

        agregarVertice(vertice1);
        agregarVertice(vertice2);

        LinkedList  temp = (LinkedList) MapaAdyacencia.get(vertice1);
        temp.add(vertice2);
        return true;
    }

    public boolean isEmpty(){

        return MapaAdyacencia.isEmpty();
    }

    public int size(){

        return MapaAdyacencia.size();
    }

}
