namespace Polybius_Verfahren
{
    public class DataInput : IDataInput
    {

        //lässt einen das Schluesselwort definieren. Dieses darf keine Zahlen beinhalten und die Länge muss größer als 0 sein
        public string InputKey()
        {
            String key = "";
            bool validInput;
            do{
                System.Console.WriteLine("Bitte das Schluesselwort eingeben:");
                key = Console.ReadLine();
                validInput = key.All(Char.IsLetter) && key.Count() > 0;
                if(validInput){
                    System.Console.WriteLine("Schluesselwort akzeptiert!");
                }else{
                    System.Console.WriteLine("Ungueltiges Schluesselwort!");
                }
            }while(!validInput);

            return key;
        }

        //lässt einen den zu verschluesselnden Text definieren. Dieser darf keine Zahlen beinhalten und die Länge muss größer als 0 sein
        public string InputText()
        {
            String text = "";
            bool validInput;
            do{
                System.Console.WriteLine("Bitte den zu verschluesselnden Text eingeben:");
                text = Console.ReadLine();
                validInput = text.All(Char.IsLetter) && text.Count() > 0;
                if(validInput){
                    System.Console.WriteLine("Text akzeptiert!");
                }else{
                    System.Console.WriteLine("Ungueltiger Text!");
                }
                
            }while(!validInput);

            return text;
        }
    }
}