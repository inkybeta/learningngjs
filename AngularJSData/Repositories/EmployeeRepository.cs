using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularJSCore;

namespace AngularJSData.Repositories
{
    public class EmployeeRepository:IEmployeeRepository
    {
        private readonly EmployeeContext _dbContext;

        public EmployeeRepository(EmployeeContext dataContext)
        {
            _dbContext = dataContext;
        }

        public async Task<EmployeeModel> GetEmployeeByNumber(int id)
        {
            return await
                _dbContext.EmployeeDataSet.Where(c => c.EmployeeNumber == id)
                    .Select(
                        c =>
                            new EmployeeModel()
                            {
                                Age = c.Age,
                                Group = c.Group,
                                Job = c.Job,
                                EmployeeNumber = c.EmployeeNumber,
                                Name = c.Name,
                                Performance = c.Performance
                            }).FirstAsync();
        }

        public async Task<EmployeeModel[]> GetEmployeesByAge(int age)
        {
            return await _dbContext.EmployeeDataSet.Where(c => c.Age == age).ToArrayAsync();
        }

        public async Task<EmployeeModel[]> GetEmployeesByGroup(string group)
        {
            return await _dbContext.EmployeeDataSet.Where(c => c.Group == group).ToArrayAsync();
        }

        public async Task<EmployeeModel[]> GetEmployeesByName(string name)
        {
            return await _dbContext.EmployeeDataSet.Where(c => c.Name == name).ToArrayAsync();
        }

        public async Task<EmployeeModel[]> GetEmployeesByJob(string job)
        {
            return await _dbContext.EmployeeDataSet.Where(c => c.Job == job).ToArrayAsync();
        }

        public async Task<EmployeeModel[]> GetEmployeesByPerformance(int performance)
        {
            return await _dbContext.EmployeeDataSet.Where(c => c.Performance == performance).ToArrayAsync();
        }

        public async Task<int> GetEmployeeCount()
        {
            return await _dbContext.EmployeeDataSet.CountAsync();
        }

        public async Task<EmployeeModel[]> GetEmployees(int count, int skip)
        {
            return await _dbContext.EmployeeDataSet.OrderBy(c => c.Name).Skip(skip).Take(count).ToArrayAsync();
        }
        public async Task SaveChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
        public async Task<bool> RemoveEmployee(EmployeeModel employee)
        {
            bool successful = _dbContext.EmployeeDataSet.Remove(employee) != null;
            await SaveChanges();
            return successful;
        }

        public async Task<bool> AddEmployee(EmployeeModel employee)
        {
            if(employee == null)
                throw new ArgumentNullException("employee", "The employee model was null.");
            bool successful = _dbContext.EmployeeDataSet.Add(employee) != null;
            await SaveChanges();
            return successful;
        }
    }
}
