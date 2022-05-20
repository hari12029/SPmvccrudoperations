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
        void Add(Employee obj);
        void Update(Employee obj);
        void Delete(int EmployeeId);
        void save();

    }

}
