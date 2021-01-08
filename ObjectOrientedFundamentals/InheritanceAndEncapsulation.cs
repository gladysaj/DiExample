using ObjectOrientedFundamentals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ObjectOrientedFundamentals
{
    #region Introduction
    /* What is Inheritance?
     * 
     * "Inheritance enables a new class to receive or inherit the attributes and methods of existing classes using the same implementation which is a great form of code reuse. "
     *  Barron Stone, "Programming Foundations: Object Oriented Design." https://www.linkedin.com/learning/programming-foundations-object-oriented-design-3/inheritance?u=3322.
     *  
     *  " Inheritance is a feature of object-oriented programming languages that allows you to define a base class that provides specific functionality (data and behavior) and to define derived classes that either inherit or override that functionality." 
     *  MS Docs, "Inheritance in C# and .NET." https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/inheritance.
     */


    /* What is Encapsulation?
     * 
     * "Encapsulation means that a group of related properties, methods, and other members are treated as a single unit or object."
     * Ms Docs, "Object-Oriented programming (C#)."
     * 
     * Typically, only the object's own methods can directly inspect or manipulate its fields. Hiding the internals of the object protects its integrity by preventing users from setting the internal data of the component into an invalid or inconsistent state. A supposed benefit of encapsulation is that it can reduce system complexity, and thus increase robustness, by allowing the developer to limit the interdependencies between software components. 
     * Wikipedia, "Encapsulation (computer programming)." https://en.wikipedia.org/wiki/Encapsulation_(computer_programming).
     * 
     * "Well, if you're the person writing these classes, why would you want to hide your own code? Why keep secrets from yourself? - It's not about being secretive. It's about reducing dependencies between different parts of the application. The change in one place won't cause a domino effect and require multiple changes elsewhere. - Then how much should you hide? - Well, different languages have different levels of support for hiding properties and methods. But the general rule is to encapsulate as much as possible."
     * Olivia Stone, "Programming Foundations: Object Oriented Design." https://www.linkedin.com/learning/programming-foundations-object-oriented-design-3/encapsulation?resume=false&u=3322.
     */

    /* Expresions are being used in the code below
     * 
     * The two methods below are functionally the same but use different syntax:
     * 
     * public string GetName() => name;
     * 
     * public string GetName()
     * {
     *      return name;
     * }
     * 
     * Expression body definition  - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-operator#expression-body-definition
     * The => token is supported in two forms: as the lambda operator and as a separator of a member name and the member implementation in an expression body definition.
     * An expression body definition has the following general syntax: member => expression; here expression is a valid expression.The return type of expression must be implicitly convertible to the member's return type. Return type may be assumed.
     *
     * Lambda expressions(C# reference) - https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
     * Use the lambda declaration operator => to separate the lambda's parameter list from its body. To create a lambda expression, you specify input parameters (if any) on the left side of the lambda operator and an expression or a statement block on the other side.
    */


    /*
       Questions
            -   What are access modifiers in c#?
            -   Why do we encapsulate?
            -   What are getters and setters
            -   Simple Objects (Kiss) - We often create objects that kinda like "types" and purpose is only to store data.
            -   What is inheritance and why is it important?
    */

    #endregion

    #region Encapsulation
    public class Person
    {
        // NOTE: Change to protected
        private string name;
        private string phone;
        private string address;
        public Person(string newName, string newPhone, string newAddress)
        {
            name = newName;
            phone = newPhone;
            address = newAddress;
        }

        // Getters and Setters
        public string GetName() => name;
        public string GetPhone() => phone;
        public string GetAddress() => address;
        public void SetName(string updateName) => name = updateName;
        public void SetPhone(string updatePhone) => name = updatePhone;
        public void SetAddress(string updateAddress) => name = updateAddress;

        // NOTE: Add Virtual
        public void Update(string updateName, string updatePhone, string updateAddress)
        {
            name = updateName;
            phone = updatePhone;
            address = updateAddress;
        }
    }

    #region SimpleObjects
    public class Person2
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }

    public class People
    {
        private readonly List<Person2> persons = new List<Person2> { };
        // NOTE: Change how people are added and validate
        public void Add(Person2 person) => persons.Add(person);
        // NOTE: Key difference between these two.  Discuss removing settesr?
        public Person2 GetPerson(Guid id) => persons.Find(p => p.Id == id);
        public string GetPhone(Guid id) => persons.Find(p => p.Id == id).Phone;
        //Why is this here?
        public void CallPerson(Guid id)
        {
            //NOT IMPLMENTED
        }
    }


    #endregion

    #endregion

    #region Inheritance

    public class Customer : Person
    {
        private int customerId;
        public readonly List<Item> cart = new List<Item> { };

        // Example of adding the the contructor
        public Customer(int personCustomerId, string personName, string personPhone, string personAddress) : base(personName, personPhone, personAddress)
        {
            customerId = personCustomerId;
        }
        public int GetId() => customerId;

        // Example of overridding a method
        /*public override void Update(string updateName, string updatePhone, string updateAddress)
        {
            base.Update(updateName, updatePhone, updateAddress);
            Console.WriteLine($"Customer {name} with id {customerId} has been updated.");
        }*/
    }

    #endregion

    #region Inheritance Activity
    // Make an employee class that inherits the Person class.  Write at least one method that may retrieve the employee id frield.
    #endregion
}

