using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Yuya.Net.CastleAutomapperFacility
{
    public interface IMapper<TProfile>
        where TProfile : Profile, new()
    {
        /// <summary>
        /// Gets the automatic mapper.
        /// </summary>
        /// <value>
        /// The automatic mapper.
        /// </value>
        IMapper AutoMapper { get; }

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object. The source
        //     type is inferred from the source object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        // Type parameters:
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        TDestination Map<TDestination>(object source);

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with supplied
        //     mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts);

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        // Type parameters:
        //   TSource:
        //     Source type to use, regardless of the runtime type
        //
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        TDestination Map<TSource, TDestination>(TSource source);

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with supplied
        //     mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts);

        //
        // Summary:
        //     Execute a mapping from the source object to the existing destination object.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type
        //
        // Returns:
        //     The mapped destination object, same instance as the destination object
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);

        //
        // Summary:
        //     Execute a mapping from the source object to the existing destination object with
        //     supplied mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        //   opts:
        //     Mapping options
        //
        // Type parameters:
        //   TSource:
        //     Source type to use
        //
        //   TDestination:
        //     Destination type
        //
        // Returns:
        //     The mapped destination object, same instance as the destination object
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts);

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with explicit
        //     System.Type objects
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to create
        //
        // Returns:
        //     Mapped destination object
        object Map(object source, Type sourceType, Type destinationType);

        //
        // Summary:
        //     Execute a mapping from the source object to a new destination object with explicit
        //     System.Type objects and supplied mapping options.
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to create
        //
        //   opts:
        //     Mapping options
        //
        // Returns:
        //     Mapped destination object
        object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);

        //
        // Summary:
        //     Execute a mapping from the source object to existing destination object with
        //     explicit System.Type objects
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to use
        //
        // Returns:
        //     Mapped destination object, same instance as the destination object
        object Map(object source, object destination, Type sourceType, Type destinationType);

        //
        // Summary:
        //     Execute a mapping from the source object to existing destination object with
        //     supplied mapping options and explicit System.Type objects
        //
        // Parameters:
        //   source:
        //     Source object to map from
        //
        //   destination:
        //     Destination object to map into
        //
        //   sourceType:
        //     Source type to use
        //
        //   destinationType:
        //     Destination type to use
        //
        //   opts:
        //     Mapping options
        //
        // Returns:
        //     Mapped destination object, same instance as the destination object
        object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts);

        //
        // Summary:
        //     Project the input queryable.
        //
        // Parameters:
        //   source:
        //     Queryable source
        //
        //   parameters:
        //     Optional parameter object for parameterized mapping expressions
        //
        //   membersToExpand:
        //     Explicit members to expand
        //
        // Type parameters:
        //   TDestination:
        //     Destination type
        //
        // Returns:
        //     Queryable result, use queryable extension methods to project and execute result
        //
        // Remarks:
        //     Projections are only calculated once and cached
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, object parameters = null, params Expression<Func<TDestination, object>>[] membersToExpand);

        //
        // Summary:
        //     Project the input queryable.
        //
        // Parameters:
        //   source:
        //     Queryable source
        //
        //   parameters:
        //     Optional parameter object for parameterized mapping expressions
        //
        //   membersToExpand:
        //     Explicit members to expand
        //
        // Type parameters:
        //   TDestination:
        //     Destination type to map to
        //
        // Returns:
        //     Queryable result, use queryable extension methods to project and execute result
        IQueryable<TDestination> ProjectTo<TDestination>(IQueryable source, IDictionary<string, object> parameters, params string[] membersToExpand);
    }
}