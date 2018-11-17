using System;
using System.Text;

namespace VigenereCipher
{
    class Program
    {
        static void Main(string[] args)
        {

            //Info over de Vigenere Encryptie methode: https://www.programmingalgorithms.com/algorithm/vigenere-cipher
            //Python versie: https://gist.github.com/dssstr/aedbb5e9f2185f366c6d6b50fad3e4a4
            //ASCII tabel: https://nl.wikipedia.org/wiki/ASCII_(tekenset) (ASCII 32 t/m ASCII 127 is standaard set.

            Console.WriteLine("Voorbeeld van een implementatie van Vigenere Cypher");
            Console.WriteLine("Maak een keuze voor (1) encryptie of (2) decryptie.");
            int keuze = Console.Read();
            if (keuze == 49)
            {
                Console.WriteLine("Bij encryptie moet je een zin intypen gebruik makend van de standaard ASCII karakters.");
                Console.WriteLine("De key is met alleen hoofdletters.");

                //Hulp variabele voor opslaan invoer
                string userInput = "";

                //Teller voor rij met invoer waarden
                int i = 0;
                //Rij voor de inover waarden
                string[] woord = new string[3];
                //Inlezen van twee waarden. Stop is om de lus te stoppen.
                while ((userInput = Console.ReadLine()) != "stop")
                {
                    woord[i] = userInput;
                    i = i + 1;
                }
                //Zin en key krijgen de waarden van ingelezen waarden
                string zin = woord[1];
                Console.WriteLine("Zin: " + zin);
                string key = woord[2];
                Console.WriteLine("Key: " + key);

                Console.WriteLine("De encrypte zin is: " + encrypt(zin, key));
                Console.ReadKey();
            }

            else 
            {
                Console.WriteLine("Bij decryptie moet je een zin intypen die encrypt was met Vigenere.");
                Console.WriteLine("De key is met alleen hoofdletters.");

                //Hulp variabele voor opslaan invoer
                string userInput = "";
                //Teller voor rij met invoer waarden
                int i = 0;
                //Rij voor de inover waarden
                string[] woord = new string[3];

                //Inlezen van twee waarden. Stop is om de lus te stoppen.
                while ((userInput = Console.ReadLine()) != "stop")
                {
                    woord[i] = userInput;
                    i = i + 1;
                }


                //Zin en key krijgen de waarden van ingelezen waarden
                string zin = woord[1];
                Console.WriteLine("Zin: " + zin);
                string key = woord[2];
                Console.WriteLine("Key: " + key);

                Console.WriteLine("De decrypte zin is: " + decrypt(zin, key));
                Console.ReadKey();
            }
           

        }
        public static string encrypt(string zin, string key)
        {
            string encrypteZin = "";

            byte[] keyASCII = Encoding.ASCII.GetBytes(key);
            int[] keyNumber = new int[keyASCII.Length];
            for (int i=0; i< keyASCII.Length; i++)
            {
                keyNumber[i] = (int)(keyASCII[i] - 65);
            }
                                   
            byte[] zinASCII = Encoding.ASCII.GetBytes(zin);

            //Algortime
            for (int i = 0; i < zin.Length; i++)
            {
                byte encrypteLetter = (byte)((zinASCII[i] -32 + keyNumber[i % key.Length]) % 95);
                encrypteZin = encrypteZin + (char)(encrypteLetter + 32);
            }

            return encrypteZin;
        }

        public static string decrypt(string zin, string key)
        {
            string decrypteZin = "";
            
            byte[] keyASCII = Encoding.ASCII.GetBytes(key);
            int[] keyNumber = new int[keyASCII.Length];
            for (int i = 0; i < keyASCII.Length; i++)
            {
                keyNumber[i] = (int)(keyASCII[i] - 65);
            }

            byte[] zinASCII = Encoding.ASCII.GetBytes(zin);

            //Algoritme
            for (int i = 0; i < zin.Length; i++)
            {
                byte decrypteLetter;
                                     
                decrypteLetter = (byte)((zinASCII[i] - 32 - keyNumber[i % key.Length]) % 95);
                              
                
                //Controle van algoritme
                Console.WriteLine(zinASCII[i]-32 +" "+ keyNumber[i % key.Length]+ " " + (zinASCII[i] - 32 - keyNumber[i % key.Length]) % 95 + " "+ decrypteLetter);

                decrypteZin = decrypteZin + (char)(decrypteLetter + 32);
            }


            return decrypteZin;
        }

        
    }
}
