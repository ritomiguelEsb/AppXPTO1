using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaçao
{
    class Produto
    {
        int preco;
        int codigo;
        int categoria;
        string nomeDoProduto;

        public Produto()
        {
            this.preco = 0;
            this.codigo = -1;
            this.categoria = -1;
            this.nomeDoProduto = "";
        }

        public Produto(int preco, int codigo, int categoria, string nomeDoProduto)
        {
            this.preco = preco;
            this.codigo = codigo;
            this.categoria = categoria;
            this.nomeDoProduto = nomeDoProduto;
        }

    }
}
