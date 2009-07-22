

package UsandoParqueo;

/**
 *
 * @author Luis Carlos
 */
public class Nodo<T> {

    public T id;
    public Nodo <T> siguiente;

    public Nodo(T key, Nodo<T> next){

        id = key;
        siguiente = next;

    }

}
