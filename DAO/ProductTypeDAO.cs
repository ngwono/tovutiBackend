using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class ProductTypeDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        public bool createProductType(ProductType productType)
        {
            database = new DatabaseConnection();
            database.updateCommand("insert into product_type_tbl(description) values (@description)");
            database.addValue("description", productType.description);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public bool updateProductType(ProductType productType)
        {
            database = new DatabaseConnection();
            database.updateCommand("update product_type_tbl set description=@description where id=@id");
            database.addValue("description", productType.description);
            database.addValue("id", productType.id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public List<ProductType> getProductTypeList()
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from product_type_tbl order by id asc");
            sqlDataReader = database.query();
            List<ProductType> productTypeList = new List<ProductType>();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    ProductType productType  = new ProductType();
                    productType.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productType.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    productTypeList.Add(productType);
                }
            }
            database.close();
            return productTypeList;
        }
        public ProductType getProductType(string productTypeId)
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from product_type_tbl where id=@productTypeId");
            database.addValue("productTypeId", productTypeId);
            sqlDataReader = database.query();
            ProductType productType = new ProductType();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    productType.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productType.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                }
            }
            database.close();
            return productType;
        }

        public bool deleteProductType(string id)
        {
            database = new DatabaseConnection();
            database.updateCommand("delete from product_type_tbl where id=@id");
            database.addValue("id", id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
    }
}