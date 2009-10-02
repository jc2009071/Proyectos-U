/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo6;

/**
 *
 * @author Luis C
 */
public class Arbol23<E> implements Interfaz<E>{

    Nodo<Integer> padre;

    public Arbol23(){
        padre = new Nodo("");
    }

    public void arreglar(Nodo temp, E elemento) {

        int element = Integer.parseInt(elemento.toString());

        int dato, temporal;
        temp.check();
        if(!temp.datos){
            if(temp.getData1().toString().equals("") || temp.getData1()==null)
                temp.setData1(element);
            else{
                dato = Integer.parseInt(temp.getData1().toString());
                if(element<dato && temp.getData2()==null){
                    temporal = dato;
                    temp.setData1(element);
                    temp.setData2(dato);
                }
                else
                    if(temp.getData2()==null)
                        temp.setData2(element);

            }
        }

        else{

            if(element<Integer.parseInt(temp.getData1().toString())){
                temp.check();
                if(temp.getIzq()==null){
                    temp.setIzq(new Nodo(element));
                }
                else{
                    if(!temp.getIzq().datos){
                        arreglar(temp.getIzq(), elemento);
                    }
                }
              
            }
            else{

                if(element>Integer.parseInt(temp.getData1().toString()) && element<Integer.parseInt(temp.getData2().toString())){
                    temp.check();
                    if(temp.getCentro()==null){
                        temp.setCentro(new Nodo(element));
                    }
                    else{
                        if(!temp.getCentro().datos){
                            arreglar(temp.getCentro(), elemento);
                        }
                    }
                }
                else{
                    if(element>Integer.parseInt(temp.getData2().toString())){
                        temp.check();
                        if(temp.getDer()==null){
                            temp.setDer(new Nodo(element));
                        }
                        else{
                            if(!temp.getDer().datos)
                                arreglar(temp.getDer(), elemento);
                        }
                    }
                }
            }
        }
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public E remove(E elemento) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public String mostrar() {
        return padre.toString();
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void add(E elemento) {
        arreglar(padre, elemento);
        //throw new UnsupportedOperationException("Not supported yet.");
    }

}
