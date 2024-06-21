using AutoMapper;
using Graduation_Project.DTO.OrderDto;
using Graduation_Project.DTO.WorkerDto;
using Graduation_Project.Models;
using Graduation_Project.Services;
using Microsoft.EntityFrameworkCore;

namespace Graduation_Project.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private readonly Context context;
        private readonly IMapper _mapper;
        public OrderRepository(Context context, IMapper _mapper)
        {
            this.context = context;
            this._mapper = _mapper;

        }
        public void Add(OrderClientDto orderDto)
        {
            Order newOrder= new Order();
            newOrder.ID= orderDto.ID;
            List<string> clientName= orderDto.ClientName.Split(" ").ToList();
            var clientId = context.Clients.FirstOrDefault(c => c.FName == clientName[0] 
            && c.LName == clientName[1]).ID;
            newOrder.ClientId= clientId;
            newOrder.WorkerId = 7;
            newOrder.Date = orderDto.Date;
            newOrder.Time = orderDto.Time;
            newOrder.ClientAddress= orderDto.ClientAddress;
            newOrder.Phone = orderDto.Phone;
            newOrder.Problem= orderDto.Problem;
            newOrder.typeOfOrder = (Models.TypeOfOrder)orderDto.typeOfOrder;
            newOrder.typeOfPayment = (Models.TypeOfPayment)orderDto.typeOfPayment;
            newOrder.AdminId = 1;
            context.Orders.Add(newOrder);
            context.SaveChanges();
            //Send notification to client
            Notifications ClientNoti = new Notifications();
            ClientNoti.ClientId = newOrder.ClientId;
            string msgC = "Order Done , The Worker will arrive soon.";
            ClientNoti.Messege = msgC;
            context.Notifications.Add(ClientNoti);
            context.SaveChanges();
        }
        //order by admin
        public void Edit(int id, OrderAdminDto orderAdminDto)
        {
            Order order=context.Orders.FirstOrDefault(o => o.ID==id);
            string AdminName=orderAdminDto.AdminName;
            int AdminId=context.Admins.FirstOrDefault(a=>a.Name==AdminName).ID;
            order.AdminId= AdminId;
            string WorkerName=orderAdminDto.WorkerName;
            int WorkerId=context.Workers.FirstOrDefault(w=>w.Name==WorkerName).ID;
            order.WorkerId= WorkerId;
            context.SaveChanges();
            //send notification to worker 
            Notifications workernoti = new Notifications();
            string clientFName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).FName;
            string clientLName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).LName;
            workernoti.WorkerId= WorkerId;
            string msg = $"This is your Order to {clientFName} {clientLName} , his address" +
                $" {order.ClientAddress} , his Phone Number {order.Phone} , his problem {order.Problem}" +
                $" in Date {order.Date} at Time {order.Time}";
            workernoti.Messege = msg;
            context.Notifications.Add(workernoti);
            context.SaveChanges();
            //Send notification to client
            Notifications ClientNoti=new Notifications();
            ClientNoti.ClientId= order.ClientId;
            string msgC = "Order Done , The Worker will arrive at Time";
            ClientNoti.Messege = msgC;
            context.Notifications.Add(ClientNoti);
            context.SaveChanges();
               
        }
        public List<OrderDto> GetAll()
        {
            var orders = context.Orders.ToList();
            List<OrderDto> ordersDto=new List<OrderDto>();
            if(!orders.Any())
                return null;
            foreach(var order in orders)
            {
                OrderDto orderDto = new OrderDto();
                orderDto.ID = order.ID;
                string clientFName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).FName;
                string clientLName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).LName;
                orderDto.ClientName = clientFName+" "+clientLName;
                orderDto.WorkerName = context.Workers.FirstOrDefault(w => w.ID == order.WorkerId).Name;
                orderDto.Date=order.Date;
                orderDto.Time=order.Time;
                orderDto.ClientAddress= order.ClientAddress;
                orderDto.Phone = order.Phone;
                orderDto.Problem = order.Problem;
                orderDto.typeOfOrder = (DTO.OrderDto.TypeOfOrder)order.typeOfOrder;
                orderDto.typeOfPayment= (DTO.OrderDto.TypeOfPayment)order.typeOfPayment;
                orderDto.AdminName = context.Admins.FirstOrDefault(a => a.ID == order.AdminId).Name;
                ordersDto.Add(orderDto);    
            }
            return ordersDto;

        }
        public OrderClientDto GetById(int id)
        {
            Order order=context.Orders.FirstOrDefault(o=>o.ID == id);
            OrderClientDto orderdto = new OrderClientDto();
            if (order == null)
                return null;
            orderdto.ID = order.ID;
            string clientFName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).FName;
            string clientLName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).LName;
            orderdto.ClientName = clientFName + " " + clientLName;
            orderdto.Date = order.Date;
            orderdto.Time= order.Time;
            orderdto.ClientAddress = order.ClientAddress;
            orderdto.Phone = order.Phone;
            orderdto.Problem = order.Problem;
            orderdto.typeOfOrder = (DTO.OrderDto.TypeOfOrder)order.typeOfOrder;
            orderdto.typeOfPayment= (DTO.OrderDto.TypeOfPayment)order.typeOfPayment;
            return orderdto;
        }
        public List<GetAllOrdersClientDto> GetOrdersById(int id)
        {
            var orders = context.Orders.Where(o=>o.ClientId==id).ToList();
            List<GetAllOrdersClientDto> ordersDto= new List<GetAllOrdersClientDto>();
            if (!orders.Any())
                return null;
            foreach(var order in orders)
            {
                GetAllOrdersClientDto orderClientDto = new GetAllOrdersClientDto();
                orderClientDto.ID = order.ID;
                var WorkerId = order.WorkerId;
                orderClientDto.WorkerName = context.Workers.FirstOrDefault(w => w.ID == WorkerId).Name;
                orderClientDto.Date= order.Date;
                orderClientDto.Time= order.Time;
                orderClientDto.ClientAddress= order.ClientAddress;
                orderClientDto.Phone = order.Phone;
                orderClientDto.Problem = order.Problem;
                orderClientDto.typeOfOrder = (DTO.OrderDto.TypeOfOrder)order.typeOfOrder;
                orderClientDto.typeOfPayment = (DTO.OrderDto.TypeOfPayment)order.typeOfPayment;
                ordersDto.Add(orderClientDto);
                
            }    
            return ordersDto;
        }

        public void EditOrder(int id, OrderClientDto orderDto)
        {
            Order Order = context.Orders.FirstOrDefault(o => o.ID == id);
            List<string> clientName = orderDto.ClientName.Split(" ").ToList();
            var clientId = context.Clients.FirstOrDefault(c => c.FName == clientName[0]
            && c.LName == clientName[1]).ID;
            Order.ClientId = clientId;
            Order.Date = orderDto.Date;
            Order.Time = orderDto.Time;
            Order.ClientAddress = orderDto.ClientAddress;
            Order.Phone = orderDto.Phone;
            Order.Problem = orderDto.Problem;
            Order.typeOfOrder = (Models.TypeOfOrder)orderDto.typeOfOrder;
            Order.typeOfPayment = (Models.TypeOfPayment)orderDto.typeOfPayment;
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var order = context.Orders.FirstOrDefault(o=>o.ID == id);

            //send notification to client and worker about canceling the order
            Notifications workernoti = new Notifications();
            var clientId = order.ClientId;
            string clientFName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).FName;
            string clientLName = context.Clients.FirstOrDefault(a => a.ID == order.ClientId).LName;
            workernoti.WorkerId = order.WorkerId;
            string msg = $"The Order to {clientFName} {clientLName} in Date {order.Date} Time {order.Time}was canceled.";
            workernoti.Messege = msg;
            context.Notifications.Add(workernoti);
            context.SaveChanges();
            //Send notification to client
            Notifications ClientNoti = new Notifications();
            ClientNoti.ClientId = order.ClientId;
            string msgC = "Order Deleted Successfully. ";
            ClientNoti.Messege = msgC;
            context.Notifications.Add(ClientNoti);
            context.SaveChanges();

            context.Orders.Remove(order);
            context.SaveChanges();

            
        }
    }
}
