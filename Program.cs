using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_Lista_Concesionario
{
    /*Crea una clase Automovil con los datos básicos de los automóviles (marca, modelo, cilindrada, año de fabricación, etc) 
    y los métodos necesarios para poder usarla con comodidad.

    Crea una clase Program con una serie de métodos que nos permitan trabajar con una lista genérica de automóviles.

    - Necesitaremos un Método AñadeAutomovil que a partir de una lista y un automóvil, añadirá este a la lista.

    - EliminaAutomovil que eliminará el automóvil con el índice i que se haya pasado como argumento.

    - Crea un método AutomovilesPorAñoFabricacion, que te permita encontrar en la lista los coches con una determinada fecha de fabricación 
    y que retorne una nueva lista con esos datos.

    - Otro método AutomovilesPorAñoFabricacionYColor que devuelva una sublista con los coches de la lista que sean de un determinado color 
    y una fecha pasados ambos como parámetros.

    - Método que permita mostrar el contenido de la lista.*/

    class Automovil
    {
        public string Marca {get; private set;}
        public string Modelo {get; private set;}
        public double Cilindrada {get; private set;}
        public int AñoFabricacion {get; private set;}
        public string Color {get; private set;}

        public Automovil(string marca, string modelo, double cilindrada, int añoFabricacion, string color)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Cilindrada = cilindrada;
            this.AñoFabricacion = añoFabricacion;
            this.Color = color;
        }

        public override string ToString() => $"\nMarca: {Marca}"
                                            +$"\nModelo: {Modelo}"
                                            +$"\nCilindrada: {Cilindrada}"
                                            +$"\nAño de Fabricación: {AñoFabricacion}"
                                            +$"\nColor: {Color}"
                                            +$"\n------------------------------------------\n";
    }
    class Program
    {
        static void Main(string[] args)
        {
            var automovil = new List<Automovil>();

            automovil.Add(new Automovil("Audi", "A4", 2500, 1995, "Rojo"));
            automovil.Add(new Automovil("BMW", "X5", 3200, 2007, "Negro"));
            automovil.Add(new Automovil("Opel", "Astra", 1800, 1995, "Rojo"));
            automovil.Add(new Automovil("Volkswagen", "Golf", 1500, 2007, "Gris"));
            automovil.Add(new Automovil("Mini", "CountryMan", 2100, 2000, "Azul"));
            automovil.Add(new Automovil("Toyota", "CH-R", 2800, 2013, "Blanco"));
            automovil.Add(new Automovil("Seat", "Ibiza", 1300, 1995, "Perla"));

            Menu(automovil);
        }

        static void AñadeAutomovil(List<Automovil> automovil)
        {
            int numeroCoches = 0;
            try{
                Console.Write("Introduce el nº de automoviles que quieres agregar: ");
                numeroCoches = Int32.Parse(Console.ReadLine());
            }catch(FormatException){
                Console.WriteLine("Sólo se pueden introducir valores numericos");
            }

            for(int i = 0; i < numeroCoches; i++){
                Console.WriteLine($"Introduce la marca del automovil nº {i + 1}:");
                string marca = Console.ReadLine();
                Console.WriteLine($"Introduce el modelo del automovil nº {i + 1}:");
                string modelo = Console.ReadLine();
                Console.WriteLine($"Introduce la cilindrada del automovil nº {i + 1}");
                double cilindrada = Double.Parse(Console.ReadLine());
                Console.WriteLine($"Introduce el Año de fabriación del automovil nº {i + 1}");
                int añoFabricacion = Int32.Parse(Console.ReadLine());
                Console.WriteLine($"Introduce el color del automovil nº {i + 1}");
                string color = Console.ReadLine();

                automovil.Add(new Automovil(marca, modelo, cilindrada, añoFabricacion, color));
            }
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void EliminaAutomovil(List<Automovil> automovil)
        {
            Console.WriteLine("Ha seleccionado la opción de Eliminar Automovil."
                            +$"\nA continuación se le muestra la lista de Automoviles actual:\n");
            
            for(int i = 0; i < automovil.Count; i++){
                Console.WriteLine($"Automovil {i + 1} \n{automovil[i]}");
            }

            Console.WriteLine("Seleccione el nº de automovil que desea eliminar:");
            byte numero = Byte.Parse(Console.ReadLine());

            for (int i = 0; i < automovil.Count; i++){
                if (numero == i){
                    automovil.RemoveAt(i - 1);
                    Console.WriteLine($"\nAutomovil número {i} eliminado");
                }
            }

            Console.WriteLine("\nMostrando lista de automoviles actualizada...\n");

            for(int i = 0; i < automovil.Count; i++){
                Console.WriteLine($"Automovil {i + 1} \n{automovil[i]}");
            }
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void AutomovilesPorAñoFabricacion(List<Automovil> automovil)
        {
            Console.WriteLine("\nIntroduzca un año de fabricación para encontrar el automoviles de ese mismo año"
                            + "\nSi no se encuentran coincidencias el programa volverá al menú principal");
            int año = Int32.Parse(Console.ReadLine());

            foreach(Automovil coche in automovil){
                if(coche.AñoFabricacion == año){
                    Console.WriteLine(coche.ToString());
                }
            }
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void AutomovilesPorAñoFabricacionYColor(List<Automovil> automovil)
        {
            Console.WriteLine("\nIntroduzca el año de fabricación y el color del coche, para visualizar los coches con el mismo año de fabricación y color."
                            + "\nSi no se encuentran coincidencias el programa volverá al menu principal");
            Console.Write("Introduzca el año de fabricación: ");
            int año = Int32.Parse(Console.ReadLine());
            Console.Write("Introduzca el color: ");
            string color = Console.ReadLine();

            foreach(Automovil coche in automovil){
                if(coche.AñoFabricacion == año && coche.Color == color){
                    Console.WriteLine(coche.ToString());
                }
            }
            Console.WriteLine("\nPulse cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        static void MuestraLista(List<Automovil> automovil)
        {
            Console.WriteLine("Mostrando autmoviles de la lista:");
            foreach(Automovil coche in automovil){
                Console.WriteLine(coche.ToString());
            }
        }

        static void Menu(List<Automovil> automovil)
        {
            byte opcion = 0;

            do{
                Console.WriteLine("Bienvenidos a concesionario Mike"
                                + "\nSeleccione una opción para continuar:"
                                + "\n1. Mostrar Coches de la lista."
                                + "\n2. Añadir Coches a la lista."
                                + "\n3. Eliminar Coches de la lista."
                                + "\n4. Mostrar Coches por año de fabricación."
                                + "\n5. Mostrar Coches por año y color.");

                opcion = Byte.Parse(Console.ReadLine());

                switch(opcion){
                    case 1:
                    Console.Clear();
                    MuestraLista(automovil);
                    Console.WriteLine("\nPulse cualquier tecla para volver al menú principal...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                    case 2:
                    Console.Clear();
                    Console.WriteLine("Ha seleccionado la opcion [Mostrar coches de la Lista]");
                    AñadeAutomovil(automovil);
                    break;
                    case 3:
                    Console.Clear();
                    EliminaAutomovil(automovil);
                    break;
                    case 4:
                    Console.Clear();
                    Console.WriteLine("Ha seleccionado la opción [Mostrar coches por año de fabricación]");
                    AutomovilesPorAñoFabricacion(automovil);
                    break;
                    case 5:
                    Console.Clear();
                    Console.WriteLine("Ha seleccionado la opción [Mostrar coches por año y color]");
                    AutomovilesPorAñoFabricacionYColor(automovil);
                    break;
                    default:
                    Console.WriteLine($"Opción {opcion} fuera de los parámetros esteblecidos."
                                    + "Saliendo del programa...");
                    break;
                }
            }while(opcion >= 1 && opcion <= 5);
        }
    }
}
