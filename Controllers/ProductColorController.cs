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
    public class ProductColorController : ApiController
    {
        private ProductColorDAO productColorDAO = new ProductColorDAO();
        [Route("api/productcolor/")]
        [HttpPost]

        public Response addProductColor(ProductColor productColor)
        {
            Response response = new Response();
            if (productColorDAO.createProductColor(productColor))
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
        [Route("api/productcolor/{id}")]
        [HttpPut]
        public Response updateProductColor(ProductColor productColor)
        {
            Response response = new Response();
            if (productColorDAO.updateProductColor(productColor))
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
        [Route("api/productcolor/")]
        [HttpGet]
        public List<ProductColor> getProductColorList()
        {
            return productColorDAO.getProductColorList();
        }
        [Route("api/productcolor/{id}")]
        [HttpGet]
        public ProductColor getProductColor(string id)
        {
            return productColorDAO.getProductColor(id);
        }

        [Route("api/productcolor/{id}")]
        [HttpDelete]
        public Response deleteProductColor(string id)
        {
            Response response = new Response();
            if (productColorDAO.deleteProductColor(id))
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
