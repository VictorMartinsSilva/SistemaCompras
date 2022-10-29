using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using ProdutoAgg = SistemaCompra.Domain.ProdutoAggregate;
using SolicitacaoCompraAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly ProdutoAgg.IProdutoRepository _produtoRepository;
        private readonly SolicitacaoCompraAgg.ISolicitacaoCompraRepository _solicitacaoCompraRepository;

        public RegistrarCompraCommandHandler(ProdutoAgg.IProdutoRepository produtoRepository, SolicitacaoCompraAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository,
                                                IUnitOfWork uow, IMediator mediator) : base (uow, mediator)
        {
            _produtoRepository = produtoRepository;
            _solicitacaoCompraRepository = solicitacaoCompraRepository;
        }
        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var solicitacaoCompra = new SolicitacaoCompraAgg.SolicitacaoCompra(request.NomeFornecedor, request.UsuarioSolicitante);

                var itens = new Itens(_produtoRepository);
                solicitacaoCompra.RegistrarCompra(itens.ItensConvert(request.Itens));

                _solicitacaoCompraRepository.RegistrarCompra(solicitacaoCompra);

                Commit();
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}
