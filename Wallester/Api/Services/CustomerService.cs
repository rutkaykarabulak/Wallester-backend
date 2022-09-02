using Wallester.Api.DbModels;
using Wallester.Api.EFModels;
using Customer = Wallester.Api.DbModels.Customer;
using Microsoft.EntityFrameworkCore;
using static Wallester.Api.CommonTypes;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Wallester.Api.Services
{
    public class CustomerService: ICustomerService
    {
        private PostgresDbContext _postgreDbContext;

        public CustomerService(PostgresDbContext dbContext)
        {
            _postgreDbContext = dbContext;
        }

        public void Create(Customer customer)
        {
            Random random = new();
            EFModels.Customer customerModel = new EFModels.Customer() {
                Id = random.Next(1, 1000),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                FullName = customer.FullName,
                Gender = customer.Gender,
                BirthDate = DateTime.SpecifyKind(customer.BirthDate, DateTimeKind.Utc),
                Email = customer.Email,
                Address = customer.Address,
                DateCreated = DateTime.SpecifyKind(DateTime.Now, DateTimeKind.Utc),
                CountryOfBirth = customer.CountryOfBirth,
                Title = customer.Title,
                MarialStatus = customer.MarialStatus,
                EmploymentStatus = customer.EmploymentStatus,
                Type = customer.Type
            };

            _postgreDbContext.Customers.Add(customerModel);
            _postgreDbContext.SaveChanges();
        }

        public List<Customer> GetAll()
        {
            List<Customer> response = new List<Customer>();
            List<EFModels.Customer> customerRepo = _postgreDbContext.Customers.ToList();
            customerRepo.ForEach(row => response.Add(new Customer()
            {
                Id = row.Id,
                FirstName = row.FirstName,
                LastName = row.LastName,
                FullName = row.FullName,
                BirthDate = row.BirthDate,
                Gender = row.Gender,
                Email = row.Email,
                Address = row.Address,
                DateCreated = row.DateCreated,
                CountryOfBirth = row.CountryOfBirth,
                Title = row.Title,
                MarialStatus = row.MarialStatus,
                EmploymentStatus = row.EmploymentStatus,
                Type = row.Type,
                
            }));
            return response;
        }

        public async Task<Customer>? GetCustomer(int id)
        {
            EFModels.Customer? row = await _postgreDbContext.Customers.FindAsync(id);

            if(row == null)
            {
                return null;
            }

            return new Customer()
            {
                Id = row.Id,
                FirstName = row.FirstName,
                LastName = row.LastName,
                FullName = row.FullName,
                BirthDate = row.BirthDate,
                Gender = row.Gender,
                Email = row.Email,
                Address = row.Address,
                DateCreated = row.DateCreated,
                CountryOfBirth = row.CountryOfBirth,
                Title = row.Title,
                MarialStatus = row.MarialStatus,
                EmploymentStatus = row.EmploymentStatus,
                Type = row.Type,
            };
        }

        public async Task<bool> Remove(int id)
        {
            EFModels.Customer? customer = new();
            customer = await _postgreDbContext.Customers.FindAsync(id);


            if (customer == null)
            {
                return false;
            }

            _postgreDbContext.Remove(customer);
            _postgreDbContext.SaveChanges();

            return true;
        }

        public async Task<bool> Update(CustomerPut customerPut)
        {
            EFModels.Customer? customer = new();
            customer = await _postgreDbContext.Customers.FindAsync(customerPut.Id);

            if(customer == null)
            {
                return false;
            }

            customerPut.IsNullCheckAndSet(customer);

            _postgreDbContext.SaveChanges();
            return true;
        }
    }

    public class CustomerPut
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public DateTime? BirthDate { get; set; }
        public GenderType? Gender { get; set; }

        public string? Email { get; set; }
        public string? Address { get; set; }


        public string? CountryOfBirth { get; set; }

        public TitleType? Title { get; set; }

        public MarialStatus? MarialStatus { get; set; }

        public EmploymentStatus? EmploymentStatus { get; set; }

        public CustomerType? Type { get; set; }

        public void IsNullCheckAndSet(EFModels.Customer customerToUpdate)
        {
            if (!string.IsNullOrEmpty(FirstName))
            {
                customerToUpdate.FirstName = FirstName;
            }
            if (!string.IsNullOrEmpty(LastName))
            {
                customerToUpdate.LastName = LastName;
            }
            if (!string.IsNullOrEmpty(FullName))
            {
                customerToUpdate.FullName = FullName;
            }
            if (BirthDate.HasValue)
            {
                customerToUpdate.BirthDate = BirthDate.Value;
            }
            if (Gender.HasValue)
            {
                customerToUpdate.Gender = Gender.Value;
            }
            if (!string.IsNullOrEmpty(Email))
            {
                customerToUpdate.Email = Email;
            }
            if (!string.IsNullOrEmpty(Address))
            {
                customerToUpdate.Address = Address;
            }
            if (!string.IsNullOrEmpty(CountryOfBirth))
            {
                customerToUpdate.CountryOfBirth = CountryOfBirth;
            }
            if (Title.HasValue)
            {
                customerToUpdate.Title = Title.Value;
            }
            if (MarialStatus.HasValue)
            {
                customerToUpdate.MarialStatus = MarialStatus.Value;
            }
            if (EmploymentStatus.HasValue)
            {
                customerToUpdate.EmploymentStatus = EmploymentStatus.Value;
            }
            if (Type.HasValue)
            {
                customerToUpdate.Type = Type.Value;
            }

        }
    }
}
