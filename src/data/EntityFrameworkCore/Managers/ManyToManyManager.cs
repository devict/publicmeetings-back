using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DevIct.PublicMeetings.Back.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DevIct.PublicMeetings.Back.Data.EntityFrameworkCore.Managers
{
    /// <summary>
    /// Base class for managing junction tables for many to many relationships.
    /// </summary>
    /// <typeparam name="TA">
    /// One of the <see cref="DatabaseObject"/> types that is part of the relationship.
    /// </typeparam>
    /// <typeparam name="TB">
    /// The other <see cref="DatabaseObject"/> type that is part of the relationship.
    /// </typeparam>
    /// <typeparam name="TJunction">
    /// The <see cref="DatabaseObject"/> type used for the junction table.
    /// </typeparam>
    internal abstract class ManyToManyManager<TA, TB, TJunction>
        where TA : DatabaseObject
        where TB : DatabaseObject
        where TJunction : DatabaseObject
    {
        protected readonly Context _context;
        protected readonly ILogger _logger;

        /// <summary>
        /// Gets the junction table in <see cref="_context"/>.
        /// </summary>
        protected abstract DbSet<TJunction> _table { get; }

        /// <summary>
        /// Gets the <see cref="Expression{TDelegate}"/> used to retrieve
        /// <typeparamref name="TA"/> from the database matching a 
        /// <typeparamref name="TJunction"/> record.
        /// </summary>
        protected abstract Expression<Func<TJunction, TA>> _getA { get; }

        /// <summary>
        /// Gets the <see cref="Expression{TDelegate}"/> used to retrieve
        /// <typeparamref name="TB"/> from the database matching a 
        /// <typeparamref name="TJunction"/> record.
        /// </summary>
        protected abstract Expression<Func<TJunction, TB>> _getB { get; }

        protected ManyToManyManager(Context context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Gets the <see cref="Expression{TDelegate}"/> used to match a
        /// <typeparamref name="TJunction"/> record to <paramref name="a"/>
        /// </summary>
        protected abstract Expression<Func<TJunction, bool>> MatchRecord(TA a);

        /// <summary>
        /// Gets the <see cref="Expression{TDelegate}"/> used to match a
        /// <typeparamref name="TJunction"/> record to a <paramref name="b"/>
        /// </summary>
        protected abstract Expression<Func<TJunction, bool>> MatchRecord(TB b);

        /// <summary>
        /// Gets the <see cref="Expression{TDelegate}"/> used to match a
        /// <typeparamref name="TJunction"/> record to both <paramref name="a"/>
        /// and <paramref name="b"/>
        /// </summary>
        protected abstract Expression<Func<TJunction, bool>> MatchRecord(TA a, TB b);

        /// <summary>
        /// Creates a new <typeparamref name="TJunction"/> for <paramref name="a"/>
        /// and <paramref name="b"/>.
        /// </summary>
        protected abstract TJunction NewJunction(TA a, TB b);

        public async Task<DataResult> Create(TA a, TB b)
        {
            try
            {
                if (await _table.AnyAsync(MatchRecord(a, b)))
                {
                    _logger.LogInformation($"Tried to create record "
                            + $"for {a.GetType().Name} {a.Id}" +
                            $" and {b.GetType().Name} {b.Id} but record already exists.");
                }
                else
                {
                    _ = _context.Add(NewJunction(a, b));
                    _ = await _context.SaveChangesAsync();
                }
                return DataResult.Success;
            }
            catch (Exception e)
            {
                return DataResult.Failure(DataError.Generic(e.Message));
            }
        }

        public async Task<DataResult> Delete(TA a, TB b)
        {
            try
            {
                TJunction? record = await _table
                    .FirstOrDefaultAsync(MatchRecord(a, b));
                if (record != null)
                {
                    _ = _context.Remove(record);
                    _ = await _context.SaveChangesAsync();
                }
                return DataResult.Success;
            }
            catch (Exception e)
            {
                return DataResult.Failure(DataError.Generic(e.Message));
            }
        }

        protected async Task<DataResult<PagedResult<TB>>> FindByA(TA a, PageRequest? pageRequest)
        {
            try
            {
                IEnumerable<TB> results = await _table
                    .Where(MatchRecord(a))
                    .Select(_getB)
                    .ToListAsync();
                return DataResult<PagedResult<TB>>.Success(
                    new PagedResult<TB>(results, pageRequest ?? new PageRequest()));
            }
            catch (Exception e)
            {
                return DataResult<PagedResult<TB>>.Failure(DataError.Generic(e.Message));
            }
        }

        protected async Task<DataResult<PagedResult<TA>>> FindByB(TB b, PageRequest? pageRequest)
        {
            try
            {
                IEnumerable<TA> results = await _table
                    .Where(MatchRecord(b))
                    .Select(_getA)
                    .ToListAsync();
                return DataResult<PagedResult<TA>>.Success(
                    new PagedResult<TA>(results, pageRequest ?? new PageRequest()));
            }
            catch (Exception e)
            {
                return DataResult<PagedResult<TA>>.Failure(DataError.Generic(e.Message));
            }
        }
    }
}
