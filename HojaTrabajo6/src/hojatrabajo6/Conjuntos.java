/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

/**
 *
 * @author Luis C
 */
public class Conjuntos<E> implements InterfazConjuntos<E> {

    private Arbol23 arbolA = new Arbol23();
    private Arbol23 arbolB = new Arbol23();
    private Arbol23 arbolC = new Arbol23();

    public void add(E conjunto, E elemento) {

        if(conjunto.toString().equals("A"))
            arbolA.add(elemento);
        else
            if(conjunto.toString().equals("B"))
                arbolB.add(elemento);

        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public E remove(E conjunto, E elemento) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public void union() {
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void interseccion() {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public String mostrar(String print) {

        if(print.equals("A"))
            return arbolA.mostrar();
        else
            if(print.equals("B"))
                return arbolB.mostrar();
            else
                if(print.equals("C"))
                    return arbolC.mostrar();
                else
                    return "";
        //throw new UnsupportedOperationException("Not supported yet.");
    }

}