using AutoMapper;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Yuya.Net.CastleAutomapperFacility.NetFrameworkTest
{
    public class MapperConfiguratorTests : IDisposable
    {
        private readonly MockRepository mockRepository;

        public MapperConfiguratorTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private MapperConfigurator<TestProfile> CreateMapperConfigurator()
        {
            return new MapperConfigurator<TestProfile>(new TestProfile());
        }

        [Fact]
        public void Constructor_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var unitUnderTest = this.CreateMapperConfigurator();

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.Configuration.ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_StateUnderTest_NullParameter()
        {
            // Act
            var unitUnderTest = new MapperConfigurator<TestProfile>(null);

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.Configuration.ShouldNotBeNull();
        }


        [Fact]
        public void Configuration_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var unitUnderTest = this.CreateMapperConfigurator();

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.Configuration.ShouldNotBeNull();
        }


        [Fact]
        public void CreateMapper_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateMapperConfigurator();

            // Act
            var result = unitUnderTest.CreateMapper();

            // Assert
            result.ShouldNotBeNull();
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