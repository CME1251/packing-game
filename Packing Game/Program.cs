using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Packing_Game
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(170, 44);

            // INPUTS:

            int[] len_blocks = new int[12];

            char[] main_box = new char[108];
            char[] h_box1 = new char[20];
            char[] h_box2 = new char[20];
            char[] h_box3 = new char[20];

            char[] c_box1 = new char[20];
            char[] c_box2 = new char[20];
            char[] c_box3 = new char[20];


            Random random = new Random();
            //Baslangic inputları
            int init_value = (int)'A';
            int last_value = (int)'L';
            int h_score = 0;
            int best_score = 0;
            int c_score = 0;

            //Güncel box eleman sayilari:
            int len_hbox1 = 0;
            int len_hbox2 = 0;
            int len_hbox3 = 0;

            int len_cbox1 = 0;
            int len_cbox2 = 0;
            int len_cbox3 = 0;

            //Hesaplamalar için inputlar:

            int step = 0;
            int step2 = 0;

            //Zaman için inputlar:

            TimeSpan tspan;
            DateTime start, now;

            start = DateTime.Now;
            int time = 60;
            int tspan_int = 0;
            int timer_control = 0;
            int printscreen = 1;

            /* ************************* */

            while (init_value <= last_value)
            {
                int length = random.Next(4, 10);
                len_blocks[step2] = length;
                for (int i = 0; i < length; i++)
                {
                    main_box[step] = Convert.ToChar(init_value);
                    step++;
                }
                init_value++;
                step2++;
            }
            char[] h_box0 = (char[])main_box.Clone();
            char[] c_box0 = (char[])main_box.Clone();

            do
            {
                now = DateTime.Now;
                tspan = now - start;
                tspan_int = Convert.ToInt32(tspan.TotalSeconds);

                if (timer_control == tspan_int) // Oyun süresi içinde:
                {
                    time = 60 - tspan_int;
                    timer_control++;
                    printscreen = 1;
                }

                // HUMAN COMMANDS
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo cmd1 = Console.ReadKey();
                    ConsoleKeyInfo cmd2 = Console.ReadKey();
                    if ((int)'A' <= (int)cmd1.KeyChar && (int)cmd1.KeyChar <= (int)'L')
                    {
                        if (h_box0.Contains(cmd1.KeyChar))
                        {
                            for (int count = 0; count < h_box0.Length; count++) // Kaçinci indexten basladigi buldu.
                            {
                                if (h_box0[count] == cmd1.KeyChar)
                                {
                                    int diff = (int)cmd1.KeyChar - (int)'A'; // Kaçinci harf oldugunu buldu.
                                    if (cmd2.KeyChar == '1')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box1[a] != '\0')
                                            {
                                                len_hbox1++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox1)
                                        {
                                            for (int i = 0; i < len_blocks[diff]; i++)
                                            {
                                                h_box1[len_hbox1 + i] = h_box0[count + i];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (cmd2.KeyChar == '2')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box2[a] != '\0')
                                            {
                                                len_hbox2++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox2)
                                        {
                                            for (int m = 0; m < len_blocks[diff]; m++)
                                            {
                                                h_box2[len_hbox2 + m] = h_box0[count + m];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (cmd2.KeyChar == '3')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box3[a] != '\0')
                                            {
                                                len_hbox3++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox3)
                                        {
                                            for (int n = 0; n < len_blocks[diff]; n++)
                                            {
                                                h_box3[len_hbox3 + n] = h_box0[count + n];
                                            }
                                        }

                                        else
                                        {
                                            break;
                                        }
                                    }
                                    Array.Clear(h_box0, count, len_blocks[diff]);
                                    break;
                                }
                            }
                        }

                        else if (h_box1.Contains(cmd1.KeyChar))
                        {
                            for (int count = 0; count < h_box1.Length; count++) // Kaçinci indexten basladigi buldu.
                            {
                                if (h_box1[count] == cmd1.KeyChar)
                                {
                                    int diff = (int)cmd1.KeyChar - (int)'A'; // Kaçinci harf oldugunu buldu.

                                    int sum = 0;
                                    for (int j = 0; j < diff; j++)  // box0 a atarken indexine göre atama yapabilmek için harf dizininden indexi buluyor.
                                    {
                                        sum = sum + len_blocks[j];
                                    }

                                    if (cmd2.KeyChar == '0')
                                    {
                                        for (int i = 0; i < len_blocks[diff]; i++)
                                        {
                                            h_box0[sum + i] = h_box1[count + i];
                                        }
                                    }
                                    /*
                                    else if (cmd2.KeyChar == '2')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box2[a] != '\0')
                                            {
                                                len_hbox2++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox2)
                                        {
                                            for (int m = 0; m < len_blocks[diff]; m++)
                                            {
                                                h_box2[len_hbox2 + m] = h_box1[count + m];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (cmd2.KeyChar == '3')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box3[a] != '\0')
                                            {
                                                len_hbox3++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox3)
                                        {
                                            for (int n = 0; n < len_blocks[diff]; n++)
                                            {
                                                h_box3[len_hbox3 + n] = h_box1[count + n];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    } */
                                    else
                                    {
                                        break;
                                    }
                                    Array.Clear(h_box1, count, len_blocks[diff]);
                                    for (int b = count; b < 20 - len_blocks[diff]; b++)
                                    {
                                        h_box1[b] = h_box1[b + len_blocks[diff]];
                                        Array.Clear(h_box1, b + len_blocks[diff], 1);
                                    }
                                }
                            }
                        }
                        else if (h_box2.Contains(cmd1.KeyChar))
                        {
                            for (int count = 0; count < h_box2.Length; count++) // Kaçinci indexten basladigi buldu.
                            {
                                if (h_box2[count] == cmd1.KeyChar)
                                {
                                    int diff = (int)cmd1.KeyChar - (int)'A'; // Kaçinci harf oldugunu buldu.
                                    int sum = 0;
                                    for (int j = 0; j < diff; j++) // Hbox0 a atarken kaçinci indexten baslamasi gerektigini bulacak.
                                    {
                                        sum = sum + len_blocks[j];
                                    }
                                    if (cmd2.KeyChar == '0')
                                    {
                                        for (int m = 0; m < len_blocks[diff]; m++)
                                        {
                                            h_box0[sum + m] = h_box2[count + m];
                                        }
                                    }
                                    /*
                                    else if (cmd2.KeyChar == '1')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box1[a] != '\0')
                                            {
                                                len_hbox1++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox1)
                                        {
                                            for (int i = 0; i < len_blocks[diff]; i++)
                                            {
                                                h_box1[len_hbox1 + i] = h_box2[count + i];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (cmd2.KeyChar == '3')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box3[a] != '\0')
                                            {
                                                len_hbox3++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox3)
                                        {
                                            for (int n = 0; n < len_blocks[diff]; n++)
                                            {
                                                h_box3[len_hbox3 + n] = h_box2[count + n];
                                            }
                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    */
                                    else
                                    {
                                        break;
                                    }
                                    Array.Clear(h_box2, count, len_blocks[diff]);
                                    for (int b = count; b < 20 - len_blocks[diff]; b++)
                                    {
                                        h_box2[b] = h_box2[b + len_blocks[diff]];
                                        Array.Clear(h_box2, b + len_blocks[diff], 1);
                                    }
                                }

                            }
                        }

                        else if (h_box3.Contains(cmd1.KeyChar))
                        {
                            for (int count = 0; count < h_box3.Length; count++) // Kaçinci indexten basladigi buldu.
                            {
                                if (h_box3[count] == cmd1.KeyChar)
                                {
                                    int diff = (int)cmd1.KeyChar - (int)'A'; // Kaçinci harf oldugunu buldu.
                                    int sum = 0;
                                    for (int j = 0; j < diff; j++) // Hbox0 a atarken kaçinci indexten baslamasi gerektigini bulacak.
                                    {
                                        sum = sum + len_blocks[j];
                                    }
                                    if (cmd2.KeyChar == '0')
                                    {
                                        for (int n = 0; n < len_blocks[diff]; n++)
                                        {
                                            h_box0[sum + n] = h_box3[count + n];
                                        }
                                    }
                                    /*
                                    else if (cmd2.KeyChar == '1')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box1[a] != '\0')
                                            {
                                                len_hbox1++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox1)
                                        {
                                            for (int i = 0; i < len_blocks[diff]; i++)
                                            {
                                                h_box1[len_hbox1 + i] = h_box3[count + i];
                                            }

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    else if (cmd2.KeyChar == '2')
                                    {
                                        for (int a = 0; a < 20; a++)
                                        {
                                            if (h_box2[a] != '\0')
                                            {
                                                len_hbox2++;
                                            }
                                        }
                                        if (len_blocks[diff] <= 20 - len_hbox2)
                                        {
                                            for (int m = 0; m < len_blocks[diff]; m++)
                                            {
                                                h_box2[len_hbox2 + m] = h_box3[count + m];
                                            }

                                        }
                                        else
                                        {
                                            break;
                                        }
                                    }
                                    */
                                    else
                                    {
                                        break;
                                    }

                                    Array.Clear(h_box3, count, len_blocks[diff]);
                                    for (int b = count; b < 20 - len_blocks[diff]; b++)
                                    {
                                        h_box3[b] = h_box3[b + len_blocks[diff]];
                                        Array.Clear(h_box3, b + len_blocks[diff], 1);
                                    }
                                }

                            }
                        }
                    }
                }
 /*               else
                {
                    
                    // CALCULATION FOR COMPUTER :
                    
                    for (int i = 0; i < 12; i++)
                    {
                        int sum = 0;
                        int sum2 = 0;
                        int sum3 = 0;
                        int sum4 = 0;

                        for (int b = 0; b < c_box1.Length; b++)
                        {
                            if (c_box1[b] != '0')
                            {
                                len_cbox1++;
                            }
                        }

                        for (int j = 1; j < 12 - i; j++)
                        {
                            sum = len_blocks[i] + len_blocks[i + j];
                            if (sum > best_score)
                            {
                                best_score = sum;
                            }

                            for (int k = j + 1; k < 12 - i; k++)
                            {
                                sum2 = sum + len_blocks[i + k];
                                if (sum2 <= 20 && best_score < sum2)
                                {
                                    best_score = sum2;
                                    Console.WriteLine("index1: [" + i + "] index2: [" + (i + j) + "] index3:[" + (i + k) + "] result: " + sum2);
                                }

                                for (int l = k + 1; l < 12 - i; l++)
                                {
                                    sum3 = sum2 + len_blocks[i + l];
                                    if (sum3 <= 20 && best_score <= sum3)
                                    {
                                        best_score = sum3;
                                        Console.WriteLine("index1: [" + i + "] index2: [" + (i + j) + "] index3:[" + (i + k) + "] index4:[" + (i + l) + "] result: " + sum3);
                                    }

                                    for (int m = l + 1; m < 12 - i; m++)
                                    {
                                        sum4 = sum3 + len_blocks[i + m];
                                        if (sum4 <= 20 && best_score <= sum4)
                                        {
                                            best_score = sum4;
                                            Console.WriteLine("index1: [" + i + "] index2: [" + (i + j) + "] index3:[" + (i + k) + "] index4:[" + (i + l) + "] index5:[" + (i + m) + "] result: " + sum3);
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            */
               
                // EKRANA BASMA: 

                if (printscreen == 1)
                {
                    printscreen = 0;
                    Console.Clear();

                    //SCREEN:


                    Console.SetCursorPosition(40, 1);
                    Console.Write("Human ");
                    Console.SetCursorPosition(40, 2);
                    Console.Write("---------- ");
                    Console.SetCursorPosition(40, 3);
                    Console.Write("Score: " + h_score);

                    Console.SetCursorPosition(75, 1);
                    Console.Write("Time: " + time);

                    Console.SetCursorPosition(110, 1);
                    Console.Write("Computer ");
                    Console.SetCursorPosition(110, 2);
                    Console.Write("---------- ");
                    Console.SetCursorPosition(110, 3);
                    Console.Write("Score: " + c_score);

                    for (int m = 4; m < 35; m++)
                    {
                        Console.SetCursorPosition(80, m);
                        Console.Write("|");

                    }
                    Console.SetCursorPosition(35, 12);
                    for (int u = 1; u < 21; u++)
                    {
                        if (u % 5 == 0)
                        {
                            Console.Write(u);

                        }
                        else
                        {
                            Console.Write("  ");
                        }
                    }
                    Console.SetCursorPosition(35, 13);
                    for (int u = 1; u < 21; u++)
                    {
                        if (u % 5 != 0)
                        {
                            Console.Write("- ");
                        }
                        else if (u % 5 == 0)
                        {
                            Console.Write("+ ");
                        }
                    }

                    int count1 = 0;
                    int count2 = 0;
                    int count3 = 0;

                    for (int a = 0; a < 20; a++)
                    {
                        if (h_box1[a] != '\0')
                        {
                            count1++;
                        }
                    }

                    for (int a = 0; a < 20; a++)
                    {
                        if (h_box2[a] != '\0')
                        {
                            count2++;
                        }
                    }

                    for (int a = 0; a < 20; a++)
                    {
                        if (h_box3[a] != '\0')
                        {
                            count3++;
                        }
                    }

                    h_score = count1 + count2 + count3;

                    len_hbox1 = 0;
                    len_hbox2 = 0;
                    len_hbox3 = 0;


                    Console.SetCursorPosition(76, 15);
                    Console.Write(count1);

                    Console.SetCursorPosition(76, 16);
                    Console.Write(count2);

                    Console.SetCursorPosition(76, 17);
                    Console.Write(count3);

                    Console.SetCursorPosition(10, 30);



                    // Hbox0 Yazdirma
                    int control2 = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        Console.SetCursorPosition(2, 9 + j);
                        Console.Write(len_blocks[j] + " ");
                        for (int i = 0; i < len_blocks[j]; i++)
                        {
                            Console.Write(h_box0[control2 + i]);
                        }
                        control2 = control2 + len_blocks[j];
                        Console.WriteLine("");
                        Console.SetCursorPosition(2, 9 + j);
                    }

                    Console.SetCursorPosition(4, 8);
                    Console.Write("[0]");
                    Console.SetCursorPosition(89, 8);
                    Console.Write("[0]");

                    // Hbox1
                    Console.SetCursorPosition(30, 15);
                    Console.Write("[1]  ");
                    for (int i = 0; i < h_box1.Length; i++)
                    {
                        Console.Write(h_box1[i] + " ");
                    }

                    // Hbox2
                    Console.SetCursorPosition(30, 16);
                    Console.Write("[2]  ");
                    for (int i = 0; i < h_box2.Length; i++)
                    {
                        Console.Write(h_box2[i] + " ");
                    }

                    // Hbox3
                    Console.SetCursorPosition(30, 17);
                    Console.Write("[3]  ");
                    for (int i = 0; i < h_box3.Length; i++)
                    {
                        Console.Write(h_box3[i] + " ");
                    }

                    //Cbox0
                    int control3 = 0;
                    for (int u = 0; u < 12; u++)
                    {
                        Console.SetCursorPosition(87, 9 + u);
                        Console.Write(len_blocks[u] + " ");
                        for (int i = 0; i < len_blocks[u]; i++)
                        {
                            Console.Write(c_box0[control3 + i]);
                        }
                        control3 = control3 + len_blocks[u];
                        Console.WriteLine("");
                        Console.SetCursorPosition(87, 9 + u);
                    }

                    // Cbox1
                    Console.SetCursorPosition(115, 15);
                    Console.Write("[1]  ");
                    for (int i = 0; i < c_box1.Length; i++)
                    {
                        Console.Write(c_box1[i] + " ");
                    }

                    // Cbox2
                    Console.SetCursorPosition(115, 16);
                    Console.Write("[2]  ");
                    for (int i = 0; i < c_box2.Length; i++)
                    {
                        Console.Write(c_box2[i] + " ");
                    }

                    // Cbox3
                    Console.SetCursorPosition(115, 17);
                    Console.Write("[3]  ");
                    for (int i = 0; i < c_box3.Length; i++)
                    {
                        Console.Write(c_box3[i] + " ");
                    }
                    Console.SetCursorPosition(20, 30);
                    Console.Write("Your Command: ");
                }
            }
            while (true) ;

        }
    }
}