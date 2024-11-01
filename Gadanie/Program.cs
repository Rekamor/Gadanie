using System.Text.Json;

public class Program
{
    
    public static void Main()
    {
        const string filePath = @"C:\Users\1092023\RiderProjects\Gadanie\Gadanie\adjectives_by_letter.json";
        var jsonString = File.ReadAllText(filePath);
        var wordsDictionary = JsonSerializer.Deserialize<Dictionary<string, List<string>>>(jsonString);
        
        Random random = new Random();
        string name, sex, answer;
        
        Gadanie:
        Console.WriteLine("Введите имя или фамилию");
        name = Console.ReadLine().ToUpper();
        
        Console.WriteLine("Введите пол (М/Ж)");
        sex = Console.ReadLine();

        Console.WriteLine("\nРасшифровка вашего имени:\n");

        for (int i = 0; i < name.Length; i++)
        {
            try
            {
                if (sex == "Ж" || sex == "ж" || sex == "F" || sex == "f")
                {
                    Console.WriteLine(
                        name[i] + " - " + Female(wordsDictionary[Convert.ToString(name[i])][random
                            .Next(wordsDictionary[Convert.ToString(name[i])].Count)])
                    );
                }
                else
                {
                    Console.WriteLine(
                        name[i] + " - " + wordsDictionary[Convert.ToString(name[i])][random
                            .Next(wordsDictionary[Convert.ToString(name[i])].Count)]
                    );
                }
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
        Console.WriteLine("\nХотите продолжить?");
        answer = Console.ReadLine();
        if (answer.ToUpper() == "ДА" || answer.ToUpper() == "YES" || answer.ToUpper() == "Д" || answer.ToUpper() == "Y")
        {
            Console.WriteLine();
            goto Gadanie;
        }
    }

    static string Female(string word)
    {
        return word + "\b\bая";
    }
}
