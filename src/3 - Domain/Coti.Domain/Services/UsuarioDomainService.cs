using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coti.Domain.Services
{
    public class UsuarioDomainService : BaseDomainService<Usuario>, IUsuarioDomainService
    {
        private readonly IUnitOfWork unitOfWork;
        public UsuarioDomainService(IUnitOfWork unitOfWork)
            : base(unitOfWork.UsuarioRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override Usuario Post(Usuario entity)
        {
            if (unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(entity.Email)) != null)
                throw new Exception($"O Email informado '{entity.Email}' já encontra-se cadastrado. Tente outro.");

            return base.Post(entity);

        }

        public Usuario Get(string email, string senha)
        {
            return unitOfWork.UsuarioRepository.Get(u => u.Email.Equals(email) && u.Senha.Equals(senha));
        }
    }
}
