using System;

public class Item
{
    protected double _weight;
    protected double _size;
    protected string _name;

    public Item(double weight, double size, string name)
    {
        this._weight = weight;
        this._size = size;
        this._name = name;
    }
    // Haut
    public double AnnaPaino()
    {
        return _weight;
    }
    public double AnnaKoko()
    {
        return _size;
    }
    public string AnnaNimi()
    {
        return _name;
    }
    // Asetukset
    public void AsetaPaino(double weight)
    {
        _weight = weight;
    }
    public void AsetaKoko(double size)
    {
        _size = size;
    }
    public void AsetaNimi(string name)
    {
        _name = name;
    }
    // Printtaukset
    public virtual string ItemInfo()
    {
        string tiedot = $"{_name} - Paino: {_weight} Koko: {_size}";
        return tiedot;
    }
}

public class Arrow : Item
{
    // tee tavara luokat
}