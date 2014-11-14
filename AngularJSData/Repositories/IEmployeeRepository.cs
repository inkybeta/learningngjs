using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AngularJSCore;

namespace AngularJSData.Repositories
{
    public interface IEmployeeRepository
    {
        Task<EmployeeModel> GetEmployeeByNumber(int id);
        Task<EmployeeModel[]> GetEmployeesByName(string name);
        Task<EmployeeModel[]> GetEmployees(int count, int skip);
        Task<EmployeeModel[]> GetEmployeesByAge(int age);
        Task<EmployeeModel[]> GetEmployeesByJob(string job);
        Task<EmployeeModel[]> GetEmployeesByPerformance(int performance);
        Task<EmployeeModel[]> GetEmployeesByGroup(string group);
        Task<bool> AddEmployee(EmployeeModel employee);
        Task<bool> RemoveEmployee(EmployeeModel employee);
        Task<int> GetEmployeeCount();
        Task SaveChanges();
    }
}
