using MediatR;
using SistemaCompra.Infra.Data.UoW;
using System;
using System.Threading;
using System.Threading.Tasks;
using SolicitacaoAgg = SistemaCompra.Domain.SolicitacaoCompraAggregate;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommandHandler : CommandHandler, IRequestHandler<RegistrarCompraCommand, bool>
    {
        private readonly SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoRepository;

        public RegistrarCompraCommandHandler(SolicitacaoAgg.ISolicitacaoCompraRepository solicitacaoCompraRepository, IUnitOfWork uow, IMediator mediator) : base(uow, mediator)
        {
            this.solicitacaoRepository = solicitacaoCompraRepository;
        }

        public Task<bool> Handle(RegistrarCompraCommand request, CancellationToken cancellationToken)
        {
            var solitacao = new SolicitacaoAgg.SolicitacaoCompra(request.usuarioSolicitante, request.nomeFornecedor);
            solicitacaoRepository.RegistrarCompra(solitacao);

            Commit();
            PublishEvents(solitacao.Events);

            return Task.FromResult(true);
        }
    }
}
