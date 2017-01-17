using System;
using CryptoServiceClassLibrary;
namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var pas = new Password(5);
            Console.WriteLine(pas);
        }
    }
}