using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace G_NET106_OOP_Assignment05
{
    public class DeliveryAddress
    {
        public string City;
        public string Street;
        public int BuldingNumber;
        public DeliveryAddress(string city, string street, int buldingNumber)
        {
            City = city;
            Street = street;
            BuldingNumber = buldingNumber;
        }
        public string GetFullAddress()
        {
            return $"bulding number : {BuldingNumber}, street : {Street}, city : {City}";
        }
    }
    public interface ITrackable
    {
        string GetTrackingStatus();
    }
    public interface IInsurable
    {
        decimal CalculateInsurance();
    }

    public abstract partial class Shipment : ITrackable, IInsurable
    {
        private string description;
        private decimal weight;
        private decimal deliveryFee;
        private string trackingCode;
        public DeliveryAddress Destination { get; set; }
        public string TrackingCode
        {
            get { return trackingCode; }
        }
        public string Description
        {
            get { return description; }

            set
            {
                if (value != null)
                {
                    description = value;
                }
            }
        }
        public decimal Weight
        {
            get { return weight; }

            set
            {
                if (value > 0)
                {
                    weight = value;
                }
            }
        }
        public decimal DeliveryFee
        {
            get { return deliveryFee; }

            set
            {

                if (value > 0)
                {
                    deliveryFee = value;
                }
            }
        }
        public abstract decimal EstimatedCost
        {
            get;
        }

        public abstract void PrintShipment();

        public abstract decimal CalculateInsurance();

        public static int TotalShipmentsCreated;

        static Shipment()
        {
            TotalShipmentsCreated = 0;
            Console.WriteLine("Shipment System Initialized");
        }

        public Shipment(string trackingCode)
        {
            this.trackingCode = trackingCode == null ? "unknown" : trackingCode;

            description = "unknown";
            weight = 1;
            deliveryFee = 50;
            Destination = new DeliveryAddress("Cairo", "Unknown Street", 0);
            TotalShipmentsCreated++;
        }
        public Shipment(string trackingCode, string description, decimal weight, decimal deliveryFee, DeliveryAddress destination)
        {
            this.trackingCode = trackingCode == null ? "Unknown" : trackingCode;
            this.description = description == null ? "Unknown" : description;
            this.weight = weight > 0 ? weight : 1;
            this.deliveryFee = deliveryFee > 0 ? deliveryFee : 50;
            Destination = destination;
            TotalShipmentsCreated++;
        }
        public static int GetTotalShipmentsCreated()
        {
            return TotalShipmentsCreated;
        }

        public void UpdateDeliveryFee(decimal newFee)
        {
            if (newFee > 0)
            {
                deliveryFee = newFee;
            }
        }
        public void UpdateWeight(decimal newWeight)
        {
            if (newWeight > 0)
            {
                Weight = newWeight;
            }
        }
        public void UpdateWeight(decimal newWeight, decimal packingWeight)
        {
            if (newWeight > 0 && packingWeight >= 0)
            {
                Weight = newWeight + packingWeight;
            }
        }
        public Shipment CopyShipment()
        {
            return (Shipment)MemberwiseClone();
        }

        public Shipment ShallowCopy()
        {
            return (Shipment)MemberwiseClone();
        }
        public Shipment DeepCopy()
        {
            Shipment copy = (Shipment)MemberwiseClone();

            copy.Destination =new DeliveryAddress(Destination.City,Destination.Street,Destination.BuldingNumber);

            return copy;
        }

        partial void OnTrackingStatusChanged(string newStatus);
    }
}
