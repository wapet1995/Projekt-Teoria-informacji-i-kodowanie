using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_TIiK
{
    public partial class Decompresion
    {
        private static bool[] ConvertByteToBoolArray(byte b)
        {
            // prepare the return result
            bool[] result = new bool[8];

            // check each bit in the byte. if 1 set to true, if 0 set to false
            for (int i = 0; i < 8; i++)
                result[i] = (b & (1 << i)) == 0 ? false : true;

            // reverse the array
            Array.Reverse(result);

            return result;
        }

        Dictionary<String, String> dictionary =
            new Dictionary<String, String>();
        public void makeDictionary(String path,Form1 window)
        {        
            string binaryData = "";
            byte show;
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    Byte tempBool = reader.ReadByte();
                    bool[] booleanarray = ConvertByteToBoolArray(tempBool);
                    foreach(bool item in booleanarray)
                    { 
                    if (item == true)
                        binaryData += "1";
                    else
                        binaryData += "0";
                    }
                }
            }

            char[] tekstArray = binaryData.ToArray();
          
            int i = 0;
            for( ; i < tekstArray.Length; )
            {
                string lengthBinary = binaryData.Substring(i, 16);   
                int lengthBinaryInt = BitStringToInt(lengthBinary);
                if (lengthBinaryInt <= 0)
                    break;

                if (i + 32 > tekstArray.Length)
                    break;
                    
                string firstSignBinary = binaryData.Substring(i + 16, 16);
                string secondSignBinary = binaryData.Substring(i + 32, 16);
                string coupleSings = Convert.ToChar(BitStringToInt(firstSignBinary)) + "" + Convert.ToChar(BitStringToInt(secondSignBinary));
                string codeSign = binaryData.Substring(i + 48, lengthBinaryInt);
                Console.WriteLine("dlugosc: " + lengthBinary + "pierwszy znak" + firstSignBinary + " drugi " + secondSignBinary + " kod" + codeSign);
                Console.WriteLine(codeSign + " " + coupleSings);
                dictionary.Add(codeSign, coupleSings);
                if (i + 48 + lengthBinaryInt > tekstArray.Length)
                    break;
                i = i + 48 + lengthBinaryInt;
            }

            i = i + 16;
            string codeSignFromText = "";
            string encodedText = "";
            for (; i < tekstArray.Length; i++)
            {

                codeSignFromText += tekstArray[i];
                if (dictionary.Where(x => x.Key == codeSignFromText).Any())
                {
                    encodedText += dictionary[codeSignFromText];
                    codeSignFromText = "";
                }
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

           
            MethodInvoker inv = delegate
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, encodedText);
                }
                window.setDecompresionText(encodedText);
                MessageBox.Show("Zdekodowano");
            }; window.Invoke(inv);
        }


        // jakiegoś streamreadera do odczytu z pliku utwórz będę go brał w parametrach funkcji i po skońćzeniu funkcji będzie na pozyci już do odczytu pliko za słownikiem :)
        //dalej sobie sam poradzisz chyba XDD bo słownik będziesz mieć i streamreadera ustawionego na początek właściwego pliku)

        public static int BitStringToInt(string bits)
        {
            var reversedBits = bits.Reverse().ToArray();
            var num = 0;
            for (var power = 0; power < reversedBits.Count(); power++)
            {
                var currentBit = reversedBits[power];
                if (currentBit == '1')
                {
                    var currentNum = (int)Math.Pow(2, power);
                    num += currentNum;
                }
            }

            return num;
        }

    }



    public partial class Compresion
    {
        String result;
        //panie masz tu w path śćieżke do pliku zapisz mi to co zwróci do result XD
        public void start(String path,String filenameWithPath, Form1 window)
        {
            string python = @"C:\Users\Dawid\AppData\Local\Programs\Python\Python36-32\python.exe";
            string myPythonApp = @"C:\Users\Dawid\Documents\GitHub\Projekt-Teoria-informacji-i-kodowanie\Projekt_TIiK\shannon-fano.py";

            path = path.Replace('\\', '/');
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.Arguments = myPythonApp + " " + path;

            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();

            StreamReader myStreamReader = myProcess.StandardOutput;
            string myString = myStreamReader.ReadToEnd(); // dane przekazane z pythona
            
            myProcess.WaitForExit();
            myProcess.Close();

            writeToFile(myString, filenameWithPath);
            FileInfo fi = new FileInfo(filenameWithPath);
            MethodInvoker inv = delegate
            {
                window.setCompresionText((fi.Length / 1024).ToString());
                MessageBox.Show("Zakodowano");
            }; window.Invoke(inv);
        }
    }



}
