/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

/**
 *
 * @author Luis C
 */
public interface Interfaz<E> {

    public void add(Nodo temp, E elemento);
    public E remove(E elemento);
    public String mostrar(String conjunto);
}
