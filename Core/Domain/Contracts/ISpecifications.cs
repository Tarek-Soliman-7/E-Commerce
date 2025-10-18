﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        //Signature for prop [Exp ==> Where]
        public Expression<Func<TEntity, bool>>? Criteria { get; }
        //Signature for prop [Exp ==> Include]
        // Include (p=>p.productType).Include(p=>p.productBrand)
        public List<Expression<Func<TEntity, object>>>? IncludeExpressions { get; }
        public Expression<Func<TEntity, object>> OrderBy { get; }
        public Expression<Func<TEntity, object>> OrderByDescending { get; }

    }
}
