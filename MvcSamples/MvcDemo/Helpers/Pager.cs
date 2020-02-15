using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcDemo.Helpers
{
    public class Pager
    {
        /// <summary>
        /// 表示两边都有省略号时，中间的分页链接的个数，如 1..4 5 6 7 8 9 ... 100
        /// </summary>
        const int SHOW_COUNT = 6;

        public int RecordCount { get; set; }

        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public int PageCount
        {
            get
            {
                return (RecordCount - 1) / PageSize + 1;
            }
        }

        private List<int> CalcPages()
        {
            var pages = new List<int>();

            int start = (PageIndex - 1) / SHOW_COUNT * SHOW_COUNT + 1;
            int end = Math.Min(PageCount, start + SHOW_COUNT - 1);

            if (start == 1)
            {
                end = Math.Min(PageCount, end + 1);
            }
            else if (end == PageCount)
            {
                start = Math.Max(1, end - SHOW_COUNT);
            }
            pages.AddRange(Enumerable.Range(start, end - start + 1));

            if (start == PageIndex && start > 2)
            {
                pages.Insert(0, start - 1);
                pages.RemoveAt(pages.Count - 1);
            }
            if (PageCount > 1)
            {
                if (pages[0] > 1)
                {
                    pages.Insert(0, 1); //如果页列表第一项不是第一页，则在队头添加第一页
                }
                if (pages[1] == 3)
                {
                    pages.Insert(1, 2); //如果是1..3这种情况，则把..换成2
                }
                else if (pages[1] > 3)
                {
                    pages.Insert(1, -1); //插入左侧省略号
                }

                if (pages.Last() == PageCount - 2)
                {
                    pages.Add(PageCount - 1); //如果是 98..100这种情况，则..换成99
                }
                else if (pages.Last() < PageCount - 2)
                {
                    pages.Add(-1); //插入右侧省略号
                }

                if (pages.Last() < PageCount)
                {
                    pages.Add(PageCount); //最后一页
                }
            }

            return pages;
        }

        /// <summary>
        /// 用于显示页号数组，如果中间有小于0的页号，则表示是省略号
        /// </summary>
        public List<int> Pages
        {
            get { return CalcPages(); }
        }


        /// <summary>
        /// 根据指定的集合表达式和排序字段得出一个分页对象和分页后的数据集
        /// </summary>
        /// <typeparam name="T">实体的类型</typeparam>
        /// <typeparam name="TSort">用于排序的属性类型</typeparam>
        /// <param name="allList">初始的集合</param>
        /// <param name="orderExpress">排序的表达式</param>
        /// <param name="page">页号</param>
        /// <param name="pageSize">页数</param>
        /// <returns></returns>
        public static Pager GetPagedList<T, TSort>(ref IQueryable<T> allList,
            Expression<Func<T, TSort>> orderExpress, int? page, int pageSize = 20)
        {
            int p = Math.Max(1, page == null ? 1 : page.Value);
            var recordCount = allList.Count();
            allList = allList.OrderByDescending(orderExpress)
                .Skip((p - 1) * pageSize)
                .Take(pageSize);

            return new Pager()
            {
                PageIndex = p,
                PageSize = pageSize,
                RecordCount = recordCount,
            };
        }
    }
}