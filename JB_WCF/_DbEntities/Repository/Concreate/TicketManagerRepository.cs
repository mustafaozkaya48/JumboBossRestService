
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
    public class TicketManagerRepository
    {
        private IRepository<Ticket> _TicketRepository;
        private IUnitOfWork _TicketsUnitofWork;
        private DbContext _dbContext;
        public TicketManagerRepository()
        {
            _dbContext = new JumboBossEntities();
            _TicketRepository = new EFRepository<Ticket>(_dbContext);
            _TicketsUnitofWork = new EFUnitOfWork(_dbContext);
        }

        public Ticket GetTicket(string TableName)
        {
            return _TicketRepository.Get(x => x.TableName == TableName && x.IsClosed == false);
        }
        public Ticket SetTicket(Ticket ticket)
        {
            _TicketRepository.Insert(ticket);
          
            return _TicketRepository.Get(x=>x.TableName==ticket.TableName&&x.IsClosed==ticket.IsClosed&&x.IsLocked==ticket.IsLocked);
        }
        public void UpdateTicket(Ticket ticket)
        {
            _TicketRepository.Updete(ticket);
        }

    }
}
