
namespace class02
{
    internal class Program
    {
        static void Main(string[] args)
        {


            String file = "tickets.csv";
            string choice;

            do
            {
                // ask user a question
                Console.WriteLine("1) Read data from file.");
                Console.WriteLine("2) Create file from data.");
                Console.WriteLine("Enter any other key to exit.");
                // input response
                choice = Console.ReadLine();

                if (choice == "1")
                {
                    StreamReader sr = new StreamReader(file);
                    sr.ReadLine();

                    while (!sr.EndOfStream) { 
                    var line = sr.ReadLine();
                    string[] arr = line.Split('|');
                    Console.WriteLine($"course: {arr[0]},Grade: {arr[1]}");
                    }
                    sr.Close();//always close



                }
                else if (choice == "2")
                {
                    StreamWriter sw = new StreamWriter(file,true);


                    Console.WriteLine("Enter a course (Y/N)?");
                    string resp = Console.ReadLine().ToUpper();
                    if (resp != "Y") { break; }

                    Console.WriteLine("Enter the course name.");
                    string names = Console.ReadLine();

                    Console.WriteLine("Enter the course grade.");

                    String grades = Console.ReadLine().ToUpper();

                    sw.WriteLine($"{names} | {grades}");

                    sw.Close(); // alaways close and dont loop your close statement
                }

            } while (choice == "1" || choice == "2");
        }


        public static void ArrayNotes()
        {
            //string[] stringArray;
            //var doubleArray = new double[10];
            // int[] intArray;
            var names = new string[7];
            var grades = new string[7];
            int i = 0;

            for (i = 0; i < 7; i++)
            {
                Console.WriteLine("Enter a course (Y/N)?");
                string resp = Console.ReadLine().ToUpper();
                if (resp != "Y") { break; }

                Console.WriteLine("Enter the course name.");
                names[i] = Console.ReadLine();

                Console.WriteLine("Enter the course grade.");

                grades[i] = Console.ReadLine().ToUpper();
            }

            int gradePoints = 0;
            for (int x = 0; x < i; x++)
            {
                int gp = grades[x] == "A" ? 4 : grades[x] == "B" ? 3 : grades[x] == "C" ? 2 : grades[x] == "D" ? 1 : 0;
                gradePoints += gp;

                //  Console.WriteLine("Course: " + names[x] + "Grade:" + grades[x]);
                //  Console.WriteLine("Course: {0}, Grade: {1}, Points: {2}", names[x], grades[x], gp);
                Console.WriteLine($"Course :{names[x]} Grade: {grades[x]}");
            }

            double GPA = (double)gradePoints / i;
            // Console.WriteLine("GPA: {0:N2}", GPA);
            Console.WriteLine("GPA: {GPA:N2}");

        }
        public void ListNotes()
        {
            List<string> list = new List<string>();

            list.Add("");



        }

        public void FileReading()
        {
           
    } }
}


