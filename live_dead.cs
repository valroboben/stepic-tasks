using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut
{
    class Program
    {
        // a-b-c ��.��.�� ��������     d-e-f ��.��.�� ������� ��� ������       dnei ������ ���������� == 0
        static int superZiklMensheIliRavno(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = two + 1; i <= konstanta; i++)
            {
                Console.WriteLine("superZiklMensheIliRavno ������ ������� ��������� ���� ���� ��� ������� �� ������� ��� �� ����� ���� ������, i = " + i + " sum ����� ������� ���� �������� = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; Console.Write(" ����� sum = " + itog); continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; Console.Write(" ����� sum = " + itog); continue; }
                if (i == 2 && three % 4 == 0) { itog += 29; Console.WriteLine(" ����� sum = " + itog); continue; }
                if (i == 2) { itog += 28; Console.Write(" ����� sum = " + itog); }
            }
            return itog;
        }   // ��������� ��� ������ ������� ��������� ���� ���� ��� ������� �� ������� ��� �� ����� ���� ������

        static int superZiklMenshe(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = two + 1; i < five; i++)
            {
                Console.WriteLine("superZiklMenshe ������ ��������� ���� ���� ��� ������� ������� ��� ����� ���� ������, i = " + i + " sum ����� ������� ���� �������� = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; continue; }
                if (i == 2 && two % 4 == 0) { itog += 29; continue; }
                if (i == 2) { itog += 28; }
            }
            return itog;
        }   // ��������� ��� ������ ��������� ���� ���� ��� ������� ������� ��� ����� ���� ������

        static int ziklDniPervie(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            if (two == 1 || two == 3 || two == 5 || two == 7 || two == 8 || two == 10 || two == 12) { konstanta = 31; }
            if (two == 4 || two == 6 || two == 9 || two == 11) { konstanta = 30; }
            if (two == 2) { konstanta = 28; }
            if (two == 2 && three % 4 == 0) { konstanta = 29; }
            if (two == five && three == six) { konstanta = four; }

            for (int i = one; i <= konstanta; i++)
            { itog++; Console.WriteLine("daysFirstOrOnly ��� ������� ��������� ������ ����� ���� ������������� � ����� ������ ����� ����������� ��� ����� ����� = " + itog); }
            return itog; // ��������� ��� ������� ��������� ������ ����� ���� ������������� � ����� ������
        }

        static int ziklFromBegin(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = konstanta + 1; i < five; i++)
            {
                Console.WriteLine("ziklFromBegin ������ ������� ����, ���� ��� �� ������������, i = " + i + " sum ����� ������� ���� �������� = " + itog);
                if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { itog += 31; continue; }
                if (i == 4 || i == 6 || i == 9 || i == 11) { itog += 30; continue; }
                if (i == 2 && two % 4 == 0) { itog += 29; continue; }
                if (i == 2) { itog += 28; }
            }
            return itog;
        } // ������ ������ ������� ����, ���� ��� �� ������������

        static int yearsFull(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            for (int i = c + 1; i < f; i++)
            {
                Console.WriteLine("yearsFull , i = " + i + " sum ����� ������� ���� �������� = " + itog);
                if (i % 4 == 0) { itog += 366; continue; }
                itog += 365;
                Console.Write(" ����� sum = " + itog);
            }
            return itog;
        }  // ��������� �������� ������ ����

        static int ziklMonthFromEnd(int one, int two, int three, int four, int five, int six, int itog, int dnei, int konstanta)
        {
            for (int i = 1; i < five; i++)
            {
                Console.WriteLine("ziklMonthFromEnd ������ ���������� ����, ���� ��� �� ������������, i = " + i + " sum ����� ������� ���� �������� = " + itog);
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
        }  // ��������� �������� ��� �� ������ ������ ������� ���� , ���� ������������� ����

        static int daysFirstOrOnly(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            itog = ziklDniPervie(a, b, c, d, e, f, itog, dnei, konstanta);
            return itog;
        }  // ��������� �������� ��� �� ������������ ����� ������������� ����

        static int monthLast(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            if (c != f)
            {
                konstanta = 1;
                itog = ziklMonthFromEnd(a, b, c, d, e, f, itog, dnei, konstanta);
            }
            return itog;
        }  // ��������� �������� ������ ������ ��������/���������� ���� (���� �� �� ������������)

        static int daysLast(int a, int b, int c, int d, int e, int f, int itog, int dnei, int konstanta)
        {
            {
                for (int i = 1; i <= d; i++)
                    if (c == f && b == e) { break; }// �� ������ � ���� ��� �������� ������������ 2020 + �� ������ � ���� ��� �������� ������ ������� (10)
                    else
                    { Console.WriteLine("daysLast �������� ��� ��������/���������� ������ (���� �� �� ������������), i = " + i + " sum ����� ������� ���� �������� = " + itog); itog++; }
            }
            return itog;
        }  // ��������� �������� ��� ��������/���������� ������ (���� �� �� ������������)

        static void Main(string[] args)
        {

            Console.Write("���� �� ������ ��������� ���������� ���� ����� �������� �������, ������� 1 ");
            Console.WriteLine();
            Console.Write("���� �� ������ ��������� ���������� ���� ����� ��� �������, ������� 2 ");
            Console.WriteLine();
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int daysDefault = 0;
            int konstanta = 0;

            switch (caseSwitch)
            {
                case 1:
                    Console.Write("������� ���� �������� � ������� ��.��.���� ");
                    string live = Console.ReadLine();
                    string[] liveArray = live.Split('.');
                    int[] liveArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(liveArray[i]);
                        liveArrayNum[i] = number;
                    } // liveArrayNum == ������� ������ �� ��.��.���� ��������

                    DateTime dt = DateTime.Now;
                    string curDate = dt.ToShortDateString();
                    string[] curDateArray = curDate.Split('.');
                    int[] curDateNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(curDateArray[i]);
                        curDateNum[i] = number;
                    } // curDateNum == ������� ������ �� ��.��.���� ������������ ��� 

                    sum = yearsFull(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta); // ��������� �������� ��� �� ������ ����

                    sum = monthFull(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta); // ��������� �������� ������ ������ ������� ��� ������������� ����

                    sum = daysFirstOrOnly(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    sum = monthLast(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    sum = daysLast(liveArrayNum[0], liveArrayNum[1], liveArrayNum[2], curDateNum[0], curDateNum[1], curDateNum[2], sum, daysDefault, konstanta);

                    Console.WriteLine("otvet =  " + sum);
                    break;

                case 2:
                    Console.Write("������� ���� �������� � ������� ��.��.���� ");
                    string live2 = Console.ReadLine();
                    string[] live2Array = live2.Split('.');
                    int[] live2ArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(live2Array[i]);
                        live2ArrayNum[i] = number;
                    } // liveArrayNum == ������� ������ �� ��.��.���� ��������

                    Console.Write("������� ���� ������ � ������� ��.��.���� ");
                    string dead = Console.ReadLine();
                    string[] deadArray = dead.Split('.');
                    int[] deadArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(deadArray[i]);
                        deadArrayNum[i] = number;
                    } // liveArrayNum == ������� ������ �� ��.��.���� ��������

                    sum = yearsFull(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta); // ��������� �������� ��� �� ������ ����

                    sum = monthFull(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta); // ��������� �������� ������ ������ ������� ��� ������������� ����

                    sum = daysFirstOrOnly(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    sum = monthLast(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    sum = daysLast(live2ArrayNum[0], live2ArrayNum[1], live2ArrayNum[2], deadArrayNum[0], deadArrayNum[1], deadArrayNum[2], sum, daysDefault, konstanta);

                    Console.WriteLine("otvet =  " + sum);
                    break;
            }









        }
    }
}
