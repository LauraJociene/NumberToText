using System;

namespace NumberToText
{
    class Program
    {
        static void Main(string[] args)
        {

            string userNumber = GetUserNumber("įveskite pasirinktą skaičių nuo -999999999 iki 999999999:");
            int convertedNumber = ConvertInputTextToInt(userNumber);
            Console.WriteLine($"Konvertuotas skaičius: {convertedNumber}");
            bool IsInRange = IsNumberInRange(convertedNumber);
            Console.WriteLine($"Ar skaičius patenka i rėžius -999999999 iki 999999999: {IsInRange}");
            string numberInWords = ChangeNumberToText(convertedNumber);
            Console.WriteLine($"Žodžiais: {numberInWords}");


        }

        static string GetUserNumber(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        static bool IsInputTextIsANumber(string inputText)
        {
            string text = inputText;

            for (int i = 0; i < text.Length; i++)
            {
                char character = text[i];

                if (character == '-')
                {
                    if (character == text[0] && text.Length > 1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ne skaičius");
                        return false;
                    }
                }
                else if (character == '0' || character == '1' || character == '2' || character == '3' || character == '4' || character == '5' || character == '6'
                    || character == '7' || character == '8' || character == '9')
                {
                    continue;
                }

                else
                {
                    Console.WriteLine("Ne skaičius");
                    return false;
                }


            }
            Console.WriteLine($"Skaičius: {inputText}");
            return true;
        }


        static int ConvertInputTextToInt(string inputText)
        {
            bool badInput;

            Console.WriteLine($"Įvesta reikšmė: '{inputText}'");

            if (!IsInputTextIsANumber(inputText))
            {
                do
                {

                    inputText = GetUserNumber("Bloga Įvestis. Įveskite pasirinktą skaičių nuo -999999999 iki 999999999:");

                    badInput = !IsInputTextIsANumber(inputText);

                } while (badInput);

            }
            return Convert.ToInt32(inputText);
        }


        static bool IsNumberInRange(int number)
        {

            if (number >= -999999999 && number <= 999999999)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ChangeNumberToText(int inputNumber)
        {
            if (inputNumber == 0)
                return "nulis";

            if (inputNumber < 0)
                return "minus " + ChangeNumberToText(Math.Abs(inputNumber));

            string numberInWords = "";

            if ((inputNumber / 1000000) > 0)
            {
                if (inputNumber / 1000000 == 1)
                {
                    numberInWords += " milijonas ";
                }
                else
                {
                    numberInWords += ChangeNumberToText(inputNumber / 1000000) + (((inputNumber / 1000000) % 100 == 0) ? " milijonų " : " milijonai ");

                }
                inputNumber %= 1000000;

            }

            if ((inputNumber / 1000) > 0)
            {
                if (inputNumber / 1000 == 1)
                {
                    numberInWords += " tūkstantis ";
                }
                else
                {
                    numberInWords += ChangeNumberToText(inputNumber / 1000) + (((inputNumber / 1000) % 10 == 0) ? " tūkstančių " : " tūkstančiai ");
                }

                inputNumber %= 1000;
            }

            if ((inputNumber / 100) > 0)
            {
                if (inputNumber / 100 == 1)
                {
                    numberInWords += " šimtas ";
                }
                else
                {
                    numberInWords += ChangeNumberToText(inputNumber / 100) + " šimtai ";

                }
                inputNumber %= 100;
            }

            if (inputNumber > 0)
            {

                var units = new[] { "nulis", "vienas", "du", "trys", "keturi", "penki", "šeši", "septyni", "aštuoni", "devyni", "dešimt", "vienuolika", "dvylika", "trylika", "keturiolika", "penkiolika", "šešiolika", "septyniolika", "aštuoniolika", "devyniolika" };
                var dozens = new[] { "nulis", "dešimt", "dvidešimt", "trisdešimt", "keturiasdešimt", "penkiasdešimt", "šešiasdešimt", "septyniasdešimt", "aštuoniasdešimt", "devyniasdešimt" };

                if (inputNumber < 20)
                    numberInWords += units[inputNumber];
                else
                {
                    numberInWords += dozens[inputNumber / 10];
                    if ((inputNumber % 10) > 0)
                        numberInWords += " " + units[inputNumber % 10];
                }
            }

            return numberInWords;
        }


    }
}
