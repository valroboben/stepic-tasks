using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace livedead
{
    class Program
    {




        static public int findDaysInMonth(int i, int maybeVisokosnyGod)
        {
            int daysInMonth = 0;
            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12)
            {
                daysInMonth = 31;
            }
            if (i == 4 || i == 6 || i == 9 || i == 11)
            {
                daysInMonth = 30;
            }
            if (i == 2 && maybeVisokosnyGod % 4 != 0)
            {
                daysInMonth = 28;
            }
            if (i == 2 && maybeVisokosnyGod % 4 == 0)
            {
                daysInMonth = 29;
            }
            return daysInMonth;
        }

        static public bool caseSwitchCheck(string caseSwitchInput)
        {
            bool caseSwitchCheck = true;
            int caseSwitchCheckLength = caseSwitchInput.Length;
            if (caseSwitchCheckLength > 1)
            {
                Console.WriteLine("You have input " + caseSwitchInput + " . Your input is too long, start again");
                caseSwitchCheck = false;
            }

            char[] caseSwitchInputArray = caseSwitchInput.ToCharArray();
            for (int i = 0; i < caseSwitchCheckLength; i++)
            {
                if ((int)caseSwitchInputArray[i] < 49 || (int)caseSwitchInputArray[i] > 50)
                {
                    Console.WriteLine("You have input " + caseSwitchInput + " . You can input only figures - 1 or 2. Please input again");
                    caseSwitchCheck = false;
                    break;
                }
            }
            return caseSwitchCheck;
        }

        static public bool dateInputCheck(string someDateString)
        {
            bool dateInputCheck = true;
            int counter = 0;
            int someDateStringLength = someDateString.Length;
            if (someDateStringLength < 5)
            {
                Console.WriteLine("You have input " + someDateString + " . The date you have input is TOO short, please, try again!");
                dateInputCheck = false;
                goto EndDateInputCheck;
            }

            char[] someDateCharArray = someDateString.ToCharArray();
            for (int i = 0; i < someDateStringLength; i++)
            {
                if ((int)someDateCharArray[0] == 46)
                {
                    Console.WriteLine("You have input " + someDateString + " . A date must not start with a DOT !");
                    dateInputCheck = false; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] < 46 || (int)someDateCharArray[i] == 47 || (int)someDateCharArray[i] > 57)
                {
                    Console.WriteLine("You have input " + someDateString + " . You must input only numbers and dots in format: dd.mm.yyyy ! Only A.D. dates are accepted. Please input again");
                    dateInputCheck = false; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] == 46 && (int)someDateCharArray[i - 1] == 46)
                {
                    Console.WriteLine("You have input " + someDateString + " . There mustn't be to DOTS in a row!");
                    dateInputCheck = false; goto EndDateInputCheck;
                }
                if ((int)someDateCharArray[i] == 46)
                {
                    counter++;
                }
            }
            if (counter != 2)
            {
                Console.WriteLine("You have input " + someDateString + " . But there MUST be two dots to make dd.mm.yyyy format !!! ");
                dateInputCheck = false; goto EndDateInputCheck;
            }
            if ((int)someDateCharArray[someDateStringLength - 1] == 46)
            {
                Console.WriteLine("You have input " + someDateString + " . The date mustn't end with a DOT !");
                dateInputCheck = false; goto EndDateInputCheck;
            }

            string[] someDateDDMMYYYYArray = someDateString.Split('.');
            int[] someDateDDMMYYYYNumericArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int number = Convert.ToInt32(someDateDDMMYYYYArray[i]);
                someDateDDMMYYYYNumericArray[i] = number;
            } 
            // created dd.mm.yyyy array for input date

            DateTime dt = DateTime.Now;
            string currentDateDDMMYYYCheck = dt.ToShortDateString();
            string[] currentDateDDMMYYYYArray = currentDateDDMMYYYCheck.Split('.');
            int[] currentDateDDMMYYYYNumericArray = new int[3];
            for (int i = 0; i < 3; i++)
            {
                int number = Convert.ToInt32(currentDateDDMMYYYYArray[i]);
                currentDateDDMMYYYYNumericArray[i] = number;
            } 
            // created dd.mm.yyyy array for current date

            if (currentDateDDMMYYYYNumericArray[2] < someDateDDMMYYYYNumericArray[2])
            {
                Console.WriteLine("You have input " + someDateString + " . Year of input date is AFTER the current date? Please input again");
                dateInputCheck = false; goto EndDateInputCheck;
            }
            if (currentDateDDMMYYYYNumericArray[2] == someDateDDMMYYYYNumericArray[2] && currentDateDDMMYYYYNumericArray[1] < someDateDDMMYYYYNumericArray[1])
            {
                Console.WriteLine("You have input " + someDateString + " . Month of input date is AFTER the current date? Please input again");
                dateInputCheck = false; goto EndDateInputCheck;
            }
            if (currentDateDDMMYYYYNumericArray[2] == someDateDDMMYYYYNumericArray[2] && currentDateDDMMYYYYNumericArray[1] == someDateDDMMYYYYNumericArray[1] && currentDateDDMMYYYYNumericArray[0] < someDateDDMMYYYYNumericArray[0])
            {
                Console.WriteLine("You have input " + someDateString + " . Day of input date is AFTER the current date? Please input again");
                dateInputCheck = false; goto EndDateInputCheck;
            }
            if (someDateDDMMYYYYNumericArray[1] > 12)
            {
                Console.WriteLine("You have input " + someDateString + " . There can not be a month number " + someDateDDMMYYYYNumericArray[1] + " ! Please input again");
                dateInputCheck = false; goto EndDateInputCheck;
            }
            int maybeDDIsMoreThanDaysInMonth = findDaysInMonth(someDateDDMMYYYYNumericArray[1], someDateDDMMYYYYNumericArray[2]);
            if (someDateDDMMYYYYNumericArray[0] > maybeDDIsMoreThanDaysInMonth)
            {
                Console.WriteLine("You have input " + someDateString + " . There are only " + maybeDDIsMoreThanDaysInMonth + " days in month " + someDateDDMMYYYYNumericArray[1] + " in year " + someDateDDMMYYYYNumericArray[2] + " ! Please input again");
                dateInputCheck = false; goto EndDateInputCheck;
            }
        EndDateInputCheck:
            return dateInputCheck;
        }
        // we've checked the input format dd.mm.yyyy


        static public int yearsFull(int yyyyBirth, int yyyyLast)
        {
            int plusDaysOfLife = 0;
            for (int i = yyyyBirth + 1; i < yyyyLast; i++)
            {
                if (i % 4 == 0) { plusDaysOfLife += 366; continue; }
                plusDaysOfLife += 365;
            }
            return plusDaysOfLife;
        }
        // counts FULL YEARS that were lived

        static public int monthFullFirstOrOnly(int mmBirth, int yyyyBirth, int mmLast, int yyyyLast)
        {
            int plusDaysOfLife = 0;
            if (yyyyBirth != yyyyLast)
            {
                for (int i = mmBirth + 1; i <= 12; i++)
                {
                int daysInMonth = findDaysInMonth(i, yyyyBirth);
                    plusDaysOfLife += daysInMonth;
             //   Console.WriteLine("first year full months!  i = " + i + " itog = " + daysOfLife);
                }
            }
            else if (yyyyBirth == yyyyLast)
            {
                for (int i = mmBirth + 1; i < mmLast; i++)
                {
                    int daysInMonth = findDaysInMonth(i, yyyyBirth);
                    plusDaysOfLife += daysInMonth;
                 //   Console.WriteLine("ONLY year full months! i = " + i + " itog = " + daysOfLife);
                }
            }
            return plusDaysOfLife;
        }  
        // counts days of FULL MONTHS of the 1-st or THE ONLY life year

        static public int daysFirstOrOnlyMonth(int[] firstDDMMYYYY, int[] lastDDMMYYYY)
        {
            int peremennaya = 0;
            int plusDaysOfLife = 0;
            if (firstDDMMYYYY[1] == 1 || firstDDMMYYYY[1] == 3 || firstDDMMYYYY[1] == 5 || firstDDMMYYYY[1] == 7 || firstDDMMYYYY[1] == 8 || firstDDMMYYYY[1] == 10 || firstDDMMYYYY[1] == 12)
            {
                peremennaya = 31;
            }
            if (firstDDMMYYYY[1] == 4 || firstDDMMYYYY[1] == 6 || firstDDMMYYYY[1] == 9 || firstDDMMYYYY[1] == 11)
            {
                peremennaya = 30;
            }
            if (firstDDMMYYYY[1] == 2)
            {
                peremennaya = 28;
            }
            if (firstDDMMYYYY[1] == 2 && firstDDMMYYYY[2] % 4 == 0)
            {
                peremennaya = 29;
            }
            if (firstDDMMYYYY[1] == lastDDMMYYYY[1] && firstDDMMYYYY[2] == lastDDMMYYYY[2])
            {
                peremennaya = lastDDMMYYYY[0];
            }
            for (int i = firstDDMMYYYY[0]; i <= peremennaya; i++)
            {
                plusDaysOfLife++;
             //   Console.WriteLine("plus day first month!");
            }
            return plusDaysOfLife; 
        }  
        // counts days of the first NOT FULL month in life OR of the ONLY MONTH in one's life

        static public int monthFullLastYear(int yyyyBirth, int mmLast, int yyyyLast)
        {
            int plusDaysOfLife = 0;
            if (yyyyBirth != yyyyLast)
            {
                for (int i = 1; i < mmLast; i++)
                {
                    int daysInMonth = findDaysInMonth(i, yyyyLast);
                    plusDaysOfLife += daysInMonth;
                 //   Console.WriteLine("last months! i = " + i + " itog = " + daysOfLife);
                }
            }
            return plusDaysOfLife;
        }  
        // counts FULL MONTHS of the LAST YEAR (if it is NOT THE ONLY YEAR in life)

        static public int daysLastMonthLastYear(int[] firstDDMMYYYY, int[] lastDDMMYYYY)
        {
            int plusDaysOfLife = 0;
            {
                for (int i = 1; i <= lastDDMMYYYY[0]; i++)
                    if (firstDDMMYYYY[2] == lastDDMMYYYY[2] && firstDDMMYYYY[1] == lastDDMMYYYY[1])
                    {
                        break;
                    }
                    else
                    {
                        plusDaysOfLife++;
                    }
            }
            return plusDaysOfLife;
        }  
        // counts days of the last NOT FULL month (if it is NOT THE ONLY in life)

        static public bool birthAndDeathCheck(int[] firstDDMMYYYY, int[] lastDDMMYYY)
        {
            bool deadBeforeBirth = true;
            if (lastDDMMYYY[2] < firstDDMMYYYY[2])
            {
                Console.WriteLine("Death YEAR is earlier than birth year? input death date again!");
                deadBeforeBirth = false;
                goto EndBirthAndDeathCheck;
            }
            if (lastDDMMYYY[2] == firstDDMMYYYY[2] && lastDDMMYYY[1] < firstDDMMYYYY[1])
            {
                Console.WriteLine("Death MONTH is earlier than birth month? input death date again!");
                deadBeforeBirth = false;
                goto EndBirthAndDeathCheck;
            }
            if (lastDDMMYYY[2] == firstDDMMYYYY[2] && lastDDMMYYY[1] == firstDDMMYYYY[1] && lastDDMMYYY[0] < firstDDMMYYYY[0])
            {
                Console.WriteLine("Death DAY is earlier than birth day? input death date again!");
                deadBeforeBirth = false;
            }
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
            {
                Console.WriteLine("You have input an empty line. Let's start again from the very beginning!");
                goto Begin;
            }

            thereIsAnError = caseSwitchCheck(caseSwitchInput);
            if (thereIsAnError == false)
            {
                goto Begin;
            }

            int caseSwitchInputNumber = Convert.ToInt32(caseSwitchInput);

            switch (caseSwitchInputNumber)
            {

                case 1:
                    Console.Write("Input birth date in format dd.mm.yyyy ");
                    string birthDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(birthDateString))
                    {
                        Console.WriteLine("You have input an empty line. Input birth date again!");
                        goto case 1;
                    }

                    thereIsAnError = dateInputCheck(birthDateString);
                    if (thereIsAnError == false)
                    {
                        goto case 1;
                    }

                    string[] birthDateDDMMYYYYArray = birthDateString.Split('.');
                    int[] birthDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(birthDateDDMMYYYYArray[i]);
                        birthDateDDMMYYYYNumericArray[i] = number;
                    } 
                    // created dd.mm.yyyy array for input date

                    DateTime dt = DateTime.Now;
                    string currentDateDDMMYYYCheck = dt.ToShortDateString();
                    string[] currentDateDDMMYYYYArray = currentDateDDMMYYYCheck.Split('.');
                    int[] currentDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(currentDateDDMMYYYYArray[i]);
                        currentDateDDMMYYYYNumericArray[i] = number;
                    } 
                    // created dd.mm.yyyy array for current date

                    daysOfLife += yearsFull(birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[2]);
                    daysOfLife += monthFullFirstOrOnly(birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2]); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года
                    daysOfLife += daysFirstOrOnlyMonth(birthDateDDMMYYYYNumericArray, currentDateDDMMYYYYNumericArray);
                    daysOfLife += monthFullLastYear(birthDateDDMMYYYYNumericArray[2], currentDateDDMMYYYYNumericArray[1], currentDateDDMMYYYYNumericArray[2]);
                    daysOfLife += daysLastMonthLastYear(birthDateDDMMYYYYNumericArray, currentDateDDMMYYYYNumericArray);

                    Console.WriteLine("from " + birthDateString + " to " + currentDateDDMMYYYCheck + " it is " + daysOfLife + " days of life");
                    break;

                case 2:
                    Console.Write("Input birth date in format dd.mm.yyyy ");
                    birthDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(birthDateString))
                    {
                        Console.WriteLine("You have input an empty line. Inpu t birth date again!");
                        goto case 2;
                    }

                    thereIsAnError = dateInputCheck(birthDateString);
                    if (thereIsAnError == true)
                    {
                        goto case 2;
                    }

                    birthDateDDMMYYYYArray = birthDateString.Split('.');
                    birthDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(birthDateDDMMYYYYArray[i]);
                        birthDateDDMMYYYYNumericArray[i] = number;
                    }
                    // created dd.mm.yyyy array for input date

                    InputDeathDate:
                    Console.Write("Input death date in format dd.mm.yyyy ");
                    string deathDateString = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(deathDateString))
                    {
                        Console.WriteLine("You have input an empty line. Input death date again!");
                        goto InputDeathDate;
                    }

                    thereIsAnError = dateInputCheck(deathDateString);
                    if (thereIsAnError == true)
                    {
                        goto InputDeathDate;
                    }

                    string[] deathDateDDMMYYYYArray = deathDateString.Split('.');
                    int[] deathDateDDMMYYYYNumericArray = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(deathDateDDMMYYYYArray[i]);
                        deathDateDDMMYYYYNumericArray[i] = number;
                    } 
                    // created dd.mm.yyyy array for input death date

                    bool deadBeforeBirth = birthAndDeathCheck(birthDateDDMMYYYYNumericArray, deathDateDDMMYYYYNumericArray);
                    if (deadBeforeBirth == false)
                    {
                        goto InputDeathDate;
                    }

                    daysOfLife += yearsFull(birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[2]);
                    daysOfLife += monthFullFirstOrOnly(birthDateDDMMYYYYNumericArray[1], birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2]); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года
                    daysOfLife += daysFirstOrOnlyMonth(birthDateDDMMYYYYNumericArray, deathDateDDMMYYYYNumericArray);
                    daysOfLife += monthFullLastYear(birthDateDDMMYYYYNumericArray[2], deathDateDDMMYYYYNumericArray[1], deathDateDDMMYYYYNumericArray[2]);
                    daysOfLife += daysLastMonthLastYear(birthDateDDMMYYYYNumericArray, deathDateDDMMYYYYNumericArray);

                    Console.WriteLine("from " + birthDateString + " to " + deathDateString + " it is " + daysOfLife + " days of life");

                    break;
            }

            Console.WriteLine("want to try again? input 8 an press enter!");
            Console.WriteLine("If you want the programm to be closed - input anything but 8.");
            string input = Console.ReadLine();
            if (input == "8")
            {
                goto Begin;
            }
            else Console.WriteLine("have a good day, bye!");


        }
    }
}
