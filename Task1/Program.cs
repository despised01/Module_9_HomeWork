using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptions = new Exception[]
            {
                new ArgumentException(),
                new NotSupportedException(),
                new RankException(),
                new IndexOutOfRangeException(),
                new MyException("Неизвестная ошибка.")
            };

            foreach (var ecxeption in exceptions)
            {
                try
                {
                    throw ecxeption;
                }

                catch (Exception ex) when (ex is ArgumentException)
                {
                    Console.WriteLine("Непустой аргумент, передаваемый в метод, является недопустимым. ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex) when (ex is NotSupportedException)
                {
                    Console.WriteLine("Метод или операция не поддерживается. ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex) when (ex is RankException)
                {
                    Console.WriteLine("В метод передается массив с неправильным числом измерений. ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex) when (ex is IndexOutOfRangeException)
                {
                    Console.WriteLine("Индекс находится за пределами границ массива или коллекции. ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }

                catch (Exception ex) when (ex is MyException)
                {
                    Console.WriteLine("Произошла неизвестная ошибка в работе программы. ({0})", ex.GetType());
                    Console.WriteLine(ex.Message);
                }

                finally
                {
                    Console.Read();
                }
            }
        }
    }
    
    class MyException: Exception
    {
        public MyException(string _message) : base(_message) { }
    }

}
