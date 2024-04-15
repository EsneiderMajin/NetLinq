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
//PrintBooks(queries.LibrosMas450PagOrderDesc());

//Tres primeros libros de Java publicados recientemente
//PrintBooks(queries.TresPrimerosLibrosJavaRecientes());

//Tercer y cuarto libro con mas de 400 paginas
//PrintBooks(queries.TercerCuartoLibroMas400Paginas());

//tres primeros libros de la coleccion
//PrintBooks(queries.TresPrimerosLibrosColeccion());

//Libros entre 200 y 500 paginas
//Console.WriteLine($"Libros entre 200 y 500 paginas: {queries.LibrosEntre200500Paginas()}");

//fecha publicacion mas antigua
//Console.WriteLine($"Fecha publicacion mas antigua: {queries.FechaPublicacionLibroMasAntiguo()}");

//libro con mas paginas
//Console.WriteLine($"Libro con mas paginas: {queries.LibroConMasPaginas()}");

//libro con menos paginas
//var libroMenorPag = queries.LibroConMenosPaginas();
//Console.WriteLine($"Libro con menos paginas: {libroMenorPag.Title} {libroMenorPag.PageCount}");

//Libro con mas paginas
//var libroMasReciente = queries.LibroConFechaPublicacionMasReciente();
//Console.WriteLine($"Libro con fecha de publicacion mas reciente: {libroMasReciente.Title} " +
//  $"{libroMasReciente.PublishedDate.ToShortDateString()}");

//Suma de paginas de 0 a 500
//Console.WriteLine($"Suma de paginas de 0 a 500: {queries.SumaPaginasLibrosEntre0y500()}");

//Libros publicados despues del 2015
//Console.WriteLine($"Libros publicados despues del 2015: {queries.TitulosLibrosPublicadosDespues2015()}");

//Promedio de caracteres en los titulos de los libros
//Console.WriteLine($"Promedio de caracteres en los titulos de los libros: {queries.PromedioCaracteresTitulos()}");

//Libros publicados a partir del 2000
//ImprimirGrupo(queries.LibrosDespues2000AgrupadosPorAnio());

//Diccionario de libros agrupados por primera letra del titulo
//var diccionarioLookup = queries.DiccionariosDeLibrosPorLetra();
//imprimirDiccionario(diccionarioLookup, 'A');

//libros filtrados con la clausura join
PrintBooks(queries.LibrosDespues2005conmasde500pags());


void PrintBooks(IEnumerable<Book> books)
{
    Console.WriteLine("{0,-60} {1,15} {2,15}", "Titulo", "N paginas", "Fecha publicacion");
    foreach (var book in books)
    {
        Console.WriteLine("{0,-60} {1,15} {2,15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());

    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach (var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: {grupo.Key}");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo","N Paginas", "Fecha Actualizacion");
        foreach (var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
        }
    }
}

void imprimirDiccionario(ILookup<char, Book> ListadeLibros, char letra)
{
    Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N Paginas", "Fecha Actualizacion");

    foreach (var item in ListadeLibros[letra])
    {
        Console.WriteLine("{0,-60} {1, 15} {2, 15}", item.Title, item.PageCount, item.PublishedDate.ToShortDateString());
    }

}

