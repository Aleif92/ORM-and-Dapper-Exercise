namespace ORM_Dapper;

public interface IDdepartmentRepository
{
    public IEnumerable<Department> GetAllDepartments();
}