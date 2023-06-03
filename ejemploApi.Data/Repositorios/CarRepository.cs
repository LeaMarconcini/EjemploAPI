using Dapper;
using ejemploApi.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ejemploApi.Data.Repositorios
{
    public class CarRepository : ICarRepository
    {
        private readonly MySQLConfiguration _connectionString;
        public CarRepository(MySQLConfiguration connectionString) 
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public async Task<bool> DeleteCar(Car car)
        {
            var db = dbConnection();
            var sql = @"DELETE FROM cars WHERE id= @id";
            var result = await db.ExecuteAsync(sql, new { id = car.id });
            return result > 0;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            var db = dbConnection();
            var sql = @"SELECT id, make, model, color, years, doors FROM cars";

            return await db.QueryAsync<Car>(sql, new { });
        }

        public async Task<Car> GetDetails(int id)
        {
            var db = dbConnection();
            var sql = @"SELECT id, make, model, color, years, doors
                        FROM cars 
                        WHERE id = @id";

            return await db.QueryFirstOrDefaultAsync<Car>(sql, new { id = id });
        }

        public async Task<bool> InsertCar(Car car)
        {
            var db = dbConnection();
            var sql = @"INSERT INTO cars (make, model, color, years, doors)
                        values (@make, @model, @color, @years, @doors";

            var result = await db.ExecuteAsync(sql, new 
            { car.make, car.model, car.color, car.years, car.doors });
            return result > 0;
        }   

        public async Task<bool> UpdateCar(Car car)
        {
            var db = dbConnection();
            var sql = @"UPDATE cars
                        SET make=@make,
                        model=@model,
                        color=@color,
                        years=@years,
                        doors=@doors
                        WHERE id = @id
                        ";

            var result = await db.ExecuteAsync(sql, new
            { car.make, car.model, car.color, car.years, car.doors, car.id});
            return result > 0;
        }
    }
}
