using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TovutiBackend.Models;
using TovutiBackend.DAO;

namespace TovutiBackend.Controllers
{
    public class ProductController : ApiController
    {
        private ProductDAO productDAO = new ProductDAO();
        [Route("api/product/")]
        [HttpPost]

        public Response addProduct(Product product)
        {
            Response response = new Response();
            if (productDAO.createProduct(product))
            {
                response.Status = Constants.Constant.STATUS_SUCC;
                response.Message = Constants.Constant.MESSAGE_CREATE_SUCC;
            }
            else
            {
                response.Status = Constants.Constant.STATUS_FAIL;
                response.Message = Constants.Constant.MESSAGE_CREATE_FAIL;
            }
            return response;
        }

        [Route("api/product/{id}")]
        [HttpPut]
        public Response updateProduct(Product product)
        {
            Response response = new Response();
            if (productDAO.updateProduct(product))
            {
                response.Status = Constants.Constant.STATUS_SUCC;
                response.Message = Constants.Constant.MESSAGE_UPDATE_SUCC;
            }
            else
            {
                response.Status = Constants.Constant.STATUS_FAIL;
                response.Message = Constants.Constant.MESSAGE_UPDATE_FAIL;
            }
            return response;
        }

        [Route("api/product/")]
        [HttpGet]
        public List<Product> getProductList()
        {
            return productDAO.getProductList();
        }
        [Route("api/product/{id}")]
        [HttpGet]
        public List<Product> getProductsByCategory(string id)
        {
            return productDAO.getProductsByCategory(id);
        }

        [Route("api/product/{id}")]
        [HttpDelete]
        public Response deleteProduct(string id)
        {
            Response response = new Response();
            if (productDAO.deleteProduct(id))
            {
                response.Status = Constants.Constant.STATUS_SUCC;
                response.Message = Constants.Constant.MESSAGE_DELETE_SUCC;
            }
            else
            {
                response.Status = Constants.Constant.STATUS_FAIL;
                response.Message = Constants.Constant.MESSAGE_DELETE_FAIL;
            }
            return response;
        }
    }
}
