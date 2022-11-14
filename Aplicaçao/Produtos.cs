using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Aplicaçao
{   
    public class Produtos
    {
        
        private static Dictionary<int, Produto> produtosDict = new Dictionary<int, Produto>();
        public static Produtos instance;

        public Produtos()
        {
            if(instance == null)
            {
                instance = this;
            }
        }

        public void addProdutos(int preco, int codigo, int categoria, string nomeDoProduto)
        {
            int id = produtosDict.Count + 1;
            Produto produto = new Produto( preco, codigo, categoria, nomeDoProduto);
            produtosDict.Add(id, produto);
        }

        public void delProdutos(int id)
        {
            produtosDict.Remove(id);
        }

        public object getProduct(int id)
        {
            return produtosDict[id];
        }

        public int getDictLenght()
        {
            return produtosDict.Count;
        }
    }

}
