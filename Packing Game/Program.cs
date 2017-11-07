using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packing_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //INPUTS:
            Random random = new Random();
            string user_name;

            int time = 60;
            int tspan_int = 0;
            int timer_control = 0;

            int int_cmd_box = 0;

            // Blocks ID:
            char[] blocks_ID = new char[12] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L'};

            // Human-Blocks:

            char[] h_A = new char[9];
            char[] h_B = new char[9];
            char[] h_C = new char[9];
            char[] h_D = new char[9];
            char[] h_E = new char[9];
            char[] h_F = new char[9];
            char[] h_G = new char[9];
            char[] h_H = new char[9];
            char[] h_I = new char[9];
            char[] h_J = new char[9];
            char[] h_K = new char[9];
            char[] h_L = new char[9];


            // Computer-Blocks:

            char[] c_A = new char[9];
            char[] c_B = new char[9];
            char[] c_C = new char[9];
            char[] c_D = new char[9];
            char[] c_E = new char[9];
            char[] c_F = new char[9];
            char[] c_G = new char[9];
            char[] c_H = new char[9];
            char[] c_I = new char[9];
            char[] c_J = new char[9];
            char[] c_K = new char[9];
            char[] c_L = new char[9];



            // Boxes:

            char[][] h_box0 = new char[12][] { h_A, h_B, h_C, h_D, h_E, h_F, h_G, h_H, h_I, h_J, h_K, h_L };
            char[][] c_box0 = new char[12][] { h_A, h_B, h_C, h_D, h_E, h_F, h_G, h_H, h_I, h_J, h_K, h_L };

            char[] h_box1 = new char[20];
            char[] h_box2 = new char[20];
            char[] h_box3 = new char[20];

            char[] c_box1 = new char[20];
            char[] c_box2 = new char[20];
            char[] c_box3 = new char[20];

            // Beginning Page:

            Console.SetWindowSize(170, 44);
            Console.SetCursorPosition(5, 1);
            Console.Write("Please Enter Your Name:");

            user_name = Console.ReadLine();
            Console.Clear();
            Console.SetCursorPosition(30, 1);
            Console.WriteLine("·``·.¸¸.·``·¸.·``·.¸¸.·``·    Hello " + user_name + ", Welcome to Packing Game!    ·``·.¸¸.·``·¸.·``·.¸¸.·``·");
            Console.SetCursorPosition(63, 4);
            Console.WriteLine("[ Press '1'   - Start Game     ]");
            Console.SetCursorPosition(63, 5);
            Console.WriteLine("[ Press '2'   - Instructions   ]");
            Console.SetCursorPosition(63, 6);
            Console.WriteLine("[ Press 'ESC' - Exit           ]");

        

            // Selection:

            if (Console.KeyAvailable == false)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                // Escape - Oyundan Çık
                if (key.Key == ConsoleKey.Escape)
                {
                    Environment.Exit(0);
                }

                // Seçimi Kontrol Et
                else
                {
                    // 1 - Oyunu Başlat
                    if (key.Key == ConsoleKey.NumPad1 || key.Key == ConsoleKey.D1)
                    {
                        // SCREEN
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.SetCursorPosition(35, 1);
                        Console.WriteLine("¸.·``·.¸¸.·``·¸¸.·``· (>^.^)>            PACKING GAME            <(^.^<) ¸.·``·.¸¸.·``·¸¸.·``·  ");

                        Console.SetCursorPosition(40, 6);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("-  " + user_name.ToUpper() + "  -");
                        Console.SetCursorPosition(110, 6);
                        Console.WriteLine("-  COMPUTER  -");
                        for (int i = 8; i < 33; i++)
                        {
                            Console.SetCursorPosition(15, i);
                            Console.WriteLine("|");
                            Console.SetCursorPosition(75, i);
                            Console.WriteLine("|");

                            Console.SetCursorPosition(85, i);
                            Console.WriteLine("|");
                            Console.SetCursorPosition(145, i);
                            Console.WriteLine("|");
                        }

                        for (int n = 15; n < 76; n++)
                        {
                            Console.SetCursorPosition(n, 8);
                            Console.WriteLine("=");
                            Console.SetCursorPosition(n + 70, 8);
                            Console.WriteLine("=");

                            Console.SetCursorPosition(n, 32);
                            Console.WriteLine("=");
                            Console.SetCursorPosition(n + 70, 32);
                            Console.WriteLine("=");
                        }

                        // BEGINNING OF GAME !! DİZİ İŞLEMLERİ BURADA
                        // Insan için blockları box0'a atama:
                        int[] length_tutma = new int[12];
                        Console.SetCursorPosition(0, 9);
                        for (int step = 0; step < 12; step++)
                        {
                            int length = random.Next(4,10);
                            length_tutma[step] = length;
                            Console.Write(length + " ");
                            for (int i=0; i<length; i++)
                            {
                                h_box0[step][i] = blocks_ID[step];
                                Console.Write(h_box0[step][i]);
                            } 
                            Console.WriteLine();
                        }
                        Console.WriteLine(" ");
                        // Computer için blockları box0'a atama:
                        int[] length_tutma2 = new int[12];
                        
                        for (int step = 0; step < 12; step++)
                        {
                            int length = random.Next(4, 10);
                            length_tutma2[step] = length;
                            Console.Write(length + " ");
                            for (int i = 0; i < length; i++)
                            {
                                c_box0[step][i] = blocks_ID[step];
                                Console.Write(c_box0[step][i]);
                            }
                            Console.WriteLine();

                        }

                        //TIMER
                        DateTime start = DateTime.Now;
                        DateTime now;
                        TimeSpan tspan;

                        while (time > 0)
                        {
                            now = DateTime.Now;
                            tspan = now - start;
                            tspan_int = Convert.ToInt32(tspan.TotalSeconds);

                            if (timer_control == tspan_int) // Oyun süresi içinde:
                            {
                                time = 60 - tspan_int;
                                Console.SetCursorPosition(72, 4);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" Remaining time:  " + time + " ");
                                timer_control++;
                            }
                        }

                        //HUMAN COMMANDS 
                        if (Console.KeyAvailable == false)
                        {
                            ConsoleKeyInfo cmd_block = Console.ReadKey(true); 
                            if (cmd_block.Key.Equals(ConsoleKey.A) || cmd_block.Key.Equals(ConsoleKey.B) || cmd_block.Key.Equals(ConsoleKey.C) || cmd_block.Key.Equals(ConsoleKey.D) || cmd_block.Key.Equals(ConsoleKey.E) || cmd_block.Key.Equals(ConsoleKey.F) || cmd_block.Key.Equals(ConsoleKey.G) || cmd_block.Key.Equals(ConsoleKey.H) || cmd_block.Key.Equals(ConsoleKey.I) || cmd_block.Key.Equals(ConsoleKey.J) || cmd_block.Key.Equals(ConsoleKey.K) || cmd_block.Key.Equals(ConsoleKey.L))
                            {
                                // Arrayler arasinda tasima islemi yapmak için box'i alip boxa bagli olarak tasima islemi yap

                                if (Console.KeyAvailable == false)
                                {
                                    ConsoleKeyInfo cmd_box = Console.ReadKey(true);
                                    if (cmd_box.Key == ConsoleKey.NumPad0 || cmd_box.Key == ConsoleKey.D0) 
                                    {
                                        int_cmd_box = 0;
                                    }
                                    else if (cmd_box.Key == ConsoleKey.NumPad1 || cmd_box.Key == ConsoleKey.D1)
                                    {
                                        int_cmd_box = 1;
                                    }
                                    else if (cmd_box.Key == ConsoleKey.NumPad2 || cmd_box.Key == ConsoleKey.D2)
                                    {
                                        int_cmd_box = 2;
                                    }
                                    else if (cmd_box.Key == ConsoleKey.NumPad3 || cmd_box.Key == ConsoleKey.D3)
                                    {
                                        int_cmd_box = 3;
                                    }

                                }
                            }

                        }

                        // BREAK THE GAME

                        /* Kazananı ve skorları ekrana yazdır
                         * Oyuncuya tekrar oynamak isteyip istemediğini sor
                         * Yetişirse en yüksek skorunu bastır
                         */
                        if (time == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("TIME OVER");
                        }

                    }

                    // 2 - Oyun Açıklamaları:

                    /* Oyun açıklamalarını yaz.
                     * Önceki ekrana döndürmeye çalış. && Oyunu başlat && Çıkış Ekranını yazdır
                     */
                    else if (key.Key == ConsoleKey.NumPad2 || key.Key == ConsoleKey.D2) 
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.SetCursorPosition(35, 1);
                        Console.WriteLine("¸.·``·.¸¸.·``·¸.·``·.¸¸.·``·            INSTRUCTIONS            ¸.·``·.¸¸.·``·¸.·``·.¸¸.·``·");
                        Console.SetCursorPosition(50, 3);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("* You use commands to transfer blocks.");
                        Console.SetCursorPosition(50, 4);
                        Console.WriteLine("* Commands are 2 characters: The first character is the block name (A to L)");
                        Console.SetCursorPosition(50, 5);
                        Console.WriteLine("* The second character is the box to be transferred");
                        Console.SetCursorPosition(50, 8);
                        Console.WriteLine("Oyunu Başlatmak İçin 'Space' tuşuna basınız.");
                        Console.SetCursorPosition(50, 9);
                        Console.WriteLine("Oyundan Çıkmak İçin 'ESC' tuşuna basınız.");

                        if (Console.KeyAvailable == false)  // Tekrar oyun sayfası
                        {
                            ConsoleKeyInfo selection = Console.ReadKey(true);
                            if (selection.Key.Equals(ConsoleKey.Spacebar)) 
                            {   
                                // SCREEN
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(35, 1);
                                Console.WriteLine("¸.·``·.¸¸.·``·¸¸.·``· (>^.^)>            PACKING GAME            <(^.^<) ¸.·``·.¸¸.·``·¸¸.·``·  ");
                                Console.SetCursorPosition(40, 6);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("-  " + user_name.ToUpper() + "  -");
                                Console.SetCursorPosition(110, 6);
                                Console.WriteLine("-  COMPUTER  -");
                                for (int i = 8; i < 33; i++)
                                {
                                    Console.SetCursorPosition(15, i);
                                    Console.WriteLine("|");
                                    Console.SetCursorPosition(75, i);
                                    Console.WriteLine("|");

                                    Console.SetCursorPosition(85, i);
                                    Console.WriteLine("|");
                                    Console.SetCursorPosition(145, i);
                                    Console.WriteLine("|");
                                }

                                for (int n = 15; n < 76; n++)
                                {
                                    Console.SetCursorPosition(n, 8);
                                    Console.WriteLine("=");
                                    Console.SetCursorPosition(n + 70, 8);
                                    Console.WriteLine("=");

                                    Console.SetCursorPosition(n, 32);
                                    Console.WriteLine("=");
                                    Console.SetCursorPosition(n + 70, 32);
                                    Console.WriteLine("=");
                                }

                                // BEGINNING OF GAME !! DİZİ İŞLEMLERİ BURADA
                                // Insan için blockları box0'a atama:
                                int[] length_tutma = new int[12];
                                Console.SetCursorPosition(0, 9);
                                for (int step = 0; step < 12; step++)
                                {
                                    int length = random.Next(4, 10);
                                    length_tutma[step] = length;
                                    Console.Write(length + " ");
                                    for (int i = 0; i < length; i++)
                                    {
                                        h_box0[step][i] = blocks_ID[step];
                                        Console.Write(h_box0[step][i]);
                                    }

                                    Console.WriteLine();
                                }

                                //TIMER
                                DateTime start = DateTime.Now;
                                DateTime now;
                                TimeSpan tspan;

                                while (time > 0)
                                {
                                    now = DateTime.Now;
                                    tspan = now - start;
                                    tspan_int = Convert.ToInt32(tspan.TotalSeconds);

                                    if (timer_control == tspan_int) // Oyun süresi içinde:
                                    {
                                        time = 60 - tspan_int;
                                        Console.SetCursorPosition(72, 4);
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write(" Remaining time:  " + time + " ");
                                        timer_control++;

                                    }
                                }

                                // BREAK THE GAME

                                /* Kazananı ve skorları ekrana yazdır
                                 * Oyuncuya tekrar oynamak isteyip istemediğini sor
                                 * Yetişirse en yüksek skorunu bastır
                                 */
                                if (time == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("TIME OVER");
                                    Console.Read();
                                }
                            }
                            else if (selection.Key.Equals(ConsoleKey.Escape)) 
                            {
                                Environment.Exit(0);
                            }
   
                        }
                    }

                    // Invalid Inputs:
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.SetCursorPosition(10, 1);
                        Console.WriteLine("Probably, you entered something wrong or you try to find bugs but it is unsuccesful try NIHAHAHA!");
                        Console.ResetColor();
                    }

                }

            }
        }
    }
}
