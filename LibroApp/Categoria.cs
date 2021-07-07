using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp
{
    public class Categoria
    {

        public void AgregarCategoria()
        {
            var agregar = Task.Run(() => Agregar());
            agregar.Wait();
        }

        public void ListarCategorias()
        {
            var listar = Task.Run(() => Listar());
            listar.Wait();
        }

        public void EditarCategorias()
        {
            var editar = Task.Run(() => Editar());
            editar.Wait();
        }

        public void EliminarCategorias()
        {
            var eliminar = Task.Run(() => Eliminar());
            eliminar.Wait();
        }

        private void Agregar()
        {
            Console.WriteLine("AGREGAR CATEGORIA" +
                              "\n\nIntroduce el nombre de la categoria...");
            string opcNombreCategoria = Console.ReadLine();

            Console.WriteLine("\n\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataCategorias = db.Categorias;

                dataCategorias.Add(new Database.Models.Categoria
                {
                    NombreCategoria = opcNombreCategoria
                });

                db.SaveChanges();
            }
        }

        private void Editar()
        {
            Console.WriteLine("EDITA UNA CATEGORIA");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nEscribe el ID de la categoria que deseas editar...");
            int opcEditarCategoria = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\nIntroduce el nuevo nombre de la categoria...");
            string nuevoNombreCategoria = Console.ReadLine();

            Console.WriteLine("\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataEditarCategoria = db.Categorias.First(a => a.CategoriaId == opcEditarCategoria);
                dataEditarCategoria.NombreCategoria = nuevoNombreCategoria;

                db.SaveChanges();
            }
        }

        private void Listar()
        {
            Console.WriteLine("LISTA DE CATEGORIAS");

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspera...\n");
                var dataListaCategorias = db.Categorias.OrderBy(x => x.NombreCategoria).ToList();

                Parallel.ForEach(dataListaCategorias, categoria =>
                {
                    Console.WriteLine($"ID: {categoria.CategoriaId} -- Categoria: {categoria.NombreCategoria}");
                });
            }
        }

        private void Eliminar()
        {
            Console.WriteLine("ELIMINAR CATEGORIA");
            Console.WriteLine("\n\n");

            Listar();

            Console.WriteLine("\n\nIntroduce el ID de una categoria para eliminar...");
            int opcEliminarCategoria = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEstas seguro que quieres eliminar esta categoria Y/N?");
                string yesNo = Console.ReadLine();

                if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine("\n\nEspera...");
                    var dataEliminarCategoria = db.Categorias.First(c => c.CategoriaId == opcEliminarCategoria);
                    db.Categorias.Remove(dataEliminarCategoria);

                    db.SaveChanges();
                }
                else if (yesNo == "N" || yesNo == "n")
                {
                    Console.Clear();
                    Menu.MantenimientoCategorias();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido una tecla incorrecta. Vuelve a intentarlo." +
                                      "Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    Menu.MantenimientoCategorias();
                }
            }
        }

    }
}
