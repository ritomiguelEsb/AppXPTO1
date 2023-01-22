using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Aplicaçao
{
    internal class Registos
    {
        public static Registos instance;
        private static Dictionary<int, Registo> registosDict = new Dictionary<int, Registo>();
        string path = "./../../database/data.txt";
        public Registos()
        {
            if(instance == null)
            {
                instance = this;
            }
            lerFicheiro();
        }


        public void delProduct(int id)
        {
            registosDict.Remove(id);
        }
        public void changeDict(int i)
        {
            for (int x = i; x < registosDict.Count + 1; x++)
            {
                try
                {
                    registosDict[x] = registosDict[x + 1];
                    registosDict[x].backID();
                }
                catch (Exception)
                {
                    registosDict.Remove(x);
                }
            }
            //registosDict.Remove(registosDict.Count);
        }

        public void addRegisto(Registo _registo)
        {
            registosDict.Add(_registo.getID(), _registo);
        }

        public void delRegisto(int id)
        {
            registosDict.Remove(id);
        }

        public Registo getRegisto(int id)
        {
            return registosDict[id];
        }

        public int getDictLenght()
        {
            return registosDict.Count();
        }


        public void lerFicheiro()
        {
            StreamReader stream;
            stream = new StreamReader(path);
            registosDict.Clear();
            while(stream.Peek() >= 0)
            {
                string line = stream.ReadLine();
                string[] words = line.Split(';');
                DateTimePicker date = new DateTimePicker();
                date.Value = DateTime.Parse(words[2]);
                registosDict.Add(registosDict.Count()+1,new Registo(Convert.ToInt32(words[0]), Convert.ToInt32(words[1]), date, words[3], Convert.ToInt64(words[4]), words[5], words[6], Convert.ToBoolean(words[7])));
            }
        }


        public void guardarFicheiro()
        {
            StreamWriter stream;
            
            stream = new StreamWriter(path);
            if (registosDict.Count < 0) return;
            for (int i = 1; i < registosDict.Count +1; i++)
            {
                stream.Write(registosDict[i].getID().ToString() + ";");
                stream.Write(registosDict[i].getCodigo().ToString() + ";");
                stream.Write(registosDict[i].getDataTempo().Value.ToString() + ";");
                stream.Write(registosDict[i].getNome().ToString() + ";");
                stream.Write(registosDict[i].getTelefone().ToString() + ";");
                stream.Write(registosDict[i].getEmail().ToString() + ";");
                stream.Write(registosDict[i].getAvaria().ToString() + ";");
                stream.Write(registosDict[i].getGarantia().ToString() + ";");
                stream.Write(Environment.NewLine);
            }
            stream.Close();
            MessageBox.Show("Registos Salvos!");
        }
    }
}
