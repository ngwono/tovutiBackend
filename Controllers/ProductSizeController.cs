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
    public class ProductSizeController : ApiController
    {
        private ProductSizeDAO productSizeDAO  = new ProductSizeDAO();

        [Route("api/productsize/")]
        [HttpPost]

        public Response addProductSize(ProductSize productSize)
        {
            Response response = new Response();
            if (productSizeDAO.createProductSize(productSize))
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
        [Route("api/productsize/{id}")]
        [HttpPut]
        public Response updateProductSize(ProductSize productSize)
        {
            Response response = new Response();
            if (productSizeDAO.updateProductSize(productSize))
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
        [Route("api/productsize/")]
        [HttpGet]
        public List<ProductSize> getProductSizeList()
        {
            return productSizeDAO.getProductSizeList();
        }
        [Route("api/productsize/{id}")]
        [HttpGet]
        public ProductSize getProductSize(string id)
        {
            return productSizeDAO.getProductSize(id);
        }

        [Route("api/productsize/{id}")]
        [HttpDelete]
        public Response deleteProductSize(string id)
        {
            Response response = new Response();
            if (productSizeDAO.deleteProductSize(id))
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
