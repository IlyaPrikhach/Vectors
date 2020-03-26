using System;
using System.IO;

namespace Vectors
{
    class Program
    {
        static StreamReader inlet = new StreamReader("Inlet.in");
        static StreamWriter outlet = new StreamWriter("Outlet.out");
        static void Main(string[] args)
        {
            Console.WriteLine("Какой тип ввода данных вы будете использовать? Из файла 1, из консоли 2");
            string[] inputType = Console.ReadLine().Replace('.', ',').Split(' ');
            int type = int.Parse(inputType[0]);
            int N = 0, c = 0, b = 0;
            double B = 0, C = 0;
            if (type == 1)
            {
                вводДанныхFile(out N, out B, out C);
                massOperationsFile(N, B, C, out b, out c);
            }
            else if (type == 2)
            {
                вводДанныхConsole(out N, out B, out C);
                massOperationsConsole(N, B, C, out b, out c);
            }
            else 
            {
                Console.WriteLine("Неверные данные");
               
            }

            Console.WriteLine("Количество элементов массива не делящихся на " + C + " " + c);
            Console.WriteLine("Количество элементов массива не делящихся на " + B + " " + b);
            outlet.WriteLine("Количество элементов массива не делящихся на " + C + " " + c);
            outlet.WriteLine("Количество элементов массива не делящихся на " + B + " " + b);
            outlet.Close();
            Console.ReadLine();
        }

        static void вводДанныхConsole(out int N, out double B, out double C)
        {
            try
            {
                Console.WriteLine("Введите N, B, C");
                string[] аргументы = Console.ReadLine().Replace('.', ',').Split(' ');
                N = int.Parse(аргументы[0]);
                B = double.Parse(аргументы[1]);
                C = double.Parse(аргументы[2]);
                if(B == 0 || C == 0)
                {
                    Console.WriteLine("Значение равно 0");
                    вводДанныхConsole(out N, out B, out C);
                }
                if(N < 0)
                {
                    Console.WriteLine("Количество элементов массива не может быть орицаельным");
                }
            }
            catch
            {
                Console.WriteLine("неверные данные");
                вводДанныхConsole(out N, out B, out C);
            }
        }

        static void вводДанныхFile(out int N, out double B, out double C)
        {
            try
            {
                Console.WriteLine("Введите N, B, C");
            string[] аргументы = Console.ReadLine().Replace('.', ',').Split(' ');
            N = int.Parse(аргументы[0]);
            B = double.Parse(аргументы[1]);
            C = double.Parse(аргументы[2]);
                if (B == 0 || C == 0)
                {
                    Console.WriteLine("Значение равно 0");
                    вводДанныхConsole(out N, out B, out C);
                }
                if (N < 0)
                {
                    Console.WriteLine("Количество элементов массива не может быть орицаельным");
                }

                Console.WriteLine("Данные  из файла");
                
            }
            catch
            {
                Console.WriteLine("неверные данные");
                вводДанныхConsole(out N, out B, out C);
            }
        }

        static void massOperationsConsole(int N, double B, double C, out int  b, out int  c)
        {
            int[] mass = null;
            try
            {
                Console.WriteLine("Введите " + N + " Элементов массива");
                string[] TempArray = Console.ReadLine().Replace("  ", " ").Split(' ');

                mass = new int[N];
                for (int i = 0; i < N; i++)
                {
                    mass[i] = Convert.ToInt32(TempArray[i]);
                }
            }
            catch
            {
                Console.WriteLine("Вы ввели неверное количество элементов массива");
                massOperationsConsole(N, B, C, out b, out c);
            }
           

            c = 0;
            b = 0;
            
            foreach (int massPer in mass)
            {
                if (massPer % B != 0)
                {
                     b++;

                }
                if (massPer % C != 0)
                {
                    c++;

                }
            }

        }

        static void massOperationsFile(int N, double B, double C, out int b, out int c)
        {
            c = 0;
            b = 0;
            try
            {
                int [] mass = new int [N];
                for (int i = 0; i < N; i++)
                {
                    
                    mass[i] = Convert.ToInt32(inlet.ReadLine());
                    Console.WriteLine(mass[i]);
                }

                //string[] text = inlet.ReadToEnd().Split('\n');
                //int[] mass = Array.ConvertAll(text, int.Parse );
                if(mass.Length != N)
                {
                    Console.WriteLine("Введено неверное количество элементов массива. Введите данные повторно или проверьте файл");
                    вводДанныхFile(out N, out B, out C);
                }

              
                foreach (int massPer in mass)
                {
                    if (massPer % B != 0)
                    {
                        b++;

                    }
                    if (massPer % C != 0)
                    {
                        c++;

                    }
                }
            }
            catch
            {
                Console.WriteLine("Неправильный ввод данных ");
            }


        }


    }
}
