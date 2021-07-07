using System;

namespace LibroApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LIBRO APP" +
                              "\n\nIntroduce el numero con la opcion deseada... " +
                              "\n\n1. Mantenimiento de autores" +
                              "\n2. Mantenimiento de categorias" +
                              "\n3. Mantenimiento de editoriales" +
                              "\n4. Mantenimiento de libros" +
                              "\n5. Busqueda de libros" + 
                              "\n\n6. Salir");
            int opc = int.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    Console.Clear();
                    Menu.MantenimientoAutores();
                    break;
                case 2:
                    Console.Clear();
                    Menu.MantenimientoCategorias();
                    break;
                case 3:
                    Console.Clear();
                    break;
                case 4:
                    Console.Clear();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("Adios, espero que vuelvas pronto. PResiona cualquier tecla para salir...");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
