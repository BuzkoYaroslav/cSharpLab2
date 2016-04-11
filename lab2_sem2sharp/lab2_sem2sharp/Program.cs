
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_sem2sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Polynomial> polies = new List<Polynomial>();

            while (true)
            {
                try
                {
                    char c = Menu();
                    switch (c)
                    {
                        case '1':
                            {
                                polies.Add(ReadPoly());
                                break;
                            }
                        case '2':
                            {
                                WritePolies(polies);
                                break;
                            }
                        case '3':
                            {
                                int i, j;
                                ReadIndeces(out i, out j);

                                (polies[i] * polies[j]).WritePoly();
                                break;
                            }
                        case '4':
                            {
                                int i, j;
                                ReadIndeces(out i, out j);

                                (polies[i] + polies[j]).WritePoly();
                                break;
                            }
                        case '5':
                            {
                                int i, j;
                                ReadIndeces(out i, out j);

                                (polies[i] - polies[j]).WritePoly();
                                break;
                            }
                        case '6':
                            {
                                Console.WriteLine("Введите имя файла: ");
                                StreamWriter sWrite = null;
                                try
                                {
                                    sWrite = new StreamWriter(Console.ReadLine());

                                    for (int i = 0; i < polies.Count; i++)
                                        sWrite.WriteLine(polies[i].ToString());
                                }
                                catch (Exception exp)
                                {
                                    Console.WriteLine(exp.Message);
                                }
                                finally
                                {
                                    sWrite.Close();
                                }
                                break;
                            }
                        case '7':
                            {
                                return;
                            }
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        static char Menu()
        {
            Console.WriteLine("1 - Добавить многочлен \n" +
                              "2 - Вывести многочлены \n" +
                              "3 - Перемножить многочлены \n" +
                              "4 - Сложить многочлены \n" +
                              "5 - Отнять многочлены \n" +
                              "6 - Сохранить многочлены в файл \n" +
                              "7 - Выйти.");
            Console.WriteLine("Введите операцию: ");

            return Console.ReadLine()[0];
        }
        static Polynomial ReadPoly()
        {
            Console.WriteLine("Введите степень многочлена: ");

            int number = Convert.ToInt16(Console.ReadLine());
            double[] coef = new double[number + 1];

            Console.WriteLine("Введите коефициенты многочлена: ");
            for (int i = 0; i <= number; i++)
                coef[i] = Convert.ToDouble(Console.ReadLine());

            return new Polynomial(coef);
        }
        static void WritePolies(List<Polynomial> polies)
        {
            for (int i = 0; i < polies.Count; i++)
                polies[i].WritePoly();
        }
        static void ReadIndeces(out int i, out int j)
        {
            Console.WriteLine("Введите первый индекс: ");
            i = Convert.ToInt16(Console.ReadLine());

            Console.WriteLine("Введите второй индекс: ");
            j = Convert.ToInt16(Console.ReadLine());
        }
    }
}
