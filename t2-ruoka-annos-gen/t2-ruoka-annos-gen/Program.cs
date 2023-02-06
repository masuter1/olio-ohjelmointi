using System;
using System.Linq;

(string paa, string lisuke, string kastike) ruoka;
(string annos1, string annos2, string annos3) annokset = ("place", "place", "place");
int kohta = 1;
int annos = 1;
Console.WriteLine("Luodaan kolme annosta");
while (true)
{
    if (annos == 4) { break; }
    switch (kohta)
    {
        case 1:
            Console.Write("Pääraaka-aine (nautaa, kanaa, kasviksia): ");
            ruoka.paa = Console.ReadLine();
            if (ruoka.paa.ToLower() == "nautaa" || ruoka.paa.ToLower() == "kanaa" || ruoka.paa.ToLower() == "kasviksia")
            {
                switch (annos)
                {
                    case 1:
                        annokset.annos1 = ruoka.paa;
                        break;
                    case 2:
                        annokset.annos2 = ruoka.paa;
                        break;
                    case 3:
                        annokset.annos3 = ruoka.paa;
                        break;
                }
                kohta++;
                break;
            }
            else { break; }
        case 2:
            Console.Write("Lisukkeet (perunaa, riisiä, pastaa): ");
            ruoka.lisuke = Console.ReadLine();
            if (ruoka.lisuke.ToLower() == "perunaa" || ruoka.lisuke.ToLower() == "riisiä" || ruoka.lisuke.ToLower() == "pastaa")
            {
                switch (annos)
                {
                    case 1:
                        annokset.annos1 = annokset.annos1 + " ja " + ruoka.lisuke + " ";
                        break;
                    case 2:
                        annokset.annos2 = annokset.annos2 + " ja " + ruoka.lisuke + " ";
                        break;
                    case 3:
                        annokset.annos3 = annokset.annos3 + " ja " + ruoka.lisuke + " ";
                        break;
                }
                kohta++;
                break;
            }
            else { break; }
        case 3:
            Console.Write("Kastike (pippuri, chili, tomaatti, curry): ");
            ruoka.kastike = Console.ReadLine();
            if (ruoka.kastike.ToLower() == "pippuri" || ruoka.kastike.ToLower() == "chili" || ruoka.kastike.ToLower() == "tomaatti" || ruoka.kastike.ToLower() == "curry")
            {
                switch (annos)
                {
                    case 1:
                        annokset.annos1 = annokset.annos1 + ruoka.kastike + "-kastikkeella";
                        annos++;
                        break;
                    case 2:
                        annokset.annos2 = annokset.annos2 + ruoka.kastike + "-kastikkeella";
                        annos++;
                        break;
                    case 3:
                        annokset.annos3 = annokset.annos3 + ruoka.kastike + "-kastikkeella";
                        annos++;
                        break;
                }
                kohta = 1;
                break;
            }
            else { break; }
    }
}
Console.WriteLine($"{annokset.annos1}, {annokset.annos2}, {annokset.annos3}");