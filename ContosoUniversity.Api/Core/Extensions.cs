﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Api.Core
{
    public static  class Extensions
    {
        /// <summary>
        /// Extension method to add pagination info to Response headers
        /// </summary>
        /// <param name="response"></param>
        /// <param name="currentPage"></param>
        /// <param name="itemsPerPage"></param>
        /// <param name="totalItems"></param>
        /// <param name="totalPages"></param>
        public static void AddPagination(this HttpResponse response,
            int currentPage,int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage,
                itemsPerPage, totalItems, totalPages);

            response.Headers.Add("Pagination",
                JsonConvert.SerializeObject(paginationHeader));

            response.Headers.Add("access-control-expose-headers", "Pagination");
        }

        public static void AddApplicationError(this HttpResponse response, string message)
        {
            response.Headers.Add("Application-Error", message);
            response.Headers.Add("access-control-expose-headers", "Application-Error");
        }
    }

}
