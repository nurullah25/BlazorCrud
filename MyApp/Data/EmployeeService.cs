using Microsoft.EntityFrameworkCore;

namespace MyApp.Data
{
    public class EmployeeService
    {
        private readonly IDbContextFactory<EmployeeDbContext> _contextFactory;
        public EmployeeService(IDbContextFactory<EmployeeDbContext> contextFactory)
        {
            this._contextFactory = contextFactory;
        }
        public async Task<List<Employee>> GetAll()
        {
            using (var _dbContext = _contextFactory.CreateDbContext())
            {
                try
                {
                    return await _dbContext.Employees.ToListAsync();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<bool> InsertOrUpdateEmployee(Employee obj,string action)
        {
            using(var _dbContext=_contextFactory.CreateDbContext())
            {
                try
                {
                    if (action == "add")
                    {
                        obj.Id = 0;
                        await _dbContext.Employees.AddAsync(obj);
                        await _dbContext.SaveChangesAsync();
                    }
                    else
                    {
                        _dbContext.Employees.Update(obj);
                        await _dbContext.SaveChangesAsync();
                    }
                    return true;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public async Task<Employee> GetDataById(long id)
        {
            using (var _dbContext = _contextFactory.CreateDbContext())
            {
                try
                {
                    return await _dbContext.Employees.FirstOrDefaultAsync(t => t.Id == id);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        public async Task<bool> DeleteDataById(long id)
        {
            using(var _dbContext = _contextFactory.CreateDbContext())
            {
                try
                {
                    bool result = false;
                    Employee obj = await GetDataById(id);
                    if (obj!= null)
                    {
                        _dbContext.Employees.Remove(obj);
                        await _dbContext.SaveChangesAsync();
                        result= true;
                    }
                    return result;
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
    }
}
