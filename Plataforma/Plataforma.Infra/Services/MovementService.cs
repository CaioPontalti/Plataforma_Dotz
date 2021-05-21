using Plataforma.Domain.Entities;
using Plataforma.Domain.Enums;
using Plataforma.Domain.Interfaces;
using Plataforma.Domain.Response.Balance;
using Plataforma.Domain.ViewModels.Balance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plataforma.Infra.Services
{
    public class MovementService : IMovementService
    {
        private readonly IMovementRepository _movementRepository;

        public MovementService(IMovementRepository movementRepository)
        {
            _movementRepository = movementRepository;
        }

        public async Task<BalanceUserResponse> Balance(string id)
        {
            try
            {
                BalanceUserResponse balance = null;
                var extract = await _movementRepository.Extract(id);
                if (extract != null)
                {
                    balance = new BalanceUserResponse();

                    var credit = extract.Where(c => c.TypeMovement == (int)EMovementType.Credit).Sum(c=>c.Points);
                    var debit = extract.Where(c => c.TypeMovement == (int)EMovementType.Debit).Sum(c => c.Points);

                    balance.TotalCredit = credit;
                    balance.TotalDebit = debit;
                    balance.Total = credit - debit;
                }

                return await Task.FromResult(balance);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<BalanceResponse> CreateMovement(CreateMovementViewModel model)
        {
            try
            {
                var entity = new Balance()
                {
                    UserId = model.UserId,
                    Points = model.Points,
                    TypeMovement = (int)model.Type
                };

                var balanceCreate = await _movementRepository.Create(entity);

                BalanceResponse response = new BalanceResponse()
                {
                    Id = balanceCreate.Id,
                    UserId = balanceCreate.UserId,
                    Points = balanceCreate.Points,
                    TypeMovement = Enum.GetName(typeof(EMovementType), balanceCreate.TypeMovement)
                };

                return await Task.FromResult(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<ExtractResponse>> Extract(string id)
        {
            try
            {
                var extract = await _movementRepository.Extract(id);
                List<ExtractResponse> extractLst = null;
                if (extract != null)
                {
                    extractLst = new List<ExtractResponse>();
                    foreach (var item in extract)
                    {
                        var ext = new ExtractResponse()
                        {
                            Id = item.Id,
                            Points = item.Points,
                            TypeMovement = Enum.GetName(typeof(EMovementType), item.TypeMovement)
                        };

                        extractLst.Add(ext);
                    }
                }
                return await Task.FromResult(extractLst);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
