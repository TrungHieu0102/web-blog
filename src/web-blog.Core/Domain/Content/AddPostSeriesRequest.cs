﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace web_blog.Core.Models.Content
{
    public class AddPostSeriesRequest
    {
        public Guid PostId { get; set; }
        public Guid SeriesId { get; set; }
        public int SortOrder { set; get; }
    }
}