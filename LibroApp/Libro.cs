using Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibroApp
{
    public class Libro
    {

        public void AgregarLibro()
        {
            var agregar = Task.Run(() => Agregar());
            agregar.Wait();
        }

        public void ListarLibros()
        {
            var listar = Task.Run(() => Listar());
            listar.Wait();
        }

        public void EditarLibros()
        {
            var editar = Task.Run(() => Editar());
            editar.Wait();
        }

        public void EliminarLibros()
        {
            var eliminar = Task.Run(() => Eliminar());
            eliminar.Wait();
        }


        private void Agregar()
        {
            Console.WriteLine("AGREGAR LIBRO" +
                              "\n\nIntroduce el nombre del libro...");
            string opcNombreLibro = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el año de publicacion del libro...");
            int opcAnoPublicacionLibro = int.Parse(Console.ReadLine());

            Console.Clear();

            //Lista de categorias
            Console.WriteLine("\n\nCategorias creadas");

            ListaCategoriasCreadas();

            Console.WriteLine("\n\nIntroduce el ID de la categoria del libro...");
            int opcCategoriaIDLibro = int.Parse(Console.ReadLine());

            Console.Clear();

            //Lista de autores
            Console.WriteLine("\n\nAutores creados");

            ListaAutoresCreados();

            Console.WriteLine("\n\nIntroduce el ID del autor del libro...");
            int opcAutorIDLibro = int.Parse(Console.ReadLine());

            Console.Clear();

            //Lista de editoriales
            Console.WriteLine("\n\nEditoriales creados");

            ListaEditorialesCreados();

            Console.WriteLine("\n\nIntroduce el ID del editorial del libro...");
            int opcEditorialIDLibro = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\n\nEspere...");

            using (var db = new LibroAppDBContext())
            {
                var dataLibros = db.Libros;

                var categorias = db.Categorias.First(a => a.CategoriaId == opcCategoriaIDLibro);
                var autores = db.Autores.First(a => a.AutorId == opcAutorIDLibro);
                var editoriales = db.Editoriales.First(a => a.EditorialId == opcEditorialIDLibro);

                dataLibros.Add(new Database.Models.Libro
                {
                    NombreLibro = opcNombreLibro,
                    AnoPublicacionLibro = opcAnoPublicacionLibro,
                    CategoriaLibro = categorias.NombreCategoria,
                    AutorLibro = autores.NombreAutor,
                    EditorialLibro = editoriales.NombreEditorial
                });

                db.SaveChanges();
            }

        }

        private void Editar()
        {
            Console.WriteLine("EDITA UN LIBRO" +
                              "\nLista de libros");

            ListaLibrosParaEditar();

            Console.WriteLine("\n\nEscribe el ID del libro que deseas editar...");
            int opcEditarLibroID = int.Parse(Console.ReadLine());

            Console.WriteLine("\n\nIntroduce el nuevo nombre del libro...");
            string opcNuevoNombreLibro = Console.ReadLine();

            Console.WriteLine("\n\nIntroduce el nuevo año de publicacion del libro...");
            int opcNuevoAnoPublicacion = int.Parse(Console.ReadLine());

            Console.Clear();

            //Categorias
            Console.WriteLine("Lista de categorias creadas en el sistema...");

            ListaCategoriasCreadas();

            Console.WriteLine("Introduce el ID de la nueva categoria del libro...");
            int opcCategoriaLibroID = int.Parse(Console.ReadLine());

            Console.Clear();

            //Editoriales
            Console.WriteLine("Lista de editoriales creados en el sistema...");

            ListaEditorialesCreados();

            Console.WriteLine("Introduce el ID del nuevo editorial del libro...");
            int opcEditorialLibroID = int.Parse(Console.ReadLine());

            Console.Clear();

            //Autores
            Console.WriteLine("Lista de autores creados en el sistema...");

            ListaAutoresCreados();

            Console.WriteLine("Introduce el ID del nuevo autor del libro...");
            int opcAutorLibroID = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                var dataEditarLibro = db.Libros.First(a => a.LibroId == opcEditarLibroID);
                var categorias = db.Categorias.First(a => a.CategoriaId == opcCategoriaLibroID);
                var autores = db.Autores.First(a => a.AutorId == opcEditorialLibroID);
                var editoriales = db.Editoriales.First(a => a.EditorialId == opcAutorLibroID);

                dataEditarLibro.NombreLibro = opcNuevoNombreLibro;
                dataEditarLibro.AnoPublicacionLibro = opcNuevoAnoPublicacion;
                dataEditarLibro.CategoriaLibro = categorias.NombreCategoria;
                dataEditarLibro.EditorialLibro = editoriales.NombreEditorial;
                dataEditarLibro.AutorLibro = autores.NombreAutor;

                db.SaveChanges();
            }

        }

        private void Listar()
        {
            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspera...\n");
                var dataListaLibros = db.Libros.OrderBy(x => x.NombreLibro).ToList();

                Parallel.ForEach(dataListaLibros, libro =>
                {
                    Console.WriteLine($"ID: {libro.LibroId} -- Libro: {libro.NombreLibro} -- año: {libro.AnoPublicacionLibro} -- Categoria: {libro.CategoriaLibro} -- Autor: {libro.AutorLibro} -- Editorial: {libro.EditorialLibro}");
                });
            }
        }

        private void Eliminar()
        {
            Console.WriteLine("ELIMINAR LIBRO");
            Console.WriteLine("\n\n");

            ListaLibrosParaEditar();

            Console.WriteLine("\n\nIntroduce el ID de un libro para eliminar...");
            int opcEliminarLibro = int.Parse(Console.ReadLine());

            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEstas seguro que quieres eliminar este libro Y/N?");
                string yesNo = Console.ReadLine();

                if (yesNo == "Y" || yesNo == "y")
                {
                    Console.WriteLine("\n\nEspera...");
                    var dataEliminarLibro = db.Libros.First(b => b.LibroId == opcEliminarLibro);
                    db.Libros.Remove(dataEliminarLibro);

                    db.SaveChanges();
                }
                else if (yesNo == "N" || yesNo == "n")
                {
                    Console.Clear();
                    Menu.MantenimientoLibros();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Has introducido una tecla incorrecta. Vuelve a intentarlo." +
                                      "Presiona cualquier tecla para salir...");
                    Console.ReadKey();
                    Menu.MantenimientoLibros();
                }
            }

        }

        private void ListaLibrosParaEditar()
        {
            using (var db = new LibroAppDBContext())
            {
                Console.WriteLine("\nEspera...\n");
                var dataListaLibros = db.Libros.OrderBy(x => x.NombreLibro).ToList();

                Parallel.ForEach(dataListaLibros, libro =>
                {
                    Console.WriteLine($"ID: {libro.LibroId} -- Libro: {libro.NombreLibro}");
                });
            }
        }

        private void ListaCategoriasCreadas()
        {

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

        private void ListaAutoresCreados()
        {
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
        
        private void ListaEditorialesCreados()
        {
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

    }
}
