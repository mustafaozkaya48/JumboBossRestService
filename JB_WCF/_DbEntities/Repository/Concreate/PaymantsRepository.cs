
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class PaymantsRepository
    {
        private IRepository<Payment> _PaymentsRepository;
        private IUnitOfWork _PaymentsUnitofWork;
        private DbContext _dbContext;
        public PaymantsRepository()
        {
            _dbContext = new JumboBossEntities();
            _PaymentsRepository = new EFRepository<Payment>(_dbContext);
            _PaymentsUnitofWork = new EFUnitOfWork(_dbContext);
        }
        public List<Payment> PaymantsAdd(Payment payment)
        {
            _PaymentsRepository.Insert(payment);

            return _PaymentsRepository.GetAll(x => x.OrderNumber == payment.OrderNumber).ToList(); 
        }
        public List<Payment> GetList(int TicketId)
        {
            return _PaymentsRepository.GetAll(x=>x.OrderNumber==TicketId).ToList();
        }

    }
}
