using System;

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

        static int LCM(int a, int b)
        {
            int num1, num2;
            if (a > b)
            {
                num1 = a; num2 = b;
            }
            else
            {
                num1 = b; num2 = a;
            }

            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }

        static int countOfOperations = 0;
        static Complex[] complexNumbers = new Complex[1000000];
        static char[] arithmetic_operators = new char[1000000];

        public static Complex operator +(Complex c, Complex d)
        {
            if (countOfOperations == 0) {
                complexNumbers[countOfOperations] = c;
            }
            complexNumbers[countOfOperations+1] = d;
            arithmetic_operators[countOfOperations] = '+';
            countOfOperations++;
            Complex result = new Complex(c.a + d.a, c.b + d.b);
            return result;
        }

        public static Complex operator -(Complex c, Complex d)
        {
            if (countOfOperations == 0)
            {
                complexNumbers[countOfOperations] = c;
            }
            complexNumbers[countOfOperations + 1] = d;
            arithmetic_operators[countOfOperations] = '-';
            countOfOperations++;
            Complex result = new Complex(c.a - d.a, c.b - d.b);
            return result;
        }

        public static Complex operator *(Complex c, Complex d)
        {
            if (countOfOperations == 0)
            {
                complexNumbers[countOfOperations] = c;
            }
            complexNumbers[countOfOperations + 1] = d;
            arithmetic_operators[countOfOperations] = '*';
            countOfOperations++;
            Complex result = new Complex(c.a * d.a, c.b * d.b);
            return result;
        }

        public static Complex operator /(Complex c, Complex d)
        {
            if (countOfOperations == 0)
            {
                complexNumbers[countOfOperations] = c;
            }
            complexNumbers[countOfOperations + 1] = d;
            arithmetic_operators[countOfOperations] = '/';
            countOfOperations++;
            Complex result = new Complex(c.a / d.a, c.b / d.b);
            return result;
        }

        public override string ToString()
        {
            for (int i = 0; i < countOfOperations + 1; i++) {
                if (i == 0)
                    Console.Write(complexNumbers[i].a + "/" + complexNumbers[i].b);
                else
                    Console.Write(" " + arithmetic_operators[i - 1] + " " + +complexNumbers[i].a + "/" + complexNumbers[i].b);
            }

            Complex LCMforFractions = new Complex(complexNumbers[0].a, complexNumbers[0].b);

            if (countOfOperations >= 1) {
                for (int i = 0; i < countOfOperations+1; i++)
                {
                    if (i == 0)
                        ++i;
                    LCMforFractions.b = LCM(LCMforFractions.b, complexNumbers[i].b);
                    if (complexNumbers[i].b != complexNumbers[i - 1].b) {
                        if (complexNumbers[i].b != LCMforFractions.b)
                            complexNumbers[i].a *= (LCMforFractions.b / complexNumbers[i].b);
                        if (complexNumbers[i-1].b != LCMforFractions.b) 
                            complexNumbers[i - 1].a *= (LCMforFractions.b / complexNumbers[i - 1].b);
                        complexNumbers[i - 1].b = LCMforFractions.b;
                        complexNumbers[i].b = LCMforFractions.b;
                        Console.Write(" = " + complexNumbers[i - 1].a + "/" + complexNumbers[i - 1].b + " " + arithmetic_operators[i - 1] + " " +  complexNumbers[i].a + "/" + LCMforFractions.b);
                    }

                    if (arithmetic_operators[i - 1] == '+')
                        complexNumbers[i].a += complexNumbers[i - 1].a;
                    else if (arithmetic_operators[i - 1] == '-')
                    {
                        complexNumbers[i - 1].a -= complexNumbers[i].a;
                        complexNumbers[i].a = complexNumbers[i - 1].a;
                    }
                    else if (arithmetic_operators[i - 1] == '*')
                        complexNumbers[i].a *= complexNumbers[i - 1].a;
                    else if (arithmetic_operators[i - 1] == '/')
                    {
                        complexNumbers[i - 1].a /= complexNumbers[i].a;
                        complexNumbers[i].a = complexNumbers[i - 1].a;
                    }

                    LCMforFractions.a = complexNumbers[i].a;
                }
            }

            countOfOperations = 0;
            Array.Clear(arithmetic_operators, 0, arithmetic_operators.Length);
            Array.Clear(complexNumbers, 0, complexNumbers.Length);
            return " = " + LCMforFractions.a + "/" + LCMforFractions.b + " = " + (double) LCMforFractions.a / (double) LCMforFractions.b;
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

        public static BigInteger operator -(BigInteger right, BigInteger left)
        {
            Console.Write(right + " - " + left);
            return new BigInteger(right.bigInt - left.bigInt);
        }

        public static BigInteger operator *(BigInteger right, BigInteger left)
        {
            Console.Write(right + " * " + left);
            return new BigInteger(right.bigInt * left.bigInt);
        }

        public static BigInteger operator /(BigInteger right, BigInteger left)
        {
            Console.Write(right + " / " + left);
            return new BigInteger(right.bigInt / left.bigInt);
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
                Console.Write(primeNumbers[i] + " ");
            }
            
            Console.WriteLine("\nEnter complex numbers arithmetics:");
            string line = Console.ReadLine();
            int num1 = 0, num2 = 0, den1 = 1, den2 = 1;
            bool firstExist = false, finished = false;
            char arithm_operator = '+';
            string converter = "";
            for(int i=0;i<line.Length;i++)
            {
                char ch = line[i];
                if (Char.IsDigit(ch))
                    converter += ch;
                if (((ch == '+' || ch == '-' || ch == '*' || ch == '/') && Char.IsWhiteSpace(line[i - 1]) && Char.IsWhiteSpace(line[i + 1])) || i == line.Length - 1)
                {
                    if(!firstExist)
                    {
                        den1 = int.Parse(converter);
                        firstExist = true;
                        arithm_operator = ch;
                    }
                    else
                    {
                        den2 = int.Parse(converter);
                        finished = true;
                    }
                    converter = "";
                }
                if (ch == '/' && Char.IsDigit(line[i-1]) && Char.IsDigit(line[i+1]))
                {
                    if (!firstExist)
                        num1 = int.Parse(converter);
                    else
                        num2 = int.Parse(converter);
                    converter = "";
                }
                

                if(finished)
                {
                    if (arithm_operator == '+')
                        Console.WriteLine(new Complex(num1, den1) + new Complex(num2, den2));
                    else if (arithm_operator == '-')
                        Console.WriteLine(new Complex(num1, den1) - new Complex(num2, den2));
                    else if (arithm_operator == '*')
                        Console.WriteLine(new Complex(num1, den1) * new Complex(num2, den2));
                    else if (arithm_operator == '/')
                        Console.WriteLine(new Complex(num1, den1) / new Complex(num2, den2));
                    firstExist = false;
                    finished = false;
                }
            }
            /*
            Console.WriteLine(new Complex(6, 3) + new Complex(7, 4) - new Complex(3, 3));
            Console.WriteLine(new Complex(1, 4) + new Complex(5, 4) + new Complex(6, 4));*/
            Console.WriteLine(new Student("Bauyrzhan", "Muratbek", 2.5));
            Console.WriteLine(32525245234 + 435345234123);
            Console.WriteLine(32525245234 - 435345234123);
            Console.WriteLine(32525 * 43534);
            Console.WriteLine(435345234123 / 3252524);
            Console.WriteLine(435345234123 % 32525245234);
            Console.WriteLine((new BigInteger(3)).Pow(3));
            Console.ReadKey();
        }
    }
}
