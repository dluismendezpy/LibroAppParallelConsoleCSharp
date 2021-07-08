using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp
{
    public class Editorial
    {
        public void AgregarEditorial()
        {
            var agregar = Task.Run(() => Agregar());
            agregar.Wait();
        }

        public void EditarEditoriales()
        {
            var editar = Task.Run(() => Editar());
            editar.Wait();
        }

        public void ListarEditoriales()
        {
            var listar = Task.Run(() => Listar());
            listar.Wait();
        }

        public void EliminarEditoriales()
        {
            var eliminar = Task.Run(() => Eliminar());
            eliminar.Wait();
        }

        private void Agregar()
        {
            Console.WriteLine("AGREGAR EDITORIAL" +
                              "\n\nIntroduce el nombre del editorial...");
            string opcNombreEditorial = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce telefono del editorial...");
            string opcTelefonoEditorial = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el pais del editorial...");
            string opcPaisEditorial = Console.ReadLine();

            Console.WriteLine("\n\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataEditoriales = db.Editoriales;

                dataEditoriales.Add(new Database.Models.Editoriale
                {
                    NombreEditorial = opcNombreEditorial,
                    TelefonoEditorial = opcTelefonoEditorial,
                    PaisEditorial = opcPaisEditorial
                });

                db.SaveChanges();
            }

        }

        private void Editar()
        {
            Console.WriteLine("EDITA UN EDITORIAL");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nEscribe el ID del editorial que deseas editar...");
            int opcEditarEditorial = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\nIntroduce el nuevo nombre del editorial...");
            string nuevoNombreEditorial = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el nuevo telefono del editorial...");
            string nuevoTelefonoEditorial = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el nuevo pais del editorial...");
            string nuevoPaisEditorial = Console.ReadLine();

            Console.WriteLine("\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataEditarEditorial = db.Editoriales.First(a => a.EditorialId == opcEditarEditorial);

                dataEditarEditorial.NombreEditorial = nuevoNombreEditorial;
                dataEditarEditorial.TelefonoEditorial = nuevoTelefonoEditorial;
                dataEditarEditorial.PaisEditorial = nuevoPaisEditorial;

                db.SaveChanges();
            }
        }

        private void Listar()
        {
            Console.WriteLine("LISTA DE EDITORIALES");

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspera...\n");
                var dataListaEditoriales = db.Editoriales.OrderBy(x => x.NombreEditorial).ToList();

                Parallel.ForEach(dataListaEditoriales, editorial =>
                {
                    Console.WriteLine($"ID: {editorial.EditorialId} -- Editorial: {editorial.NombreEditorial} -- Telefono: {editorial.TelefonoEditorial} -- Pais: {editorial.PaisEditorial}");
                });
            }
        }

        private void Eliminar()
        {
            Console.WriteLine("ELIMINAR EDITORIAL");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nIntroduce el ID de un editorial para eliminar...");
            int opcEliminarEditorial = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEstas seguro que quieres eliminar este editorial Y/N?");
                string yesNo = Console.ReadLine();

                if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine("\n\nEspera...");
                    var dataEliminarEditorial = db.Editoriales.First(b => b.EditorialId == opcEliminarEditorial);
                    db.Editoriales.Remove(dataEliminarEditorial);

                    db.SaveChanges();
                }
                else if (yesNo == "N" || yesNo == "n")
                {
                    Console.Clear();
                    Menu.MantenimientoEditoriales();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido una tecla incorrecta. Vuelve a intentarlo." +
                                      "Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    Menu.MantenimientoEditoriales();
                }
            }
        }

    }
}
