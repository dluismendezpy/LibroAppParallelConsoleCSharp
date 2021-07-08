using System;
using System.Collections.Generic;
using System.Text;

namespace LibroApp
{
    public class Menu
    {
        // Objetos
        private static Autor autor = new Autor();
        private static Categoria categoria = new Categoria();
        private static Editorial editorial = new Editorial();

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
        
        public static void MantenimientoEditoriales()
        {
            Console.WriteLine("LIBRO APP - EDITORIALES" +
                              "\n\nIntroduce el numero de la opcion deseada... " +
                              "\n\n1. Agregar editorial" +
                              "\n2. Editar editorial" +
                              "\n3. Eliminar editorial" +
                              "\n4. Listar editoriales" +
                              "\n5. Volver atras");

            int opcEditorial = int.Parse(Console.ReadLine());

            switch (opcEditorial)
            {
                case 1:
                    Console.Clear();
                    editorial.AgregarEditorial();
                    break;
                case 2:
                    Console.Clear();
                    editorial.EditarEditoriales();
                    break;
                case 3:
                    Console.Clear();
                    editorial.EliminarEditoriales();
                    break;
                case 4:
                    Console.Clear();
                    editorial.ListarEditoriales();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. Presiona cualquier tecla para volver...");
                    Console.ReadKey();
                    Menu.MantenimientoEditoriales();
                    break;
            }
        }
    }
}
