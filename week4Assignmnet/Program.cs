using System.Net;

namespace week4Assignmnet;

internal class Program
{
    private static void Main(string[] args)
    {
        string input;

        var file = "movies.csv";
        var Lines = new List<string>();


        var check = new checker();


        if (File.Exists(file))
        {
            var sr = new StreamReader(file);
            try
            {
                sr.ReadLine();


                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    Lines.Add(check.validate(line));
                }
            }

            catch (Exception ex)
            {
            }
            finally
            {
                sr.Close();
            }
        }

        do
        {
            Console.WriteLine("1) Read data from file.");
            Console.WriteLine("2) Create file from data.");
            Console.WriteLine("Enter any other key to exit.");

            // stored user  input 
            input = Console.ReadLine();


            if (input == "1")
            {
                Console.WriteLine("how many records would you like to see ");
                var amount = Convert.ToInt32(Console.ReadLine());
                var loop = Lines.Count - amount;

                for (var i = loop; i < Lines.Count(); i++)
                {
                    Console.WriteLine(Lines[i]);
                    Console.WriteLine();
                }
            }

            else if (input == "2")
            {
                var sw = new StreamWriter(file, true);

                // gathering user input

              //  var id = Lines.Count + 1;

                
                 Console.WriteLine("Movie Id");
                var id = Convert.ToInt64(Console.ReadLine());
                
                while (check.IdContains(id))
                {
                    Console.WriteLine($"ID {id} already exists make another ID");
                    id = Convert.ToInt64(Console.ReadLine());
                }


                Console.WriteLine("Title");
                var title = Console.ReadLine();
                while (check.TitleContains(title))
                {
                    Console.WriteLine($"Title {title} already exists make another Title");
                    title = Console.ReadLine();
                }


                Console.WriteLine("how many genres");
                var genre = Convert.ToInt32(Console.ReadLine());


                // a string array with the sise of watchers variable i can add to in my loop 
                var genres = new string[genre];
                // for loop to store the names the user enters followed by a pipe so i don't have to edit the way the file reads 
                for (var i = 0; i < genre; i++)
                {
                    Console.WriteLine("whats the genre(s)");
                    genres[i] = Console.ReadLine();
                }


                sw.WriteLine(check.create(id, title, string.Join('|', genres)));
                Lines.Add(check.create(id, title, string.Join('|', genres)));


                sw.Close(); // always close and don't loop your close statement
            }
        } while (input == "1" || input == "2");
    }
}