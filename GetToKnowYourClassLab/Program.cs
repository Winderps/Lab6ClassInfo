using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;

namespace GetToKnowYourClassLab
{
    class Program
    {
        static string[][] ClassInfo =
        {   //            Name            Hometown       Favorite food             Favorite band
            new string[] {"Mike Reardon", "Wyoming, MI", "Homemade Mac n' Cheese", "Bayside" },
            new string[] {"Jim Dickens", "Letterkenny, Ontario", "Steak", "Queen" },
            new string[] {"Jared Keeso", "Letterkenny, Ontario", "Fresh Produce", "Aerosmith" },
            new string[] {"Squirrely Dan", "New York, NY", "Mashed Potatoes n' Gravy", "Smashing Pumpkins" },
            new string[] {"Tyler Johnston", "Wyoming, MI", "Lasagna", "Black Sabbath" },
            new string[] {"Leroy Jethro Gibbs", "Washington DC", "Taco Casserole", "Def Leppard" },
            new string[] {"Donald Mallard", "Centralia, PN", "Burgers", "Lynyrd Skynyrd" },
            new string[] {"Timothy McGee", "Colma, CA", "Omelettes", "Ozzy Osbourne" },
            new string[] {"Anthony DiNozzo", "Roswell, NM", "Pizza", "The Who" },
            new string[] {"Abby Sciuto", "Hildale, UT", "Beef Stew", "Kid Rock" },
            new string[] {"Nathan Dales", "Miracle Village, FL", "Black Bean Soup", "AC/DC" },
            new string[] {"Dylan Playfair", "Coffee Springs, AL", "Chocolate Cake", "Bon Jovi" },
            new string[] {"Andrew Herr", "Why, AZ", "Grilled Cheese", "Survivor" },
            new string[] {"Jacob Tierney", "Yolo, CA", "Crab Rangoon", "Journey" },
            new string[] {"Nicholas Torres", "Hel, MI", "Orange Chicken", "Scorpions" },
            new string[] {"Jenny Shepard", "Slaughter Beach, DL", "Sushi", "Earth Wind & Fire" },
            new string[] {"Caitlin Todd", "Hazardville, CT", "Fried Fish", "Led Zeppelin" },
            new string[] {"Eleanor Bishop", "Last Chance, CO", "Clam Chowder", "Guns n' Roses" },
            new string[] {"Leon Vance", "Bliss Corner, MA", "Mushroom Chicken", "The Beatles" },
            new string[] {"Mark Forward", "Tinkerville, NH", "Roast Beef", "The Rolling Stones" },
            new string[] {"Jacqueline Sloane", "Truth or Consequences, NM", "Kielbasa", "Foghat" }
        };
        static void Main(string[] args)
        {
            Console.Title = "Classmate Information App";
            Console.WriteLine("Welcome to the Class Information Database");

            bool cont = true;
            while (cont)
            {
                Console.Write($"Please enter the name or student number of someone you would like to look up (1-{ClassInfo.Length}): ");
                string input = Console.ReadLine();
                string[] studentInfo = null;
                bool validInput = false;
                while (!validInput)
                {
                    try
                    {
                        try
                        {
                            int studentId = int.Parse(input);
                            studentInfo = GetStudentInfo(studentId-1);
                            validInput = true;
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("That student does not exist!");
                        }
                    }
                    catch (FormatException)
                    {
                        string[][] possibleResults = GetStudentInfo(input);
                        if (possibleResults.Equals(null))
                        {
                            Console.WriteLine("I couldn't find any students with that name");
                        }
                        else
                        {
                            if (possibleResults.Length > 1)
                            {
                                bool validInput2 = false;
                                while (!validInput2)
                                {
                                    try
                                    {
                                        Console.WriteLine("Multiple matches found!");
                                        for (int i = 0; i < possibleResults.Length; i++)
                                        {
                                            Console.WriteLine($"{i + 1}. {possibleResults[i][0]}");
                                        }
                                        Console.Write("Please enter the number of the student you want: ");
                                        studentInfo = possibleResults[int.Parse(Console.ReadLine()) - 1];
                                        validInput2 = true;
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("That was too high of a number!");
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("That wasn't a number at all!");
                                    }
                                }
                            }
                            else
                            {
                                studentInfo = possibleResults[0];
                            }
                            validInput = true;
                        }
                    }
                }
                bool validInput3 = false;
                while (!validInput3)
                {
                    Console.Write($"What information would you like on {studentInfo[0]}? Please enter hometown, food, band, or all: ");

                    switch(Console.ReadLine().ToLower())
                    {
                        case "hometown":
                            validInput3 = true;
                            Console.WriteLine($"{studentInfo[0]} is from {studentInfo[1]}");
                            break;
                        case "food":
                            validInput3 = true;
                            Console.WriteLine($"{studentInfo[0]} likes to eat {studentInfo[2]}");
                            break;
                        case "band":
                            validInput3 = true;
                            Console.WriteLine($"{studentInfo[0]} listens to {studentInfo[3]}");
                            break;
                        case "all":
                            Console.WriteLine($"{studentInfo[0]} is from {studentInfo[1]}, they like to eat {studentInfo[2]} and listen to {studentInfo[3]}");
                            validInput3 = true;
                            break;
                        default:
                            Console.WriteLine("Oops! I couldn't understand that, try again!");
                            break;
                    }
                }

                Console.Write("Enter y(es) to continue or anything else to exit: ");
                cont = Console.ReadLine().ToLower().StartsWith('y');
            }
        }

        static string[] GetStudentInfo(int id)
        {
            return ClassInfo[id];
        }
        static string[][] GetStudentInfo(string name)
        {
            List<string[]> ret = new List<string[]>();
            foreach(string[] student in ClassInfo)
            {
                if (student[0].ToLower().StartsWith(name))
                {
                    ret.Add(student);
                }
            }
            if (ret.Count == 0)
                return null;
            return ret.ToArray();
        }
    }
}
