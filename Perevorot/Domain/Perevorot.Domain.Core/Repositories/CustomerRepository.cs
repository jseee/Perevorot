﻿
using System.Linq;
using Perevorot.Domain.Core.Infrastructure;
using Perevorot.Domain.IRepositories;
using Perevorot.Domain.Models.DomainEntities;

namespace Perevorot.Domain.Core.Repositories
{
    public class CustomerRepository : Repository, ICustomerRepository
    {
        public User GetUserByUserNameAndPassword(string username, string password)
        {
            var perevorotContext = Session;
            var result = from u in perevorotContext.Users
                         where u.UserName == username 
                             select u;
            
            return result.FirstOrDefault();
        }

        public void AddNewCustomer(string name)
        {
            var perevorotContext = Session;
            var newCustomer = new Customer(name);
            perevorotContext.Customers.Add(newCustomer);

            perevorotContext.SaveChanges();


        }

        public void Save(Customer user)
        {
            throw new System.NotImplementedException();
        }
    }
}