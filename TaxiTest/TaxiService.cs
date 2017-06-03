using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class TaxiService
{
    public TaxiService(ITaxi cab, ITaxi bus)
    {
        Cab = cab;
        Bus = bus;
    }

    public ITaxi Cab { get; set; }
    public ITaxi Bus { get; set; }

    private float kmDiscountThreshold = 50;
    private float capacityDiscountThreshold = 9;

    public float CalculateTotalPrice(float km, int persons) {
        if (persons < 1)
            throw new Exception("No persons");

        float totalPrice = 0;
        int personsLeft = persons;

        do {
            if (personsLeft > Cab.Capacity) {
                totalPrice += Bus.CalculatePrice(km);
                personsLeft -= Math.Min(personsLeft, Bus.Capacity);
            }
            else {
                totalPrice += Cab.CalculatePrice(km);
                personsLeft -= Math.Min(personsLeft, Cab.Capacity);
            }
        } while (personsLeft > 0);
        
        if (km >= kmDiscountThreshold && persons >= capacityDiscountThreshold)
            totalPrice -= totalPrice * 0.1f;

        return totalPrice;
    } 
}


