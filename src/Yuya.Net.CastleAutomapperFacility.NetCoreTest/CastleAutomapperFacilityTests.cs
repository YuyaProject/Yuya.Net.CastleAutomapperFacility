using AutoMapper;
using Castle.Windsor;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Yuya.Net.CastleAutomapperFacility.NetCoreTest
{
    public class CastleAutomapperFacilityTests : IDisposable
    {
        private MockRepository mockRepository;

        public CastleAutomapperFacilityTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private CastleAutomapperFacility CreateCastleAutomapperFacility()
        {
            return new CastleAutomapperFacility();
        }

        [Fact]
        public void RegisterProfile_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            WindsorContainer container = new WindsorContainer();
            container.AddFacility<CastleAutomapperFacility>(cfg => {
                // Act
                cfg.RegisterProfile<TestProfile>();
            });


            // Assert
            var mapper = container.Resolve<IMapper<TestProfile>>();

            mapper.ShouldNotBeNull();
        }

        [Fact]
        public void RegisterProfilesFromAssembly_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            WindsorContainer container = new WindsorContainer();
            container.AddFacility<CastleAutomapperFacility>(cfg=> {
                // Act
                cfg.RegisterProfilesFromAssembly<CastleAutomapperFacilityTests>();
            });


            // Assert
            var mapper = container.Resolve<IMapper<TestProfile>>();

            mapper.ShouldNotBeNull();
        }

        [Fact]
        public void RegisterProfilesInApplication_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            WindsorContainer container = new WindsorContainer();
            container.AddFacility<CastleAutomapperFacility>(cfg => {
                // Act
                cfg.RegisterProfilesInApplication<CastleAutomapperFacilityTests>();
            });


            // Assert
            var mapper = container.Resolve<IMapper<TestProfile>>();

            mapper.ShouldNotBeNull();
        }






        public class TestClass1
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class TestClass2
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public class TestProfile : Profile
        {
            public TestProfile()
            {
                this.CreateMap<TestClass1, TestClass2>();
                this.CreateMap<TestClass2, TestClass1>();
            }
        }
    }
}