using System;
using System.Text;

namespace Observer
{
    public class Beobachter
    {
        public string BeobachterName { get; private set; }
        public Beobachter(string name)
        {
            this.BeobachterName = name;
        }
        public void Benachrichtigen()
        {
            Console.WriteLine("Hallo {0}, es ist ein neuer Artikel im Lager verfügbar.", 
                    this.BeobachterName);
        }
    }
}
