using AutoMapper;
using Moq;
using Shouldly;
using System;
using Xunit;

namespace Yuya.Net.CastleAutomapperFacility.NetFrameworkTest
{
    public class MapperTests : IDisposable
    {
        private MockRepository mockRepository;
        private MapperConfigurator<TestProfile> mapperConfigurator;

        public MapperTests()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);
            mapperConfigurator = new MapperConfigurator<TestProfile>(new TestProfile());
        }

        public void Dispose()
        {
            this.mockRepository.VerifyAll();
        }

        private Mapper<TestProfile> CreateMapper()
        {
            return new Mapper<TestProfile>(mapperConfigurator);
        }

        [Fact]
        public void Constructor_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var unitUnderTest = this.CreateMapper();

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.AutoMapper.ShouldNotBeNull();
        }

        [Fact]
        public void Constructor_StateUnderTest_NullParameter()
        {
            // Act
            var unitUnderTest = new Mapper<TestProfile>(null);

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.AutoMapper.ShouldNotBeNull();
        }


        [Fact]
        public void Automapper_StateUnderTest_ExpectedBehavior()
        {
            // Act
            var unitUnderTest = this.CreateMapper();

            // Assert
            unitUnderTest.ShouldNotBeNull();
            unitUnderTest.AutoMapper.ShouldNotBeNull();
        }

        /// <summary>
        /// Maps the state under test expected behavior.
        /// public TDestination Map<TDestination>(object source)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };

            // Act
            var result = unitUnderTest.Map<TestClass2>((object)source);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior1.
        /// public TDestination Map<TDestination>(object source, Action<IMappingOperationOptions> opts)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            Action<IMappingOperationOptions> opts = (x) => { };

            // Act
            var result = unitUnderTest.Map<TestClass2>((object)source, opts);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior2.
        /// public TDestination Map<TSource, TDestination>(TSource source)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior2()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };

            // Act
            var result = unitUnderTest.Map<TestClass1, TestClass2>(source);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior3.
        /// public TDestination Map<TSource, TDestination>(TSource source, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior3()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            Action<IMappingOperationOptions> opts = (x) => { };

            // Act
            var result = unitUnderTest.Map<TestClass1, TestClass2>(source, opts);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior4.
        /// public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior4()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            TestClass2 destination = new TestClass2();

            // Act
            var result = unitUnderTest.Map<TestClass1, TestClass2>(source, destination);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
            destination.ShouldNotBeNull();
            destination.Id.ShouldBe(source.Id);
            destination.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior5.
        /// public TDestination Map<TSource, TDestination>(TSource source, TDestination destination, Action<IMappingOperationOptions<TSource, TDestination>> opts)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior5()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            TestClass2 destination = new TestClass2();
            Action<IMappingOperationOptions> opts = (x) => { };

            // Act
            var result = unitUnderTest.Map<TestClass1, TestClass2>(source, destination, opts);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(source.Id);
            result.Name.ShouldBe(source.Name);
            destination.ShouldNotBeNull();
            destination.Id.ShouldBe(source.Id);
            destination.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior6.
        /// public object Map(object source, Type sourceType, Type destinationType)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior6()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };

            // Act
            var result = unitUnderTest.Map((object)source, typeof(TestClass1), typeof(TestClass2));

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<TestClass2>();
            var result2 = result as TestClass2;
            result2.Id.ShouldBe(source.Id);
            result2.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior7.
        /// public object Map(object source, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior7()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            Action<IMappingOperationOptions> opts = (x) => { };

            // Act
            var result = unitUnderTest.Map((object)source, typeof(TestClass1), typeof(TestClass2), opts);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<TestClass2>();
            var result2 = result as TestClass2;
            result2.Id.ShouldBe(source.Id);
            result2.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior8.
        /// public object Map(object source, object destination, Type sourceType, Type destinationType)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior8()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            TestClass2 destination = new TestClass2();

            // Act
            var result = unitUnderTest.Map((object)source, (object)destination, typeof(TestClass1), typeof(TestClass2));

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<TestClass2>();
            var result2 = result as TestClass2;
            result2.Id.ShouldBe(source.Id);
            result2.Name.ShouldBe(source.Name);

            destination.ShouldNotBeNull();
            destination.Id.ShouldBe(source.Id);
            destination.Name.ShouldBe(source.Name);
        }

        /// <summary>
        /// Maps the state under test expected behavior9.
        /// public object Map(object source, object destination, Type sourceType, Type destinationType, Action<IMappingOperationOptions> opts)
        /// </summary>
        [Fact]
        public void Map_StateUnderTest_ExpectedBehavior9()
        {
            // Arrange
            var unitUnderTest = this.CreateMapper();
            TestClass1 source = new TestClass1() { Id = 1, Name = "John Doe" };
            TestClass2 destination = new TestClass2();
            Action<IMappingOperationOptions> opts = (x) => { };

            // Act
            var result = unitUnderTest.Map((object)source, (object)destination, typeof(TestClass1), typeof(TestClass2), opts);

            // Assert
            result.ShouldNotBeNull();
            result.ShouldBeOfType<TestClass2>();
            var result2 = result as TestClass2;
            result2.Id.ShouldBe(source.Id);
            result2.Name.ShouldBe(source.Name);

            destination.ShouldNotBeNull();
            destination.Id.ShouldBe(source.Id);
            destination.Name.ShouldBe(source.Name);
        }

        //[Fact]
        //public void ProjectTo_StateUnderTest_ExpectedBehavior()
        //{
        //    // Arrange
        //    var unitUnderTest = this.CreateMapper();
        //    IQueryable source = TODO;
        //    object parameters = TODO;
        //    Expression<Func<TDestination, object>>[] membersToExpand = TODO;

        //    // Act
        //    var result = unitUnderTest.ProjectTo(
        //        source,
        //        parameters,
        //        membersToExpand);

        //    // Assert
        //    Assert.True(false);
        //}

        //[Fact]
        //public void ProjectTo_StateUnderTest_ExpectedBehavior1()
        //{
        //    // Arrange
        //    var unitUnderTest = this.CreateMapper();
        //    IQueryable source = TODO;
        //    IDictionary<string, object> parameters = TODO;
        //    string[] membersToExpand = TODO;

        //    // Act
        //    var result = unitUnderTest.ProjectTo(
        //        source,
        //        parameters,
        //        membersToExpand);

        //    // Assert
        //    Assert.True(false);
        //}

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