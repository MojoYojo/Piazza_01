using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Piazza_01
{
    class Complex
    {
        public int a, b;

        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        public static Complex operator +(Complex c, Complex d)
        {
            Complex result = new Complex(c.a + d.a, c.b + d.b);
            return result;
        }

        public override string ToString()
        {
            return a + "/" + b;
        }
    }

    class Student
    {
        public string firstName, lastName;
        public double gpa;

        public Student (string firstName, string lastName, double gpa)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.gpa = gpa;
        }

        public override string ToString()
        {
            return this.firstName + " " + lastName + " " + gpa;
        }
    }

    class BigInteger
    {
        public long bigInt;

        public BigInteger(long bigInt)
        {
            this.bigInt = bigInt;
        }

        public static BigInteger operator +(BigInteger right, BigInteger left) {
            Console.Write(right + " + " + left);
            return new BigInteger(right.bigInt + left.bigInt);
        }

        public BigInteger Pow(int power)
        {
            Console.Write(this.bigInt + "^" + power);
            this.bigInt = Convert.ToInt64(Math.Pow(this.bigInt, power));
            return new BigInteger(this.bigInt);
        }

        public override string ToString()
        {
            return " = " + bigInt;
        }

    }

    class Program
    {
         static void Main(string[] args)
         {
            int N;//Количество элементов массива
            int.TryParse(Console.ReadLine(), out N);//Вводим количество
            int[] array = new int[N], primeNumbers = new int[N];
            int count = 0;
            for (int i = 0; i < N; i++)
            {
                int.TryParse(Console.ReadLine(), out array[i]);//Присваиваем элемент массиву
                int numberOfDivisors = 0;//количество делителей, нужно для того, чтобы узнать является ли число простым
                for (int j = 2; j <= array[i]; j++)
                {
                    if (array[i] % j == 0)//Узнаем является ли число простым
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
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(primeNumbers[i] + " ");
            }
           
            Console.WriteLine(new Complex(5, 6) + new Complex (7, 8));
            Console.WriteLine(new Student("Bauyrzhan", "Muratbek", 2.5));
            Console.WriteLine(32525245234 + 435345234123);
            Console.WriteLine((new BigInteger(3)).Pow(3));
            Console.ReadKey();
        }
    }
}
