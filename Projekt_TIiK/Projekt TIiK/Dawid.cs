﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_TIiK
{
    public partial class Decompresion
    {
        //słownik z naszymi parami gdzie kluczem jest liczba short (otrzymana po konwersji z bitarray
        Dictionary<String, String> dictionary =
            new Dictionary<String, String>();

        public void makeDictionary(String path)
        {
            StreamReader streamReader = new StreamReader(path, Encoding.UTF8);
            string binaryData = streamReader.ReadToEnd();
            char[] tekstArray = binaryData.ToArray();

            int i = 0;
            for( ; i < tekstArray.Length; )
            {
                string lengthBinary = binaryData.Substring(i, 16);   
                int lengthBinaryInt = BitStringToInt(lengthBinary);
                if (lengthBinaryInt <= 0)
                    break;

                string firstSignBinary = binaryData.Substring(i + 16, 16);
                string secondSignBinary = binaryData.Substring(i + 32, 16);
                string coupleSings = Convert.ToChar(BitStringToInt(firstSignBinary)) + "" + Convert.ToChar(BitStringToInt(secondSignBinary));
                string codeSign = binaryData.Substring(i + 48, lengthBinaryInt);
                dictionary.Add(codeSign, coupleSings );
                i = i + 48 + lengthBinaryInt;
            }

            i = i + 16;
            string codeSignFromText = "";
            string encodedText = "";
            for (; i < tekstArray.Length; )
            {
                codeSignFromText += tekstArray[i];
                if(dictionary.Where(x=>x.Key == codeSignFromText).Any())
                {
                    encodedText += dictionary[codeSignFromText];
                }
            }

            
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
        public void start(String path)
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
        }
    }



}