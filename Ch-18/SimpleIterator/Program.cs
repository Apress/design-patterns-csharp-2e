using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleIterator
{
    public class Arts : IEnumerable
    {
        private string[] Subjects;

        public Arts()
        {
            Subjects = new[] { "English", "History", "Geography", "Psychology" };
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string subject in Subjects)
            {
                yield return subject;
            }
        }
    }

    public class Science : IEnumerable
    {
        private LinkedList<string> Subjects;

        public Science()
        {
            Subjects = new LinkedList<string>();
            Subjects.AddFirst("Mathematics");
            Subjects.AddFirst("Computer Science");
            Subjects.AddFirst("Physics");
            Subjects.AddFirst("Electronics");
        }

        public IEnumerator GetEnumerator()
        {
            foreach (string subject in Subjects)
            {
                yield return subject;
            }
        }       
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Iterator Pattern.A simple demonstration using built-in contructs.***");
            Arts artsPapers = new Arts();
            Console.WriteLine("\nArts subjects are as follows:");
            //Consume values from the collection's GetEnumerator()
            foreach (string subject in artsPapers)
            {
                Console.WriteLine(subject);
            }

            Science sciencePapers = new Science();
            Console.WriteLine("\nScience subjects are as follows:");
            //Consume values from the collection's GetEnumerator()
            foreach (string subject in sciencePapers)
            {
                Console.WriteLine(subject);
            }
           
        }
    }
}
