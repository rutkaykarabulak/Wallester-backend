using Wallester.Api.DbModels;

namespace Wallester.Api.Services
{
    /// <summary>
    /// This interfaces is used to handle CRUD operations on customer.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Gets all customer records in database.
        /// </summary>
        /// <returns>List of customers</returns>
        public abstract List<Customer> GetAll();

        /// <summary>
        /// Gets customer with specified id
        /// </summary>
        /// <param name="id">id of customer</param>
        /// <returns>Customer if given id is exist in our database, null otherwise.</returns>
        public abstract Task<Customer>? GetCustomer(int id);

        /// <summary>
        /// Creates a customer from a given object.
        /// </summary>
        /// <param name="customer"></param>
        public abstract void Create(Customer customer);

        /// <summary>
        /// Removes a customer with given id
        /// Id must be a valid id that exists in our database, otherwise operation won't be succeed.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>True, if operation is successfull, false otherwise</returns>
        public abstract Task<bool> Remove(int id);

        /// <summary>
        /// Updates the customer with given put object
        /// </summary>
        /// <returns>True, if operation is successfull, false otherwise</returns>
        public abstract Task<bool> Update(CustomerPut customerPut);
    }
}
