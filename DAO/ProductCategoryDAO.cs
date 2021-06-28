using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class ProductCategoryDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        public bool createProductCategory(ProductCategory productCategory)
        {
            database = new DatabaseConnection();
            database.updateCommand("insert into product_category_tbl(code,description) values (@code,@description)");
            database.addValue("code", productCategory.code);
            database.addValue("description", productCategory.description);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public bool updateProductCategory(ProductCategory productCategory)
        {
            database = new DatabaseConnection();
            database.updateCommand("update product_category_tbl set code=@code,description=@description where id=@id");
            database.addValue("code", productCategory.code);
            database.addValue("description", productCategory.description);
            database.addValue("id", productCategory.id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public List<ProductCategory> getProductCategoryList()
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from product_category_tbl order by id asc");
            sqlDataReader = database.query();
            List<ProductCategory> productCategoryList = new List<ProductCategory>();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productCategory.code = sqlDataReader.GetString(sqlDataReader.GetOrdinal("code"));
                    productCategory.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    productCategoryList.Add(productCategory);
                }
            }
            database.close();
            return productCategoryList;
        }
        public ProductCategory getProductCategory(string productCategoryId)
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from product_category_tbl where id=@productCategoryId");
            database.addValue("productCategoryId", productCategoryId);
            sqlDataReader = database.query();
            ProductCategory productCategory = new ProductCategory();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    productCategory.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productCategory.code = sqlDataReader.GetString(sqlDataReader.GetOrdinal("code"));
                    productCategory.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                }
            }
            database.close();
            return productCategory;
        }

        public bool deleteProductCategory(string id)
        {
            database = new DatabaseConnection();
            database.updateCommand("delete from product_category_tbl where id=@id");
            database.addValue("id", id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
    }
}