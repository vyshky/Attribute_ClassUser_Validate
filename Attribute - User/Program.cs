using System;

namespace AttributeUser
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Alex", 1000);
            Console.WriteLine($"Имя - {user.Name} | Возраст - {user.Age}");
            Console.WriteLine("Класс - " + Validate.User(user));
            Console.WriteLine("Конструктор - " + Validate.UserConstructor(user));
            Console.WriteLine("Метод - " + Validate.UserMethod(user));
        }
    }
}