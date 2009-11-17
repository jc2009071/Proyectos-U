/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hoja7grafos;

/**
 *
 * @author Luis C
 */
public class Nodo<E> {

    String nombre;
    E peso;

    public Nodo(String name){

        nombre = name;
    }

    public Nodo(String Nombre, E pesoTemp) {

        nombre=Nombre;
        peso=pesoTemp;
    }


    public void setNombre(String Nombre){

         nombre = Nombre;
    }

    public String getNombre() {
        return nombre;
    }

    public E getPeso() {
        return peso;
    }

    public void setPeso(E pesoTemp) {
        peso = pesoTemp;
    }


}
