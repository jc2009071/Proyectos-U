/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package UsandoParqueo;

/**
 *
 * @author Administrator
 */
public class Nodo<T> {

    public T id;
    public Nodo <T> siguiente;

    public Nodo(T key, Nodo<T> next){

        id =key;
        siguiente = next;

    }
}
