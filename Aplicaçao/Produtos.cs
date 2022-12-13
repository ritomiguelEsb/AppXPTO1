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
using System.Windows.Forms;

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

        public void addProdutos(double preco, int codigo, string categoria, string nomeDoProduto)
        {
            int id = produtosDict.Count + 1;
            Produto produto = new Produto( preco, codigo, categoria, nomeDoProduto, id);
            produtosDict.Add(id, produto);
        }

        public void delProduct(int id)
        {
            produtosDict.Remove(id);
        }

        public Produto getProduct(int id)
        {
            return produtosDict[id];
        }

        //Função de guardar em xml

        public void changeDict(int i)
        {
            for(int x=i; x < produtosDict.Count+1; x++)
            {
                try
                {
                    produtosDict[x] = produtosDict[x + 1];
                    produtosDict[x].backID();
                }
                catch (Exception)
                {
                    produtosDict.Remove(x);
                }
            }
            //produtosDict.Remove(produtosDict.Count);
        }

        public int getDictLenght()
        {
            return produtosDict.Count;
        }
    }

}
