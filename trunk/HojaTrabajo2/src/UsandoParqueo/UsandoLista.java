
package UsandoParqueo;

/**
 *
 * @author Luis Carlos
 */
public class UsandoLista <E> implements StackInterface {

    Nodo<E> cabeza;     //

    public UsandoLista(){

        cabeza=null;    //inicia cabeza con null
    }

    public E pop() {

        if(cabeza==null){        //si a lista esta vacia regresa null
            return null;
        }

        else{
            Nodo<E> otro = cabeza;      // guarda cabeza en un temporal
            cabeza = otro.siguiente;    // cabeza apunta al siguiente
            return otro.id;             // regresa id
        }

        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void push(E push) {
        cabeza = new Nodo<E>(push, cabeza);
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public E peek() {
        if(cabeza==null)        // si esta vacia regresa null
            return null;
        else
            return cabeza.id;   // regresa ultimo elemento
    }

}
