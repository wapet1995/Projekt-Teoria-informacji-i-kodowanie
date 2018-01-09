using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace test
{

    class Program
    {
        static void Main(string[] args)
        {
   

            
            string tekst = "abcafgababacaffgabfgcabffg";                // przyklad z naszej prezentacji

            if (tekst.Length % 2 != 0)                                  // gdy jest nieparzyta liczba znaków, dopełniamy spacją
                tekst += " ";

            int pairSize = tekst.Length / 2;            // ilosc par
            Console.WriteLine("ilość par " + pairSize);

            char[] tekstArray = tekst.ToArray();
            List<Signs> listSigns = new List<Signs>();                                  // na tej liscie beda wszystkie pary
            for(int i = 0; i < tekst.Length; i += 2)
            {
                string temp = tekstArray[i].ToString() + tekst[i+1].ToString();         // laczymy dwa sasiednie znaki w pare dwoch znakow
                if(listSigns.Where(x=>x.name == temp).Any())                            // jezeli na liscie jest juz taka para
                {
                    Signs tempSigns = listSigns.Where(x => x.name == temp).Single();
                    tempSigns.value += 1;                                                       // to zwiekszamy ilosc wystapien
                }
                else
                {
                    Signs tempSigns = new Signs();                                      // w przeciwnym wypadku zapisujemy pare do listy
                    tempSigns.name = temp;
                    tempSigns.value = 1.0;
                    tempSigns.binary = "";
                    listSigns.Add(tempSigns);
                }
                
            }

            var names = new List<string>(listSigns.Select(x=>x.name));                  // tworzymy liste stringow skladajaca sie z nazwy par
            foreach(string name in names)
            {
                Signs tempSign = listSigns.Where(x=>x.name == name).First();
                tempSign.value /= pairSize;                                             // liczymy czestotliwosc dla kazdej pary znajdujacej sie na liscie
            }

            Console.WriteLine("\nSlajd 6");                             // slajd 6
            foreach (var item in listSigns)
                Console.WriteLine(item.name + " " + item.value);

            listSigns = listSigns.OrderByDescending(x => x.value).ToList();             // sortujemy malejaco wg czestotliwosci
            Console.WriteLine("\nSlajd 7");                             // slajd 7
            foreach (var item in listSigns)
                Console.WriteLine(item.name + " " + item.value);


             names = new List<string>(listSigns.Select(x => x.name));   // drugi raz ta sama funkcja, po to by byla odpowiednia kolejnosc par

              double minValue = 9999;
              double differenceValue;
              List<string> leftNames = new List<string>();
              List<string> templeftNames = new List<string>();

            foreach(string name in names)
            {
                templeftNames.Add(name);
                countDifference(listSigns, templeftNames, names, out differenceValue);
                if(minValue > differenceValue)
                {
                    minValue = differenceValue;
                    leftNames = new List<string>(templeftNames);    // tworzymy liste, do ktorej elementow dodamy binarne 0
                }
            }

            foreach (string item in leftNames)
            {
                Signs tempSigns = listSigns.Where(x => x.name == item).First();
                tempSigns.binary += "0";
            }

            List<string> rightNames = names.Except(leftNames).ToList();   // tworzymy liste, do ktorej elementow dodamy binarne 1
            foreach (string item in rightNames)
            {
                Signs tempSigns = listSigns.Where(x => x.name == item).First();
                tempSigns.binary += "1";
            }

            
            while(leftNames.Count > 1)
            {
               // todo
            }

            while(rightNames.Count > 1)
            {
                // todo
            }
             
        }

      
        public static void countDifference(List<Signs> listSigns, List<string> leftNames, List<string> allKeys, out double differenceValue)
        {
            double leftValue = 0;
            double rightValue = 0;
            List<string> rightNames = new List<string>(allKeys.Except(leftNames).ToList());
            // jakby ktoś nie wiedział czemu nie zrobiłem tak: List<string> rightNames = allKeys.Except(leftNames).ToList();
            // dlatego, ze wtedy elementy listy przekazane byly by przez referencje i te listy nie byly by niezalezne od siebie
            foreach (string key in leftNames)
            {
                Signs tempsign =listSigns.Where(x => x.name == key).First();
                leftValue += tempsign.value;
            }

            foreach (string key in rightNames)
            {
                Signs tempsign = listSigns.Where(x => x.name == key).First();
                rightValue += tempsign.value;
            }
            differenceValue = leftValue - rightValue;
            if (differenceValue < 0)
                differenceValue = -differenceValue;
        }



        public static void taskLoop(List<Signs> listSigns, List<string> sideNames)
        {
            List<string> names = new List<string>(listSigns.Select(x => x.name));   // drugi raz ta sama funkcja, po to by byla odpowiednia kolejnosc par

            double minValue = 9999;
            double differenceValue;
            List<string> leftNames = new List<string>();
            List<string> templeftNames = new List<string>();

            foreach (string name in names)
            {
                templeftNames.Add(name);
                countDifference(listSigns, templeftNames, names, out differenceValue);
                if (minValue > differenceValue)
                {
                    minValue = differenceValue;
                    leftNames = new List<string>(templeftNames);    // tworzymy liste, do ktorej elementow dodamy binarne 0
                }
            }

            foreach (string item in leftNames)
            {
                Signs tempSigns = listSigns.Where(x => x.name == item).First();
                tempSigns.binary += "0";
            }

            List<string> rightNames = names.Except(leftNames).ToList();   // tworzymy liste, do ktorej elementow dodamy binarne 1
            foreach (string item in rightNames)
            {
                Signs tempSigns = listSigns.Where(x => x.name == item).First();
                tempSigns.binary += "1";
            }
        }


    }
}
