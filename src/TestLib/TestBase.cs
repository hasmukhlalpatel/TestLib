using AutoFixture;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestLib
{
    public abstract class TestBase<T>
        where T : class
    {
        protected  Dictionary<Type, Mock> MockedList { get; private set; } = new Dictionary<Type, Mock>();

        public TestBase()
        {
            LazySut = new Lazy<T>(() => { return InstantiateSut(); }, true);
        }

        private T InstantiateSut()
        {
            var type = typeof(T);
            if (type.IsAbstract || type.IsInterface)
                throw new InvalidOperationException($"{typeof(T).Name} should not be an Interface or an Abstract class.");

            var constructors = type.GetConstructors(BindingFlags.Public | BindingFlags.Instance);
            if (constructors.Any())
            {
                var constructor = constructors.First();
                var constructedMockParameters = constructor.GetParameters()
                    .Select(x => GetMock(x.ParameterType).Object)
                    .ToList();

                return constructor.Invoke(constructedMockParameters.ToArray()) as T;
            }
            else
            {
                return Activator.CreateInstance(type) as T;
            }
        }

        private Mock GetMock(Type serviceType)
        {
            if (MockedList.ContainsKey(serviceType))
            {
                return MockedList[serviceType];
            }
            try
            {
                var constructedMockType = typeof(Mock<>).MakeGenericType(serviceType);
                var constructedMockObject = (Mock)Activator.CreateInstance(constructedMockType);
                return MockedList[serviceType] = constructedMockObject;
            }
            catch (Exception ex)
            {
                throw new TargetInvocationException($"{serviceType.Name} must an interface or an Abstract or non sealed class.", ex);
            }
        }

        protected Mock<Tsrv> GetMock<Tsrv>()
            where Tsrv : class
        {
            return (Mock<Tsrv>)GetMock(typeof(Tsrv));
        }

        protected Lazy<T> LazySut { get; private set; }
        
        protected T Sut { get { return LazySut.Value; }  }

        protected Fixture Fixture { get; private set; } = new Fixture();
    }
}
