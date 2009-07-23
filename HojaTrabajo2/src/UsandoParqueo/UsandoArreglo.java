

package UsandoParqueo;
/**
 *
 * @author Luis Carlos
 */
public class UsandoArreglo<E> implements StackInterface<E> {

  E[] arreglo = (E[]) new Object [10];
  private int pointer;

  public UsandoArreglo(){
    pointer = 0;
  }

  public E pop() {

      E temp = (E) "";

      if(pointer >0){
        temp =arreglo[pointer-1];
        arreglo[pointer-1]=null;
      }

      pointer--;
      return temp;
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public void push(E temp) {

        if(pointer<9){

            arreglo[pointer]= temp;
            pointer++;
        }
        //throw new UnsupportedOperationException("Not supported yet.");
    }

    public E peek() {

        E temp = (E) "";
        if(pointer>0){
            temp = arreglo[pointer-1];
        }
        else
            temp  = null;

        return temp;
        //throw new UnsupportedOperationException("Not supported yet.");
    }

}
