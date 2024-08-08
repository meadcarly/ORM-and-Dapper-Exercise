using System;
using System.Collections.Generic;
namespace ORM_Dapper;

public interface IDepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
    
    public void InsertDepartment(string newDepartmentName);
}