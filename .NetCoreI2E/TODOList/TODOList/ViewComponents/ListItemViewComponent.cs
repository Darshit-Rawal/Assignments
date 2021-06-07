using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TODOList.Models;

namespace TODOList.ViewComponents
{
    public class ListItemViewComponent : ViewComponent
    {
        Lists listItem = new Lists();
        public ListItemViewComponent()
        {
            Provider provider = new Provider();
        }

        public async Task<IViewComponentResult> InvokeAsync(Lists list)
        {
            var model = list;
            return await Task.FromResult((IViewComponentResult)View("TodoList", model));
        }
    }
}
