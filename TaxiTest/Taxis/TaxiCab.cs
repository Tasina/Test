using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaxiCab : ITaxi
{
    public TaxiCab()
    {
        StartPrice = 100;
        PricePerKm = 10;
        Capacity = 4;
    }

    public int Capacity { get; set; }

    public float StartPrice { get; set; }

    public float PricePerKm { get; set; }

    public float CalculatePrice(float km)
    {
        return StartPrice + (km * PricePerKm);
    }

}
