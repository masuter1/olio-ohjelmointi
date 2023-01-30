using System;

namespace t1_ovi
{
    class Program
    {
        public static void NoCanDo()
        {
            Console.WriteLine("Et voi tehdä tuota tai en ymmärtänyt. ");
        }
        enum Ovi { Auki, Sulki, Lukittu };
        static void Main(string[] args)
        {

            Ovi ovi = Ovi.Auki;
            string komento;
            while (true)
            {
                switch (ovi)
                {
                    case Ovi.Auki:
                        Console.Write("Ovi on auki. Mitä haluat tehdä? ");
                        komento = Console.ReadLine();
                        if (komento.ToLower() == "sulje")
                        {
                            ovi = Ovi.Sulki;
                            break;
                        }
                        else
                        {
                            NoCanDo();
                            break;
                        }
                    case Ovi.Sulki:
                        Console.Write("Ovi on sulki. Mitä haluat tehdä? ");
                        komento = Console.ReadLine();
                        if (komento.ToLower() == "avaa")
                        {
                            ovi = Ovi.Auki;
                            break;
                        }
                        else if (komento.ToLower() == "lukitse")
                        {
                            ovi = Ovi.Lukittu;
                            break;
                        }
                        else
                        {
                            NoCanDo();
                            break;
                        }
                    case Ovi.Lukittu:
                        Console.Write("Ovi on lukittu. Mitä haluat tehdä? ");
                        komento = Console.ReadLine();
                        if (komento.ToLower() == "poista lukitus")
                        {
                            ovi = Ovi.Sulki;
                            break;
                        }
                        else
                        {
                            NoCanDo();
                            break;
                        }

                }
            }
        }
    }
}