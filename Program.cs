namespace TextDecorator;

class Program
{
    static void Main(string[] args)
    {
        // foreach (string s in args)
        // {
        //     Console.WriteLine(s);
        // }

        if (args.Length <= 1 || args[0].ToLower() == "help")
        {
            ShowHelp();
            return;
        }
        
        switch (args[0].ToLower())
        {
            case "b":
            case "#":
                BlockMode(args);
                break;
            case "alt":
                AltMode(args);
                break;
            case "pig":
                PigLatin(args);
                break;
            default:
                ShowHelp();
                break;
        }
    }

    private static void PigLatin(string[] args)
    {
        string[] input = args.Skip(1).ToArray();
        foreach (string word in input)
        {
            Console.Write(Piggify(word) + " ");
        }

        Console.Write("\n");

        // Pig Latin 101
        // If the word starts with a vowel simple add "yay" to the end
        // Otherwise add the characters before the first vowel to the end and add "ay"

    }

    private static string Piggify(string word)
    {
        Char[] vowels = new[] { 'a', 'e', 'i', 'o', 'u'};
        if (vowels.Contains(word[0]))
        {
            return word + "yay";
        }
        
        vowels = new [] { 'a', 'e', 'i', 'o', 'u', 'y'};
        
        //dealing with a word that starts with a consonant.
        String output_start = "";
        String output_end = "";
        String ultimate_end = "ay";
        char? punct = null;

        bool begin = true;
        bool containsUpper = false;
        foreach (char c in word)
        {
            if (vowels.Contains(Char.ToLower(c)))
            {
                begin = false;
            }

            if (!containsUpper && char.IsUpper(c))
            {
                containsUpper = true;
            }
            
            if (char.IsPunctuation(c))
            {
                punct = c;
                break;
            }
            
            if (begin)
            {
                output_end += Char.ToLower(c);
            }
            else
            {
                output_start += Char.ToLower(c);
            }
        }

        if (containsUpper)
        {
            string newfront = "";
            for (int i = 0; i < output_start.Length; i++)
            {
                if (i == 0)
                {
                    
                    newfront += Char.ToUpper(output_start[i]);
                }
                else
                {
                    newfront += output_start[i];
                }
            }

            output_start = newfront;
        }

        if (punct != null)
        {
            ultimate_end += punct;
        }

        return output_start + output_end + ultimate_end;
    }

    private static void AltMode(string[] args)
    {
        string message = ArgsToString(args);

        bool caps = false;
        foreach (char c in message)
        {
            char output;
            if (caps)
            {
                output = Char.ToUpper(c);
            }
            else
            {
                output = Char.ToLower(c);
            }
            
            caps = !caps;
            Console.Write(output);
        }
        Console.Write("\n");
    }

    private static void BlockMode(string[] args)
    {
        string message = ArgsToString(args);

        for (int i = 0; i < message.Length +4; i++)
        {
            Console.Write("#");
        }
        Console.WriteLine( "\n# " + message + " #" );
        for (int i = 0; i < message.Length +4; i++)
        {
            Console.Write("#");
        }
        Console.WriteLine("");
    }

    static String ArgsToString(String[] args)
    {
        String[] message_array = args.Skip(1).ToArray();
        String message = "";
        foreach (string word in message_array)
        {
            message += word + " ";
        }
        return message.Trim();
    }

    static void ShowHelp()
    {
        Console.WriteLine("This is help!");
        Console.WriteLine("You must provide at least 2 arguments");
        Console.WriteLine("use B for clock mode");
        Console.WriteLine("use alt for alternating capitalization");
        Console.WriteLine("use pig for pig latin");
    }
}