using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibroApp
{
    public class Autor
    {
        public void AgregarAutor()
        {
            var agregar =  Task.Run(() => Agregar());
            agregar.Wait();
        }

        public void ListarAutores()
        {
            var listar = Task.Run(() => Listar());
            listar.Wait();
        }

        public void EditarAutores()
        {
            var editar = Task.Run(() => Editar());
            editar.Wait();
        }

        public void EliminarAutores()
        {
            var eliminar = Task.Run(() => Eliminar());
            eliminar.Wait();
        }

        private void Agregar()
        {
            Console.WriteLine("AGREGAR AUTOR" +
                              "\n\nIntroduce el nombre del autor...");
            string nombreAutor = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el correo electronico...");
            string correoAutor = Console.ReadLine();

            Console.WriteLine("\n\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataAutores = db.Autores;

                dataAutores.Add(new Database.Models.Autore
                {
                    NombreAutor = nombreAutor,
                    CorreoElectronicoAutor = correoAutor
                });

                db.SaveChanges();
            }

        }

        private void Editar()
        {
            Console.WriteLine("EDITA UN AUTOR");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nEscribe el ID del autor que quieras editar...");
            int opcEditarAutor = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\nIntroduce el nuevo nombre del autor...");
            string nuevoNombreAutor = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el nuevo correo del autor...");
            string nuevoCorreoAutor = Console.ReadLine();

            Console.WriteLine("\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataEditar = db.Autores.First(a => a.AutorId == opcEditarAutor);
                dataEditar.NombreAutor = nuevoNombreAutor;
                dataEditar.CorreoElectronicoAutor = nuevoCorreoAutor;

                db.SaveChanges();
            }
        }

        private void Listar()
        {
            Console.WriteLine("LISTA DE AUTORES");

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspera...\n");
                var dataListaAutores = db.Autores.OrderBy(x => x.NombreAutor).ToList();

                Parallel.ForEach(dataListaAutores, autor =>
                {
                    Console.WriteLine($"ID: {autor.AutorId} -- Autor: {autor.NombreAutor} -- Correo Electronico: {autor.CorreoElectronicoAutor}");             
                });
            }
        }

        private void Eliminar()
        {
            Console.WriteLine("ELIMINAR AUTOR");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nIntroduce el ID de un autor para eliminar...");
            int opcEliminarAutor = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEstas seguro que quieres eliminar este autor Y/N?");
                string yesNo = Console.ReadLine();

                if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine("\n\nEspera...");
                    var dataEliminarAutor = db.Autores.First(b => b.AutorId == opcEliminarAutor);
                    db.Autores.Remove(dataEliminarAutor);
                    db.SaveChanges();
                }
                else if (yesNo == "N" || yesNo == "n")
                {
                    Console.Clear();
                    Menu.MantenimientoAutores();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido una tecla incorrecta. Vuelve a intentarlo." +
                                      "Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    Menu.MantenimientoAutores();     
                }
            }
        }

    }
}
