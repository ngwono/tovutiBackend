using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class SingleProductDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        public Product getProduct(string id)
        {
            database = new DatabaseConnection();
            database.queryCommand("select * from products_tbl where id=@id");
            database.addValue("id", id);
            sqlDataReader = database.query();
            Product product = new Product();
            if (sqlDataReader != null)
            {
                while (sqlDataReader.Read())
                {

                    product.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    product.category = sqlDataReader.GetString(sqlDataReader.GetOrdinal("category"));
                    product.product_type = sqlDataReader.GetString(sqlDataReader.GetOrdinal("product_type"));
                    product.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    product.attribute1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute1"));
                    product.attribute2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute2"));
                    //product.productList = (sqlDataReader.GetString(sqlDataReader.GetOrdinal("productList")) + "").Split(new char[] { ',' }).ToList();
                    //product.productListDesc = new List<string>();
                    //for (int p = 0; p < product.productList.Count; p++)
                    //{
                    //    product.productListDesc.Add(getProduct(product.productList.ElementAt(p)).description);
                    //}
                    //product.productDesc = String.Join(",", product.productListDesc.ToArray());
                    product.price = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("price")) + "";

                }
            }
            database.close();
            return product;
        }

    }
}