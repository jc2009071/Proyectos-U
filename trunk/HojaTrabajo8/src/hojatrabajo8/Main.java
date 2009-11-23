/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package hojatrabajo8;

import java.util.Scanner;

/**
 *
 * @author Luis C
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        // TODO code application logic here

        Scanner scan = new Scanner(System.in);
        Grafo grafo = new Grafo();
        int opcion,nodo1,nodo2,peso;

        do{
            System.out.println();
            System.out.println("menu");
            System.out.println("1. agregar vertice");
            System.out.println("2. agregar enlace");
            System.out.println("3. encontrar camino mas corto");
            System.out.println("4. mostrar");
            System.out.println("5. salir");

            opcion = scan.nextInt();

            switch(opcion){
                case 1:
                    System.out.println("Ingrese nombre del vertice (numero): ");
                    nodo1=scan.nextInt();
                    if(!grafo.agregarNodo(nodo1))
                        System.out.println("Ese vertice ya existe.");
                    break;
                case 2:
                    System.out.println("Ingrese nombre del vertice fuente (numero): ");
                    nodo1=scan.nextInt();
                    System.out.println("Ingrese nombre del vertice destino (numero): ");
                    nodo2=scan.nextInt();
                    System.out.println("Ingrese peso del enlace (numero<1000): ");
                    peso=scan.nextInt();

                    grafo.agregarEnlace(nodo1, nodo2, peso);
                    
                    break;
                case 3:
                    grafo.path();
                    System.out.println("Matriz: ");
                    System.out.println(grafo.mostrar());
                    break;
                case 4:
                    System.out.println("Vertices: ");
                    System.out.println(grafo.toString());
                    System.out.println("Matriz: ");
                    System.out.println(grafo.mostrar());
                    break;
                case 5:

                    break;

                default:
                    System.out.println("Ingreso invalido.");
            }
        }while (opcion!=5);


    }

}
