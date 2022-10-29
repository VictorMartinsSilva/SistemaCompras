using SistemaCompra.Application.SolicitacaoCompra.Command.Query.RegistrarCompra;
using System.Collections.Generic;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;

namespace SistemaCompra.Application
{
    public class Itens
    {
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;
        public Itens(ProdutoAgg.IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }
        public List<SolicitacaoCompraAgg.Item> ItensConvert(List<ItemViewModel> itens)
        {
            var aux = new List<SolicitacaoCompraAgg.Item>();
            foreach(var item in itens)
            {
                var produto = _produtoRepository.Obter(item.Id);
                aux.Add(new SolicitacaoCompraAgg.Item(produto, item.Qtde));
            }
            return aux;
        }
    }
}
