using System;
using System.Reflection;

[AttributeUsage(AttributeTargets.All)]
public class AgeValidationAttribute : Attribute
{
    protected readonly int age;

    public AgeValidationAttribute()
    {
        age = 0;
    }

    public AgeValidationAttribute(int age)
    {
        this.age = age;
    }

    public int GetAge()
    {
        return age;
    }
}

namespace AttributeUser
{
    [AgeValidation(18)]
    public class User
    {
        public string Name { get; set; }

        public int Age { get; set; }

        [AgeValidation(18)]
        public void MethodInfo()
        {
            Console.WriteLine("Hello World");
        }

        [AgeValidation(18)]
        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}