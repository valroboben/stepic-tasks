my_projects

    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Debut
{
    class Program
    {
        ass

        static void Main(string[] args)
        {

            Console.Write("≈сли ¬ы хотите посчитать количество дней жизни живущего сегодн€, нажмите 1 ");
            Console.WriteLine();
            Console.Write("≈сли ¬ы хотите посчитать количество дней жизни уже мЄртвого, нажмите 2 ");
            Console.WriteLine();
            int caseSwitch = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            int dnei = 0;

            switch (caseSwitch)
            {
                case 1:
                    Console.Write("введите дату рождени€ в формате дд.мм.гггг ");
                    string live = Console.ReadLine();
                    string[] liveArray = live.Split('.');
                    int[] liveArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(liveArray[i]);
                        liveArrayNum[i] = number;
                    }

                    DateTime dt = DateTime.Now;
                    string curDate = dt.ToShortDateString();
                    string[] curDateArray = curDate.Split('.');
                    int[] curDateNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(curDateArray[i]);
                        curDateNum[i] = number;
                    }

                    for (int i = liveArrayNum[2] + 1; i < curDateNum[2]; i++)
                    {
                        if (i % 4 == 0) { sum += 366; continue; }
                        sum += 365;
                    }  // посчитали все полные года

                    if (liveArrayNum[2] != curDateNum[2])
                    {
                        for (int i = liveArrayNum[1] + 1; i <= 12; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали все мес€цы первого неполного года

                        if (liveArrayNum[1] == 01 || liveArrayNum[1] == 03 || liveArrayNum[1] == 05 || liveArrayNum[1] == 07 || liveArrayNum[1] == 08 || liveArrayNum[1] == 10 || liveArrayNum[1] == 12) { dnei = 31; }
                        if (liveArrayNum[1] == 04 || liveArrayNum[1] == 06 || liveArrayNum[1] == 09 || liveArrayNum[1] == 11) { dnei = 30; }
                        if (liveArrayNum[1] == 02 && liveArrayNum[2] % 4 == 0) { dnei = 29; }
                        if (liveArrayNum[1] == 2 && liveArrayNum[2] != 0) { dnei = 28; }
                        for (int i = liveArrayNum[0]; i <= dnei; i++)
                        {
                            sum++;
                        } // посчитали дни первого мес€ца первого неполного года


                        for (int i = 1; i < curDateNum[1]; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали полные мес€цы текущего неполного года

                        for (int i = 1; i < curDateNum[0]; i++)
                        { sum++; }  // посчитали дни неполного текущего мес€ца
                    }

                    if (liveArrayNum[2] == curDateNum[2])
                    {
                        for (int i = liveArrayNum[1] + 1; i < curDateNum[1]; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали полные мес€цы текущего года при рождении в этом году

                        for (int i = 1; i < curDateNum[0]; i++)
                        { sum++; }  // посчитали дни неполного текущего мес€ца

                        if (liveArrayNum[1] == 01 || liveArrayNum[1] == 03 || liveArrayNum[1] == 05 || liveArrayNum[1] == 07 || liveArrayNum[1] == 08 || liveArrayNum[1] == 10 || liveArrayNum[1] == 12) { dnei = 31; }
                        if (liveArrayNum[1] == 04 || liveArrayNum[1] == 06 || liveArrayNum[1] == 09 || liveArrayNum[1] == 11) { dnei = 30; }
                        if (liveArrayNum[1] == 02 && liveArrayNum[2] % 4 == 0) { dnei = 29; }
                        if (liveArrayNum[1] == 2 && liveArrayNum[2] != 0) { dnei = 28; }
                        for (int i = liveArrayNum[0]; i <= dnei; i++)
                        {
                            sum++;
                        } // посчитали дни первого мес€ца первого неполного года

                    }

                    if (liveArrayNum[1] == curDateNum[1] && liveArrayNum[2] == curDateNum[2])
                    {
                        if (curDateNum[1] == 1 || curDateNum[1] == 3 || curDateNum[1] == 5 || curDateNum[1] == 7 || curDateNum[1] == 8 || curDateNum[1] == 10 || curDateNum[1] == 12) { sum -= 31; }
                        if (curDateNum[1] == 4 || curDateNum[1] == 6 || curDateNum[1] == 9 || curDateNum[1] == 11) { sum -= 30; }
                        if (curDateNum[1] == 2 && liveArrayNum[2] % 4 == 0) { sum -= 29; }
                        if (curDateNum[1] == 2) { sum -= 28; }
                    }
                    Console.WriteLine("¬ы живЄте на этом свете уже " + sum + " дней, неплохо!");
                    break;


                case 2:
                    Console.WriteLine("введите дату рождени€ умершего человека в формате дд.мм.гггг ");
                    string liveDead = Console.ReadLine();
                    string[] liveDeadArray = liveDead.Split('.');
                    int[] liveDeadArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(liveDeadArray[i]);
                        liveDeadArrayNum[i] = number;
                    }
                    Console.WriteLine("введите дату смерти умершего человека в формате дд.мм.гггг ");
                    string deadDead = Console.ReadLine();
                    string[] deadDeadArray = deadDead.Split('.');
                    int[] deadDeadArrayNum = new int[3];
                    for (int i = 0; i < 3; i++)
                    {
                        int number = Convert.ToInt32(deadDeadArray[i]);
                        deadDeadArrayNum[i] = number;
                    }

                    for (int i = liveDeadArrayNum[2] + 1; i < deadDeadArrayNum[2]; i++)
                    {
                        if (i % 4 == 0) { sum += 366; continue; }
                        sum += 365;
                    }  // посчитали все полные года

                    if (liveDeadArrayNum[2] != deadDeadArrayNum[2])
                    {
                        for (int i = liveDeadArrayNum[1] + 1; i <= 12; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveDeadArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали все мес€цы первого неполного года
                        if (liveDeadArrayNum[1] == 01 || liveDeadArrayNum[1] == 03 || liveDeadArrayNum[1] == 05 || liveDeadArrayNum[1] == 07 || liveDeadArrayNum[1] == 08 || liveDeadArrayNum[1] == 10 || liveDeadArrayNum[1] == 12) { dnei = 31; }
                        if (liveDeadArrayNum[1] == 04 || liveDeadArrayNum[1] == 06 || liveDeadArrayNum[1] == 09 || liveDeadArrayNum[1] == 11) { dnei = 30; }
                        if (liveDeadArrayNum[1] == 02 && liveDeadArrayNum[2] % 4 == 0) { dnei = 29; }
                        if (liveDeadArrayNum[1] == 2 && liveDeadArrayNum[2] != 0) { dnei = 28; }
                        for (int i = liveDeadArrayNum[0]; i <= dnei; i++)
                        {
                            sum++;
                        } // посчитали дни первого мес€ца первого неполного года

                        for (int i = 1; i < deadDeadArrayNum[1]; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveDeadArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали полные мес€цы последнего неполного года

                        for (int i = 1; i < deadDeadArrayNum[0]; i++)
                        { sum++; }  // посчитали дни последнего неполного мес€ца
                    }

                    if (liveDeadArrayNum[2] == deadDeadArrayNum[2])
                    {
                        for (int i = liveDeadArrayNum[1] + 1; i < deadDeadArrayNum[1]; i++)
                        {
                            if (i == 1 || i == 3 || i == 5 || i == 7 || i == 8 || i == 10 || i == 12) { sum += 31; continue; }
                            if (i == 4 || i == 6 || i == 9 || i == 11) { sum += 30; continue; }
                            if (i == 2 && liveDeadArrayNum[2] % 4 == 0) { sum += 29; continue; }
                            if (i == 2) { sum += 28; }
                        } // посчитали полные мес€цы единственного года в жизни
                        for (int i = 1; i < deadDeadArrayNum[0]; i++)
                        { sum++; }  // посчитали дни неполного последнего мес€ца жизни
                        if (liveDeadArrayNum[1] == 01 || liveDeadArrayNum[1] == 03 || liveDeadArrayNum[1] == 05 || liveDeadArrayNum[1] == 07 || liveDeadArrayNum[1] == 08 || liveDeadArrayNum[1] == 10 || liveDeadArrayNum[1] == 12) { dnei = 31; }
                        if (liveDeadArrayNum[1] == 04 || liveDeadArrayNum[1] == 06 || liveDeadArrayNum[1] == 09 || liveDeadArrayNum[1] == 11) { dnei = 30; }
                        if (liveDeadArrayNum[1] == 02 && liveDeadArrayNum[2] % 4 == 0) { dnei = 29; }
                        if (liveDeadArrayNum[1] == 2 && liveDeadArrayNum[2] != 0) { dnei = 28; }
                        for (int i = liveDeadArrayNum[0]; i <= dnei; i++)
                        {
                            sum++;
                        } // посчитали дни первого мес€ца первого неполного года

                    }

                    if (liveDeadArrayNum[1] == deadDeadArrayNum[1] && liveDeadArrayNum[2] == deadDeadArrayNum[2])
                    {
                        if (deadDeadArrayNum[1] == 1 || deadDeadArrayNum[1] == 3 || deadDeadArrayNum[1] == 5 || deadDeadArrayNum[1] == 7 || deadDeadArrayNum[1] == 8 || deadDeadArrayNum[1] == 10 || deadDeadArrayNum[1] == 12) { sum -= 31; }
                        if (deadDeadArrayNum[1] == 4 || deadDeadArrayNum[1] == 6 || deadDeadArrayNum[1] == 9 || deadDeadArrayNum[1] == 11) { sum -= 30; }
                        if (deadDeadArrayNum[1] == 2 && deadDeadArrayNum[2] % 4 == 0) { sum -= 29; }
                        if (deadDeadArrayNum[1] == 2) { sum -= 28; }
                    }


                    Console.WriteLine("ѕрожить под небом " + sum + " дней тоже неплохо! ¬ечна€ пам€ть!");
                    break;

            }









        }
    }
}
