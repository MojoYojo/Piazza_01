using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Piazza_01
{
    class Program
    {
        static void Main(string[] args)
        {
            int N;//Количество элементов массива
            int.TryParse(Console.ReadLine(), out N);//Вводим количество
            int[] array = new int[N], primeNumbers = new int[N];
            int count = 0;
            for (int i=0;i<N;i++)
            {
                int.TryParse(Console.ReadLine(), out array[i]);//Присваиваем элемент массиву
                int numberOfDivisors = 0;//количество делителей, нужно для того, чтобы узнать является ли число простым
                for(int j=2;j<=array[i];j++)
                {
                    if(array[i]%j==0)//Узнаем является ли число простым
                        numberOfDivisors++;
                    if (numberOfDivisors > 1)//Если количество делителей превышает больше 1, то тогда заканчиваем дальнейший цикл, должен напомнить, что мы автоматически взяли "1" как делитель, потому-что оно делится на любое число
                        break;
                }
                if (numberOfDivisors < 2)//Если количество делителей меньше 2, то присваеваем данный элемент массива в новый массив предназначенный для содержания простых чисел
                {
                    primeNumbers[count] = array[i];
                    count++;
                }
            }

            Console.WriteLine("Prime numbers: ");//Тем самым выводим простые числа
            for (int i=0;i< count;i++)
            {
                Console.Write(primeNumbers[i]+" ");
            }
            Console.ReadKey();
        }
    }
}
