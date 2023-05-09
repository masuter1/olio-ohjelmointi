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
    public Arrow() : base(0.1, 0.05, "nuoli") { }
}
public class Bow : Item
{
    public Bow() : base(1.0, 4.0, "jousi") { }
}
public class Rope : Item
{
    public Rope() : base(1.0, 1.5, "köysi") { }
}
public class Water : Item
{
    public Water() : base(2.0, 2.0, "vesi") { }
}
public class Meal : Item
{
    public Meal() : base(1.0, 0.5, "ruoka-annos") { }
}
public class Sword : Item
{
    public Sword() : base(5.0, 3.0, "miekka") { }
}

public class Backpack
{
    private int _bpMaxItems = 10;
    private double _bpMaxSize = 20;
    private double _bpMaxWeight = 30;
    private Item[] _items;
    public Backpack(int bpMaxItems, double bpMaxSize, double bpMaxWeight, Item[] items)
    {
        this._bpMaxItems = bpMaxItems;
        this._bpMaxSize = bpMaxSize;
        this._bpMaxWeight = bpMaxWeight;
        this._items = items;
    }
    public bool AddItems(Item item)
    {
        int itemCount = _items.Length;
        double currentSize;
        double currentWeight;
        if (itemCount >= _bpMaxItems + 1) { return false; }

        foreach (Item storedItem in _items)
        {
            storedItem.AnnaKoko();
        }
    }

}

