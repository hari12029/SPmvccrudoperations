using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPmvccrudoperations.Repository
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee GetById(int Employeeid);
        void Add(Employee emp);
        void Update(Employee emp);
        void Delete(int EmployeeId);
        void save();

    }

}
