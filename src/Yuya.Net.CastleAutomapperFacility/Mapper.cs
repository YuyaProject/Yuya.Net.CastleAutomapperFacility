using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Yuya.Net.CastleAutomapperFacility
{
    /// <summary>
    /// Mapper Internal Class
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    /// <seealso cref="Yuya.Net.CastleAutomapperFacility.IMapper{TProfile}" />
    internal class Mapper<TProfile> : IMapper<TProfile>
        where TProfile : Profile, new()
    {
        /// <summary>
        /// The configurator
        /// </summary>
        private readonly IMapperConfigurator<TProfile> _configurator;

        public Mapper(IMapperConfigurator<TProfile> configurator)
        {
            _configurator = configurator ?? new MapperConfigurator<TProfile>(null);
            AutoMapper = _configurator.CreateMapper();
        }

        public IMapper AutoMapper { get; private set; }

        public TDestination Map<TDestination>(object source)
        {
            return AutoMapper.Map<TDestination>(source);
        }

        public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        {
            return AutoMapper.Map<TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return AutoMapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return AutoMapper.Map<TSource, TDestination>(source, opts);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return AutoMapper.Map<TSource, TDestination>(source, destination);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        {
            return AutoMapper.Map<TSource, TDestination>(source, destination, opts);
        }

        public object Map(object source, Type sourceType, Type destinationType)
        {
            return AutoMapper.Map(source, sourceType, destinationType);
        }

        public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return AutoMapper.Map(source, sourceType, destinationType, opts);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType)
        {
            return AutoMapper.Map(source, destination, sourceType, destinationType);
        }

        public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        {
            return AutoMapper.Map(source, destination, sourceType, destinationType, opts);
        }

        /// <summary>
        /// Projects to.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="membersToExpand">The members to expand.</param>
        /// <returns></returns>
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand)
        {
            return AutoMapper.ProjectTo<TDestination>(source, parameters, membersToExpand);
        }

        /// <summary>
        /// Projects to.
        /// </summary>
        /// <typeparam name="TDestination">The type of the destination.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="membersToExpand">The members to expand.</param>
        /// <returns></returns>
        public IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand)
        {
            return AutoMapper.ProjectTo<TDestination>(source, parameters, membersToExpand);
        }
    }
}