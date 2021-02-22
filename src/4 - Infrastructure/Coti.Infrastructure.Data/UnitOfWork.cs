using Coti.Domain.Interface.Repository;
using Coti.Infrastructure.Context.Base;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace Coti.Infrastructure.Data
{
    public class UnitOfWork : Coti.Domain.Interface.Repository.IUnitOfWork
    {
        private readonly CotiContext CotiContext;
        private IDbContextTransaction Transaction;

        public UnitOfWork(CotiContext cotiContext)
        {
            this.CotiContext = cotiContext;
        }

        #region Repositories

        private IDependenteRepository dependenteRepository;
        public IDependenteRepository DependenteRepository
        {
            get
            {
                if (dependenteRepository == null)
                {
                    dependenteRepository = new DependenteRepository(CotiContext);
                }

                return dependenteRepository;
            }
        }

        private IFuncionarioRepository funcionarioRepository;
        public IFuncionarioRepository FuncionarioRepository 
        {
            get
            {
                if (funcionarioRepository == null)
                {
                    funcionarioRepository = new FuncionarioRepository(CotiContext);
                }

                return funcionarioRepository;
            }
        }

        private IUsuarioRepository usuarioRepository;
        public IUsuarioRepository UsuarioRepository
        {
            get
            {
                if (usuarioRepository == null)
                {
                    usuarioRepository = new UsuarioRepository(CotiContext);
                }

                return usuarioRepository;
            }
        }

        #endregion

        #region Transactions
        public void BeginTransaction()
        {
            if (Transaction == null)
            {
                Transaction = CotiContext.Database.BeginTransaction();
            }
        }

        public void Commit()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Transaction = null;
            }
        }

        public void Rollback()
        {
            try
            {
                if (Transaction != null)
                {
                    Transaction.Rollback();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Transaction = null;
            }
        }

        public void Dispose()
        {
            CotiContext.Dispose();
        }
        #endregion
    }
}
