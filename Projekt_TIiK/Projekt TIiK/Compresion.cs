using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;

namespace Projekt_TIiK
{
    public partial class Compresion
    {
        Dictionary<String, String> dictionary =
            new Dictionary<String, String>();
        List<Boolean> listofBits = new List<Boolean>();
       
        private void getDictionaryFromResult(String result)

        {
            Debug.Write(result);
            dictionary =JsonConvert.DeserializeObject<Dictionary<String, String>>(result);
        }

        private void writeToFile(String result, String path)
        {
            getDictionaryFromResult(result);
            convert();




        }

        public void test()
        {

            using (StreamReader sr = new StreamReader("data.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                
                line = line.Replace("[", "\"[").Replace("]","]\"");
                MessageBox.Show(line);
                writeToFile(line, "sample.bin");
            }
    }

        private void convert()
        {
            foreach (KeyValuePair<String, String> entry in dictionary)
            {
                if (entry.Key != "text") {
                    Boolean[] key;

                    key = Convert.ToString(Int32.Parse(entry.Value), 2).Select(s => s.Equals('1')).ToArray();


                    Boolean[] sizeofKey;
                    sizeofKey= Convert.ToString(key.Length, 2).Select(s => s.Equals('1')).ToArray();


                    if (sizeofKey.Length < 16)
                    {
                        for (int i = 0; i < 16 - sizeofKey.Length; i++)
                        {
                            listofBits.Add(false);
                          
                        }
                    }
                    for (int i = 0; i < sizeofKey.Length; i++)
                    {
                        listofBits.Add(sizeofKey[i]);
                     
                    }
                 

                    //para znaków do bitlist
              

                    Boolean[] char1;
                    Boolean[] char2;

                    char1= Convert.ToString((Int16)entry.Key[0], 2).Select(s => s.Equals('1')).ToArray();
                    char2 = Convert.ToString((Int16)entry.Key[1], 2).Select(s => s.Equals('1')).ToArray();

                   for(int i=0; i<8-char1.Length; i++)
                    {
                        listofBits.Add(false);
                    }
                   for(int i=0; i<char1.Length; i++)
                    {
                        listofBits.Add(char1[i]);
                    }
                    for (int i = 0; i < 8 - char2.Length; i++)
                    {
                        listofBits.Add(false);
                    }
                    for (int i = 0; i < char2.Length; i++)
                    {
                        listofBits.Add(char2[i]);
                    }

                    for (int i = 0; i < key.Length; i++)
                    {
                        listofBits.Add(key[i]);
                    }

                }
            }

            //wczytanie tekstu
            string value;
           dictionary.TryGetValue("text",out value);

         
            value=value.Replace("[","").Replace("]","");
            
         
            //przerobienie tekstu na tablice intów
         

           // Nie działa :(
           int[] items = value.Split(',').Select(n => Convert.ToInt32(n)).ToArray();


            for (int j = 0; j < 16; j++)
            {
                listofBits.Add(false);
            }

            //zapisanie jej do tablicy 
            for (int i = 0; i < items.Length; i++)
            {

                Boolean[] pair = Convert.ToString(items[i], 2).Select(s => s.Equals('1')).ToArray();
                for(int j=0; j<pair.Length; j++)
                {
                    listofBits.Add(pair[j]);
                }

            }
            
           

            String mes= "";
            foreach (var item in listofBits)
            {
                if (item)
                    mes = mes + "1";
                else
                    mes = mes + "0";
            }
            Debug.Write(mes);

        }


    }
}
