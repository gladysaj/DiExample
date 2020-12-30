using ObjectOrientedFundamentals.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedFundamentals
{
    #region Introduction
    /* Abstraction
     * 
     * "Abstraction means we focus on the essential qualities of something rather than one specific example." 
     * Barron Stone, "Programming Foundations: Object-Oriented Design." https://www.linkedin.com/learning/programming-foundations-object-oriented-design-3/abstraction?u=3322.
     * 
     * In software engineering and computer science, abstraction is: 
     *   - The process of removing physical, spatial, or temporal details[2 or attributes in the study of objects or systems to focus attention on details of greater importance;  it is similar in nature to the process of generalization. (Not OOP definition).  
     *   - The creation of abstract concept-objects by mirroring common features or attributes of various non-abstract objects or systems of study – the result of the process of abstraction.
     * Wikipedia, "Abstraction (computer science)." https://en.wikipedia.org/wiki/Abstraction_(computer_science). 
     * 
     * "Abstraction means hiding the unnecessary details from type consumers."
     * Microsoft Doc Documentation, "Object-Oriented programming (C#)." https://docs.microsoft.com/en-us/dotnet/csharp/tutorials/intro-to-csharp/object-oriented-programming
     */

    /*Polymorphism
     * 
     * "In programming languages and type theory, polymorphism is the provision of a single interface to entities of different types or the use of a single symbol to represent multiple different types." 
     * Wikipedia, "Polymorphism (computer science)." https://en.wikipedia.org/wiki/Polymorphism_(computer_science).


    /* Abstraction in C#
     * 
     * Two common ways for abstraction in C# are:
     *      - Abstract classes: An abstract class cannot be instantiated. The purpose of an abstract class is to provide a common definition of a base class that multiple derived classes can share
     *      - Interfaces: An interface contains definitions for a group of related functionalities that a non-abstract class or a struct must implement. It's a completely "abstract class", which can only contain abstract methods and properties
     */
    #endregion

    #region Abstraction

    /// <summary>
    /// Handles interacting with User
    /// </summary>
    public interface IUserInterface
    {
        void Tell(string tell);
        string Ask(string ask);
    }

    public class DocumentUserInterface : IUserInterface
    {
        public void Tell(string tell)
        {
            Message(tell);
        }

        public string Ask(string ask)
        {
            Message(ask);

            return Console.ReadLine();
        }

        private void Message(string message)
        {
            using System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\TestTextFile.log", true);
            file.WriteLine(message);
        }
    }
    #endregion

    #region Abstraction Activity
    // Create a ConsoleUserInterface class that inherits IUserInterface.  For the Tell method it should use Console.WriteLine.  For the AskMethod it should use Console.WriteLine and Console.ReadLine().

    # endregion

    #region Cheat!
    /* public class ConsoleUserInterface : IUserInterface
     {
         public void Tell(string tell)
         {
             Console.WriteLine(tell);
         }
         public string Ask(string ask)
         {
             Console.WriteLine(ask);

             return Console.ReadLine();
         }
     }*/
    #endregion

    #region Polymorphism
    public class Setup
    {
        private IUserInterface ui;
        public Setup()
        {
            ui = AskUserForInterface();
        }
        public void GetUserInformation()
        {
            ui.Tell("Greetings and Hello!");
            var name = ui.Ask("What is your name?");
            var color = ui.Ask("What is your favorite color?");
            var number = ui.Ask("What is your favorite number?");
            ui.Tell($"Hi {name}.  Your favorite color is {color}.  Your favorite number is {number}.");
            Console.WriteLine(Environment.NewLine);
        }

        private IUserInterface AskUserForInterface()
        {
            Console.WriteLine(AsksAndTells.ChooseInterface);
            var response = Console.ReadLine();

            if (IsValiUserInterfaceSelection(response, out IUserInterface ui))
            {
                return ui;
            }
            else
            {
                Console.WriteLine(AsksAndTells.MustChooseValidInterface);

                return AskUserForInterface();
            }
        }

        private bool IsValiUserInterfaceSelection(string userResponse, out IUserInterface ui)
        {

            // TryParse is used here instead of Parse becuase the decision was made exception should not be used for invalid player input workflow.
            var response = Int32.TryParse(userResponse, out int amount);

            // Fancy switch statment that sets the out prameter "ui" to a instatiated object 
            switch (amount)
            {
                case 1:
                    ui = new DocumentUserInterface();
                    break;

                default:
                    ui = null;
                    return false;
            };

            return response;
        }
    }
    #endregion
}


