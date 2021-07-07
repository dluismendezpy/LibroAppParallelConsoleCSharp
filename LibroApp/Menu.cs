using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp
{
    public class Menu
    {
        private static Autor autor = new Autor();
        private static Categoria categoria = new Categoria();

        public static void MantenimientoAutores()
        {
            Console.WriteLine("LIBRO APP - AUTORES" +
                              "\n\nIntroduce el numero de la opcion deseada... " +
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

        public static void MantenimientoCategorias()
        {
            Console.WriteLine("LIBRO APP - CATEGORIAS" +
                              "\n\nIntroduce el numero de la opcion deseada... " +
                              "\n\n1. Agregar categoria" +
                              "\n2. Editar categoria" +
                              "\n3. Eliminar categoria" +
                              "\n4. Listar categorias" +
                              "\n5. Volver atras");

            int opcCategoria = int.Parse(Console.ReadLine());

            switch (opcCategoria)
            {
                case 1:
                    Console.Clear();
                    categoria.AgregarCategoria();
                    break;
                case 2:
                    Console.Clear();
                    categoria.EditarCategorias();
                    break;
                case 3:
                    Console.Clear();
                    categoria.EliminarCategorias();
                    break;
                case 4:
                    Console.Clear();
                    categoria.ListarCategorias();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. Presiona cualquier tecla para volver...");
                    Console.ReadKey();
                    Menu.MantenimientoCategorias();
                    break;
            }
        }
    }
}
