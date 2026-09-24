namespace G_NET106_OOP_Assignment05
{
    internal class Program
    {
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
            #endregion
            #endregion
        }
    }
}
