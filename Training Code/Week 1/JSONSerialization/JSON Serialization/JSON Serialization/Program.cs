using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json; //1. DataContractJsonSerializer class is found
namespace JSON_Serialization
{
    /* Must attach [DataContract] attribute for an Object that is being serialized/deserialized */
    [DataContract] // Define Data Contract
    public class User
    {
        /* Define Data Members in Object that you want to serialize */
        [DataMember]
        public string Name { get; set; }
        [DataMember] // can define data members with properties
        public int Age { get; set; }
        [DataMember] // define data members without properties
        public int id;
        [DataMember]
        public int[] myArr= new int[5] { 1, 2, 3, 4, 5 };
        [DataMember]
        public string gender; // not defined, can not be serialized
        public User(string name, int age, int id, string gender)
        {
            Name = name;
            Age = age;
            this.id = id;
            this.gender = gender;
        }
        static void Main(string[] args)
        {
            User user = new User("Bob", 37, 3, "M"); // User object to be serialized
            MemoryStream ms = new MemoryStream();
            try
            { 
                // Instantiate DataContractJsonSerializer that will serialize User types to JSON
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(User));
                // Uses WriteObject method to serialize the user data members to the stream
                ser.WriteObject(ms, user);
                ms.Position = 0; // sets position of memory stream
                StreamReader sr = new StreamReader(ms);
                Console.WriteLine("JSON form of User object: " + sr.ReadToEnd());
                ms.Position = 0;  // sets position of memory stream back to start
                User user2 = (User)ser.ReadObject(ms); // Deserializes JSON data to a User Object
                Console.WriteLine("Name = {0}, Age = {1}, ID = {2}, Scores = {3}, Gender = {4}", user2.Name, user2.Age, user2.id, 
                    user2.myArr[2], user2.gender); // Data members retrieved via Deserialization
                sr.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
            Console.Read();
        }
    }
}
