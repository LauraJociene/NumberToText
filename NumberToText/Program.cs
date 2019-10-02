using System;

namespace NumberToText
{
    class Program
    {
        static void Main(string[] args)
        {

            string userNumber = GetUserNumber("įveskite pasirinktą skaičių nuo -99 iki 99:");
            Console.WriteLine($"Įvesta reikšmė: '{userNumber}'");
            int convertedNumber = ConvertInputTextInt(userNumber);
            Console.WriteLine($"Konvertuotas skaičius: {convertedNumber}");
            bool IsInRange = IsNumberInRange(convertedNumber);
            Console.WriteLine($"Ar skaičius patenka i rėžius -99...99: {IsInRange}");
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
                char simbolis = text[i];

                if (simbolis == '-')
                {
                    if (simbolis == text[0] && text.Length > 1)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine("Ne skaičius");
                        return false;
                    }
                }
                else if (simbolis == '0' || simbolis == '1' || simbolis == '2' || simbolis == '3' || simbolis == '4' || simbolis == '5' || simbolis == '6'
                    || simbolis == '7' || simbolis == '8' || simbolis == '9')
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


        static int ConvertInputTextInt(string inputText)
        {

            if (IsInputTextIsANumber(inputText))
            {

                return Convert.ToInt32(inputText);
            }

            else
            {
                return 0;
            }
        }

        static bool IsNumberInRange(int number)
        {
            if (number >= -99 && number <= 99)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ChangeNumberToText(int inputNumber)
        {

            string sign = "";
            string dozens ="";
            string units="";

            int number;
            if (inputNumber < 0)
            {
                sign = "minus";
                number = inputNumber * -1;
            }
            else
            {
                number = inputNumber;
            }

            if ((number>=0 && number <20) || number%10==0)
            {
                units=GetTextForNumber(number);
            }

            if (number>20 && number<100 && number % 10 != 0)
            {
                dozens = GetTextForNumber((number / 10)*10);
                units = GetTextForNumber(number % 10);
            }

            return sign + " " +  dozens + " " + units;
        }

        static string GetTextForNumber (int number)
        {

            string name;
            switch (number)
            {
                case 0:
                    name = "nulis";
                    break;
                case 1:
                    name = "vienas";
                    break;
                case 2:
                    name = "du";
                    break;
                case 3:
                    name = "trys";
                    break;
                case 4:
                    name = "keturi";
                    break;
                case 5:
                    name = "penki";
                    break;
                case 6:
                    name = "šeši";
                    break;
                case 7:
                    name = "septyni";
                    break;
                case 8:
                    name = "aštuoni";
                    break;
                case 9:
                    name = "devyni";
                    break;
                case 10:
                    name = "dešimt";
                    break;
                case 11:
                    name = "vienuolika";
                    break;
                case 12:
                    name = "dvylika";
                    break;
                case 13:
                    name = "trylika";
                    break;
                case 14:
                    name = "keturiolika";
                    break;
                case 15:
                    name = "penkiolika";
                    break;
                case 16:
                    name = "šešiolika";
                    break;
                case 17:
                    name = "septyniolika";
                    break;
                case 18:
                    name = "aštuoniolika";
                    break;
                case 19:
                    name = "devyniolika";
                    break;
                case 20:
                    name = "dvidešimt";
                    break;
                case 30:
                    name = "trisdešimt";
                    break;
                case 40:
                    name = "keturiasdešimt";
                    break;
                case 50:
                    name = "penkiasdešimt";
                    break;
                case 60:
                    name = "šešiasdešimt";
                    break;
                case 70:
                    name = "septyniasdešimt";
                    break;
                case 80:
                    name = "aštuoniasdešimt";
                    break;
                case 90:
                    name = "devyniasdešimt";
                    break;
                default:
                    name = "nežinomas";
                    break;
            }
            return name;
        }

    }
}
