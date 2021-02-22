using Coti.Domain.Entities;
using Coti.Domain.Interface.Repository;
using Coti.Domain.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Coti.Domain.Services
{
    public class FuncionarioDomainService : BaseDomainService<Funcionario>, IFuncionarioDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public FuncionarioDomainService(IUnitOfWork unitOfWork) 
            : base(unitOfWork.FuncionarioRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public Funcionario ObterFuncionarioDependente(int idFuncionario)
        {
            return unitOfWork.FuncionarioRepository.ObterFuncionarioDependente(idFuncionario);
        }

        public override Funcionario Post(Funcionario entity)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var adDependente = unitOfWork.DependenteRepository;

                if (unitOfWork.FuncionarioRepository.Get(x => x.CPF.Equals(entity.CPF)) != null)
                {
                    throw new Exception($"O CPF informado '{entity.CPF}' já encontra-se cadastrado.Tente outro.");
                }

                entity.DataAdmissao = DateTime.Today;
                var funcionario = base.Post(entity);

                entity.Dependente.ToList()
                    .ForEach(item => 
                    {
                        item.IdFuncionario = funcionario.IdFuncionario;
                        adDependente.Post(item);
                    });

                unitOfWork.Commit();

                return entity;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public override void Put(Funcionario entity)
        {
            try
            {
                unitOfWork.BeginTransaction();

                var adDependente = unitOfWork.DependenteRepository;

                var funcionarioBD = this.Get(entity.IdFuncionario);

                if (funcionarioBD == null)
                    throw new Exception("Funcionario não encontrado");

                funcionarioBD.Nome = entity.Nome;
                funcionarioBD.CPF = entity.CPF;
                funcionarioBD.Salario = entity.Salario;
                funcionarioBD.TipoFuncionario = entity.TipoFuncionario;

                base.Put(funcionarioBD);

                var listaDependenteBD = adDependente
                    .Query(x => x.IdFuncionario == entity.IdFuncionario)
                    .ToList();

                listaDependenteBD.ForEach(item => { adDependente.Delete(item); });

                entity.Dependente.ToList()
                    .ForEach(item => 
                    {
                        item.IdFuncionario = funcionarioBD.IdFuncionario;
                        adDependente.Post(item);
                    });

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }

        public override void Delete(Funcionario entity)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var adDependente = unitOfWork.DependenteRepository;

                var listaDependente = adDependente
                    .Query(x => x.IdFuncionario == entity.IdFuncionario)
                    .ToList();

                listaDependente.ForEach(item => { adDependente.Delete(item); });

                var funcionarioBD = base.Get(entity.IdFuncionario);

                if (funcionarioBD == null)
                    throw new Exception("Funcionário não encontrado.");

                base.Delete(funcionarioBD);

                unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}
