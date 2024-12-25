using System;
using System.Collections.Generic;

namespace FindingShortestPath
{
    class Program
    {

        static void Main(string[] args)
        {
            // связи точек и их растояния
            List<PointsOnKatya> arrayRooms = new List<PointsOnKatya>() { };

            while (true)
            {
                Console.WriteLine("Выберете номер задачи:\n");
                Console.WriteLine("1. Создать маршрут");
                Console.WriteLine("2. Поиск кратчайшего пути между 2-мя точками");
                Console.WriteLine("3. Выход из программы\n");

                Console.Write("Введите номер задачи: ");
                if (int.TryParse(Console.ReadLine(), out int issueNumber))
                {
                    switch (issueNumber)
                    {
                        case 1:
                            Console.WriteLine("\nСтарый маршрут сброшен.");
                            arrayRooms.Clear();

                            bool IsAddingPath = true;

                            while (IsAddingPath)
                            {
                                Console.WriteLine("\nДобавление пути.");
                                Console.Write("\nВведите номер первой точки: ");
                                if (int.TryParse(Console.ReadLine(), out int firstPoint))
                                {
                                    Console.Write("Введите номер второй точки: ");
                                    if (int.TryParse(Console.ReadLine(), out int secondPoint))
                                    {
                                        bool IsPointsUnique = true; // Маршрут уникальный?

                                        //  Проверка, что точка маршрута не ссылается саму на себя
                                        if(firstPoint == secondPoint)
                                        {
                                            Console.Write("\nМаршрут ссылается сам на себя.\n");
                                        }
                                        else
                                        {
                                            // Проверка, что данной последовательности еще не существует
                                            if (arrayRooms.Count > 0)
                                            {
                                                foreach (var point in arrayRooms)
                                                {
                                                    if (point.firstPoint == firstPoint && point.secondPoint == secondPoint)
                                                    {
                                                        // Маршрут уже существуют
                                                        Console.WriteLine("Маршрут уже существует.");
                                                        IsPointsUnique = false;
                                                        continue;
                                                    }
                                                }

                                                // Если маршрут уникальный
                                                if (IsPointsUnique)
                                                {
                                                    while (true)
                                                    {
                                                        Console.Write("Введите растояние между точками: ");
                                                        if (double.TryParse(Console.ReadLine(), out double distance))
                                                        {
                                                            PointsOnKatya pointsOnKatya = new PointsOnKatya();
                                                            pointsOnKatya.firstPoint = firstPoint;
                                                            pointsOnKatya.secondPoint = secondPoint;
                                                            pointsOnKatya.distance = distance;
                                                            arrayRooms.Add(pointsOnKatya);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Некорректное растояние.\n");
                                                        }
                                                    }
                                                }
                                            }
                                            else // Если массив еще не заполнен
                                            {
                                                while (true)
                                                {
                                                    Console.Write("Введите растояние между точками: ");
                                                    if (double.TryParse(Console.ReadLine(), out double distance))
                                                    {
                                                        PointsOnKatya pointsOnKatya = new PointsOnKatya();
                                                        pointsOnKatya.firstPoint = firstPoint;
                                                        pointsOnKatya.secondPoint = secondPoint;
                                                        pointsOnKatya.distance = distance;
                                                        arrayRooms.Add(pointsOnKatya);
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Некорректное растояние.\n");
                                                    }
                                                }
                                            }
                                        }
                                   

                                        Console.WriteLine("\nВыберете действие:");
                                        Console.WriteLine("1. Закончить ввод");
                                        Console.WriteLine("2. Добавить еще точку\n");

                                        bool IsAddingPathV2 = true;

                                        while (IsAddingPathV2)
                                        {
                                            Console.Write("Введите номер действия: ");
                                            if (int.TryParse(Console.ReadLine(), out int action))
                                            {
                                                switch (action)
                                                {
                                                    case 1:
                                                        IsAddingPath = false;
                                                        IsAddingPathV2 = false;
                                                        break;

                                                    case 2:
                                                        IsAddingPathV2 = false;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine("Некорректный номер. Введите номера снова.");
                                            }
                                            Console.WriteLine();
                                        }


                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный номер. Введите номера снова.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Некорректный номер. Введите номера снова.");
                                }


                            }
                            break;

                        case 2:
                            while (true)
                            {
                                // Проверка, что есть пути
                                if(arrayRooms != null && arrayRooms.Count > 0)
                                {
                                    Console.Write("\nВведите номер первой точки: ");
                                    if (int.TryParse(Console.ReadLine(), out int firstPoint))
                                    {
                                        Console.Write("Введите номер второй точки: ");
                                        if (int.TryParse(Console.ReadLine(), out int secondPoint))
                                        {
                                            bool IsExistenceOfFirstPoint = false; // Проверка 1 точки на сущестование
                                            bool IsExistenceOfSecondPoint = false; //  Проверка 2 точки на сущестование

                                            foreach (var point in arrayRooms)
                                            {
                                                if (point.firstPoint == firstPoint || point.secondPoint == firstPoint)
                                                {
                                                    IsExistenceOfFirstPoint = true;
                                                }

                                                if (point.firstPoint == secondPoint || point.secondPoint == secondPoint)
                                                {
                                                    IsExistenceOfSecondPoint = true;
                                                }
                                            }


                                            if (!IsExistenceOfFirstPoint)
                                            {
                                                Console.WriteLine("Первая точка не существует.");
                                            }

                                            if (!IsExistenceOfSecondPoint)
                                            {
                                                Console.WriteLine("Вторая точка не существует.");
                                            }


                                            // Если все точки существуют
                                            // Ищем самый короткий путь
                                            Console.WriteLine("\nСамый короткий путь.\n");

                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Некорректный номер. Введите номера снова.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Некорректный номер. Введите номера снова.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("\nНет ни одного маршрута. Выход в меню.\n");
                                    break;
                                }

                                
                            }
                            
                            break;

                    }
                }
                else
                {
                    Console.WriteLine("Некорректный номер задачи. Введите номер снова.");
                }

            }
        }
    }
}
