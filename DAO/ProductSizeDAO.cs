using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class ProductSizeDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        public bool createProductSize(ProductSize productSize)
        {
            database = new DatabaseConnection();
            database.updateCommand("insert into size_tbl(abbreviation,description) values (@abbreviation,@description)");
            database.addValue("abbreviation", productSize.abbreviation);
            database.addValue("description", productSize.description);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public bool updateProductSize(ProductSize productSize)
        {
            database = new DatabaseConnection();
            database.updateCommand("update size_tbl set abbreviation=@abbreviation,description=@description where id=@id");
            database.addValue("abbreviation", productSize.abbreviation);
            database.addValue("description", productSize.description);
            database.addValue("id", productSize.id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public List<ProductSize> getProductSizeList()
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from size_tbl order by id asc");
            sqlDataReader = database.query();
            List<ProductSize> productSizeList = new List<ProductSize>();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    ProductSize productSize = new ProductSize();
                    productSize.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productSize.abbreviation = sqlDataReader.GetString(sqlDataReader.GetOrdinal("abbreviation"));
                    productSize.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    productSizeList.Add(productSize);
                }
            }
            database.close();
            return productSizeList;
        }
        public ProductSize getProductSize(string productsizeId)
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from size_tbl where id=@productsizeId");
            database.addValue("productsizeId", productsizeId);
            sqlDataReader = database.query();
            ProductSize productSize = new ProductSize();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    productSize.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productSize.abbreviation = sqlDataReader.GetString(sqlDataReader.GetOrdinal("abbreviation"));
                    productSize.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                }
            }
            database.close();
            return productSize;
        }

        public bool deleteProductSize(string id)
        {
            database = new DatabaseConnection();
            database.updateCommand("delete from size_tbl where id=@id");
            database.addValue("id", id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
    }
}