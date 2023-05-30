namespace Polybius_Verfahren
{
    public class PolybiusService : IAlgorithmService{
        private readonly IDataInput dataInput;
        private String key;
        private bool isKeySet;
        private String text;
        private bool isTextSet;
        private String alpha = "ABCDEFGHIKLMNOPQRSTUVWXYZ";

        private Char[] encryptionMatrix;
        private List<int> encrytionNumbers;
        private bool endProgram;

        public PolybiusService(IDataInput dataInput)
        {
            this.dataInput = dataInput;
            this.encryptionMatrix = new Char[25];
            this.isKeySet = false;
            this.isTextSet = false;
            this.endProgram = false;
            this.encrytionNumbers = new List<int>();
            
        }

        public void Run()
        {
            do{
            System.Console.WriteLine("[1]Eingabe Schluesselword\n[2]Eingabe Text\n[3]Verschluesseln\n[4]Beenden");
            switch(Console.ReadLine()){
                case "1":
                    this.key = this.dataInput.InputKey();
                    if(!this.isKeySet){
                        this.isKeySet = !this.isKeySet;
                    }
                    break;
                case "2":
                    this.text = this.dataInput.InputText();
                    if(!this.isTextSet){
                        this.isTextSet = !this.isTextSet;
                    }    
                    break;
                case "3":
                    if(!this.isKeySet){
                        System.Console.WriteLine("Schluesselwort nicht gesetzt!");
                    }else if(!this.isTextSet){
                        System.Console.WriteLine("Kein Text zum verschlüsseln vorhanden.");
                    }else{
                        SetLetterArray();
                        EncryptInput();
                        PrintEncryptionNumbers();
                    }
                    break;

                case "4":
                    this.endProgram = !this.endProgram;
                    break;
                default:
                    System.Console.WriteLine("Ungültige Eingabe");        
                    break;
            }

            }while(!this.endProgram);
        }

        private void SetLetterArray(){
            String keyAndAlphabet = key + alpha;
            this.encryptionMatrix = keyAndAlphabet.ToCharArray().Distinct().ToArray();
        }

        private void EncryptInput(){
            String textToUpper = this.text.ToUpper();
            encrytionNumbers.Clear();
            foreach (var letter in textToUpper)
            {
                for(int i = 0; i < this.encryptionMatrix.Count(); i++){
                    if(letter.Equals(this.encryptionMatrix[i])){
                        this.encrytionNumbers.Add(i);
                        break;
                    }
                }
            }
        }

        private void PrintEncryptionNumbers(){
            System.Console.WriteLine("Text:" + this.text);
            System.Console.WriteLine("Key:" + this.key);
            foreach (var number in encrytionNumbers)
            {
                System.Console.Write(number + " ");
            }
            System.Console.WriteLine();
        }
    }
}