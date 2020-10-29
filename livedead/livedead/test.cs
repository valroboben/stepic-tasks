using livedead;
using System;

namespace livedead
{
    class Test
    {

        static bool testFindDaysInMonth()
        {
            return Program.findDaysInMonth(2, 2020) == 29 && Program.findDaysInMonth(2, 2019) == 28 && Program.findDaysInMonth(1, 2020) == 31;
        }

        static bool testCaseSwitchCheck()
        {
            return Program.caseSwitchCheck(Convert.ToString(1)) == true && Program.caseSwitchCheck(Convert.ToString(2)) == true 
                && Program.caseSwitchCheck(Convert.ToString('a')) == false && Program.caseSwitchCheck(Convert.ToString(12)) == false;
        }

        static bool testDateInputCheck()
        {
            return Program.dateInputCheck("10.01.2016") == true && Program.dateInputCheck("5.2.2016") == true && Program.dateInputCheck("33.2.2015") == false 
                && Program.dateInputCheck("5.16.2015") == false && Program.dateInputCheck("2.12.2028") == false && Program.dateInputCheck("12.12..2020") == false 
                && Program.dateInputCheck("a.sdf.452") == false;
        }

        static bool testYearsFull()
        {
            return Program.yearsFull(2017, 2019) == 365 && Program.yearsFull(2016, 2019) == 730 && Program.yearsFull(2015, 2017) == 366 
                && Program.yearsFull(2015, 2018) == 731;
        }

        static bool testMonthFullFirstOrOnly()
        {
            return Program.monthFullFirstOrOnly(10, 2015, 6, 2020) == 61 && Program.monthFullFirstOrOnly(11, 2015, 6, 2020) == 31
                && Program.monthFullFirstOrOnly(01, 2015, 3, 2015) == 28 && Program.monthFullFirstOrOnly(01, 2016, 4, 2016) == 90;
        }

        static bool testDaysFirstOrOnlyMonth()
        {
            return Program.daysFirstOrOnlyMonth(new int[] { 3, 2, 2020 }, new int[] { 4, 2, 2020 }) == 2
                && Program.daysFirstOrOnlyMonth(new int[] { 3, 2, 2020 }, new int[] { 2, 5, 2020 }) == 27
                && Program.daysFirstOrOnlyMonth(new int[] { 3, 2, 2019 }, new int[] { 2, 5, 2020 }) == 26
                && Program.daysFirstOrOnlyMonth(new int[] { 30, 12, 2015 }, new int[] { 2, 5, 2020 }) == 2;
        }

        static bool testMonthFullLastYear()
        {
            return Program.monthFullLastYear(2015, 3, 2015) == 0 && Program.monthFullLastYear(2015, 3, 2016) == 60
                && Program.monthFullLastYear(2012, 4, 2015) == 90 && Program.monthFullLastYear(2011, 3, 2015) == 59;
        }

        static bool testDaysLastMonthLastYear()
        {
            return Program.daysLastMonthLastYear(new int[] { 2, 2, 2015 }, new int[] { 5, 2, 2015 }) == 0
                && Program.daysLastMonthLastYear(new int[] { 30, 1, 2015 }, new int[] { 30, 3, 2016 }) == 30
                && Program.daysLastMonthLastYear(new int[] { 30, 1, 2015 }, new int[] { 27, 2, 2016 }) == 27
                && Program.daysLastMonthLastYear(new int[] { 30, 1, 2015 }, new int[] { 27, 2, 2019 }) == 27
                && Program.daysLastMonthLastYear(new int[] { 30, 1, 2015 }, new int[] { 25, 12, 2016 }) == 25;
        }

        static bool testBirthAndDeathCheck()
        {
            return Program.birthAndDeathCheck(new int[] { 10, 10, 2015 }, new int[] { 11, 12, 2016 }) == true
                && Program.birthAndDeathCheck(new int[] { 10, 10, 2015 }, new int[] { 9, 10, 2015 }) == false
                && Program.birthAndDeathCheck(new int[] { 8, 11, 2015 }, new int[] { 9, 10, 2015 }) == false
                && Program.birthAndDeathCheck(new int[] { 10, 10, 2017 }, new int[] { 9, 10, 2016 }) == false;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("\n \t starting testFindDaysInMonth");
            if (testFindDaysInMonth())
            {
                Console.WriteLine("Tests testFindDaysInMonth passed");
            }
            else
            {
                Console.WriteLine("Tests testFindDaysInMonth failed");
            }

            Console.WriteLine("\n \t starting testCaseSwitchCheck");
            if (testCaseSwitchCheck())
            {
                Console.WriteLine("Tests testCaseSwitchCheck passed");
            }
            else
            {
                Console.WriteLine("Tests testCaseSwitchCheck failed");
            }

            Console.WriteLine("\n \t starting testDateInputCheck");
            if (testDateInputCheck())
            {
                Console.WriteLine("Tests testDateInputCheck passed");
            }
            else
            {
                Console.WriteLine("Tests testDateInputCheck failed");
            }

            Console.WriteLine("\n \t starting testYearsFull");
            if (testYearsFull())
            {
                Console.WriteLine("Tests testYearsFull passed");
            }
            else
            {
                Console.WriteLine("Tests testYearsFull failed");
            }

            Console.WriteLine("\n \t testMonthFullFirstOrOnly");
            if (testYearsFull())
            {
                Console.WriteLine("Tests testMonthFullFirstOrOnly passed");
            }
            else
            {
                Console.WriteLine("Tests testMonthFullFirstOrOnly failed");
            }

            Console.WriteLine("\n \t testDaysFirstOrOnlyMonth");
            if (testYearsFull())
            {
                Console.WriteLine("Tests testDaysFirstOrOnlyMonth passed");
            }
            else
            {
                Console.WriteLine("Tests testDaysFirstOrOnlyMonth failed");
            }

            Console.WriteLine("\n \t testDaysFirstOrOnlyMonth");
            if (testDaysFirstOrOnlyMonth())
            {
                Console.WriteLine("Tests testDaysFirstOrOnlyMonth passed");
            }
            else
            {
                Console.WriteLine("Tests testDaysFirstOrOnlyMonth failed");
            }

            Console.WriteLine("\n \t testMonthFullLastYear");
            if (testMonthFullLastYear())
            {
                Console.WriteLine("Tests testMonthFullLastYear passed");
            }
            else
            {
                Console.WriteLine("Tests testMonthFullLastYear failed");
            }

            Console.WriteLine("\n \t testDaysLastMonthLastYear");
            if (testDaysLastMonthLastYear())
            {
                Console.WriteLine("Tests testDaysLastMonthLastYear passed");
            }
            else
            {
                Console.WriteLine("Tests testDaysLastMonthLastYear failed");
            }

            Console.WriteLine("\n \t testBirthAndDeathCheck");
            if (testBirthAndDeathCheck())
            {
                Console.WriteLine("Tests testBirthAndDeathCheck passed");
            }
            else
            {
                Console.WriteLine("Tests testBirthAndDeathCheck failed");
            }
            
        }


    }




}