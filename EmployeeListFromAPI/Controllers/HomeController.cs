using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using EmployeeListFromAPI.Models;
using PagedList;
using Newtonsoft.Json.Linq;

namespace EmployeeListFromAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page)
        {
            //retrieve all the cached parameters
            string baseurl = SiteGlobal.ApiUrl;
            int pageSize = SiteGlobal.DefaultPageSize;
            int pageIndex = SiteGlobal.DefaultPageIndex;
            string contentTypeHeader = SiteGlobal.ContentTypeHeader;
            string acceptHeader = SiteGlobal.AcceptHeader;
            string dataJson = SiteGlobal.dataJson;

            //initialise the page index to 1 if there is no value 
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;

            //initialise list and pagedlist of employees
            IPagedList<EmployeeModel> Emp_Paged = null;
            List<EmployeeModel> EmpInfo = new List<EmployeeModel>();

            try
            {
                //retrieving the API data using webclient
                using (var client = new WebClient())
                {
                    client.Headers.Add(contentTypeHeader);
                    client.Headers.Add(acceptHeader);
                    var res = client.DownloadString(baseurl);
                    if (res != null)
                    {
                        //parsing the json results retrieved from API
                        JObject results = JObject.Parse(res);

                        //insert the data retrieved from API into a list
                        foreach (var result in results[dataJson])
                        {
                            int id = (int)result["id"];
                            string employee_name = (string)result["employee_name"];
                            int employee_salary = (int)result["employee_salary"];
                            int employee_age = (int)result["employee_age"];
                            string profile_image = (string)result["profile_image"];
                            EmpInfo.Add(new EmployeeModel() { ID = id, 
                                Name = employee_name, 
                                Salary = employee_salary, 
                                Age = employee_age, 
                                Profile = profile_image });
                        }

                        //initialising the paged list using page index and page size
                        Emp_Paged = EmpInfo.ToPagedList(pageIndex, pageSize);
                        return View(Emp_Paged);
                    }
                    else
                    {
                        return Content("Item not found, please refresh the page");
                    }
                }
            }
            catch (Exception ex)
            {
                //catching the web exception
                if (ex is WebException we && we.Response is HttpWebResponse)
                {
                    HttpWebResponse response = (HttpWebResponse)we.Response;
                    // it can be 404, 500 etc...
                    Console.WriteLine(response.StatusCode);
                }
                //redirecting to the same method with the page index if error occurs
                // we can also give up retyring after few attempts
                return RedirectToAction("Index", new { page });
            }
        }
    }
}



