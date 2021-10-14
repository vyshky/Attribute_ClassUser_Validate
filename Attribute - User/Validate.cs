using System;
using System.Reflection;

namespace AttributeUser
{
    public class Validate
    {
        /// <summary>
        /// Валидация возраста usera через атрибут над классом
        /// Поиск атрибута над классом
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true and false</returns>
        public static bool User(User user) // ищет атрибуты над классом
        {
            // User testClass = new User("", 18); // пример получения типа
            // Type type = testClass.GetType();   // пример получения типа
            Type typeUser = typeof(User);//Получаем тип User
            Attribute[] methodInfo = Attribute.GetCustomAttributes(typeUser); // вызывает класс Attribute и получаем атрибуты; тоже самое только вызавает MethodInfo typeUser.GetCustomAttributes(false) false - не искать атрибуты базовых классов 

            foreach (Attribute attr in methodInfo) // methodInfo хранит атрибуты
            {
                // attr.GetType() == typeof(AgeValidationAttribute) проверяем тип атрибута , если атрибут не совпадает то пропускаем условие
                if (attr.GetType() == typeof(AgeValidationAttribute) && ((AgeValidationAttribute)attr).GetAge() <= user.Age)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Валидация возраста usera через атрибут над конструктором
        /// Поиск атрибута над конструктором
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true and false</returns>
        public static bool UserConstructor(User user)
        {
            Type typeUser = typeof(User); //Получаем тип User
            foreach (ConstructorInfo ctor in typeUser.GetConstructors()) // GetMethod получает методы  // ctor хранит в себе конструктор и атрибуты которые можно получить
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(ctor)) // тоже самое  ctor.GetCustomAttributes(false)
                {
                    // attr.GetType() == typeof(AgeValidationAttribute) проверяем тип атрибута , если атрибут не совпадает то пропускаем условие
                    if (attr.GetType() == typeof(AgeValidationAttribute) && ((AgeValidationAttribute)attr).GetAge() <= user.Age)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Валидация возраста usera через атрибут над методом
        /// Поиск атрибута над методом
        /// </summary>
        /// <param name="user"></param>
        /// <returns>true and false</returns>
        public static bool UserMethod(User user)
        {
            Type typeUser = typeof(User); //Получаем тип User
            foreach (MethodInfo mInfo in typeUser.GetMethods()) // GetMethod получает методы// mInfo хранит в себе метод и атрибуты которые можно получить
            {
                foreach (Attribute attr in Attribute.GetCustomAttributes(mInfo)) // тоже самое  methodInfo.GetCustomAttributes(false)
                {
                    // attr.GetType() == typeof(AgeValidationAttribute) проверяем тип атрибута , если атрибут не совпадает то пропускаем условие
                    if (attr.GetType() == typeof(AgeValidationAttribute) && ((AgeValidationAttribute)attr).GetAge() <= user.Age)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}