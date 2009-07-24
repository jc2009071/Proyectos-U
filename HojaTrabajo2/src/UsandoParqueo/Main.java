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

        //cambiar para usar diferente implementacion
        UsandoArreglo<String> parq = new UsandoArreglo<String>();
        // UsandoLista<String> parq = new UsandoLista<String>();

         Scanner scan = new Scanner(System.in);
         String ingreso;

               int opcion;
               do { //menu
            System.out.println("\n**************************************");
            System.out.println("*           Hoja de Trabajo 2        *");
            System.out.println("**************************************");
            System.out.println("1. Ingreso de vehiculos");
            System.out.println("2. Salida de vehiculos");
            System.out.println("3. Ultima placa ingresada");
            System.out.println("4. Salir");
            System.out.println("\nIngrese la opcion deseada: ");
            opcion = scan.nextInt(); // ingreso de opcion
            scan.nextLine();//ENTER
            System.out.println("");

            switch (opcion) {

                case 1:// ingreso de vehiculos
                    System.out.println("Ingrese la placa de su vehiculo: ");
                    ingreso = scan.nextLine();
                    parq.push(ingreso);
                    break;

                case 2://solo saca el ultimo vehiculo
                    System.out.println("Vehiculo sacado con placa: " + parq.pop());
                    break;

                case 3://muestra la ultima placa
                    System.out.println("Ultima placa ingresada: " + parq.peek());
                    break;

                case 4: // mensaje de despedida
                    System.out.println("Adios\n");
                    break;

                default: // programacion defensiva
                    System.out.println("Ingreso invalido, intentelo de nuevo");
            }
        } while (opcion != 4);//condicion para salir del ciclo
    }

}
