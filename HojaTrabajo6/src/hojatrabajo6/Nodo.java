/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

/**
 *
 * @author Luis C
 */
public class Nodo<E> {

        private E data1=null, data2=null;
        boolean completo=false, datos=false;
        private Nodo<E> padre, izquierdo, derecho, centro;

        public Nodo(E value){
            padre = izquierdo = derecho = centro = null;
            if(data1==null)
                data1=value;
            else
                data2=value;
        }

        public E getData1(){
            return data1;
        }

        public void setData1(E dato){
            data1=dato;
        }

        public E getData2(){
            return data2;
        }

        public void setData2(E dato){
            data2= dato;
        }

        public Nodo<E> getIzq(){
            return izquierdo;
        }
        public void setIzq(Nodo<E> izq){
            izquierdo = izq;
        }

        public Nodo<E> getDer(){
            return derecho;
        }

        public void setDer(Nodo<E> der){
            derecho = der;
        }

        public Nodo<E> getPadre(){
            return padre;
        }

        public void setPadre(Nodo<E> temp){
            padre=temp;
        }

        public Nodo<E> getCentro(){
            return centro;
        }

        public void setCentro(Nodo<E> temp){
            centro=temp;
        }

        public void check(){
            if(izquierdo!=null && derecho!=null && centro!=null && data1!=null && data2!=null)
                completo = true;
            else
                completo = false;

            if(data1!=null && data2!=null)
                datos =true;
            else
                datos = false;

        }

    @Override
        public String toString(){
            String print="";

            if(izquierdo!=null)
                print+=izquierdo.toString();

            if(data1!=null)
                print+=data1;

            if(centro!=null)
                print+=centro.toString();

            if(data1!=null)
                print+=data2;

            if(derecho!=null)
                print+= derecho.toString();

            return print;
        }

        
}
