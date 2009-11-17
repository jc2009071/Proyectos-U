/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hoja7grafos;

/**
 *
 * @author Luis C
 */
public class Enlace<E> {

    String nombre;
    E peso;

    public Enlace(String name, E peso_temp){

        nombre=name;
        peso = peso_temp;
    }

    public void setNombre(String name){
        nombre = name;
    }

    public String getNombre(){
        return nombre;
    }

    public void setPeso(E peso_temp){
        peso = peso_temp;
    }

    public E getPeso(){
        return peso;
    }
}
