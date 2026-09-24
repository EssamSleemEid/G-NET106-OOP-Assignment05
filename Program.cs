namespace G_NET106_OOP_Assignment05
{
    internal class Program
    {
        public static class DeliveryUtilities
        {
            public static void PrintSeparator()
            {
                Console.WriteLine("==========================================");
            }

            public static void PrintSystemTitle()
            {
                PrintSeparator();
                Console.WriteLine("North sinai Delivery System");
                PrintSeparator();
            }
        }

        public class StandardShipment : Shipment
        {
            public StandardShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress Destination) : base(trackingCode, description, weight, deliveryFee, Destination)
            {

            }
            public override decimal EstimatedCost
            {
                get
                {
                    return DeliveryFee + (decimal)(Weight * 5);
                }
            }

            public override void PrintShipment()
            {
                Console.WriteLine("Standard Shipment");
                Console.WriteLine("Tracking Code : " + TrackingCode);
                Console.WriteLine("Description : " + Description);
                Console.WriteLine("Weight : " + Weight + " kg");
                Console.WriteLine("Delivery Fee : " + DeliveryFee + " EGP");
                Console.WriteLine("Destination : " + Destination.GetFullAddress());
                Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
            }

            public override decimal CalculateInsurance()
            {
                return EstimatedCost * 0.05m;
            }
        }

        public class ExpressShipment : Shipment
        {
            private decimal ExtraFee;

            public decimal extrafee
            {
                get { return ExtraFee; }

                set
                {
                    if (value >= 0)
                    {
                        ExtraFee = value;
                    }
                }
            }

            public override decimal EstimatedCost
            {
                get { return DeliveryFee + (decimal)(Weight * 5) + ExtraFee; }
            }

            public ExpressShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress Destination, decimal ExtraFee) : base(trackingCode, description, weight, deliveryFee, Destination)
            {
                extrafee = ExtraFee;
            }
            public override void PrintShipment()
            {
                Console.WriteLine("Express Shipment");
                Console.WriteLine("Tracking Code : " + TrackingCode);
                Console.WriteLine("Description : " + Description);
                Console.WriteLine("Weight : " + Weight + " kg");
                Console.WriteLine("Delivery Fee : " + DeliveryFee + " EGP");
                Console.WriteLine("Extra Fee : " + ExtraFee + " EGP");
                Console.WriteLine("Destination : " + Destination.GetFullAddress());
                Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
            }

            public override decimal CalculateInsurance()
            {
                return EstimatedCost * 0.08m;
            }
        }

        public class InternationalShipment : Shipment
        {
            private string DestinationCountry;
            private decimal CustomerFee;

            public string destinationCountry
            {
                get { return DestinationCountry; }

                set
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        DestinationCountry = value;
                    }
                }
            }

            public decimal customerFee
            {
                get { return CustomerFee; }

                set
                {
                    if (value >= 0)
                    {
                        CustomerFee = value;
                    }
                }
            }

            public override decimal EstimatedCost
            {
                get { return DeliveryFee + (decimal)(Weight * 5) + customerFee; }
            }

            public InternationalShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress Destination, string DestinationCountry, decimal CustomerFee) : base(trackingCode, description, weight, deliveryFee, Destination)
            {
                destinationCountry = DestinationCountry;
                customerFee = CustomerFee;
            }

            public virtual void GenerateCustomsReport()
            {
                Console.WriteLine("Customs Report Generated.");
            }

            public override void PrintShipment()
            {
                Console.WriteLine("International Shipment");
                Console.WriteLine("Tracking Code : " + TrackingCode);
                Console.WriteLine("Description : " + Description);
                Console.WriteLine("Weight : " + Weight + " kg");
                Console.WriteLine("Delivery Fee : " + DeliveryFee + " EGP");
                Console.WriteLine("Destination : " + Destination.GetFullAddress());
                Console.WriteLine("Destination Country : " + DestinationCountry);
                Console.WriteLine("Customs Fee : " + CustomerFee + " EGP");
                Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
            }

            public override decimal CalculateInsurance()
            {
                return EstimatedCost * 0.12m;
            }
        }

        public class PriorityInternationalShipment : InternationalShipment
        {
            public PriorityInternationalShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress Destination, string DestinationCountry, decimal CustomerFee) : base(description, weight, deliveryFee, trackingCode, Destination, DestinationCountry, CustomerFee)
            {

            }
            public override void GenerateCustomsReport()
            {
                Console.WriteLine("Customs Report Generated.");
            }

        }

        public sealed class CompletedShipment : Shipment
        {
            public CompletedShipment(string description, decimal weight, decimal deliveryFee, string trackingCode, DeliveryAddress Destination) : base(trackingCode, description, weight, deliveryFee, Destination)
            {

            }

            public override decimal EstimatedCost
            {
                get
                {
                    return DeliveryFee + (Weight * 5);
                }
            }

            public override void PrintShipment()
            {
                Console.WriteLine("Completed Shipment");
                Console.WriteLine("Tracking Code : " + TrackingCode);
                Console.WriteLine("Description : " + Description);
                Console.WriteLine("Weight : " + Weight + " kg");
                Console.WriteLine("Delivery Fee : " + DeliveryFee + " EGP");
                Console.WriteLine("Destination : " + Destination.GetFullAddress());
                Console.WriteLine("Estimated Cost : " + EstimatedCost + " EGP");
            }

            public override decimal CalculateInsurance()
            {
                return EstimatedCost * 0.05m;
            }
        }

        public class Driver
        {
            public string Name { get; set; }

            public Driver(string name)
            {

                Name = name;
            }
        }

        public static class DeliveryHelper
        {
            public static void PrintShipmentDetails(Shipment shipment)
            {
                shipment.PrintShipment();
            }
        }

        public static class DeliveryReport
        {
            public static void PrintShipment(ITrackable shipment)
            {
                Console.WriteLine(shipment.GetTrackingStatus());
            }

            public static void PrintInsurance(IInsurable shipment)
            {
                Console.WriteLine("insuranceCost : " + shipment.CalculateInsurance() + " EGP");
            }
        }

        public class DeliveryCenter
        {
            public string CenterName { get; set; }
            public Driver Driver { get; set; }
            private Shipment[] shipments;

            public DeliveryCenter(string centerName)
            {
                CenterName = centerName;
                shipments = new Shipment[20];
            }

            public Shipment this[int index]
            {
                get
                {
                    if (index >= 0 && index < shipments.Length)
                        return shipments[index];

                    return default;
                }

                set
                {
                    if (index >= 0 && index < shipments.Length)
                        shipments[index] = value;
                }
            }

            public Shipment this[string trackingCode]
            {
                get
                {
                    for (int i = 0; i < shipments.Length; i++)
                    {
                        if (shipments[i].TrackingCode == trackingCode)
                            return shipments[i];
                    }

                    return default;
                }
            }

            public bool AddShipment(Shipment shipment)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] == null)
                    {
                        shipments[i] = shipment;
                        return true;
                    }
                }

                return false;
            }

            public bool RemoveShipment(string trackingCode)
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null && shipments[i].TrackingCode == trackingCode)
                    {
                        shipments[i] = null;
                        return true;
                    }
                }
                return false;
            }

            public void PrintAllShipments()
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null)
                    {
                        shipments[i].PrintShipment();
                        Console.WriteLine();
                    }
                }
            }

            public void PrintTrackingStatuses()
            {
                for (int i = 0; i < shipments.Length; i++)
                {
                    if (shipments[i] != null)
                    {
                        ITrackable shipment = shipments[i];
                        Console.WriteLine(shipment.GetTrackingStatus());
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            #region Part01
            #region Question01
            //a) What happens when you assign one object variable to another object variable?

            //both virable is refer to the same object

            //b) Does assigning one object to another create a new object? Explain.

            //no it does not the both virables reference to the same object

            //c) What is the difference between copying an object and copying its reference?

            /*
             copy the reference mean two virable refer to the same object

             copy the object is creating a new separate object
            */
            #endregion

            #region Question02
            //a) What is a Shallow Copy?

            //it mean create a new object but the reference type member inside it is still refer to the same object as the original

            //b) What is a Deep Copy?

            //it mean create a new object and also create independent copies of it reference type members

            //c) What happens to reference-type members when a Shallow Copy is created?

            //the original and the copied objects refer to the same referenced objects

            //d) What happens to reference-type members when a Deep Copy is created?

            //the original and the copied objects have independent references

            //e) Give one situation where Deep Copy would be safer than Shallow Copy.

            //when changing a copied objects reference type data must not affect the original object
            #endregion

            #region Question03
            //a) What is a static field, and how is it different from an instance field?

            /*
             the static field belong to the class itself and its shared by all objects

             the instance feild belong to each individual object
            */

            //b) What is a static method? Can a static method directly access instance members?

            //belong to the class and can be called without creating object and no it can not directly access the instance members

            //c) What is a static constructor, and when is it executed?

            //intializes a static members and its executed automatically once before the first use of the class

            //d) What is a static class? Can you create an object from a static class?

            //contain only static members and we can not create object from it 
            #endregion

            #region Question04
            //a) What is an Extension Method?

            //its a method allow you to add functionality to existing type without modifying the original class

            //b) What keyword must be used in the first parameter of an extension method?

            // the keywork : this

            //c) Where must an extension method be declared?

            //it must declare inside a static class

            //d) Can an extension method access private members of the class it extends?

            //no it can not access private members directly
            #endregion

            #region Question05
            //a) What is a Partial Class?

            //allow  one class to be divided into multiple files

            //b) Why would a developer split one class into multiple files?

            //to organize the lage class and separate its functionality into different files

            //c) What is a Partial Method?

            //is a method declared in one part of partial class and implemented in another part of the same class 

            //d) What happens if a declared partial method has no implementation?

            //the declaration and calls of that method are removed by the compiler
            #endregion
            #endregion

            #region Part02
            DeliveryUtilities.PrintSystemTitle();

            Driver driver01 = new Driver("essam");

            DeliveryCenter center01 = new DeliveryCenter("sinai delevery center");

            center01.Driver = driver01;


            DeliveryAddress address01 = new DeliveryAddress("north sinai", "el masaeed", 1);

            DeliveryAddress address02 = new DeliveryAddress("north sinai", "el dahia", 2);

            DeliveryAddress address03 = new DeliveryAddress("north sinai", "el reisa", 3);

            StandardShipment standardShipment01 = new StandardShipment("samsung A34 phone ", 1.2m, 55, "A034", address01);

            center01.AddShipment(standardShipment01);

            ExpressShipment expressShipment01 = new ExpressShipment("laptop dell presession5570 ", 5, 120, "L507", address02, 20);

            center01.AddShipment(expressShipment01);

            InternationalShipment internationalShipment01 = new InternationalShipment("huawei smart watch Gt2", 0.4m, 200, "HG02", address03, "Egypt", 50);

            center01.AddShipment(internationalShipment01);

            center01.PrintAllShipments();

            center01.PrintTrackingStatuses();

            Console.WriteLine("total shipments : " + Shipment.GetTotalShipmentsCreated());

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("object copying");

            Shipment shipment01 = standardShipment01;
            Shipment shipment02 = shipment01;

            Console.WriteLine("original : " + shipment01.TrackingCode);

            Console.WriteLine("assigned : " + shipment02.TrackingCode);

            Console.WriteLine("make sure they are same : " + object.ReferenceEquals(shipment01, shipment02));

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Shallow Copy");

            Shipment shallowCopy = shipment01.ShallowCopy();

            Console.WriteLine("original address : " + shipment01.Destination.City);

            Console.WriteLine("copied address : " + shallowCopy.Destination.City);

            Console.WriteLine("changing the city ");

            shallowCopy.Destination.City = "raffah";

            Console.WriteLine("original address after rename : " + shipment01.Destination.City);

            Console.WriteLine("copied address after rename : " + shallowCopy.Destination.City);

            Console.WriteLine("make sure they become the same : " +object.ReferenceEquals(shipment01.Destination,shallowCopy.Destination));

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Deep Copy");

            shipment01.Destination.City = "Cairo";

            Shipment deepCopy = shipment01.DeepCopy();

            Console.WriteLine("original address : " +shipment01.Destination.City);

            Console.WriteLine("copied address : " +deepCopy.Destination.City);

            Console.WriteLine("changing copied address ");

            deepCopy.Destination.City = "arish";

            Console.WriteLine("original address : " +shipment01.Destination.City);

            Console.WriteLine("copied address : " +deepCopy.Destination.City);

            Console.WriteLine("make sure if they have the Same DeliveryAddress : " +object.ReferenceEquals(shipment01.Destination,deepCopy.Destination));

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Extension Methods");

            Console.WriteLine(standardShipment01.GetSummary());

            Console.WriteLine(expressShipment01.GetSummary());

            Console.WriteLine(internationalShipment01.GetSummary());


            Console.WriteLine("A034 is Delivered : " + standardShipment01.IsDelivered());

            Console.WriteLine("HG02 is Delivered : " + internationalShipment01.IsDelivered());

            DeliveryUtilities.PrintSeparator();

            Console.WriteLine("Tracking Status");

            standardShipment01.UpdateTrackingStatus("Out For Delivery");

            internationalShipment01.UpdateTrackingStatus("Delivered");

            #endregion
        }
    }
}
