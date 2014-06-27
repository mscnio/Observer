using System;
using System.Text;
/* Es gibt einen Lagerbestand eines Objekts, bei einer positiven
 * Bestandsveränderung werden die Abonennten des Artikels über
 * den "Neuzugang" dieses Artikels informiert.
 * 
 * Ausgabe des untenstehenden Programs in der Konsole:
 * ***************************************************
    Marcel ist jetzt Beobachter dieses Artikels.
    Marcel beobachtet diesen Artikel bereits.
    Daniel ist jetzt Beobachter dieses Artikels.
    Karl ist jetzt Beobachter dieses Artikels.
    Hallo Marcel, es ist ein neuer Artikel im Lager verfügbar.
    Hallo Daniel, es ist ein neuer Artikel im Lager verfügbar.
    Hallo Karl, es ist ein neuer Artikel im Lager verfügbar.
    Lagerbestand: 1
    Marcel hat sein Abonnement beendet.
    Daniel hat sein Abonnement beendet.
    Hallo Karl, es ist ein neuer Artikel im Lager verfügbar.
    Lagerbestand: 2
    Karl hat sein Abonnement beendet.
    Lagerbestand: 3
 * ***************************************************
 * */
namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Subjekt BeliebterArtikel = new Subjekt();

            /// wir legen ein paar beobachter an
            /// der erste
            Beobachter Marcel = new Beobachter("Marcel");
            BeliebterArtikel.Abonnieren(Marcel);
            // versuch des mehrfachen abos schlägt fehl
            BeliebterArtikel.Abonnieren(Marcel);

            // der zweite
            Beobachter Daniel = new Beobachter("Daniel");
            BeliebterArtikel.Abonnieren(Daniel);

            // der dritte uswusw
            Beobachter Karl = new Beobachter("Karl");
            BeliebterArtikel.Abonnieren(Karl);

            /// wir haben 3 abonnenten,
            /// wir verändern den bestand an cds, ergebnis soll sein,
            /// dass alle abonnenten benachrichtigt werden
            BeliebterArtikel.Lagerbestand++;
            
            Console.ReadKey(); // kurze pause

            // zwei abonnenten beenden ihr abo 
            BeliebterArtikel.DeAbonnieren(Marcel);
            BeliebterArtikel.DeAbonnieren(Daniel);

            // und der bestand verändert sich
            BeliebterArtikel.Lagerbestand++;

            Console.ReadKey(); // kurze pause

            /// der letzte abonnent beendet sein abo, bestand erhöht,
            /// KEINE abonnenten werden benachrichtigt
            BeliebterArtikel.DeAbonnieren(Karl);
            BeliebterArtikel.Lagerbestand++;

            Console.ReadKey(); // kurze pause
        }
    }
}
