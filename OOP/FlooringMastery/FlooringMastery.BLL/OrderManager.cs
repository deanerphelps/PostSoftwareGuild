using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public OrderLookupResponse LookupOrder(string orderNumber)
        {
            OrderLookupResponse response = new OrderLookupResponse();

            response.Order = _orderRepository.LoadOrder(orderNumber);

            if(!response.Order.OrderNumber.Equals(orderNumber) && orderNumber == null) //TODO Stop this from breaking!
            {
                response.Success = false;
                response.Message = $"{orderNumber} does not exist.";
                return response;
            }
            response.Success = true;
            return response;
        }
    }
}
