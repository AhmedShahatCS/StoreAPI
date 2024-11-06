﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Mapping
{
    public class Pagination<T>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int Count { get; set; }

        public IReadOnlyList<T> Data { get; set; }
        public Pagination(int size,int index, IReadOnlyList<T> data,int count) 
        {
            PageSize = size;
            PageIndex=index;
            Data = data;
            Count = count;
        
        }

    }
}
