using AutoMapper;
using LinqKit;
using uNotes.Application.AppService.Interface;
using uNotes.Application.Requests.Categorias;
using uNotes.Application.Responses.Categorias;
using uNotes.Domain.Entidades;
using uNotes.Domain.Services.Interface.Service;
using uNotes.Infra.CrossCutting.Notificacoes;
using uNotes.Infra.CrossCutting.UoW;

namespace uNotes.Application.AppService
{
    public class CategoriaAppService : BaseAppService, ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IUsuarioCategoriaService _usuarioCategoriaService;
        private readonly INotificador _notificador;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaService categoriaService, IUsuarioCategoriaService usuarioCategoriaService,IUnitOfWork unitOfWork, IMapper mapper, INotificador notificador)
        {
            _categoriaService = categoriaService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _notificador = notificador;
            _usuarioCategoriaService = usuarioCategoriaService;
        }

        public CategoriaAdicionarRequest Adicionar(CategoriaAdicionarRequest categoria, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            categoria.CriadorId = usuarioId;
            var categoriaNova = _categoriaService.Adicionar(_mapper.Map<Categoria>(categoria));
            _usuarioCategoriaService.Adicionar(new UsuarioCategoria
            {
                Categoria = categoriaNova,
                UsuarioId = usuarioId
            });
            _unitOfWork.Commit();
            return categoria;
        }

        public string Atualizar(CategoriaAtualizarRequest categoria)
        {
            _categoriaService.AtualizarCategoria(_mapper.Map<Categoria>(categoria));
            _unitOfWork.Commit();
            return "Categoria Atualizada com Sucesso";
        }

        public CategoriaObterResponse ObterPorId(Guid id)
        {
            return _mapper.Map<CategoriaObterResponse>(_categoriaService.ObterPorId(id));
        }

        public IEnumerable<CategoriaObterResponse> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CategoriaObterResponse>>(_categoriaService.ObterTodos());
        }

        public string AdicionarUsuarios(Guid categoriaId, List<Guid> usuarioAdicionarId, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            var categoria = _categoriaService.ObterPorId(categoriaId);
            if (categoria.CriadorId != usuarioId)
                return "Usuário não é o criador da categoria";
            usuarioAdicionarId.ForEach(usuario =>
            {
                _usuarioCategoriaService.Adicionar(new UsuarioCategoria
                {
                    Categoria = categoria,
                    UsuarioId = usuario
                });
            });
            _unitOfWork.Commit();
            return $"Usuário(s) adicionado na categoria {categoria.Titulo}";
        }

        public string RemoverUsuarios(Guid categoriaId, List<Guid> usuarioRemoverIds, string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            var categoria = _categoriaService.ObterPorId(categoriaId);
            if (categoria.CriadorId != usuarioId)
                return "Usuário não é o criador da categoria";
            usuarioRemoverIds.ForEach(usuario =>
            {
                var usuarioRemover = _usuarioCategoriaService.Buscar(x => x.UsuarioId == usuario && x.CategoriaId == categoria.Id).First();
                if(usuarioRemover != null)
                    _usuarioCategoriaService.Remover(usuarioRemover.Id);
            });
            _unitOfWork.Commit();
            return $"Usuário(s) removido(s) na categoria {categoria.Titulo}";
        }

        public List<CategoriaObterResponse> ObterCategoriasPorUsuario(string token)
        {
            var usuarioId = ObterInformacoesToken(token[7..]);
            if (usuarioId == null || usuarioId == Guid.Empty)
            {
                _notificador.AdicionarNotificacao("Token inválido");
                return null;
            }
            return _mapper.Map<List<CategoriaObterResponse>>(_categoriaService.ObterCategoriasPorUsuario(usuarioId)).ToList();        
        }

        public void Remover(Guid id)
        {
            _categoriaService.Remover(id);
            _unitOfWork.Commit();
        }
    }
}
