using System;

using System.Collections.Generic;

using System.Linq;

using System.Web;

using System.Web.Mvc;

using BaiTapCODEFIRST.Models;

namespace BaiTapCODEFIRST.Controllers

{

    public class CarController : Controller

    {

        public ActionResult Index()

        {

            CarModel objcar = new CarModel();

            objcar.CarID = 1;

            objcar.CarColor = "Brown";

            objcar.CarPrice = 20000;

            objcar.CarType = "sporty";



            List<CarModel> objlistcar = new List<CarModel>();

            objlistcar.Add(objcar);  // add item in list

            objcar.Listcar = objlistcar; // assigning value to CarModel object

            return View(objcar); // Returning model

        }

    }

}