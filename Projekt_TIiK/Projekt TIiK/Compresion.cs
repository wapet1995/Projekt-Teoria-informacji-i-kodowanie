﻿using Newtonsoft.Json;
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

        private void getDictionaryFromPython(String result)

        {
            Console.WriteLine(result);
            result = result.Replace("[", "\"[").Replace("]", "]\"");

            dictionary = JsonConvert.DeserializeObject<Dictionary<String, String>>(result);

        }

        private void writeToFile(String dictionaryFromPython, String path)
        {
            this.getDictionaryFromPython(dictionaryFromPython);
            convert();

            using (BinaryWriter writer = new BinaryWriter(File.Open(path, FileMode.Create)))
            {
                Console.WriteLine("count asdjasdf");
                Console.WriteLine("count " + listofBits.Count);
                for (int i = 0; i < listofBits.Count - 8; i = i + 8)
                {
                    Console.WriteLine("s " + i);
                    if(listofBits.Count > i+16)
                    { 
                    Boolean[] a = new Boolean[8];
                    a[0] = listofBits[i];
                    a[1] = listofBits[i + 1];
                    a[2] = listofBits[i + 2];
                    a[3] = listofBits[i + 3];
                    a[4] = listofBits[i + 4];
                    a[5] = listofBits[i + 5];
                    a[6] = listofBits[i + 6];
                    a[7] = listofBits[i + 7];
                    writer.Write(ConvertBoolArrayToByte(a));
                    }
                 /*   else
                    {
                        Boolean[] a = new Boolean[8];
                        for (int j = i; j< listofBits.Count; j++)
                        {
                            a[j] = listofBits[j];
                        }
                        for(int z= 0; z < listofBits.Count - i;z++)
                        {
                            a[z] = listofBits[z];
                        }
                    }*/
                }
            }





        }



        private byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
            // This assumes the array never contains more than 8 elements!
            int index = 8 - source.Length;

            // Loop through the array
            foreach (bool b in source)
            {
                // if the element is 'true' set the bit at that position
                if (b)
                    result |= (byte)(1 << (7 - index));

                index++;
            }

            return result;
        }
        public void test()
        {
            using (StreamReader sr = new StreamReader("data3.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String line = sr.ReadToEnd();
                writeToFile(line, "sample.bin");
            }

            

        }

        private void convert()
        {
            foreach (KeyValuePair<String, String> entry in dictionary)
            {


                if (entry.Key != "text")
                {
                   // Console.WriteLine(" " + entry.Key + " " + entry.Value);
                    String series = Convert.ToString(entry.Value.Length, 2);
                    for(int i=0; i<16- series.Length; i++)
                    {
                        listofBits.Add(false);
                    }

                    for (int i=0; i<series.Length; i++)
                    {
                        
                        if(series[i].Equals('1'))
                        {
                            listofBits.Add(true);
                        }
                        else
                        {
                            listofBits.Add(false);
                        }
                    }


                    
                    Boolean[] char1 = Convert.ToString((Int16)entry.Key[0], 2).Select(s => s.Equals('1')).ToArray();
             
              
              
                    for (int i = 0; i < 16 - char1.Length; i++)
                    { listofBits.Add(false);
                    }
                    for (int i = 0; i < char1.Length; i++)
                    { listofBits.Add(char1[i]); }


                 
                    if (entry.Key.Length > 1)
                    {
                       
                        Boolean[] char2 = Convert.ToString((Int16)entry.Key[1], 2).Select(s => s.Equals('1')).ToArray();

                        for (int i = 0; i < 16 - char2.Length; i++)
                        { listofBits.Add(false); }
                        for (int i = 0; i < char2.Length; i++)
                        { listofBits.Add(char2[i]); }

                    }
                    else
                    {

                        Boolean[] char2 = Convert.ToString((Int16)' ', 2).Select(s => s.Equals('1')).ToArray();

                        for (int i = 0; i < 16 - char2.Length; i++)
                        { listofBits.Add(false); }
                        for (int i = 0; i < char2.Length; i++)
                        { listofBits.Add(char2[i]); }
                    }
                   

                    for (int i = 0; i < entry.Value.Length; i++)
                    {
                        if(entry.Value[i].Equals('1'))
                        { listofBits.Add(true); }
                        else
                        {
                            listofBits.Add(false);
                        }
                         }
                }
            }


            string value;
            dictionary.TryGetValue("text", out value);
            value = value.Replace("[", "").Replace("]", "").Replace(" ","").Replace("'","");
            String[] items = value.Split(',').Select(n => n).ToArray();

        
            for (int j = 0; j < 16; j++)
            {
                listofBits.Add(false);
            }

            //zapisanie jej do tablicy 
            for (int i = 0; i < items.Length; i++)
            {
                for (int j = 0; j < items[i].Length; j++)
                {
                    if(items[i][j].Equals('1'))
                    {
                        listofBits.Add(true);
                    }
                    else
                    {
                        listofBits.Add(false);
                    }
                }

            }
            //do wyswietlania co zapisywane jest 
            var str = "";
            foreach (var item in listofBits)
            {
                if (item)
                { str = str + "1"; }
                else
                    str = str + "0";
            }
            Debug.Write(str);
        }


    }
}
