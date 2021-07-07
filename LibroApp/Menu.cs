using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp
{
    public class Menu
    {
        private static Autor autor = new Autor();

        public static void MantenimientoAutores()
        {
            Console.WriteLine("LIBRO APP - AUTORES" +
                              "\n\nIntroduce el numero con la opcion deseada... " +
                              "\n\n1. Agregar autor" +
                              "\n2. Editar autor" +
                              "\n3. Eliminar autor" +
                              "\n4. Listar autores" +
                              "\n5. Volver atras");

            int opcAutores = int.Parse(Console.ReadLine());

            switch (opcAutores)
            {
                case 1:
                    Console.Clear();
                    autor.AgregarAutor();
                    break;
                case 2:
                    Console.Clear();
                    autor.EditarAutores();
                    break;
                case 3:
                    Console.Clear();
                    autor.EliminarAutores();
                    break;
                case 4:
                    Console.Clear();
                    autor.ListarAutores();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. Presiona cualquier tecla para volver...");
                    Console.ReadKey();
                    Menu.MantenimientoAutores();
                    break;
            }
        }

    }
}
