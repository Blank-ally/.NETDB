namespace module3classcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select your animal");
            String animalSelection = Console.ReadLine();

            switch (animalSelection)
            {
                case "Pig":
                    Console.WriteLine("oink");
                    break;
                case "Dog":
                    Console.WriteLine("bark");
                    break;
                case "Cow":
                    Console.WriteLine("moo");
                    break;
                case "Cat":
                    Console.WriteLine("meow");
                    break;
                case "Chicken":
                    Console.WriteLine("chicken");
                    break;
                default: Console.WriteLine("silence");
                    break;
            }
        }
    }
}