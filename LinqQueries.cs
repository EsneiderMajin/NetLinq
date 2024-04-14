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

    }
}




