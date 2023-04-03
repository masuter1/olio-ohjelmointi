using System;

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
            try
            {
                nuolenTyyppi = Enum.Parse<NuolenTyyppi>(Question($""), true);
                switch (NuolenTyyppi)
                {
                    case NuolenTyyppi.eliitti:
                        Nuoli.CreateEliteArrow() // tee tämä
                }
            }

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
            kohta++; break;
        default: done = true; break;

    }
}


Nuoli nuoli = new Nuoli(shaft, head, fletching);

Console.Write($"Tämä nuoli maksaa {nuoli.Hinta()} kultakolikkoa\nNuolen pää: {nuoli.Head}, Nuolen Sulka: {nuoli.Fletching}, Nuolen pituus: {nuoli.Shaft}");

string Question(string question)
{
    Console.WriteLine(question); return Console.ReadLine();
}

class Nuoli
{
    public Head Head { get; set; }
    public Fletching Fletching { get; set; }
    public int Shaft { get; set; }
    public Nuoli(int shaft, Head head, Fletching fletching)
    {
        Shaft = shaft;
        Head = head;
        Fletching = fletching;
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
        return new Nuoli(100, Head.timantti, Fletching.kotkansulka);
    }
    public static Nuoli CreateBasicArrow()
    {
        return new Nuoli(85, Head.teräs, Fletching.kanansulka);
    }
    public static Nuoli CreateBeginnerArrow()
    {
        return new Nuoli(70, Head.puu, Fletching.kanansulka);
    }

}

internal enum Head { puu, teräs, timantti };
internal enum Fletching { lehti, kanansulka, kotkansulka };
internal enum NuolenTyyppi { eliitti, perus, aloittelija };