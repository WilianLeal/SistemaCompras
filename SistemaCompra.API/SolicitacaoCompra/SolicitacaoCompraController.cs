using Microsoft.AspNetCore.Mvc;
using System;
using MediatR;
using SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra;

namespace SistemaCompra.API.SolicitacaoCompra
{
    public class SolicitacaoCompraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolicitacaoCompraController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost, Route("solicitacao-compra/cadastro")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult CadastrarSolicitacaoCompra([FromBody] RegistrarCompraCommand registrarSolitacaoCompraCommand)
        {
            _mediator.Send(registrarSolitacaoCompraCommand);
            return StatusCode(201);
        }
    }
}
