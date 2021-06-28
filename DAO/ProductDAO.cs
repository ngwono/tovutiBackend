using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using TovutiBackend.Models;
using TovutiBackend.Databases;

namespace TovutiBackend.DAO
{
    public class ProductDAO
    {
        private DatabaseConnection database = null;
        private SqlDataReader sqlDataReader = null;
        private SingleProductDAO singleProductDAO = new SingleProductDAO();
        private ProductCategoryDAO productCategoryDAO = new ProductCategoryDAO();
        private ProductTypeDAO productTypeDAO = new ProductTypeDAO();
        private ProductColorDAO productColorDAO = new ProductColorDAO();
        private ProductSizeDAO productSizeDAO = new ProductSizeDAO();

        public bool createProduct(Product product)
        {
            database = new DatabaseConnection();
            database.updateCommand("insert into products_tbl(category,product_type,description,attribute1,attribute2,productList,price) values (@category,@product_type,@description,@attribute1,@attribute2,@productList,@price)");
            database.addValue("category", product.category == null ? "" : product.category);
            database.addValue("product_type", product.product_type == null ? "" : product.product_type);
            database.addValue("description", product.description == null ? "" : product.description);
            database.addValue("attribute1", product.attribute1 == null ? "" : product.attribute1);
            database.addValue("attribute2", product.attribute2 == null ? "" : product.attribute2);
            database.addValue("productList", product.productList == null ? "" : string.Join(",", product.productList.ToArray()));
            database.addValue("price", product.price == null ? "0.00" : product.price);
            bool updated = database.update();
            database.close();
            return updated;
        }

        public bool updateProduct(Product product)
        {
            database = new DatabaseConnection();
            database.updateCommand("update products_tbl set category=@category,product_type=@product_type,description=@description,attribute1=@attribute1,attribute2=@attribute2,productList=@productList,price=@price where id=@id");
            database.addValue("category", product.category == null ? "" : product.category);
            database.addValue("product_type", product.product_type == null ? "" : product.product_type);
            database.addValue("description", product.description == null ? "" : product.description);
            database.addValue("attribute1", product.attribute1 == null ? "" : product.attribute1);
            database.addValue("attribute2", product.attribute2 == null ? "" : product.attribute2);
            database.addValue("productList", product.productList == null ? "" : string.Join(",", product.productList.ToArray()));
            database.addValue("price", product.price == null ? "0.00" : product.price);
            database.addValue("id", product.id);
            bool updated = database.update();
            database.close();
            return updated;
        }
        public bool deleteProduct(string id)
        {
            database = new DatabaseConnection();
            database.updateCommand("delete from products_tbl where id=@id");
            database.addValue("id", id);
            Boolean updated = database.update();
            database.close();
            return updated;
        }

        public List<Product> getProductList()
        {
            database = new DatabaseConnection();
            database.queryCommand("select a.* from products_tbl a order by a.id asc");
            sqlDataReader = database.query();
            List<Product> productList = new List<Product>();
            if (sqlDataReader != null)
            {
                int r = 0;
                while (sqlDataReader.Read())
                {
                    Product product = new Product();
                    product.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    product.category = sqlDataReader.GetString(sqlDataReader.GetOrdinal("category"));
                    product.categoryDesc = productCategoryDAO.getProductCategory(product.category).description;
                    product.product_type = sqlDataReader.GetString(sqlDataReader.GetOrdinal("product_type"));
                    product.typeDesc = productTypeDAO.getProductType(product.product_type).description;
                    product.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    product.attribute1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute1"));
                    product.attribute1Desc = productColorDAO.getProductColor(product.attribute1).description;
                    product.attribute2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute2"));
                    product.attribute2Desc = productSizeDAO.getProductSize(product.attribute2).description;
                    product.productList = (sqlDataReader.GetString(sqlDataReader.GetOrdinal("productList")) + "").Split(new char[] { ',' }).ToList();
                    product.productListDesc = new List<string>();
                    for (int p = 0; p < product.productList.Count; p++)
                    {
                        product.productListDesc.Add(singleProductDAO.getProduct(product.productList.ElementAt(p)).description);
                    }
                    product.productDesc = String.Join(",", product.productListDesc.ToArray());
                    product.price = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("price")) + "";

                    productList.Add(product);

                    r++;
                }
            }
            database.close();
            return productList;
        }

        public List<Product> getProductsByCategory(string id)
        {
            database = new DatabaseConnection();
            database.queryCommand("select a.* from products_tbl a where a.category=@category order by a.id asc");
            database.addValue("category",id);
            sqlDataReader = database.query();
            List<Product> productList = new List<Product>();
            if (sqlDataReader != null)
            {
                int r = 0;
                while (sqlDataReader.Read())
                {
                    Product product = new Product();
                    product.id = sqlDataReader.GetInt32(sqlDataReader.GetOrdinal("id")) + "";
                    product.category = sqlDataReader.GetString(sqlDataReader.GetOrdinal("category"));
                    product.categoryDesc = productCategoryDAO.getProductCategory(product.category).description;
                    product.product_type = sqlDataReader.GetString(sqlDataReader.GetOrdinal("product_type"));
                    product.typeDesc = productTypeDAO.getProductType(product.product_type).description;
                    product.description = sqlDataReader.GetString(sqlDataReader.GetOrdinal("description"));
                    product.attribute1 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute1"));
                    product.attribute1Desc = productColorDAO.getProductColor(product.attribute1).description;
                    product.attribute2 = sqlDataReader.GetString(sqlDataReader.GetOrdinal("attribute2"));
                    product.attribute2Desc = productSizeDAO.getProductSize(product.attribute2).description;
                    product.productList = (sqlDataReader.GetString(sqlDataReader.GetOrdinal("productList")) + "").Split(new char[] { ',' }).ToList();
                    product.productListDesc = new List<string>();
                    for (int p = 0; p < product.productList.Count; p++)
                    {
                        product.productListDesc.Add(singleProductDAO.getProduct(product.productList.ElementAt(p)).description);
                    }
                    product.productDesc = String.Join(",", product.productListDesc.ToArray());
                    product.price = sqlDataReader.GetDecimal(sqlDataReader.GetOrdinal("price")) + "";

                    productList.Add(product);

                    r++;
                }
            }
            database.close();
            return productList;
        }


    }
}