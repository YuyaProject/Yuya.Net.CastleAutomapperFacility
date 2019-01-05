using AutoMapper;

namespace Yuya.Net.CastleAutomapperFacility
{
    /// <summary>
    /// Mapper Configurator By Profile Class
    /// </summary>
    /// <typeparam name="TProfile">The type of the profile.</typeparam>
    /// <seealso cref="Yuya.Net.CastleAutomapperFacility.IMapperConfigurator{TProfile}" />
    internal class MapperConfigurator<TProfile> : IMapperConfigurator<TProfile>
        where TProfile : Profile, new()
    {
        /// <summary>
        /// The profile
        /// </summary>
        private readonly TProfile _profile;

        /// <summary>
        /// Initializes a new instance of the <see cref="MapperConfigurator{TProfile}"/> class.
        /// </summary>
        /// <param name="profile">The profile.</param>
        public MapperConfigurator(TProfile profile)
        {
            _profile = profile ?? new TProfile();
            Configuration = new MapperConfiguration(cfg => cfg.AddProfile(_profile));
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public MapperConfiguration Configuration { get; private set; }

        /// <summary>
        /// Creates the mapper.
        /// </summary>
        /// <returns></returns>
        public AutoMapper.IMapper CreateMapper()
        {
            return Configuration.CreateMapper();
        }
    }
}