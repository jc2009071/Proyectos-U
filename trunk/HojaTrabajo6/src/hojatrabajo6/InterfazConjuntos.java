/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

/**
 *
 * @author Luis C
 */
public interface InterfazConjuntos<E> {

    public void add(E conjunto, E elemento);
    public E remove(E conjunto, E elemento);
    public void union();
    public void interseccion();
    public String mostrar(String print);

}
