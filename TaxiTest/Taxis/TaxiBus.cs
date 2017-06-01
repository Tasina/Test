using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaxiBus : ITaxi
{
    public TaxiBus()
    {
        StartPrice = 200;
        PricePerKm = 10;
        Capacity = 8;
    }

    public int Capacity { get; set; }

    public float StartPrice { get; set; }

    public float PricePerKm { get; set; }

    public float CalculatePrice(float km)
    {
        return StartPrice + (km * PricePerKm);
    }
}

