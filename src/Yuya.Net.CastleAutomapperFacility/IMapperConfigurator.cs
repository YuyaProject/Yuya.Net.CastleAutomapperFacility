using AutoMapper;

namespace Yuya.Net.CastleAutomapperFacility
{
    /// <summary>
    /// Mapper Configurator By Profile Interface
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    public interface IMapperConfigurator<TProfile>
        where TProfile : Profile, new()
    {
        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        MapperConfiguration Configuration { get; }

        /// <summary>
        /// Creates the mapper.
        /// </summary>
        /// <returns></returns>
        AutoMapper.IMapper CreateMapper();
    }
}