using System.Collections.Generic;
using System.Web.Http;
using ApiDiscloser.Example.Models;

namespace ApiDiscloser.Example.Controllers
{
    /// <summary>
    /// Manage orders
    /// </summary>
    /// <remarks>
    /// API for orders. This API enables consumers to retrieve, create, update and delete orders.
    /// </remarks>
    public class OrdersController : ApiController
    {
        /// <summary>
        /// Get orders
        /// </summary>
        /// <returns>Array of orders</returns>
        public IEnumerable<Order> Get()
        {
            return new List<Order>
            {
                new Order
                {
                    ClientId = 1, 
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine { Amount = 45.95m, Description = "Skylanders Swapforce" },
                        new OrderLine { Amount = 65.95m, Description = "Mario Bros" }
                    }
                },
                new Order
                {
                    ClientId = 2, 
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine { Amount = 67.95m, Description = "Battlefield" },
                        new OrderLine { Amount = 23.95m, Description = "Mr. Egg" }
                    }
                }
            };
            
        }

        /// <summary>
        /// Get order by id
        /// </summary>
        /// <param name="id">Unique identifier of order</param>
        /// <returns>Order</returns>
        public Order Get(int id)
        {
            return new Order
                {
                    ClientId = 1,
                    OrderLines = new List<OrderLine>
                    {
                        new OrderLine { Amount = 45.95m, Description = "Skylanders Swapforce" },
                        new OrderLine { Amount = 65.95m, Description = "Mario Bros" }
                    }
                };
        }
        
        /// <summary>
        /// Updates order
        /// </summary>
        /// <param name="id">Unique identifier of order</param>
        /// <param name="order">Value</param>
        /// <example>
        /// curl    -h "gfdlkgd"
        ///         -h "dfgdgdf"
        /// 
        /// </example>
        public void Put(int id, Order order)
        {
        }

        /// <summary>
        /// Deletes order
        /// </summary>
        /// <param name="id">Unique identifier of order</param>
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Creates new order
        /// </summary>
        /// <param name="order">Order</param>
        public void Post(Order order)
        {
        }
    }
}
