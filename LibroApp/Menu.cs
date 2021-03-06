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
        private static Libro libro = new Libro();
        private static BusquedaLibro busquedaLibro = new BusquedaLibro();

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
    
        public static void MantenimientoLibros()
        {
            Console.WriteLine("LIBRO APP - LIBROS" +
                              "\n\nIntroduce el numero de la opcion deseada... " +
                              "\n\n1. Agregar libro" +
                              "\n2. Editar libro" +
                              "\n3. Eliminar libro" +
                              "\n4. Listar libros" +
                              "\n5. Volver atras");

            int opcLibro = int.Parse(Console.ReadLine());

            switch (opcLibro)
            {
                case 1:
                    Console.Clear();
                    libro.AgregarLibro();
                    break;
                case 2:
                    Console.Clear();
                    libro.EditarLibros();
                    break;
                case 3:
                    Console.Clear();
                    libro.EliminarLibros();
                    break;
                case 4:
                    Console.Clear();
                    libro.ListarLibros();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. Presiona cualquier tecla para volver...");
                    Console.ReadKey();
                    Menu.MantenimientoLibros();
                    break;
            }
        }

        public static void BusquedaLibros()
        {
            Console.WriteLine("LIBRO APP - BUSQUEDA" +
                              "\n\nIntroduce el numero de la opcion deseada... " +
                              "\n\n1. Busqueda por nombre del libro" +
                              "\n2. Búsqueda por nombre del autor" +
                              "\n3. Búsqueda por nombre del editorial" +
                              "\n4. Volver atras");

            int opcLibroBusqueda = int.Parse(Console.ReadLine());

            switch (opcLibroBusqueda)
            {
                case 1:
                    Console.Clear();
                    busquedaLibro.BusquedaPorNombreDelLibro();
                    break;
                case 2:
                    Console.Clear();
                    busquedaLibro.BusquedaPorNombreDelAutor();
                    break;
                case 3:
                    Console.Clear();
                    busquedaLibro.BusquedaPorNombreDelEditorial();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. Presiona cualquier tecla para volver...");
                    Console.ReadKey();
                    Menu.MantenimientoLibros();
                    break;
            }
        }

    }
}
