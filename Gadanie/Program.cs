using System.Text.Json;

public class Program
{
    
    public static void Main()
    {
        const string filePath = @"C:\Users\y9Kap\RiderProjects\Gadanie\Gadanie\adjectives_by_letter.json";
        var jsonString = File.ReadAllText(filePath);
        var wordsDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
        Random random = new Random();

        Console.WriteLine("Введите ваше имя: ");
        string name = Console.ReadLine().ToUpper();

        Console.WriteLine("Расшифровка вашего имени: \n");

        for (int i = 0; i < name.Length; i++)
        {
            try
            {
                Console.WriteLine(
                    name[i] + " - " + wordsDictionary[Convert.ToString(name[i])][random
                                .Next(wordsDictionary[Convert.ToString(name[i])].Count)]
                );
            }
            catch
            {
                if (name[i] == ' ')
                {
                    Console.WriteLine(" ");
                }
                else
                {
                    Console.WriteLine(name[i] + " - ?");
                }
            }
        }
    }
}