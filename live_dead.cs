using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livedead
{
    class Program
    {

        static int findDaysInMonth(int i, int daysInMonth, int maybeVisokosnyGod)
        {
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { daysInMonth = 31; }
            if (i == 4 || i == 6 || i == 9 || i == 11) { daysInMonth = 30;  }
            if (i == 2 && maybeVisokosnyGod % 4 != 0) { daysInMonth = 28; }
            if (i == 2 && maybeVisokosnyGod % 4 == 0) { daysInMonth = 29; }
            return daysInMonth;
        }

        static bool caseSwitchCheck(string caseSwitchInput)
        {
            bool caseSwitchCheck = false;
            int caseSwitchCheckLength = caseSwitchInput.Length;
            if (caseSwitchCheckLength > 1) { Console.WriteLine("Your input is too long, start again");  caseSwitchCheck = true; }

            char[] caseSwitchInputArray = caseSwitchInput.ToCharArray();
            for (int i = 0; i < caseSwitchCheckLength; i++)
            {
                if ((int)caseSwitchInputArray[i] < 49 || (int)caseSwitchInputArray[i] > 50)
                {
                    Console.WriteLine("You can input only figures - 1 or 2. Please input again");
                    caseSwitchCheck = true;
                    break;
                }
            }
            return caseSwitchCheck;
        }

        static bool dateInputCheck(string someDateString)
        {
            bool dateInputCheck = false;
            int counter = 0;
            int someDateStringLength = someDateString.Length;
            if (someDateStringLength < 5) { Console.WriteLine("The date you have inpus is TOO short, please, try again!"); dateInputCheck = true; goto EndDateInputCheck; }

            char[] someDateCharArray = someDateString.ToCharArray();
            for (int i = 0; i < someDateStringLength; i++)
            {
                if ((int)someDateCharArray[0] == 46)
                {
                    Console.WriteLine("A date must not start with a DOT !");
                    dateInputCheck = true; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] < 46 || (int)someDateCharArray[i] == 47 || (int)someDateCharArray[i] > 57)
                {
                    Console.WriteLine("You must input only numbers and dots in format: dd.mm.yyyy ! Only A.D. dates are accepted. Please input again");
                    dateInputCheck = true; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] == 46 && (int)someDateCharArray[i - 1] == 46)
                {
                    Console.WriteLine("There mustn't be to DOTS in a row!");
                    dateInputCheck = true; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] == 46) { counter++; }
            }
            if (counter != 2)
            {
                Console.WriteLine("But there MUST be two dots to make dd.mm.yyyy format !!! ");
                dateInputCheck = true; goto EndDateInputCheck;
            }
            if ((int)someDateCharArray[someDateStringLength - 1] == 46)
            {
                Console.WriteLine("The date mustn't end with a DOT !");
                dateInputCheck = true; goto EndDateInputCheck;
            }

            string[] someDateDDMMYYYYArray = someDateString.Split('.');
            int[] someDateDDMMYYYYNumericArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int number = Convert.ToInt32(someDateDDMMYYYYArray[i]);
                someDateDDMMYYYYNumericArray[i] = number;
            } // created dd.mm.yyyy array for input date

            DateTime dt = DateTime.Now;
            string currentDateDDMMYYYCheck = dt.ToShortDateString();
            string[] currentDateDDMMYYYYArray = currentDateDDMMYYYCheck.Split('.');
            int[] currentDateDDMMYYYYNumericArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int number = Convert.ToInt32(currentDateDDMMYYYYArray[i]);
                currentDateDDMMYYYYNumericArray[i] = number;
            } // created dd.mm.yyyy array for current date

            if (currentDateDDMMYYYYNumericArray[2] < someDateDDMMYYYYNumericArray[2])
            {
                Console.WriteLine("Year of input date is AFTER the current date? Please input again");
                dateInputCheck = true; goto EndDateInputCheck;
            }
            if (currentDateDDMMYYYYNumericArray[2] == someDateDDMMYYYYNumericArray[2] && currentDateDDMMYYYYNumericArray[1] < someDateDDMMYYYYNumericArray[1])
            {
                Console.WriteLine("Month of input date is AFTER the current date? Please input again");
                dateInputCheck = true; goto EndDateInputCheck;
            }
            if (currentDateDDMMYYYYNumericArray[2] == someDateDDMMYYYYNumericArray[2] && currentDateDDMMYYYYNumericArray[1] == someDateDDMMYYYYNumericArray[1] && currentDateDDMMYYYYNumericArray[0] < someDateDDMMYYYYNumericArray[0])
            {
                Console.WriteLine("Day of input date is AFTER the current date? Please input again");
                dateInputCheck = true; goto EndDateInputCheck;
            }
            if (someDateDDMMYYYYNumericArray[1] > 12)
            {
                Console.WriteLine("There can not be a month number " + someDateDDMMYYYYNumericArray[1] + " ! Please input again");
                dateInputCheck = true; goto EndDateInputCheck;
            }
            int maybeDDIsMoreThanDaysInMonth = findDaysInMonth(someDateDDMMYYYYNumericArray[1], 0, someDateDDMMYYYYNumericArray[2]);
            if (someDateDDMMYYYYNumericArray[0] > maybeDDIsMoreThanDaysInMonth)
            {
                Console.WriteLine("there are only " + maybeDDIsMoreThanDaysInMonth + " days in month " + someDateDDMMYYYYNumericArray[1] + " in year " + someDateDDMMYYYYNumericArray[2] + " ! Please input again");
                dateInputCheck = true; goto EndDateInputCheck;
            }
        EndDateInputCheck:
            return dateInputCheck;
        } // we've checked the input format dd.mm.yyyy


        static int yearsFull(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast, int daysOfLife, int peremennaya)
        {
            for (int i = yyyyBirth + 1; i < yyyyLast; i++)
            {
                if (i % 4 == 0) { daysOfLife += 366; continue; }
                daysOfLife += 365;
            }
            return daysOfLife;
        }  // counts FULL YEARS that were lived

    static int monthFullFirstOrOnly(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast, int daysOfLife, int peremennaya)
        {
            if (yyyyBirth != yyyyLast)
            {
                for (int i = mmBirth + 1; i <= 12; i++)
                {
                int daysInMonth = findDaysInMonth(i, 0, yyyyBirth);
                daysOfLife += daysInMonth;
             //   Console.WriteLine("first year full months!  i = " + i + " itog = " + daysOfLife);
                }
            }
            else if (yyyyBirth == yyyyLast)
            {
                for (int i = mmBirth + 1; i < mmLast; i++)
                {
                    int daysInMonth = findDaysInMonth(i, 0, yyyyBirth);
                    daysOfLife += daysInMonth;
                 //   Console.WriteLine("ONLY year full months! i = " + i + " itog = " + daysOfLife);
                }
            }
            return daysOfLife;
        }  // counts days of FULL MONTHS of the 1-st or THE ONLY life year

        static int daysFirstOrOnlyMonth(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast, int daysOfLife, int peremennaya)
        {
            if (mmBirth == 1 || mmBirth == 3 || mmBirth == 5 || mmBirth == 7 || mmBirth == 8 || mmBirth == 10 || mmBirth == 12) { peremennaya = 31; }
            if (mmBirth == 4 || mmBirth == 6 || mmBirth == 9 || mmBirth == 11) { peremennaya = 30; }
            if (mmBirth == 2) { peremennaya = 28; }
            if (mmBirth == 2 && yyyyBirth % 4 == 0) { peremennaya = 29; }
            if (mmBirth == mmLast && yyyyBirth == yyyyLast) { peremennaya = ddLast; }
            for (int i = ddBirth; i <= peremennaya; i++)
            {
                daysOfLife++;
             //   Console.WriteLine("plus day first month!");
            }
            return daysOfLife; 
        }  // counts days of the first NOT FULL month in life OR of the ONLY MONTH in one's life

        static int monthFullLastYear(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast, int daysOfLife, int peremennaya)
        {
            if (yyyyBirth != yyyyLast)
            {
                for (int i = 1; i < mmLast; i++)
                {
                    int daysInMonth = findDaysInMonth(i, 0, yyyyLast);
                    daysOfLife += daysInMonth;
                 //   Console.WriteLine("last months! i = " + i + " itog = " + daysOfLife);
                }
            }
            return daysOfLife;
        }  // counts FULL MONTHS of the LAST YEAR (if it is NOT THE ONLY YEAR in life)

        static int daysLastMonthLastYear(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast, int daysOfLife, int peremennaya)
        {
            {
                for (int i = 1; i <= ddLast; i++)
                    if (yyyyBirth == yyyyLast && mmBirth == mmLast) { break; }// не входит в цикл при значении годарождения 2020 + не входит в цикл при значении месяца ТЕКУЩИЙ (10)
                    else
                   { daysOfLife++; }
            }
            return daysOfLife;
        }  // counts days of the last NOT FULL month (if it is NOT THE ONLY in life)

        static bool birthAndDeathCheck(int ddBirth, int mmBirth, int yyyyBirth, int ddLast, int mmLast, int yyyyLast)
        {
            bool deadBeforeBirth = false;
            if (yyyyLast < yyyyBirth)
            { Console.WriteLine("death YEAR is earlier than birth year? input death date again!"); deadBeforeBirth = true; goto EndBirthAndDeathCheck;  }
            if (yyyyLast == yyyyBirth && mmLast < mmBirth)
            { Console.WriteLine("death MONTH is earlier than birth month? input death date again!"); deadBeforeBirth = true; goto EndBirthAndDeathCheck; }
            if (yyyyLast == yyyyBirth && mmLast == mmBirth && ddLast < ddBirth)
            { Console.WriteLine("death DAY is earlier than birth day? input death date again!"); deadBeforeBirth = true; }

        EndBirthAndDeathCheck:
            return deadBeforeBirth;
        }



        static void Main(string[] args)
        {


        Begin:
            int daysOfLife = 0;
            bool thereIsAnError = false;
            Console.Write("If you want to count life days of a living person, input 1 "); Console.WriteLine();
            Console.Write("If you want to count life days of a dead person, input 2 "); Console.WriteLine();
            string caseSwitchInput = Console.ReadLine();
            if (String.IsNullOrWhiteSpace(caseSwitchInput))
            { Console.WriteLine("You have input an empty line. Let's start again from the very beginning!"); goto Begin; }

            thereIsAnError = caseSwitchCheck(caseSwitchInput);
            if (thereIsAnError == true) { goto Begin; }

            int caseSwitchInputNumber = Convert.ToInt32(caseSwitchInput);

            switch (caseSwitchInputNumber)
            {

                case 1:
                    Console.Write("Input birth date in format dd.mm.yyyy ");
                    string birthDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(birthDateString))
                    { Console.WriteLine("You have input an empty line. Input birth date again!"); goto case 1; }

                    thereIsAnError = dateInputCheck(birthDateString);
                    if (thereIsAnError == true) { goto case 1; }

                    string[] birthDateDDMMYYYYArray = birthDateString.Split('.');
                    int[] birthDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(birthDateDDMMYYYYArray[i]);
                        birthDateDDMMYYYYNumericArray[i] = number;
                    } // created dd.mm.yyyy array for input date

                    DateTime dt = DateTime.Now;
                    string currentDateDDMMYYYCheck = dt.ToShortDateString();
                    string[] currentDateDDMMYYYYArray = currentDateDDMMYYYCheck.Split('.');
                    int[] currentDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(currentDateDDMMYYYYArray[i]);
                        currentDateDDMMYYYYNumericArray[i] = number;
                    } // created dd.mm.yyyy array for current date

                    daysOfLife = yearsFull(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[0], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = monthFullFirstOrOnly(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[0], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2], daysOfLife, 0); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года
                    daysOfLife = daysFirstOrOnlyMonth(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[0], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = monthFullLastYear(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[0], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = daysLastMonthLastYear(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[0], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2], daysOfLife, 0);

                    Console.WriteLine("from " + birthDateString + " to " + currentDateDDMMYYYCheck + " it is " + daysOfLife + " days of life");
                    break;

                case 2:
                    Console.Write("Input birth date in format dd.mm.yyyy ");
                    birthDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(birthDateString))
                    { Console.WriteLine("You have input an empty line. Input birth date again!"); goto case 2; }

                    thereIsAnError = dateInputCheck(birthDateString);
                    if (thereIsAnError == true) { goto case 2; }

                    birthDateDDMMYYYYArray = birthDateString.Split('.');
                    birthDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(birthDateDDMMYYYYArray[i]);
                        birthDateDDMMYYYYNumericArray[i] = number;
                    } // created dd.mm.yyyy array for input date

                    InputDeathDate:
                    Console.Write("Input death date in format dd.mm.yyyy ");
                    string deathDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(deathDateString))
                    { Console.WriteLine("You have input an empty line. Input death date again!"); goto InputDeathDate; }

                    thereIsAnError = dateInputCheck(deathDateString);
                    if (thereIsAnError == true) { goto InputDeathDate; }

                    string[] deathDateDDMMYYYYArray = deathDateString.Split('.');
                    int[] deathDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(deathDateDDMMYYYYArray[i]);
                        deathDateDDMMYYYYNumericArray[i] = number;
                    } // created dd.mm.yyyy array for input death date

                    bool deadBeforeBirth = birthAndDeathCheck(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2]);
                    if (deadBeforeBirth == true) { goto InputDeathDate; }

                    daysOfLife = yearsFull(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = monthFullFirstOrOnly(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2], daysOfLife, 0); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года
                    daysOfLife = daysFirstOrOnlyMonth(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = monthFullLastYear(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2], daysOfLife, 0);
                    daysOfLife = daysLastMonthLastYear(birthDateDDMMYYYYNumericArray[0], birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[0], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2], daysOfLife, 0);

                    Console.WriteLine("from " + birthDateString + " to " + deathDateString + " it is " + daysOfLife + " days of life");

                    break;
            }

            Console.WriteLine("want to try again? input 8 an press enter!");
            Console.WriteLine("If you want the programm to be closed - input anything but 8.");
            string input = Console.ReadLine();
            if (input == "8") { goto Begin; }
            else Console.WriteLine("have a good day, bye!");


        }
    }
}
