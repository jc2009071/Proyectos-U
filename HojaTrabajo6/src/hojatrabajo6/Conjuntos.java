/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

import java.util.LinkedList;

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
        
        Integer[] temp_a = preparar("A");
        Integer[] temp_b = preparar("B");
        LinkedList temp = new LinkedList();
        
        for(int i=0; i<temp_a.length || i<temp_b.length ;i++){
            if(temp_a[i]<temp_b[i]){
                temp.add(temp_a[i]);
                temp.add(temp_b[i]);
            }
            else{
                if(temp_a[i]>temp_b[i]){
                    temp.add(temp_b[i]);
                    temp.add(temp_a[i]);
                }
            }
        }

        for(int i =0; i<temp.size(); i++)
            arbolC.add(temp.get(i));

        int i=0, j=0;
        
                    
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void interseccion() {
        Integer[] temp_a = preparar("A");
        Integer[] temp_b = preparar("B");
        LinkedList temp = new LinkedList();

        for(int i=0; i<temp_a.length || i<temp_b.length ;i++){
        }
        
        //throw new UnsupportedOperationException("Not supported yet.");
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

    public Integer[] preparar(String arbol){

        if(arbol.equalsIgnoreCase("A")){

            String a = mostrar("A");

            a=a.replaceAll(" ", ",");
            while(a.contains(",,"))
                a=a.replaceAll(",,", ",");
            a=a.substring(1);

            String[] temp_a1 = a.split(",");
            Integer[] temp_a = new Integer[temp_a1.length];

            for(int i=0; i<temp_a1.length ; i++){
                temp_a[i]=Integer.parseInt(temp_a1[i].toString());
            }

            return temp_a;
        }
        else{
            String b = mostrar("B");

            b=b.replaceAll(" ", ",");
            while(b.contains(",,"))
                b=b.replaceAll(",,", ",");

            b=b.substring(1);
            String[] temp_b1 = b.split(",");
            Integer[] temp_b = new Integer[temp_b1.length];

            for(int i=0; i<temp_b1.length ; i++){
                temp_b[i]=Integer.parseInt(temp_b1[i]);
            }

            return temp_b;
        }
    }

}
