/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package UsandoParqueo;
import java.util.Scanner;
/**
 *
 * @author Administrator
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {

        // UsandoArreglo<String> pila = new UsandoArreglo<String>();
         UsandoLista<String> parq = new UsandoLista<String>();

         Scanner scan = new Scanner(System.in);
         String ingreso;




        // TODO code application logic here
               int opcion;
               do {
            System.out.println("\n**************************************");
            System.out.println("*           Hoja de Trabajo 2        *");
            System.out.println("**************************************");
            System.out.println("1. Ingreso de vehiculos");
            System.out.println("2. Salida de vehiculos");
            System.out.println("3. Ultima placa ingresada");
            System.out.println("4. Salir");
            System.out.println("\nIngrese la opcion deseada: ");
            opcion = scan.nextInt();
            scan.nextLine();//ENTER
            System.out.println("");

            switch (opcion) {

                case 1:
                    System.out.println("Ingrese la placa de su vehiculo: ");
                    ingreso = scan.nextLine();
                    parq.push(ingreso);
                    break;


                case 2:
                    System.out.println("Vehiculo sacado con placa: ");
                    System.out.println(parq.pop());
                    break;

                case 3:
                    System.out.println("Ultima placa ingresada: " + parq.peek());
                    break;

                default:
                    System.out.println("Ingreso invalido, intentelo de nuevo");
            }


        } while (opcion != 4);
    }

}
