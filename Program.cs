using System;
using System.Collections.Generic;

public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}

class Sorter
{
    public delegate void SortHandler();
    public event SortHandler OnSort;

    private List<string> lastNames;

    public Sorter(List<string> lastNames)
    {
        this.lastNames = lastNames;
    }

    public void SortAscending()
    {
        lastNames.Sort();
        Console.WriteLine("Список отсортирован по возрастанию (А-Я):");
        PrintList();
    }

    public void SortDescending()
    {
        lastNames.Sort();
        lastNames.Reverse();
        Console.WriteLine("Список отсортирован по убыванию (Я-А):");
        PrintList();
    }

    private void PrintList()
    {
        foreach (var name in lastNames)
        {
            Console.WriteLine(name);
        }
    }

    public void StartSort(int choice)
    {
        switch (choice)
        {
            case 1:
                OnSort += SortAscending;
                break;
            case 2:
                OnSort += SortDescending;
                break;
            default:
                throw new InvalidInputException("Неверный ввод. Введите 1 для сортировки А-Я или 2 для сортировки Я-А.");
        }

        OnSort?.Invoke();
    }
}


class Program
{
    static void Main(string[] args)
    {
        List<string> lastNames = new List<string> { "Иванов", "Петров", "Сидоров", "Кузнецов", "Смирнов" };
        Sorter sorter = new Sorter(lastNames);

        try
        {
            Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");
            string input = Console.ReadLine();
            if (!int.TryParse(input, out int choice))
            {
                throw new InvalidInputException("Ошибка: введено не число.");
            }

            sorter.StartSort(choice);
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Произошла ошибка: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Программа завершена.");
        }
    }
}
