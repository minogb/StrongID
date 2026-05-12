using StrongID;

namespace TestApp {
    internal class Program {
        static void Main(string[] args) {
            GenericID<Program, int> value = new GenericID<Program, int>(1);
            GenericID<Program, int> value2 = new GenericID<Program, int>(1);
            GenericID<FileInfo, int> value3 = new GenericID<FileInfo, int>(1);

            ID<Program> valu4= new ID<Program>(1);

            List<GenericID<Program, int>> List = new();
            List.Add(value);
            List.Add(value2);
            //List.Add(value3);


            List<IID<int>> IDList = new();
            IDList.Add(value);
            IDList.Add(value2);
            IDList.Add(value3); 
            Console.WriteLine(value.CompareTo(value2) == 0 ? "equal" : "not equal");
            Console.WriteLine(value.Equals(value2) ? "equal" :"not equal");
            Console.WriteLine(value == value2 ? "equal" : "not equal");
            Console.WriteLine(value == valu4 ? "equal" : "not equal");
            Console.WriteLine(value);
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine(value.Equals(1) ? "equal" : "not equal");
            Console.WriteLine(value.Equals(value3) ? "equal" : "not equal");
            List.Sort();

        }
    }
}
