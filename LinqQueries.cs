using System;
using System.Collections.Generic;

using System.Text;
using System.Threading.Tasks;

namespace NetLinq
{
    internal class LinqQueries
    {
        private List<Book> librosCollection = new List<Book>();


        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("C:\\Users\\Windows 10\\Documents\\202401\\PracticasNetAngular\\NetLinq\\books.json"))
            {
                string json = reader.ReadToEnd();
                this.librosCollection = System.Text.Json.JsonSerializer.Deserialize<List<Book>>(json, 
                    new System.Text.Json.JsonSerializerOptions() {PropertyNameCaseInsensitive = true });

                
            }
        }

        public IEnumerable<Book> TodaLaColeccion()
        {
            return this.librosCollection;
        }
        //reto 1 where
        public IEnumerable<Book> LibrosDespuesdel2000()
        {
            //extension method
            //return librosCollection.Where(p => p.PublishedDate.Year > 2000);

            //query syntax - expresion
            return from l in librosCollection
                   where l.PublishedDate.Year > 2000
                   select l;
        }

        //reto 2 where
        public IEnumerable<Book> LibrosDeMas250Paginas()
        {
            //extension method
            //return this.librosCollection.Where(p => p.PageCount > 250 && p.Title.Contains("in Action") );
            //query syntax - expresion
            return from l in librosCollection
                   where l.PageCount > 250 && l.Title.Contains("in Action")
                   select l;
        }

        //reto 3 all
        public bool TodosLosLibrosTienenStatus() { 
            return librosCollection.All(p => p.Status != string.Empty);
        }

        //reto 4 any
        public bool AlgunLibroFuePublicadoEn2010()
        {
            return librosCollection.Any(p => p.PublishedDate.Year == 2010);
        }

        //reto 5 contains
        public IEnumerable<Book> LibrosdePython()
        {
            return librosCollection.Where(p => p.Categories.Contains("Python"));
        }

        //reto 6 orderby
        public IEnumerable<Book> LibrosJavaPorNombre()
        {
            return librosCollection.Where(p => p.Categories.Contains("Java")).OrderBy(p => p.Title);
        }

        //reto 7 orderbydescending
        public IEnumerable<Book> LibrosMas450PagOrderDesc()
        {
            return librosCollection.Where(p => p.PageCount > 450 ).OrderByDescending(p => p.PageCount);
        }

        //reto 8 take toma los primeros y takeLast los ultimos, takeWhile toma mientras se cumpla la condicion
        public IEnumerable<Book> TresPrimerosLibrosJavaRecientes()
        {
            /*
             *             return librosCollection
                .Where(p => p.Categories.Contains("Java"))
                .OrderByDescending(p => p.PublishedDate)
                .Take(3);
             */

            return librosCollection
                .Where(p => p.Categories.Contains("Java"))
                .OrderBy(p => p.PublishedDate)
                .TakeLast(3);
        }

        //reto 9 skip omite el primer y segundo libro
        public IEnumerable<Book> TercerCuartoLibroMas400Paginas()
        {
            return librosCollection
                .Where(P => P.PageCount > 400)
                .Take(4)
                .Skip(2);
        }

        //reto 10 select take toma los 3 primeros con select se selecciona los campos
        public IEnumerable<Book> TresPrimerosLibrosColeccion()
        {   
            return librosCollection.Take(3)
                .Select(p => new Book() { Title = p.Title, PageCount = p.PageCount });
        }

        //--------------OPERADORES LONGCOUNT Y COUNT-----------------

        //reto 11 count libros entre 200 y 500 paginas con longcount se usa para colecciones grandes con tipo long en ves de int
        public int LibrosEntre200500Paginas()
        {
            return librosCollection.Count(p => p.PageCount >= 200 && p.PageCount <= 500);
        }

        //reto 12 min
        public DateTime FechaPublicacionLibroMasAntiguo()
        {
            return librosCollection.Min(p => p.PublishedDate);
        }

        //reto 13 max libro con mas paginas
        public int LibroConMasPaginas()
        {
            return librosCollection.Max(p => p.PageCount);
        }

        //reto 14 MinBy libro con menos paginas
        public Book LibroConMenosPaginas()
        {
            return librosCollection.Where(p => p.PageCount>0).MinBy(p => p.PageCount);
        }

        //reto 15 MaxBy libro con fecha de publicacion mas reciente
        public Book LibroConFechaPublicacionMasReciente()
        {
            return librosCollection.MaxBy(p => p.PublishedDate);
        }

        //reto 16 Sum sumar paginas de todos los libros de entre 0 y 500 paginas

        public int SumaPaginasLibrosEntre0y500()
        {
            return librosCollection.Where(p => p.PageCount >= 0 && p.PageCount <= 500).Sum(p => p.PageCount);
        }

        //reto 17 Aggregate Titulo de libros que tienen fecha de publicacion posterior a 2015
        public string TitulosLibrosPublicadosDespues2015()
        {
            return librosCollection.Where(p => p.PublishedDate.Year > 2015)
                .Aggregate("",(TitulosLibros, next) =>
                {
                    if(TitulosLibros != string.Empty)
                        TitulosLibros += " - " + next.Title;
                    else
                        TitulosLibros += next.Title;
                    return TitulosLibros;
                }
                );
        }

        //reto 18 Average promedio de caracteres de los titulos de los libros
        public double PromedioCaracteresTitulos()
        {
            return librosCollection.Average(p => p.Title.Length);
        }


        //AGRUPAMIENTO DE DATOS
        //reto 19 GroupBy agrupar libros publicados a partir del 2000
        public IEnumerable<IGrouping<int, Book>> LibrosDespues2000AgrupadosPorAnio()
        {
            return librosCollection.Where(p => p.PublishedDate.Year >= 2000).GroupBy(p => p.PublishedDate.Year);
        }

        //reto 20 Retorna diccionario para consultar los libros de acuerdo a la primera letra

        public ILookup<char, Book> DiccionariosDeLibrosPorLetra()
        {
            return librosCollection.ToLookup(p => p.Title[0], p => p);
        }

        //reto 21 Join coleccion que tenga todos los libros con mas de 500 paginas, y otra que contenga
        //los libros publicados despues del 2005
        //usando join se unen las dos colecciones y se devuelven los libros que cumplen con las dos condiciones

        public IEnumerable<Book> LibrosDespues2005conmasde500pags()
        {
            var LibrosDespues2005 = librosCollection.Where(p => p.PublishedDate.Year > 2005);

            var LibrosMas500Paginas = librosCollection.Where(p => p.PageCount > 500);

            return LibrosDespues2005.Join(LibrosMas500Paginas, p => p.Title, x => x.Title, (p, x) => p);

        }

        
    }
}




