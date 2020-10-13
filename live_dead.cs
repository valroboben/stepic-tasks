using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut
{
    class Program
    {
        // a-b-c дд.мм.гг рождения     d-e-f дд.мм.гг текущий ИЛИ смерти       dnei всегда изначально == 0
        static int superZiklMensheIliRavno(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = two + 1; i <= konstanta; i++)
            {
                Console.WriteLine("superZiklMensheIliRavno месяцы первого неполного года ЕСЛИ ГОД РОЖЕНИЯ НЕ ТЕКУЩИЙ или НЕ РАВЕН ГОДУ СМЕРТИ, i = " + i + " sum перед началом этой операции = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; Console.Write(" после sum = " + itog); continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; Console.Write(" после sum = " + itog); continue; }
                if (i == 2 && three % 4 == 0) { itog += 29; Console.WriteLine(" после sum = " + itog); continue; }
                if (i == 2) { itog += 28; Console.Write(" после sum = " + itog); }
            }
            return itog;
        }   // посчитали все месяцы первого неполного года ЕСЛИ ГОД РОЖЕНИЯ НЕ ТЕКУЩИЙ или НЕ РАВЕН ГОДУ СМЕРТИ

        static int superZiklMenshe(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = two + 1; i < five; i++)
            {
                Console.WriteLine("superZiklMenshe месяцы неполного года ЕСЛИ ГОД РОЖЕНИЯ ТЕКУЩИЙ или РАВЕН ГОДУ СМЕРТИ, i = " + i + " sum перед началом этой операции = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; continue; }
                if (i == 2 && two % 4 == 0) { itog += 29; continue; }
                if (i == 2) { itog += 28; }
            }
            return itog;
        }   // посчитали все месяцы неполного года ЕСЛИ ГОД РОЖЕНИЯ ТЕКУЩИЙ или РАВЕН ГОДУ СМЕРТИ

        static int ziklDniPervie(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            if (two == 1 || two == 3 || two == 5 || two == 7 || two == 8 || two == 10 || two == 12) { konstanta = 31; }
            if (two == 4 || two == 6 || two == 9 || two == 11) { konstanta = 30; }
            if (two == 2) { konstanta = 28; }
            if (two == 2 && three % 4 == 0) { konstanta = 29; }
            if (two == five && three == six) { konstanta = four; }

            for (int i = one; i <= konstanta; i++)
            { itog++; Console.WriteLine("daysFirstOrOnly дни первого НЕПОЛНОГО месяца жизни ЛИБО ЕДИНСТВЕННОГО В ЖИЗНИ МЕСЯЦА после прибавления дня сумма стала = " + itog); }
            return itog; // посчитали дни первого НЕПОЛНОГО месяца жизни ЛИБО ЕДИНСТВЕННОГО В ЖИЗНИ МЕСЯЦА
        }

        static int ziklFromBegin(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = konstanta + 1; i < five; i++)
            {
                Console.WriteLine("ziklFromBegin месяцы первого года, если год НЕ ЕДИНСТВЕННЫЙ, i = " + i + " sum перед началом этой операции = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; continue; }
                if (i == 2 && two % 4 == 0) { itog += 29; continue; }
                if (i == 2) { itog += 28; }
            }
            return itog;
        } // полные месяцы первого года, если год НЕ ЕДИНСТВЕННЫЙ

        static int yearsFull(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            for (int i = c + 1; i < f; i++)
            {
                Console.WriteLine("yearsFull , i = " + i + " sum перед началом этой операции = " + itog);
                if (i % 4 == 0) { itog += 366; continue; }
                itog += 365;
                Console.Write(" после sum = " + itog);
            }
            return itog;
        }  // посчитали прожитые ПОЛНЫЕ годы

        static int ziklMonthFromEnd(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = 1; i < five; i++)
            {
                Console.WriteLine("ziklMonthFromEnd месяцы последнего года, если год НЕ ЕДИНСТВЕННЫЙ, i = " + i + " sum перед началом этой операции = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; continue; }
                if (i == 2 && two % 4 == 0) { itog += 29; continue; }
                if (i == 2) { itog += 28; }
            }
            return itog;
        }


        static int monthFull(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            if (c != f)
            {
                konstanta = 12;
                itog = superZiklMensheIliRavno(a, b, c, d, e, f, itog, dnei, konstanta);
            }
            else if (c == f)
            {
                konstanta = e;
                itog = superZiklMenshe(a, b, c, d, e, f, itog, dnei, konstanta);
            }
            return itog;
        }  // посчитали прожитые дни за ПОЛНЫЕ месяцы ПЕРВОГО года , либо ЕДИНСТВЕННОГО года

        static int daysFirstOrOnly(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            itog = ziklDniPervie(a, b, c, d, e, f, itog, dnei, konstanta);
            return itog;
        }  // посчитали прожитые дни за единственный месяц единственного года

        static int monthLast(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            if (c != f)
            {
                konstanta = 1;
                itog = ziklMonthFromEnd(a, b, c, d, e, f, itog, dnei, konstanta);
            }
            return itog;
        }  // посчитали прожитые полные месяцы текущего/последнего года (елси он НЕ ЕДИНСТВЕННЫЙ)

        static int daysLast(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            {
                for (int i = 1; i <= d; i++)
                    if (c == f && b == e) { break; }// не входит в цикл при значении годарождения 2020 + не входит в цикл при значении месяца ТЕКУЩИЙ (10)
                    else
                    { Console.WriteLine("daysLast прожитые дни текущего/последнего месяца (если он НЕ ЕДИНСТВЕННЫЙ), i = " + i + " sum перед началом этой операции = " + itog); itog++; }
            }
            return itog;
        }  // посчитали прожитые дни текущего/последнего месяца (если он НЕ ЕДИНСТВЕННЫЙ)

        static void Main(string[] args)
        {

            Console.Write("Если Вы хотите посчитать количество дней жизни живущего сегодня, нажмите 1 ");
            Console.WriteLine();
            Console.Write("Если Вы хотите посчитать количество дней жизни уже мёртвого, нажмите 2 ");
            Console.WriteLine();
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int daysDefault = 0;
            int konstanta = 0;

            switch (caseSwitch)
            {
                case 1:
                    Console.Write("введите дату рождения в формате дд.мм.гггг ");
                    string live = Console.ReadLine();
                    string[] liveArray = live.Split('.');
                    int[] liveArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(liveArray[i]);
                        liveArrayNum[i] = number;
                    } // liveArrayNum == создали массив из дд.мм.гггг рождения

                    DateTime dt = DateTime.Now;
                    string curDate = dt.ToShortDateString();
                    string[] curDateArray = curDate.Split('.');
                    int[] curDateNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(curDateArray[i]);
                        curDateNum[i] = number;
                    } // curDateNum == создали массив из дд.мм.гггг сегодняшнего дня 

                    sum = yearsFull(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta); // посчитали прожитые дни за ПОЛНЫЕ годы

                    sum = monthFull(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года

                    sum = daysFirstOrOnly(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    sum = monthLast(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    sum = daysLast(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    Console.WriteLine("otvet =  " + sum);
                    break;

                case 2:
                    Console.Write("введите дату рождения в формате дд.мм.гггг ");
                    string live2 = Console.ReadLine();
                    string[] live2Array = live2.Split('.');
                    int[] live2ArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(live2Array[i]);
                        live2ArrayNum[i] = number;
                    } // liveArrayNum == создали массив из дд.мм.гггг рождения

                    Console.Write("введите дату смерти в формате дд.мм.гггг ");
                    string dead = Console.ReadLine();
                    string[] deadArray = dead.Split('.');
                    int[] deadArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(deadArray[i]);
                        deadArrayNum[i] = number;
                    } // liveArrayNum == создали массив из дд.мм.гггг рождения

                    sum = yearsFull(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta); // посчитали прожитые дни за ПОЛНЫЕ годы

                    sum = monthFull(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta); // посчитали прожитые ПОЛНЫЕ месяцы ПЕРВОГО или ЕДИНСТВЕННОГО года

                    sum = daysFirstOrOnly(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    sum = monthLast(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    sum = daysLast(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    Console.WriteLine("otvet =  " + sum);
                    break;
            }









        }
    }
}
