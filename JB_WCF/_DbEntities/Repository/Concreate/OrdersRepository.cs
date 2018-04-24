
using _DbEntities.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _DbEntities.Repository.Concreate
{
     public class OrdersRepository
    {
        private IRepository<Order> _OrderRepository;
        private IUnitOfWork _OrderUnitofWork;
        private DbContext _dbContext;
        public OrdersRepository()
        {
            _dbContext = new JumboBossEntities();
            _OrderRepository = new EFRepository<Order>(_dbContext);
            _OrderUnitofWork = new EFUnitOfWork(_dbContext);
        }

        public bool InsertOrders(Order order)
        {
            if (_OrderRepository.Insert(order) > 0) return true;
            else return false;
        }

        public int GetOrderNumber(string TableName)
        {
            Order order = new Order();
            return 0;
        }
        public List<Order> OrderList(int TicketId)
        {
            return _OrderRepository.GetAll(X=>X.TicketId==TicketId).ToList(); 
        }
        public Order GetOrder(int TicketId,string ItemName)
        {
            return _OrderRepository.Get(x=>x.ItemName==ItemName&&x.TicketId== TicketId);
        }
        public void OrderUpdate(Order order)
        {
            _OrderRepository.Updete(order);
        }

        

    }

}
