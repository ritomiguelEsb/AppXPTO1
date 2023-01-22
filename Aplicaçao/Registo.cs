using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Aplicaçao
{
    internal class Registo
    {

        //Variáveis
        private int ID;
        private int codigo;
         private DateTimePicker dataTempo;
         private string nome;
         private long telefone;
         private string email;
         private string avaria;
         private bool garantia;
         

        //Inicializar Registo

        public Registo(int _ID,int _codigo, DateTimePicker _dataTempo, string _nome, long _telefone, string _email, string _avaria, bool _garantia)
        {
            this.ID = _ID;
            this.codigo = _codigo;
            this.dataTempo = _dataTempo;
            this.nome = _nome;
            this.telefone = _telefone;
            this.email = _email;
            this.avaria = _avaria;
            this.garantia = _garantia;
        }



        //Funções
        public void backID() { this.ID--; }

        public void setAtributo(int _ID, int _codigo, DateTimePicker _dataTempo, string _nome, long _telefone, string _email, string _avaria, bool _garantia)
        {
            this.ID = _ID;
            this.codigo = _codigo;
            this.dataTempo = _dataTempo;
            this.nome = _nome;
            this.telefone = _telefone;
            this.email = _email;
            this.avaria = _avaria;
            this.garantia = _garantia;
        }

        //Getters


        public int getID() { return this.ID; }
        public int getCodigo() { return this.codigo; }
        public DateTimePicker getDataTempo() { return this.dataTempo; }
        public string getNome() { return this.nome; }
        public long getTelefone() { return this.telefone; }
        public string getEmail() { return this.email; }
        public string getAvaria() { return this.avaria; }
        public bool getGarantia() { return this.garantia; }





    }
}
