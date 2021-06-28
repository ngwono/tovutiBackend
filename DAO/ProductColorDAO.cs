using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class ProductColorDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        public bool createProductColor(ProductColor productColor)
        {
            database = new DatabaseConnection();
            database.updateCommand("insert into color_tbl(code,description) values (@code,@description)");
            database.addValue("code", productColor.code);
            database.addValue("description", productColor.description);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public bool updateProductColor(ProductColor productColor)
        {
            database = new DatabaseConnection();
            database.updateCommand("update color_tbl set code=@code,description=@description where id=@id");
            database.addValue("code", productColor.code);
            database.addValue("description", productColor.description);
            database.addValue("id", productColor.id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
        public List<ProductColor> getProductColorList()
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from color_tbl order by id asc");
            sqlDataReader = database.query();
            List<ProductColor> productColorList = new List<ProductColor>();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    ProductColor productColor  = new ProductColor();
                    productColor.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productColor.code = sqlDataReader.GetString(sqlDataReader.GetOrdinal("code"));
                    productColor.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    productColorList.Add(productColor);
                }
            }
            database.close();
            return productColorList;
        }
        public ProductColor getProductColor(string productColorId)
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from color_tbl where id=@productColorId");
            database.addValue("productColorId", productColorId);
            sqlDataReader = database.query();
            ProductColor productColor = new ProductColor();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {
                    productColor.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    productColor.code = sqlDataReader.GetString(sqlDataReader.GetOrdinal("code"));
                    productColor.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                }
            }
            database.close();
            return productColor;
        }

        public bool deleteProductColor(string id)
        {
            database = new DatabaseConnection();
            database.updateCommand("delete from color_tbl where id=@id");
            database.addValue("id", id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }
    }
}