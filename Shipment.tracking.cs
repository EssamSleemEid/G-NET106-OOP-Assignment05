using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G_NET106_OOP_Assignment05
{
    public abstract partial class Shipment
    {
        private string trackingStatus = "in transit";

        public string GetTrackingStatus()
        {
            return trackingStatus;
        }

        public void UpdateTrackingStatus(string newStatus)
        {
            trackingStatus=newStatus;
            OnTrackingStatusChanged(newStatus);
        }
        partial void OnTrackingStatusChanged(string newStatus)
        {
            Console.WriteLine("Tracking status now : " + newStatus);
        }
    }
}
