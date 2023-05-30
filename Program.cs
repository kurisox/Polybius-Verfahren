namespace Polybius_Verfahren
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PolybiusService polybiusService = new PolybiusService(new DataInput());
            polybiusService.Run();
        }
    }
}