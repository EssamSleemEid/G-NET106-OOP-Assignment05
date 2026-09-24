using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET106_OOP_Assignment05
{
    public static class ShipmentExtensions
    {
        public static string GetSummary(this Shipment shipment)
        {
            string shipmentType=shipment.GetType().Name;

            return "tracking code : " + shipment.TrackingCode + " - " + "shipment type : " + shipmentType + " - " + "the wight : " + shipment.Weight + " KG " + " - " + "status : " + shipment.GetTrackingStatus();
        }
        public static bool IsDelivered(this Shipment shipment)
        {
            return shipment.GetTrackingStatus() == "Delivered"; ;
        }
    }
}
