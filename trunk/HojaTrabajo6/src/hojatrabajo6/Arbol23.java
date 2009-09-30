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

    public void add(Nodo temp, E elemento) {

        int element = Integer.parseInt(elemento.toString());

        int dato, temporal;
        if(!padre.datos){
            if(padre.getData1().toString().equals(""))
                padre.setData1(element);
            else{
                dato=padre.getData1();
                if(element<dato){
                    temporal = dato;
                    padre.setData1(element);
                    padre.setData2(dato);
                }
                else
                    padre.setData2(element);

            }
        }

        else{

            if(element<padre.getData1()){
                if(!padre.getIzq().datos){
                    if(padre.getIzq()==null)
                        padre.setIzq(new Nodo(element));
                    else
                        add(padre.getIzq(), elemento);
                }
                else{

                }

            }
            else{

                if(element>padre.getData1() && element<padre.getData2()){
                    if(!padre.getCentro().datos){
                        if(!padre.getCentro().datos){
                            if(padre.getCentro()==null)
                                padre.setCentro(new Nodo(element));
                            else
                                add(padre.getCentro(), elemento);
                        }
                    }
                    else{

                    }
                }
                else
                    if(element>padre.getData2()){
                        if(!padre.getDer().datos){
                            if(!padre.getDer().datos){
                                if(padre.getDer()==null)
                                    padre.setDer(new Nodo(element));
                                else
                                    add(padre.getDer(), elemento);
                            }
                        }
                        else{

                        }
                    }
            }
        }
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public E remove(E elemento) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

    public String mostrar(String conjunto) {
        throw new UnsupportedOperationException("Not supported yet.");
    }

}
