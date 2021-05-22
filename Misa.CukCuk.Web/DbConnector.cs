using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MISA.DemoAPI.Modals;
using MySql.Data.MySqlClient;

namespace Misa.CukCuk.Web
{
    public class DbConnector
    {
        public static string connectionString = "User Id=nvmanh;Host=103.124.92.43;Database=Ms2_13_VSH; port=3306;password =12345678;Character Set=utf8";
        IDbConnection dbConnection;
        public DbConnector()
        {
            dbConnection = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Lấy tất cả dữ liệu trong bảng thuộc kiểu tôeng quát
        /// </summary>
        /// <typeparam name="TEntity">Kiểu đối tượng cần truy xuất</typeparam>
        /// <returns>Tất cả dữ liệu</returns>
        public IEnumerable<TEntity> GetAllData<TEntity>()
        {
                var tableName = typeof(TEntity).Name;
                var storeName = $"Proc_Get{tableName}";
                var entity = dbConnection.Query<TEntity>(storeName, commandType: CommandType.StoredProcedure);
                return entity;
        }
        /// <summary>
        /// Lấy dữ liệu theo commandText truyền vào
        /// </summary>
        /// <typeparam name="H">kiểu của object</typeparam>
        /// <param name="commandText">mã SQL</param>
        /// <returns>mảng object lấy từ DB</returns>
        public IEnumerable<H> GetDataByCommand<H>(string commandText)
        {
            var tableName = typeof(H).Name;
            var sql = commandText;
            var entity = dbConnection.Query<H>(sql);
            return entity;
        }    
        public IEnumerable<H> GetById<H>(string id)
        {
            var tableName = typeof(H).Name;
            var storeName = $"Proc_Get{tableName}ById";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Thêm bộ danh sách động key,value với tên bảng và tham số truyền vào tương ứng
            dynamicParameters.Add($"@{tableName}Id",id);
            var entity = dbConnection.Query<H>(storeName,dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }
        //Lấy dữ liệu qua mã và số điện thoại
        public IEnumerable<H> GetDataByCodeandPhone<H>(string code, string phone)
        {
            var tableName = typeof(H).Name;
            var storeName = $"Proc_Get{tableName}ByCodeandPhoneNumber";
            DynamicParameters dynamicParameters = new DynamicParameters();
            //Thêm bộ danh sách động key,value với tên b và tham số truyền vào tương ứng
            dynamicParameters.Add($"@EmployeeCode", code);
            dynamicParameters.Add($"@PhoneNumber", phone);
            var entity = dbConnection.Query<H>(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            return entity;
        }

        public int Insert<H>(H entity)
        {
            var tableName = typeof(H).Name;
            var employee = entity as Employee;
            var storeName = $"Proc_Insert{tableName}";
            DynamicParameters dynamicParameters = new DynamicParameters();
            var properties = typeof(H).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                dynamicParameters.Add($"@{propertyName}", propertyValue);
            }
            var affects = dbConnection.Execute(storeName, dynamicParameters, commandType: CommandType.StoredProcedure);
            //Phải truyền đủ các properties
            return affects;
        }
    }
}
