using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manhattan.Classes
{
    public class RootData
    {
        public string type { get; set; }
        public List<FeatureClass> features { get; set; }

        
    }
}
