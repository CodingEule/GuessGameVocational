using System.Numerics;
using System.Windows.Markup;

namespace RateSpiel
{
    class Program
    {
        static void Main(string[] args)
        {

            int max;
            int min;
            int chosenNumber = 0;
            Boolean playAgain = true;
            Boolean useBinary = false;

            
            Console.WriteLine("Ich möchte ein Spiel mit Ihnen spielen!");
            Console.WriteLine("Nenne mir den unteren Grenze: ");
            min = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Nenne mir den obere Grenze: ");
            max = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ich werde mir eine Zahl aussuchen zwischen"+min+" und" + max);
            Console.WriteLine("Wie viele versuche möchtest du haben?");
            int maxTry = Convert.ToInt32(Console.ReadLine());


            


            while (playAgain)
            {
                int counter = 0;
                int randomNumber = new Random().Next(min, max);

                Console.WriteLine("Willst du die BinarySearch suchen lassen?");
                Console.WriteLine("Drücke y für ja oder eine andere Taste für nein.");
                string useBinaryQuestion = Console.ReadLine();

                if ("y".Equals(useBinaryQuestion)){
                    // call binarySearch return array[0,0, boolean findValue?]
                    int[] result = binarySearch(maxTry ,randomNumber ,min ,max);
                    Console.WriteLine(randomNumber);
                    int valueFound = result[0];
                    int tries = result[1];
                    int findRealOne = result[2];

                    if(findRealOne == 0)
                    {
                        Console.WriteLine("Leider nicht den richtigen Wert in der in angegebenen Versuchen gefunden");
                    }
                    else
                    {
                        Console.WriteLine("Der Wert ist " + valueFound + " und ich habe " + tries + "versuche gebraucht um ihn zu finden");
                    }

                }
                else
                {
                    do
                    {
                        Console.WriteLine("Rate welche Zahl ich mir ausgesucht habe.");
                        try
                        {
                            chosenNumber = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Das ist keine Zahl!");
                        }

                        if (chosenNumber == 0)
                        {
                            Console.WriteLine("Bitte gib eine Zahl zwischen " + min + " " + max);
                            continue;
                        }
                        else
                        {
                            if (randomNumber > chosenNumber)
                            {
                                Console.WriteLine("Die Zahl ist zu klein!");
                            }
                            else if (randomNumber < chosenNumber)
                            {
                                Console.WriteLine("Die Zahl ist zu groß!");
                            }
                            else
                            {
                                Console.WriteLine("Du hast gewonnen");
                                break;
                            }
                        } counter++;
                        Console.WriteLine(randomNumber);
                    } while (counter < maxTry);

                    Console.WriteLine("Möchtest du ein weiteres mal spielen");
                    Console.WriteLine("Gib y für ja oder eine andere Taste für nein ein: ");
                    string again = Console.ReadLine();

                    if ("y".Equals(again))
                    {
                        playAgain = true;
                    }
                    else
                    {
                        Console.WriteLine("Danke für's spielen");
                        playAgain = false;

                    }
                }
            }

        }
        static int[] binarySearch(int rounds, int searched, int min, int max)
        {
            int count = 0;
            int find=-1;
            int[] values = new int[3];

            while (count != rounds || searched != find)
            {
                count++;

                int valueSearch = max - min;
                find = valueSearch / 2;
                if (find == searched)
                {
                    values[0]= find;
                    values[1]= count;
                    values[2] = 1;
                    return values;
                }else if(find < searched)
                {
                    min = find +1;
                    Console.WriteLine(valueSearch);
                }
                else
                {
                    Console.WriteLine(valueSearch);
                    max = find - 1;
                }
                
            }
            values[0] = find;
            values[1] = count;
            values[2] = 0;
            return values;

        }
    }

}