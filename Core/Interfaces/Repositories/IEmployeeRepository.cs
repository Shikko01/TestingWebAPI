﻿using Core.Entities;

namespace Core.Interfaces.Repositories
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesAboveAge(int targetAge);
    }
}
