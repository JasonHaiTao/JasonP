using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebSystem.Mobel.ViewModesl
{
    public class PagedList<T> : List<T>
    {
        /// <summary>
        /// 页索引
        /// </summary>
        public int PageIndes { get; private set; }


        /// <summary>
        /// 页大小
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总数居条数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// 分页数据源构造函数
        /// </summary>
        /// <param name="source">分部数据</param>
        /// <param name="pageIndex">页索引</param>
        /// <param name="pageSize">页大小</param>
        public PagedList(List<T> source, int pageIndex, int pageSize)
        {
            PageIndes = pageIndex;
            PageSize = pageSize;
            TotalCount = source.Count();
            this.AddRange(source.Skip((PageIndes - 1) * PageSize).Take(PageSize));
        }

        /// <summary>
        /// 当前是否有上一页
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndes > 1);
            }
        }

        /// <summary>
        /// 当前是否有下一页
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndes < TotalPages);
            }

        }
    }
}
