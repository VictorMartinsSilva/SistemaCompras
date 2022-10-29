﻿using MediatR;
using SistemaCompra.Application.SolicitacaoCompra.Command.Query.RegistrarCompra;
using System.Collections.Generic;

namespace SistemaCompra.Application.SolicitacaoCompra.Command.RegistrarCompra
{
    public class RegistrarCompraCommand : IRequest<bool>
    {
        public string NomeFornecedor { get; set; }
        public string UsuarioSolicitante { get; set; }
        public List<ItemDTO> Itens { get; set; }
    }
}
