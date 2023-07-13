using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nautilus.Json;
using Nautilus.Options.Attributes;


namespace AlexejheroYTB.PickupFullCarryalls
{
   

    [Menu("PickupFullCarryalls")]
    public class SMLConfig : ConfigFile
    {
        [Toggle("pfcEnable")]
        public bool pfcEnable = false;

        [Choice("pfcMMB", "Yes", "No", "Only in player inventory")]
        public string pfcMMB;
      
       
    }
}

