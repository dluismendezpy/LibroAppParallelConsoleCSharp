using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibroApp
{
    public class BusquedaLibro
    {

        public void BusquedaPorNombreDelLibro()
        {
            var busquedaLibroNombre = Task.Run(() => BusquedaPorNombreDelLibroPrivate());
            busquedaLibroNombre.Wait();
        }

        public void BusquedaPorNombreDelAutor()
        {
            var busquedaAnoLibro = Task.Run(() => BusquedaPorNombreDelAutorPrivate());
            busquedaAnoLibro.Wait();
        }

        public void BusquedaPorNombreDelEditorial()
        {
            var busquedaEditorialLibro = Task.Run(() => BusquedaPorNombreDelEditorialPrivate());
            busquedaEditorialLibro.Wait();
        }

        private void BusquedaPorNombreDelAutorPrivate()
        {
            Console.WriteLine("Introduzca el nombre del autor del libro...");
            string nombreDelAutorDelLibro = Console.ReadLine();

            SubMenuBusquedaLibro();
            int opcSubMenuBusqueda = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspere...\n");

                var dataNombreAutorLibro = db.Libros.Where(x => x.AutorLibro == nombreDelAutorDelLibro).ToList();

                if (opcSubMenuBusqueda == 1)
                {
                    dataNombreAutorLibro.OrderBy(x => x.NombreLibro).ToList();
                    Parallel.ForEach(dataNombreAutorLibro, nombreLibro =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreLibro.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreLibro.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreLibro.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreLibro.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 2)
                {
                    //Ordenar por año de publicación del libro (desde el más reciente al más antiguo )

                    dataNombreAutorLibro.OrderBy(x => x.AnoPublicacionLibro).ToList().Reverse();
                    Parallel.ForEach(dataNombreAutorLibro, publicacion =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {publicacion.NombreLibro}" +
                                          $"\nAño de publicacion: {publicacion.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {publicacion.EditorialLibro}" +
                                          $"\nNombre del autor: {publicacion.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 3)
                {
                    //Ordenar por nombre del autor (Alfabéticamente)

                    dataNombreAutorLibro.OrderBy(x => x.AutorLibro).ToList();
                    Parallel.ForEach(dataNombreAutorLibro, nombreAutor =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreAutor.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreAutor.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreAutor.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreAutor.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 4)
                {
                    //Ordenar por nombre del editorial(Alfabéticamente)

                    dataNombreAutorLibro.OrderBy(x => x.EditorialLibro).ToList();
                    Parallel.ForEach(dataNombreAutorLibro, nombreEditorial =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreEditorial.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreEditorial.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreEditorial.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreEditorial.AutorLibro}");
                    });
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido un numero incorrecto. Vuelve a intentarlo...");

                    Thread.Sleep(1500);

                    Console.WriteLine("\n\nEsta siendo redireccionado al menu principal. Espere...");

                    Thread.Sleep(2500);
                    Menu.BusquedaLibros();
                }
            }
        }

        private void BusquedaPorNombreDelLibroPrivate()
        {
            Console.WriteLine("Introduzca el nombre del libro...");
            string nombreDelLibro = Console.ReadLine();

            SubMenuBusquedaLibro();
            int opcSubMenuBusqueda = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspere...\n");

                var dataNombreLibro = db.Libros.Where(x => x.NombreLibro == nombreDelLibro).ToList();

                if (opcSubMenuBusqueda == 1)
                {
                    dataNombreLibro.OrderBy(x => x.NombreLibro).ToList();
                    Parallel.ForEach(dataNombreLibro, nombreLibro =>
                    {
                        //var dataListaEditoriales = db.Editoriales.Where(a => a.NombreEditorial == nombreLibro.EditorialLibro).ToList();
                        //Ordenar por nombre del libro (Alfabéticamente)
                        Console.WriteLine($"\nNombre del Libro: {nombreLibro.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreLibro.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreLibro.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreLibro.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 2)
                {
                    //Ordenar por año de publicación del libro (desde el más reciente al más antiguo )

                    dataNombreLibro.OrderBy(x => x.AnoPublicacionLibro).ToList().Reverse();
                    Parallel.ForEach(dataNombreLibro, publicacion =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {publicacion.NombreLibro}" +
                                          $"\nAño de publicacion: {publicacion.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {publicacion.EditorialLibro}" +
                                          $"\nNombre del autor: {publicacion.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 3)
                {
                    //Ordenar por nombre del autor (Alfabéticamente)

                    dataNombreLibro.OrderBy(x => x.AutorLibro).ToList();
                    Parallel.ForEach(dataNombreLibro, nombreAutor =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreAutor.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreAutor.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreAutor.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreAutor.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 4)
                {
                    //Ordenar por nombre del editorial(Alfabéticamente)

                    dataNombreLibro.OrderBy(x => x.EditorialLibro).ToList();
                    Parallel.ForEach(dataNombreLibro, nombreEditorial =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreEditorial.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreEditorial.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreEditorial.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreEditorial.AutorLibro}");
                    });
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido un numero incorrecto. Vuelve a intentarlo...");

                    Thread.Sleep(1500);

                    Console.WriteLine("\n\nEsta siendo redireccionado al menu principal. Espere...");

                    Thread.Sleep(2500);
                    Menu.BusquedaLibros();
                }
            }

        }

        private void BusquedaPorNombreDelEditorialPrivate()
        {
            Console.WriteLine("Introduzca el nombre del editorial...");
            string nombreDelEditorial = Console.ReadLine();

            SubMenuBusquedaLibro();
            int opcSubMenuBusqueda = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspere...\n");

                var dataNombreEditorial = db.Libros.Where(x => x.EditorialLibro == nombreDelEditorial).ToList();

                if (opcSubMenuBusqueda == 1)
                {
                    dataNombreEditorial.OrderBy(x => x.NombreLibro).ToList();
                    Parallel.ForEach(dataNombreEditorial, nombreLibro =>
                    {
                        //var dataListaEditoriales = db.Editoriales.Where(a => a.NombreEditorial == nombreLibro.EditorialLibro).ToList();
                        //Ordenar por nombre del libro (Alfabéticamente)
                        Console.WriteLine($"\nNombre del Libro: {nombreLibro.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreLibro.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreLibro.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreLibro.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 2)
                {
                    //Ordenar por año de publicación del libro (desde el más reciente al más antiguo )

                    dataNombreEditorial.OrderBy(x => x.AnoPublicacionLibro).ToList().Reverse();
                    Parallel.ForEach(dataNombreEditorial, publicacion =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {publicacion.NombreLibro}" +
                                          $"\nAño de publicacion: {publicacion.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {publicacion.EditorialLibro}" +
                                          $"\nNombre del autor: {publicacion.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 3)
                {
                    //Ordenar por nombre del autor (Alfabéticamente)

                    dataNombreEditorial.OrderBy(x => x.AutorLibro).ToList();
                    Parallel.ForEach(dataNombreEditorial, nombreAutor =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreAutor.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreAutor.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreAutor.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreAutor.AutorLibro}");
                    });
                }
                else if (opcSubMenuBusqueda == 4)
                {
                    //Ordenar por nombre del editorial(Alfabéticamente)

                    dataNombreEditorial.OrderBy(x => x.EditorialLibro).ToList();
                    Parallel.ForEach(dataNombreEditorial, nombreEditorial =>
                    {
                        Console.WriteLine($"\nNombre del Libro: {nombreEditorial.NombreLibro}" +
                                          $"\nAño de publicacion: {nombreEditorial.AnoPublicacionLibro}" +
                                          $"\nPais de origen: " +
                                          $"\nNombre del Editorial: {nombreEditorial.EditorialLibro}" +
                                          $"\nNombre del autor: {nombreEditorial.AutorLibro}");
                    });
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido un numero incorrecto. Vuelve a intentarlo...");

                    Thread.Sleep(1500);

                    Console.WriteLine("\n\nEsta siendo redireccionado al menu principal. Espere...");

                    Thread.Sleep(2500);
                    Menu.BusquedaLibros();
                }
            }

        }

        private void SubMenuBusquedaLibro()
        {
            Console.WriteLine("\nSelecciona la opcion deseada para mostrar..." +
                              "\n\n1. Ordenar por nombre del libro (Alfabéticamente)" +
                              "\n2. Ordenar por año de publicación del libro (desde el más reciente al más antiguo )" +
                              "\n3. Ordenar por nombre del autor (Alfabéticamente)" +
                              "\n4. Ordenar por nombre del editorial(Alfabéticamente)");
        }

    }
}
