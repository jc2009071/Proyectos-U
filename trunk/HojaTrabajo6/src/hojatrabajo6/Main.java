

package hojatrabajo6;

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
        Scanner scan = new Scanner(System.in);
        Conjuntos conjuntos = new Conjuntos();
        int opcion = 0, valor;
        String conjunto;
        boolean error = true;
        
        do{

        System.out.println("\n               MENU\n");
        System.out.println("Elija una opcion:");
        System.out.println("1. Agregar Elementos al conjunto A o B");
        System.out.println("2. Retirar Elementos del conjunto A o B");
        System.out.println("3. Formar un conjunto nuevo C, que sea A union B");
        System.out.println("4. Formar un conjunto nuevo C, que sea A interseccion B");
        System.out.println("5. Mostrar cualquiera de los conjuntos");
        System.out.println("6. Salir");

                opcion = scan.nextInt();
            
        switch(opcion){
            case 1:
                error = true;
                while(error){
                    System.out.println("Elija conjunto: A o B");
                    conjunto = scan.next();
                    System.out.println("Ingrese Elemento");
                    valor=scan.nextInt();

                    if(conjunto.equalsIgnoreCase("a")){
                        error = false;
                        conjuntos.add("A", valor);

                    }
                    else
                        if(conjunto.equalsIgnoreCase("b")){
                            error = false;
                            conjuntos.add("B", valor);
                        }
                        else{
                            System.out.println("No existe ese conjunto");
                            error = true;
                        }
                }

                break;

            case 2:
                error = true;
                while(error){
                    System.out.println("Elija conjunto: A o B");
                    conjunto = scan.next();
                    System.out.println("Ingrese Elemento");
                    valor=scan.nextInt();

                    if(conjunto.equalsIgnoreCase("a")){
                        error = false;
                        conjuntos.remove("B", valor);
                    }
                    else
                        if(conjunto.equalsIgnoreCase("b")){
                            error = false;
                            conjuntos.remove("B", valor);
                        }
                        else{
                            System.out.println("No existe ese conjunto");
                            error = true;
                        }
                }
                break;

            case 3:
                conjuntos.union();
                System.out.println("Conjunto C creado.");
                break;

            case 4:
                conjuntos.interseccion();
                System.out.println("Conjunto C creado.");
                break;

            case 5:
                error = true;
                while(error){
                    System.out.println("Elija conjunto: A, B o C");
                    conjunto = scan.next();

                    if(conjunto.equalsIgnoreCase("a")){
                        error = false;
                        System.out.println(conjuntos.mostrar("A"));
                    }
                    else
                        if(conjunto.equalsIgnoreCase("b")){
                            error = false;
                            System.out.println(conjuntos.mostrar("B"));
                        }
                        else
                            if(conjunto.equalsIgnoreCase("c")){
                                error = false;
                                System.out.println(conjuntos.mostrar("C"));
                            }
                            else{
                                System.out.println("No existe ese conjunto");
                                error = true;
                            }
                }
                break;

            case 6:
                System.out.println("Adios");
                break;

            default:
                System.out.println("Error de ingreso.");
                System.out.println();

        }



        }while(opcion!=6);
    }

}
