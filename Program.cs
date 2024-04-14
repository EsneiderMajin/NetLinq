// See https://aka.ms/new-console-template for more information
using NetLinq;

Console.WriteLine("Hello, World!");

LinqQueries queries = new LinqQueries();

//Toda la coleccion
//PrintBooks(queries.TodaLaColeccion());

//Libros despues del 2000
//PrintBooks(queries.LibrosDespuesdel2000());

//Libros de mas de 250 paginas
//PrintBooks(queries.LibrosDeMas250Paginas());

//Todos los libros tienen status
//Console.WriteLine($"Todos los libros tienen status? - {queries.TodosLosLibrosTienenStatus()}");

//Algun libro fue publicado en 2010
//Console.WriteLine($"Algun libro fue publicado en 2010? - {queries.AlgunLibroFuePublicadoEn2010()}");

//Libros de Python
//PrintBooks(queries.LibrosdePython());

//libros java
//PrintBooks(queries.LibrosJavaPorNombre());

//Libros de mas de 450 pag descendente
PrintBooks(queries.LibrosMas450PagOrderDesc());


void PrintBooks(IEnumerable<Book> books)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}", "Titulo", "N paginas", "Fecha publicacion");
    foreach (var book in books)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());

    }


}
