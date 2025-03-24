using System.Text.Json;

public class Program
{
    public static long NormiceMod(long value, long divider)
    {
        if (value >= 0) return value % divider;
        else return value % divider + divider;
    }
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
            string ch = name[i].ToString();
            if (wordsDictionary.ContainsKey(ch))
            {
                long indx = NormiceMod((long)name.GetHashCode() * (i + 1), wordsDictionary[ch].Count);
                if (sex == "Ж" || sex == "ж" || sex == "F" || sex == "f")
                {
                    Console.WriteLine(ch + " - " + Female(wordsDictionary[ch][(int)indx]));
                }
                else
                {
                    Console.WriteLine(ch + " - " + wordsDictionary[ch][(int)indx]);
                }
            }
            else
            {
                Console.WriteLine(ch == " " ?  "" : ch + " - ?");
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