using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaçao
{
    public class Produto
    {
        int ID;
        float preco;
        int codigo;
        string categoria;
        string nomeDoProduto;

        public Produto()
        {
            this.ID = -1;
            this.preco = 0;
            this.codigo = -1;
            this.categoria = " ";
            this.nomeDoProduto = "";
        }

        public Produto(float preco, int codigo, string categoria, string nomeDoProduto, int ID)
        {
            this.ID = ID;
            this.preco = preco;
            this.codigo = codigo;
            this.categoria = categoria;
            this.nomeDoProduto = nomeDoProduto;
        }

        public void setAtributo(float preco, int codigo, string categoria, string nomeDoProduto, int ID)
        {
            this.ID = ID;
            this.preco = preco;
            this.codigo = codigo;
            this.categoria = categoria;
            this.nomeDoProduto = nomeDoProduto;
        }

        public void backID()
        {
            this.ID--;
        }

        public string getNome()
        {
            return nomeDoProduto;
        }
        public float getPreco()
        {
            return preco;
        }
        public int getID()
        {
            return ID;
        }
        public int getCodigo()
        {
            return codigo;
        }

        public string getCategoria()
        {
            return categoria;
        }


    }
}
