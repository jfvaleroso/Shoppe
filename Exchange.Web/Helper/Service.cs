using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Exchange.Core.Entities;
using Exchange.Core.Services.IServices;
using Exchange.Helper.Common;

namespace Exchange.Web.Helper
{
    public class Service
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IProductTypeService _productTypeService;
        private readonly IRoleService _roleService;
        private readonly IStoreService _storeService;

        public Service(IProductTypeService productTypeService)
        {
            _productTypeService = productTypeService;
        }

        public Service(IProductService productService)
        {
            _productService = productService;
        }

        public Service(IProductService productService, ICustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        public Service(IStoreService storeService, IRoleService roleService)
        {
            _storeService = storeService;
            _roleService = roleService;
        }

        public List<SelectListItem> GetProductTypeList(Guid selectedValue)
        {
            var source = new List<SelectListItem>();
            var items = _productTypeService.GetDataListByStatus(true);
            if (items == null) return source;
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.Code) || string.IsNullOrEmpty(item.Name)) continue;
                var sourceItem = new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = item.Name,
                    Selected = item.Id.Equals(selectedValue) ? true : false
                };
                source.Add(sourceItem);
            }
            return source;
        }

        public List<SelectListItem> GetProductList(Guid selectedValue)
        {
            var source = new List<SelectListItem>();
            var items = _productService.GetDataListByStatus(true);
            if (items == null) return source;
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.Code) || string.IsNullOrEmpty(item.Name)) continue;
                var sourceItem = new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = string.Format("{0} - {1}", item.ProductType.Name, item.Name),
                    Selected = item.Id.Equals(selectedValue) ? true : false
                };
                source.Add(sourceItem);
            }
            return source;
        }

        public List<SelectListItem> GetStoreList(Guid selectedValue)
        {
            var source = new List<SelectListItem>();
            var items = _storeService.GetDataListByStatus(true);
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (string.IsNullOrEmpty(item.Code) || string.IsNullOrEmpty(item.Name)) continue;
                    var sourceItem = new SelectListItem
                    {
                        Value = item.Id.ToString(),
                        Text = item.Name,
                        Selected = item.Id.Equals(selectedValue) ? true : false
                    };
                    source.Add(sourceItem);
                }
            }
            return source;
        }

        public List<SelectListItem> GetRoleList(Guid selectedValue)
        {
            var source = new List<SelectListItem>();
            var items = _roleService.GetAllData();
            if (items == null) return source;
            foreach (var item in items)
            {
                if (string.IsNullOrEmpty(item.RoleName)) continue;
                var sourceItem = new SelectListItem
                {
                    Value = item.RoleName,
                    Text = item.RoleName,
                    Selected = item.Id.Equals(selectedValue) ? true : false
                };
                source.Add(sourceItem);
            }
            return source;
        }

        public List<SelectListItem> GetCustomerList(Guid selectedValue)
        {
            var source = new List<SelectListItem>();
            var items = _customerService.GetAllData();
            if (items == null) return source;
            foreach (var item in items)
            {
                var sourceItem = new SelectListItem
                {
                    Value = item.Id.ToString(),
                    Text = Base.GenerateFullName(item.FirstName, item.MiddleName, item.LastName),
                    Selected = item.Id.Equals(selectedValue) ? true : false
                };
                source.Add(sourceItem);
            }
            return source;
        }
    }
}