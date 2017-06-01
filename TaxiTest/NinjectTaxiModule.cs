using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NinjectTaxiModule : Ninject.Modules.NinjectModule
{
    public override void Load()
    {
        Bind<ITaxi>().To<TaxiCab>();
        Bind<ITaxi>().To<TaxiBus>();
    }
}
