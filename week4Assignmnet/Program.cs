using NLog.Web;

namespace week4Assignmnet;

internal class Program
{
    private static void Main(string[] args)
    {
        string input;

        var file = "movies.csv";
        var IDs = new List<ulong>();
        var Titles = new List<string>();
        var Genres = new List<string>();

        var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

        logger.Info("Program started");
        {
            if (!File.Exists(file))
            {
                //  logger.Error("File does not exist: {file}", file);
            }
            else
            {
                var sr = new StreamReader(file);
                try
                {
                    sr.ReadLine();


                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();

                        var ind = line.IndexOf('"');
                        if (ind == -1)
                        {
                            var movie = line.Split(',');

                            IDs.Add(ulong.Parse(movie[0]));
                            Titles.Add(movie[1]);
                            Genres.Add(movie[2].Replace("|", ", "));
                        }
                        else
                        {
                            IDs.Add(ulong.Parse(line.Substring(0, ind - 1)));

                            line = line.Substring(ind + 1);
                            ind = line.IndexOf('"');

                            Titles.Add(line.Substring(0, ind));
                            line = line.Substring(ind + 2);

                            Genres.Add(line.Replace("|", ", "));
                        }
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
                    var loop = IDs.Count() - amount;

                    for (var i = loop; i < IDs.Count(); i++)
                    {
                        Console.WriteLine($"Id: {IDs[i]}");
                        Console.WriteLine($"Title: {Titles[i]}");
                        Console.WriteLine($"Genre(s): {Genres[i]}");
                        Console.WriteLine();
                    }
                }

                else if (input == "2")
                {
                    StreamWriter sw = new StreamWriter(file, true);

                    // gathering user input
                    Console.WriteLine("Movie Id");
                    UInt64 id = Convert.ToUInt64(Console.ReadLine());
                    while (IDs.Contains(id))
                    {
                        Console.WriteLine($" id {id} already exists make another ID");
                        id = Convert.ToUInt64(Console.ReadLine());

                    }


                    Console.WriteLine("Title");
                    string title = Console.ReadLine();
                    while (Titles.Contains(title))
                    {
                        Console.WriteLine($" title {title} already exists make another ID");
                        title = Console.ReadLine();

                    }

                    Console.WriteLine("how many genres");
                    int genre = Convert.ToInt32(Console.ReadLine());


                    // a string array with the sise of watchers variable i can add to in my loop 
                    String[] genres = new String[genre];
                    // for loop to store the names the user enters followed by a pipe so i don't have to edit the way the file reads 
                    for (int i = 0; i < genre; i++)
                    {
                        Console.WriteLine("whats the genre");
                        genres[i] = Console.ReadLine();
                    }

                    sw.WriteLine($"{id},{title},{string.Join('|', genres)}");
                    IDs.Add(id);
                    Titles.Add(title);
                    Genres.Add(string.Join(',', genres));
                 

                    sw.Close(); // always close and don't loop your close statement



                }
            } while (input == "1" || input == "2");
        }
    }
}