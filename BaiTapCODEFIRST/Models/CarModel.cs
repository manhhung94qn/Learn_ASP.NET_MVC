
using System.Collections.Generic;

namespace BaiTapCODEFIRST.Models
{
    public class CarModel
    {
        public int CarID { get; set; }

        public string CarType { get; set; }

        public int CarPrice { get; set; }

        public string CarColor { get; set; }


        public List<CarModel> Listcar { get; set; } // List of Car

    }

}