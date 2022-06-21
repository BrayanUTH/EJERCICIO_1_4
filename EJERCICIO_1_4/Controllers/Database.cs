using EJERCICIO_1_4.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EJERCICIO_1_4.Controllers
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Employee>();
        }

        public Task<int> CreateOrUpdateEmployee(Employee employee)
        {
            if (employee.id != 0)
            {
                return database.UpdateAsync(employee);
            }
            else
            {
                return database.InsertAsync(employee);
            }
        }

        public Task<List<Employee>> GetAllEmployee()
        {
            return database.Table<Employee>().ToListAsync();
        }
    }
}
