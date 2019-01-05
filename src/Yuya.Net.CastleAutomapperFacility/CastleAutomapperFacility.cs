using AutoMapper;
using Castle.MicroKernel;
using Castle.MicroKernel.Facilities;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Yuya.Net.CastleAutomapperFacility
{
    /// <summary>
    /// Castle Automapper Facility
    /// </summary>
    /// <seealso cref="Castle.MicroKernel.Facilities.AbstractFacility" />
    public class CastleAutomapperFacility : AbstractFacility
    {
        private readonly List<IRegistration> _registrations = new List<IRegistration>();


        /// <summary>
        /// The custom initialization for the Facility.
        /// </summary>
        /// <remarks>
        /// It must be overridden.
        /// </remarks>
        protected override void Init()
        {
            Kernel.ComponentRegistered += KernelComponentRegistered;

            if (_registrations.Count > 0)
            {
                Kernel.Register(_registrations.ToArray());
            }

            Kernel.Register(
                // Configurator Registration
                Component
                    .For(typeof(IMapperConfigurator<>))
                    .ImplementedBy(typeof(MapperConfigurator<>))
                    .LifestyleSingleton()
                ,
                // Mapper Registration
                Component
                    .For(typeof(IMapper<>))
                    .ImplementedBy(typeof(Mapper<>))
                    .LifestyleTransient()

            );
        }

        public void RegisterProfile<TType>()
            where TType : Profile
        {
            _registrations.Add(
                // Profile Registration
                Component
                    .For<TType>()
                    .ImplementedBy<TType>()
                    .LifestyleSingleton()
            );
        }

        /// <summary>
        /// Registers the profiles from assembly.
        /// </summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        public void RegisterProfilesFromAssembly<TType>()
        {
            _registrations.Add(
                // Profile Registration
                Classes
                    .FromAssembly(typeof(TType).Assembly)
                    .BasedOn<Profile>()
                    .WithServiceSelf()
                    .LifestyleSingleton()
            );
        }

        /// <summary>Registers the profiles in application.</summary>
        /// <typeparam name="TType">The type of the type.</typeparam>
        public void RegisterProfilesInApplication<TType>()
        {
            _registrations.Add(
                // Profile Registration
                Classes
                    .FromAssemblyInThisApplication(typeof(TType).Assembly)
                    .BasedOn<Profile>()
                    .WithServiceSelf()
                    .LifestyleSingleton()
            );
        }

        private static readonly Type type = typeof(Profile);
        internal void KernelComponentRegistered(string key, IHandler handler)
        {
            if (type.IsAssignableFrom(handler.ComponentModel.Implementation) && !handler.ComponentModel.Services.Contains(handler.ComponentModel.Implementation))
            {
                handler.ComponentModel.AddService(handler.ComponentModel.Implementation);
            }
        }
    }
}