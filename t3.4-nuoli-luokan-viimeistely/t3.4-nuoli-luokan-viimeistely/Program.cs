using System;
using System.Runtime.CompilerServices;

int shaft = 0;
Head head = Head.puu;
Fletching fletching = Fletching.lehti;
NuolenTyyppi nuolenTyyppi = NuolenTyyppi.aloittelija;
int kohta = 0;
bool done = false;


while (!done)
{
    switch (kohta)
    {
        case 0:
            Nuoli eliittiNuoli = Nuoli.CreateEliteArrow();
            Nuoli perusNuoli = Nuoli.CreateBasicArrow();
            Nuoli aloittelijaNuoli = Nuoli.CreateBeginnerArrow();
            string arrowTypeQuestion = $"Minkä nuolen haluat vai haluatko tehdä nuolen itse?\nVaihtoehdot:\n{HintaString(eliittiNuoli)}, Kirjoita \"eliitti\"\n{HintaString(perusNuoli)}, Kirjoita \"perus\"\n{HintaString(aloittelijaNuoli)}, Kirjoita \"aloittelija\"\nVoit myös tehdä oman nuolen kirjoittamalla \"kustomoitu\"";
            try
            {
                nuolenTyyppi = Enum.Parse<NuolenTyyppi>(Question(arrowTypeQuestion), true);
                switch (nuolenTyyppi)
                {
                    case NuolenTyyppi.eliitti:
                        Console.WriteLine("Valitsit eliittinuolen");
                        kohta = 4; break;
                    case NuolenTyyppi.perus:
                        Console.WriteLine("Valitsit perusnuolen");
                        kohta = 4; break;
                    case NuolenTyyppi.aloittelija:
                        Console.WriteLine("Valitsit aloittelijanuolen");
                        kohta = 4; break;
                    case NuolenTyyppi.kustomoitu:
                        Console.WriteLine("Valitsit kustomoidun nuolen. Jatketaan...");
                        kohta = 1; break;
                }
            }
            catch
            {
                Console.WriteLine("Valitsethan nuolen tyypin kirjoittamalla joko \"eliitti\", \"perus\", \"aloittelija\" tai \"kustomoitu\".");
                goto case 0;
            }
            break;

        case 1:
            try
            {
                shaft = Convert.ToInt32(Question("Kuinka pitkä varsi? (60-100)"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Annathan vain kokonaisia numeroita");
                goto case 1;
            }
            if (59 > shaft || 101 < shaft) { Console.WriteLine("Annathan vain sallitun koon"); goto case 0; }
            kohta++; break;
        case 2:
            try
            {
                head = Enum.Parse<Head>(Question("Minkälaisen kärjen haluat? (puu, teräs vai timantti)"), true);
            }
            catch
            {
                Console.WriteLine("Annathan vain yhden vaihtoehdoista");
                goto case 2;
            }
            kohta++; break;
        case 3:
            try
            {
                fletching = Enum.Parse<Fletching>(Question("Minkälaisen sulan haluat? (lehti, kanansulka vai kotkansulka)"));
            }
            catch
            {
                Console.WriteLine("Annathan vain yhden vaihtoehdoista");
                goto case 3;
                
            }
            Nuoli nuoli = new Nuoli(shaft, head, fletching, "Kustomoitu Nuoli");
            HintaString(nuoli);
            kohta++; break;
        default: done = true; break;
    }
}


string HintaString(Nuoli nuoli)
{
    return $"Nimi: {nuoli.Name}, Kärki: {nuoli.Head}, Sulka: {nuoli.Fletching}, Pituus: {nuoli.Shaft}, Hinta: {nuoli.Hinta()} kultakolikkoa";
}


string Question(string question)
{
    Console.WriteLine(question); return Console.ReadLine();
}

class Nuoli
{
    public Head Head { get; set; }
    public Fletching Fletching { get; set; }
    public int Shaft { get; set; }
    public string Name { get; set; }
    public Nuoli(int shaft, Head head, Fletching fletching, string name)
    {
        Shaft = shaft;
        Head = head;
        Fletching = fletching;
        Name = name;
    }
    public double Hinta()
    {
        double hinta = 0;
        switch (Head)
        {
            case Head.timantti: hinta += 50; break;
            case Head.teräs: hinta += 5; break;
            case Head.puu: hinta += 3; break;
            default: hinta += 0; break;
        }
        switch (Fletching)
        {
            case Fletching.lehti: hinta += 0; break;
            case Fletching.kanansulka: hinta += 1; break;
            case Fletching.kotkansulka: hinta += 5; break;
            default: hinta += 0; break;
        }
        hinta += Shaft * 0.05;
        return hinta;
    }
    public static Nuoli CreateEliteArrow()
    {
        return new Nuoli(100, Head.timantti, Fletching.kotkansulka, "Eliittinuoli");
    }
    public static Nuoli CreateBasicArrow()
    {
        return new Nuoli(85, Head.teräs, Fletching.kanansulka, "Perusnuoli");
    }
    public static Nuoli CreateBeginnerArrow()
    {
        return new Nuoli(70, Head.puu, Fletching.kanansulka, "Aloittelijanuoli");
    }

}

internal enum Head { puu, teräs, timantti };
internal enum Fletching { lehti, kanansulka, kotkansulka };
internal enum NuolenTyyppi { eliitti, perus, aloittelija, kustomoitu };