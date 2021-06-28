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
    public class ProductTypeController : ApiController
    {
        private ProductTypeDAO productTypeDAO = new ProductTypeDAO();
        [Route("api/producttype/")]
        [HttpPost]

        public Response addProductType(ProductType productType)
        {
            Response response = new Response();
            if (productTypeDAO.createProductType(productType))
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
        [Route("api/producttype/{id}")]
        [HttpPut]
        public Response updateProductType(ProductType productType)
        {
            Response response = new Response();
            if (productTypeDAO.updateProductType(productType))
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
        [Route("api/producttype/")]
        [HttpGet]
        public List<ProductType> getProductTypeList()
        {
            return productTypeDAO.getProductTypeList();
        }
        [Route("api/producttype/{id}")]
        [HttpGet]
        public ProductType getProductType(string id)
        {
            return productTypeDAO.getProductType(id);
        }

        [Route("api/producttype/{id}")]
        [HttpDelete]
        public Response deleteProductType(string id)
        {
            Response response = new Response();
            if (productTypeDAO.deleteProductType(id))
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
