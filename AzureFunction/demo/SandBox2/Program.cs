using System;
using PInvokeWrapper;
namespace SandBox2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Entity e = new Entity("The Wallman", 20, 35))
            {
                e.Move(5, -10);
                Console.WriteLine($"{e.GetName()} has been moved.");
                Console.WriteLine(e.GetXPosition() + " " + e.GetYPosition());
            }
            Console.ReadKey();
        }
    }

}

