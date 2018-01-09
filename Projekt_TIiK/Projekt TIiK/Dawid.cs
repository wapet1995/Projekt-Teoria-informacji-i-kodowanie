using System;
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
        Dictionary<short, String> dictionary =
            new Dictionary<short, String>();

        // jakiegoś streamreadera do odczytu z pliku utwórz będę go brał w parametrach funkcji i po skońćzeniu funkcji będzie na pozyci już do odczytu pliko za słownikiem :)
        //dalej sobie sam poradzisz chyba XDD bo słownik będziesz mieć i streamreadera ustawionego na początek właściwego pliku)
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
            string myString = myStreamReader.ReadToEnd(); // dane z przekazane z pythona

            myProcess.WaitForExit();
            myProcess.Close();
        }
    }



}
