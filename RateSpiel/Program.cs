
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


            Console.WriteLine("Ich möchte ein Spiel mit Ihnen spielen!");
            Console.WriteLine("Nenne mir den unteren Grenze: ");
            min = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Nenne mir den obere Grenze: ");
            max = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Ich werde mir eine Zahl aussuchen zwischen" + min + " und " + max);
            Console.WriteLine("Wie viele versuche möchtest du haben?");
            int maxTry = Convert.ToInt32(Console.ReadLine());





            while (playAgain)
            {
                int counter = 0;
                int randomNumber = new Random().Next(min, max);

                Console.WriteLine("Willst du die BinarySearch suchen lassen?");
                Console.WriteLine("Drücke y für ja oder eine andere Taste für nein.");
                string useBinaryQuestion = Console.ReadLine();

                if ("y".Equals(useBinaryQuestion))
                {
                    Console.WriteLine(BinarySearch(maxTry, randomNumber, min, max));
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
                            Console.WriteLine("Bitte gib eine Zahl zwischen " + min + " & " + max);
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
                        }

                        counter++;
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

        static string BinarySearch(int rounds, int searched, int min, int max)
        {
            string output ="";
            int mid;
            while (rounds != 0)
            {
                rounds--;
                mid = (min + max) /  2;
                if (searched == mid)
                {
                    output = "Du hast den Wert gefunden. Er lautet " + mid;
                    break;
                }else if(mid < searched)
                {
                    min = mid + 1 ;
                }
                else
                {
                    max = mid -  1;
                }

            }

            if (string.IsNullOrEmpty(output))
            {
                output = "Leider haben wir den Wert nicht gefunden.";
            }
            
            return output;
        }
    }

}