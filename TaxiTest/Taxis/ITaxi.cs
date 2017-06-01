using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface ITaxi
{
    float StartPrice { get; set; }

    float PricePerKm { get; set; }

    int Capacity { get; set; }

    float CalculatePrice(float km);


}
