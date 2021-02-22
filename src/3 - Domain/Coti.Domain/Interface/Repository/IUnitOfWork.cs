using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Domain.Interface.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        #region Repositories

        IFuncionarioRepository FuncionarioRepository { get; }
        IDependenteRepository DependenteRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }

        #endregion

        #region Transactions

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion
    }
}
