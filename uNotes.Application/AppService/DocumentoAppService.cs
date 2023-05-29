using AutoMapper;
using MongoDB.Bson;
using System.Collections.Generic;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Colaboradores;
using uNotes.Application.Requests.Documentos;
using uNotes.Application.Responses.Documentos;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class DocumentoAppService : IDocumentoAppService
    {
        private readonly IDocumentoService _documentoService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public DocumentoAppService(IDocumentoService documentoService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _documentoService = documentoService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public DocumentoAdicionarRequest Adicionar(DocumentoAdicionarRequest user)
        {
            _documentoService.Adicionar(_mapper.Map<Documento>(user));
            _unitOfWork.Commit();
            return user;
        }

        public async Task<string> Atualizar(DocumentoAtualizarRequest user)
        {
            await _documentoService.AtualizarDocumento(_mapper.Map<Documento>(user));
            await _unitOfWork.CommitAsync();
            return "Notes Atualizado com Sucesso";
        }
        public DocumentoObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<DocumentoObterResponse>(_documentoService.ObterPorId(id));
        }

        public IEnumerable<DocumentoObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DocumentoObterResponse>>(_documentoService.ObterTodos());
        }
        public void Remover (Guid id)
        {
            _documentoService.Remover(id);
            _unitOfWork.Commit();
        }

        public IEnumerable<DocumentoObterResponse> ObterPorDescricao(string texto)
        {
            return _mapper.Map<IEnumerable<DocumentoObterResponse>>(_documentoService.ObterPorDescricao(texto));
        }
    }
}
