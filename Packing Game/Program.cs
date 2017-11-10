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

            int int_cmd_box;
            int cmd_count = 0;
            int total = 0;
            int sum = 0;
            int high_score = 0;

            // Blocks ID:
            char[] blocks_ID = new char[12] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L'};
            char[] blocks_ID_low = new char[12] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'ı', 'j', 'k', 'l' };

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

            int[] len_blocks = new int[12];

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
            char[] empty_char = new char[9];
            char[][] h_main = new char[12][] { h_A, h_B, h_C, h_D, h_E, h_F, h_G, h_H, h_I, h_J, h_K, h_L };
            char[][] h_box0 = h_main;
            char[][] c_box0 = new char[12][] { h_A, h_B, h_C, h_D, h_E, h_F, h_G, h_H, h_I, h_J, h_K, h_L };

            char[][] h_box1 = new char[12][];
            char[][] h_box2 = new char[12][];
            char[][] h_box3 = new char[12][];

            char[][] c_box1 = new char[12][];
            char[][] c_box2 = new char[12][];
            char[][] c_box3 = new char[12][];


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

                        for (int step = 0; step < 12; step++)
                        {
                            int length = random.Next(4, 10);
                            len_blocks[step] = length;

                            for (int i = 0; i < length; i++)
                            {
                                h_box0[step][i] = blocks_ID[step];

                            }

                        }


                        do
                        {
                            // SCREEN
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.SetCursorPosition(40, 1);
                            Console.WriteLine("¸.·``·.¸¸.·``·¸¸.·``· (>^.^)>            PACKING GAME            <(^.^<) ¸.·``·.¸¸.·``·¸¸.·``·  ");

                            Console.SetCursorPosition(50, 4);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("-  " + user_name.ToUpper() + "  -");
                            Console.SetCursorPosition(50, 5);
                            Console.WriteLine("--------------");
                            Console.SetCursorPosition(50, 6);
                            Console.WriteLine("Score: ");
                            Console.SetCursorPosition(120, 4);
                            Console.WriteLine("-  COMPUTER  -");
                            Console.SetCursorPosition(120, 5);
                            Console.WriteLine("--------------");
                            Console.SetCursorPosition(120, 6);
                            Console.WriteLine("Score: ");
                            for (int i = 10; i < 38; i++)
                            {

                                Console.SetCursorPosition(85, i);
                                Console.WriteLine("|");

                            }



                            Console.SetCursorPosition(0, 10);
                            Console.WriteLine("  [0]");
                            Console.WriteLine(" ");

                            for (int step = 0; step < 12; step++)
                            {
                                Console.Write(len_blocks[step] + " ");
                                for (int i = 0; i < len_blocks[step]; i++)
                                {
                                    Console.Write(h_box0[step][i]);
                                }
                                Console.WriteLine();

                            }

                            /*
                            //HUMAN COMMANDS 
                            
                            ConsoleKeyInfo cmd_block = Console.ReadKey(true);
                            cmd_count++;

                            if (cmd_count > total)
                            {
                                for (int i = 0; i < 12; i++)
                                {
                                    if ((cmd_block.KeyChar.Equals(blocks_ID[i]) || cmd_block.KeyChar.Equals(blocks_ID_low[i])))
                                    {

                                        if (h_box0.Contains(h_main[i]))
                                        {
                                            if (Console.KeyAvailable == false)
                                            {
                                                ConsoleKeyInfo cmd_box = Console.ReadKey(true);
                                                if (cmd_box.Key == ConsoleKey.NumPad1 || cmd_box.Key == ConsoleKey.D1)
                                                {
                                                    h_box1[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[1]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box1[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box1[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad2 || cmd_box.Key == ConsoleKey.D2)
                                                {
                                                    h_box2[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[2]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box2[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box2[step][k]);
                                                            };
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad3 || cmd_box.Key == ConsoleKey.D3)
                                                {
                                                    h_box3[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[3]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box3[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box3[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            Array.Clear(h_box0[i], 0, h_box0[i].Length);
                                        }

                                        else if (h_box1.Contains(h_main[i]))
                                        {
                                            if (Console.KeyAvailable == false)
                                            {
                                                ConsoleKeyInfo cmd_box = Console.ReadKey(true);
                                                if (cmd_box.Key == ConsoleKey.NumPad0 || cmd_box.Key == ConsoleKey.D0)
                                                {
                                                    h_box0[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[1]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            Console.Write(h_box1[step][k]);
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad2 || cmd_box.Key == ConsoleKey.D2)
                                                {
                                                    h_box2[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[2]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box2[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box2[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad3 || cmd_box.Key == ConsoleKey.D3)
                                                {
                                                    h_box3[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[3]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box0[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box0[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            Array.Clear(h_box1[i], 0, h_box1[i].Length);

                                        }

                                        else if (h_box2.Contains(h_main[i]))
                                        {
                                            if (Console.KeyAvailable == false)
                                            {
                                                ConsoleKeyInfo cmd_box = Console.ReadKey(true);
                                                if (cmd_box.Key == ConsoleKey.NumPad1 || cmd_box.Key == ConsoleKey.D1)
                                                {
                                                    h_box1[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[1]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box1[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box1[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad0 || cmd_box.Key == ConsoleKey.D0)
                                                {
                                                    h_box0[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[2]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box2[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box2[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }

                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad3 || cmd_box.Key == ConsoleKey.D3)
                                                {
                                                    h_box3[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[3]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box3[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box3[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            Array.Clear(h_box2[i], 0, h_box2[i].Length);

                                        }
                                        else if (h_box3.Contains(h_main[i]))
                                        {
                                            if (Console.KeyAvailable == false)
                                            {
                                                ConsoleKeyInfo cmd_box = Console.ReadKey(true);
                                                if (cmd_box.Key == ConsoleKey.NumPad1 || cmd_box.Key == ConsoleKey.D1)
                                                {
                                                    h_box1[i] = h_main[i];
                                                    Console.SetCursorPosition(30, 10);
                                                    Console.Write("[1]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int m = 0; m < len_blocks[step]; m++)
                                                        {
                                                            if (h_box1[step][m] != '\0')
                                                            {
                                                                Console.Write(h_box1[step][m]);
                                                            }
                                                        }

                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad2 || cmd_box.Key == ConsoleKey.D2)
                                                {
                                                    h_box2[i] = h_main[i];
                                                    Console.SetCursorPosition(40, 10);
                                                    Console.Write("[2]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int n = 0; n < len_blocks[step]; n++)
                                                        {
                                                            if (h_box2[step][n] != '\0')
                                                            {
                                                                Console.Write(h_box2[step][n]);
                                                            }
                                                        }

                                                    }
                                                }
                                                else if (cmd_box.Key == ConsoleKey.NumPad0 || cmd_box.Key == ConsoleKey.D0)
                                                {
                                                    h_box0[i] = h_main[i];
                                                    Console.SetCursorPosition(50, 10);
                                                    Console.Write("[3]   ");
                                                    for (int step = 0; step < 12; step++)
                                                    {
                                                        
                                                        for (int k = 0; k < len_blocks[step]; k++)
                                                        {
                                                            if (h_box3[step][k] != '\0')
                                                            {
                                                                Console.Write(h_box3[step][k]);
                                                            }
                                                        }
                                                        Console.WriteLine();
                                                    }
                                                }
                                            }
                                            Array.Clear(h_box3[i], 0, h_box3[i].Length);

                                        }


                                    }
                                }

                                total++;
                            }
                      

                            */



                        } while (Console.KeyAvailable);



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
                                Console.SetCursorPosition(80, 4);
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
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("TIME OVER");
                            Console.Read();
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
                            if(selection.Key.Equals(ConsoleKey.Spacebar))
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.SetCursorPosition(40, 1);
                                Console.WriteLine("¸.·``·.¸¸.·``·¸¸.·``· (>^.^)>            PACKING GAME            <(^.^<) ¸.·``·.¸¸.·``·¸¸.·``·  ");
                                Console.Read();

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
                        Console.Read();
                    }

                }

            }
        }
    }
}
