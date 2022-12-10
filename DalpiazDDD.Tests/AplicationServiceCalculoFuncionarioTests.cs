using AutoFixture;
using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DalpiazDDD.Tests
{
    [TestFixture]
    public class AplicationServiceCalculoFuncionarioTests
    {
        private static Fixture _fixture;
        private Mock<IServiceCalculoFuncionario> _serviceCalculoFuncionarioMock;
        private Mock<IMapperCalculoFuncionario> _mapperMock;
        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceCalculoFuncionarioMock = new Mock<IServiceCalculoFuncionario>();
            _mapperMock = new Mock<IMapperCalculoFuncionario>();
        }


        [Test]
        public void ApplicationServiceFuncionario_CalcularTotais_DeveRetornarCalculoTotal()
        {
            //Arrange
            var CalculoFuncionarios = _fixture.Build<CalculoFuncionario>().CreateMany(1).First();
            var CalculoFuncionariosDto = _fixture.Build<CalculoFuncionarioDto>().CreateMany(1).First();

            _serviceCalculoFuncionarioMock.Setup(x => x.CalcularTotais(500000)).Returns(CalculoFuncionarios);
            _mapperMock.Setup(x => x.MapperToCalculoFuncionarioDto(CalculoFuncionarios)).Returns(CalculoFuncionariosDto);

            var aplicationServiceFuncionario =
                new ApplicationServiceCalculoFuncionario(_serviceCalculoFuncionarioMock.Object, _mapperMock.Object);

            //Act
            var result = aplicationServiceFuncionario.CalculoFuncionarioPL(500000);

            //Assert
            Assert.IsNotNull(result);
            //Assert.AreEqual(500000, result.TotalDistribuido);
            //Assert.AreEqual(10, result.Id);
            _serviceCalculoFuncionarioMock.VerifyAll();
            _mapperMock.VerifyAll();


        }

    }
}
