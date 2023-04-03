using System;

int shaft = 0;
Head head = Head.puu;
Fletching fletching = Fletching.lehti;
int kohta = 0;
bool done = false;
while (!done)
{
    switch (kohta)
    {
        case 0:
            try
            {
                shaft = Convert.ToInt32(Question("Kuinka pitkä varsi? (60-100)"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Annathan vain kokonaisia numeroita");
                goto case 0;
            }
            if (59 > shaft || 101 < shaft) { Console.WriteLine("Annathan vain sallitun koon"); goto case 0; }
            kohta++; break;
        case 1:
            try
            {
                head = Enum.Parse<Head>(Question("Minkälaisen kärjen haluat? (puu, teräs vai timantti)"), true);
            }
            catch
            {
                Console.WriteLine("Annathan vain yhden vaihtoehdoista");
                goto case 1;
            }
            kohta++; break;
        case 2:
            try
            {
                fletching = Enum.Parse<Fletching>(Question("Minkälaisen sulan haluat? (lehti, kanansulka vai kotkansulka)"));
            }
            catch
            {
                Console.WriteLine("Annathan vain yhden vaihtoehdoista");
                goto case 2;
            }
            kohta++; break;
        default: done = true; break;

    }
}


Nuoli nuoli = new Nuoli(shaft, head, fletching);

Console.Write($"Tämä nuoli maksaa {nuoli.Hinta()} kultakolikkoa");

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


}

internal enum Head { puu, teräs, timantti };
internal enum Fletching { lehti, kanansulka, kotkansulka };