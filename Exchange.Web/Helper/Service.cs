using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Exchange.Core.Services.IServices;
using System.Web.Mvc;



namespace Exchange.Web.Helper
{
    public class Service
    {
        private readonly IProductTypeService productTypeService;
        public Service(IProductTypeService productTypeService)
        {
            this.productTypeService = productTypeService;
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
    }
}