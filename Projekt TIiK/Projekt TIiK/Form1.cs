﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_TIiK
{
    public partial class Form1 : Form
    {
        string tekst;
        Dictionary<char, double> dict_chars;
        List<SignWithFrequencyAndInformation> signWithFrequencyAndInformation;
        public Form1()
        {
            InitializeComponent();
            dict_chars = new Dictionary<char, double>();
            signWithFrequencyAndInformation = new List<SignWithFrequencyAndInformation>();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Image files (*.txt) | *.txt";
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                tekst = File.ReadAllText(openFileDialog1.FileName);
                TXBox_text.Text = tekst;
                textBoxLenghText.Text= tekst.Length.ToString();
                Form1.ActiveForm.Text = "Projekt TIiK. Wczytany tekst: " + openFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tekst = tekst.ToLower();
            dict_chars = tekst.GroupBy(c => c).ToDictionary(g => g.Key, g => (double)g.Count());
            List<char> chars = new List<char>(dict_chars.Keys);
            chars.Sort();
            List<double> counter = new List<double>();
            foreach (var item in chars)
            {
                counter.Add(dict_chars[item]);
            }
            dict_chars.Clear();
            for (int i = 0; i < chars.Count; i++)
            {
                dict_chars[chars[i]] = counter[i] / tekst.Length;
            }
            countAmountInformationPerSign();
            dataGridView1.DataSource = signWithFrequencyAndInformation.ToList();// dict_chars.ToList();
            textBoxEntropia.Text = countEntropy().ToString();
          
           
        }

        private double countEntropy()
        {
            double entropy = 0;
            foreach (var item in dict_chars)
            {
                entropy += item.Value * Math.Log((1 / item.Value), 2);
            }
            return entropy;
        }



        private void countAmountInformationPerSign() // ilosc informacji na znak
        {
            signWithFrequencyAndInformation.Clear();
            foreach (var item in dict_chars)
            {
                signWithFrequencyAndInformation.Add(new SignWithFrequencyAndInformation(item.Key, item.Value, Math.Log((1 / item.Value), 2)));   
            }
        }

private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
