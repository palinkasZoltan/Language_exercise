using Language_exercise.DL;

namespace Language_exercise.Con
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataConnection dataConnection = new DataConnection();
            List<string> list = dataConnection.ReadSingleFile("temp_file.txt").ToList();
            Console.WriteLine(list.FirstOrDefault());
        }
    }
}
