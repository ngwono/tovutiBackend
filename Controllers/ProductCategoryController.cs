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
    public class ProductCategoryController : ApiController
    {
        private ProductCategoryDAO productCategoryDAO = new ProductCategoryDAO();
        [Route("api/productcategory/")]
        [HttpPost]

        public Response addProductCategory(ProductCategory productCategory)
        {
            Response response = new Response();
            if (productCategoryDAO.createProductCategory(productCategory))
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
        [Route("api/productcategory/{id}")]
        [HttpPut]
        public Response updateProductCategory(ProductCategory productCategory)
        {
            Response response = new Response();
            if (productCategoryDAO.updateProductCategory(productCategory))
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
        [Route("api/productcategory/")]
        [HttpGet]
        public List<ProductCategory> getProductCategoryList()
        {
            return productCategoryDAO.getProductCategoryList();
        }
        [Route("api/productcategory/{id}")]
        [HttpGet]
        public ProductCategory getProductCategory(string id)
        {
            return productCategoryDAO.getProductCategory(id);
        }

        [Route("api/productcategory/{id}")]
        [HttpDelete]
        public Response deleteProductCategory(string id)
        {
            Response response = new Response();
            if (productCategoryDAO.deleteProductCategory(id))
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
