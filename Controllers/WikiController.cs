using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wikipedia.Models;

namespace Wikipedia.Controllers
{
    public class WikiController : Controller
    {
        public ActionResult HomePage()
        {
            return View();
        }

        //For saving searched item in database
        [HttpPost]
        public string SavedSearchItem(string SearchItem)
        {

            using (var db = new WikipediaDbContext())
            {
                try
                {
                    if (!db.SearchItems.Where(i => i.ItemName == SearchItem).Any())
                    {
                        SearchItem item = new SearchItem()
                        {
                            ItemName = SearchItem,
                            SearchDate = DateTime.Now
                        };
                        db.Entry(item).State = EntityState.Added;
                        db.SaveChanges();
                        return "Item Saved!";
                    }
                    else
                    {
                        return "Item not Saved!";
                    }
                }
                catch (Exception ex)
                {
                    return "Item not Saved!";
                }
            }
        }
    }
}