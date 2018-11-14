using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Common;

namespace ACM.BL
{
    public class OrderController
    {
        public CustomerRepository customerRepository { get; set; }
        public OrderRepository orderRepository { get; set; }
        public InventoryRepository inventoryRepository { get; set; }
        public EmailLibrary emailLibrary { get; set; }
        
        public OrderController()
        {
            customerRepository = new CustomerRepository();
            orderRepository = new OrderRepository();
            inventoryRepository = new InventoryRepository();
            emailLibrary = new EmailLibrary();
            
        }

        public void PlaceOrder(Customer customer,
                                Order order, Payment payment, 
                                bool allowSplitOrders, bool emailReceipt)
        {
            customerRepository = new CustomerRepository();
            customerRepository.Add(customer);

            orderRepository = new OrderRepository();
            orderRepository.Add(order);

            inventoryRepository = new InventoryRepository();
            inventoryRepository.OrderItems(order, allowSplitOrders);

            payment.ProcessPayment();

            if (emailReceipt)
            {
                customer.ValidateEmail();
                customerRepository.Update();

                emailLibrary = new EmailLibrary();
                emailLibrary.SendEmail(customer.EmailAddress,
                    "Here is your receipt");
            }
        }
    }
}
