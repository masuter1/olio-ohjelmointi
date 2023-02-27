using System;

class Nuoli
{
    private Head _head;
    private Fletching _fletching;
    private int _shaft;
    public Nuoli(int shaft, Head head, Fletching fletching)
    {
        _shaft = shaft;
        _head = head;
        _fletching = fletching;
    }
    public double Hinta()
    {
        double hinta = 0;
        switch (_head)
        {
            case Head.timantti: hinta += 50; break;
            case Head.teräs: hinta += 5; break;
            case Head.puu: hinta += 3; break;
            default: hinta += 0; break;
        }
        switch (_fletching)
        {
            case Fletching.lehti: hinta += 0; break;
            case Fletching.kanansulka: hinta += 1; break;
            case Fletching.kotkansulka: hinta += 5; break;
            default: hinta += 0; break;
        }
        hinta += _shaft * 0.05;
        return hinta;
    }
}
internal enum Head { puu, teräs, timantti };
internal enum Fletching { lehti, kanansulka, kotkansulka };