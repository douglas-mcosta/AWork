using AWork.Candidates.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AWork.Candidates.Data.Pagination
{
    public class PaginationResult<TEntity> : IPaginationResult<TEntity>
    {
        public int TotalRecords { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<TEntity> Result { get; set; }
        public int TotalItemByPage { get => Result.Count(); set { } }
        public int TotalPages { get => (int)Math.Ceiling(TotalRecords / Convert.ToDouble(TotalItemByPage)); set { } }
    }
}
