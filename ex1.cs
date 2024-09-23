using System;

class MyException : Exception
{
    public MyException(string message) : base(message)
    {
    }
}

class Program
{
    static void Main()
    {
        Exception[] exceptions = new Exception[]
        {
            new ArgumentNullException("Аргумент не может быть null"),
            new InvalidOperationException("Неверная операция"),
            new DivideByZeroException("Деление на ноль"),
            new IndexOutOfRangeException("Индекс вне диапазона"),
            new MyException("Моё исключение")
        };


        foreach (var ex in exceptions)
        {
            try
            {
                throw ex;
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"исключение: {e.Message}");
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"исключение: {e.Message}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine($"исключение: {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"исключение: {e.Message}");
            }
            catch (MyException e)
            {
                Console.WriteLine($"исключение: {e.Message}");
            }
            finally
            {
                Console.WriteLine("finally выполнен.");
            }
        }
    }
}

