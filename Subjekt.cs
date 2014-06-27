using System;
using System.Collections.Generic;
using System.Text;

namespace Observer
{
    public partial class Subjekt
    {
        // liste zum speichern der abonnentennamen
        private HashSet<Beobachter> Beobachter = new HashSet<Beobachter>();
        private int _int;

        public int Lagerbestand
        {
            get { return _int; }
            set
            {
                if (value > _int ^ _int > 1)
                {
                    Benachrichtigen();
                }
                _int = value;
                Console.WriteLine("Lagerbestand: " + _int);
            }
        }

        public void Abonnieren(Beobachter beobachter)
        {
            if (Beobachter.Contains(beobachter))
            {
                Console.WriteLine("{0} beobachtet diesen Artikel bereits.", 
                    beobachter.BeobachterName);
            }
            else
            {
                Console.WriteLine("{0} ist jetzt Beobachter dieses Artikels.", 
                    beobachter.BeobachterName);
                Beobachter.Add(beobachter);
            }
        }
        public void DeAbonnieren(Beobachter beobachter)
        {
            if (Beobachter.Contains(beobachter))
            {
                Console.WriteLine("{0} hat sein Abonnement beendet.", 
                    beobachter.BeobachterName);
                Beobachter.Remove(beobachter);
            }
            else
            {
                // beobachter gibts nicht oder hat kein abo
                Console.WriteLine("{0} beobachtet diesen Artikel nicht.", 
                    beobachter.BeobachterName);
            }
        }

        public void Benachrichtigen()
        {
            // jeden beobachter in List<Beobachter> benachrichtigen
            try
            {
                // ehemals List<T>, wofür .ForEach verfügbar ist
                // zum iterieren => Beobachter.ForEach(x => x.Benachrichtigen());
                // umstellung auf HashSet<T>:
                foreach (Beobachter B in Beobachter)
                {
                    B.Benachrichtigen();
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Es trat ein Fehler beim Benachrichtigen auf! {0}", 
                    Ex.Message);
            }
        }
    }
}
