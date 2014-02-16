using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Services.IServices;
using System.Web.Mvc;
using Exchange.Helper.Common;



namespace Exchange.Web.Helper
{
    public class Service
    {
        private readonly IProductTypeService productTypeService;
        private readonly IProductService productService;
        private readonly IStoreService storeService;
        private readonly IRoleService roleService;
        private readonly ICustomerService customerService;
        public Service(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
        }
        public Service(IProductService productService)
        {
            this.productService = productService;
        }
        public Service(IProductService productService,ICustomerService customerService)
        {
            this.productService = productService;
            this.customerService= customerService;
        }
        public Service(IStoreService storeService, IRoleService roleService)
        {
            this.storeService = storeService;
            this.roleService = roleService;
        }

        public List<SelectListItem> GetProductTypeList(int selectedValue)
        {

            List<SelectListItem> source = new List<SelectListItem>();
            var items = this.productTypeService.GetDataListByStatus(true);
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.Code) && !string.IsNullOrEmpty(item.Name))
                    {
                        SelectListItem sourceItem = new SelectListItem();
                        sourceItem.Value = item.Id.ToString();
                        sourceItem.Text = item.Name.ToString();
                        sourceItem.Selected = item.Id.Equals(selectedValue) ? true : false;
                        source.Add(sourceItem);
                    }
                }
            }
            return source;
        }
        public List<SelectListItem> GetProductList(int selectedValue)
        {

            List<SelectListItem> source = new List<SelectListItem>();
            var items = this.productService.GetDataListByStatus(true);
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.Code) && !string.IsNullOrEmpty(item.Name))
                    {
                        SelectListItem sourceItem = new SelectListItem();
                        sourceItem.Value = item.Id.ToString();
                        sourceItem.Text = string.Format("{0} - {1}", item.ProductType.Name,item.Name);
                        sourceItem.Selected = item.Id.Equals(selectedValue) ? true : false;
                        source.Add(sourceItem);
                    }
                }
            }
            return source;
        }
        public List<SelectListItem> GetStoreList(int selectedValue)
        {

            List<SelectListItem> source = new List<SelectListItem>();
            var items = this.storeService.GetDataListByStatus(true);
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.Code) && !string.IsNullOrEmpty(item.Name))
                    {
                        SelectListItem sourceItem = new SelectListItem();
                        sourceItem.Value = item.Id.ToString();
                        sourceItem.Text = item.Name.ToString();
                        sourceItem.Selected = item.Id.Equals(selectedValue) ? true : false;
                        source.Add(sourceItem);
                    }
                }
            }
            return source;
        }
        public List<SelectListItem> GetRoleList(int selectedValue)
        {

            List<SelectListItem> source = new List<SelectListItem>();
            var items = this.roleService.GetAllData();
            if (items != null)
            {
                foreach (var item in items)
                {
                    if (!string.IsNullOrEmpty(item.RoleName))
                    {
                        SelectListItem sourceItem = new SelectListItem();
                        sourceItem.Value = item.RoleName.ToString();
                        sourceItem.Text = item.RoleName.ToString();
                        sourceItem.Selected = item.Id.Equals(selectedValue) ? true : false;
                        source.Add(sourceItem);
                    }
                }
            }
            return source;
        }
        public List<SelectListItem> GetCustomerList(int selectedValue)
        {

            List<SelectListItem> source = new List<SelectListItem>();
            var items = this.customerService.GetAllData();
            if (items != null)
            {
                foreach (var item in items)
                {
                        SelectListItem sourceItem = new SelectListItem();
                        sourceItem.Value = item.Id.ToString();
                        sourceItem.Text = Base.GenerateFullName(item.FirstName, item.MiddleName, item.LastName);
                        sourceItem.Selected = item.Id.Equals(selectedValue) ? true : false;
                        source.Add(sourceItem);
                    
                }
            }
            return source;
        }

    }
}