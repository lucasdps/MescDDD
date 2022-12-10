using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using AutoMapper;
using DalpiazDDD.Application;
using DalpiazDDD.Application.Dtos;
using DalpiazDDD.Application.Interfaces.Mappers;
using DalpiazDDD.Domain.Core.Interfaces.Services;
using DalpiazDDD.Domain.Entitys;
using Moq;
using NUnit.Framework;

namespace DalpiazDDD.Tests
{
    [TestFixture]
    public class AplicationServiceFuncionarioTests
    {
        private static Fixture _fixture;
        private Mock<IServiceFuncionario> _serviceFuncionarioMock;
        private Mock<IMapperFuncionario> _mapperMock;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceFuncionarioMock = new Mock<IServiceFuncionario>();
            _mapperMock = new Mock<IMapperFuncionario>();
        }

        [Test]
        public void ApplicationServiceCliente_GetAll_DeveRetornarCincoFuncionarios()
        {
            //Arrange
            var funcionarios = _fixture.Build<Funcionario>().CreateMany(5);
            var funcionariosDto = _fixture.Build<FuncionarioDto>().CreateMany(5);

            _serviceFuncionarioMock.Setup(x => x.GetAll()).Returns(funcionarios);
            _mapperMock.Setup(x => x.MapperListFuncionariosDto(funcionarios)).Returns(funcionariosDto);

            var applicationServiceFuncionario = new AplicationServiceFuncionario(_serviceFuncionarioMock.Object, _mapperMock.Object);

            //Act
            var result = applicationServiceFuncionario.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
            _serviceFuncionarioMock.VerifyAll();
            _mapperMock.VerifyAll();
        }

        [Test]
        public void ApplicationServiceFuncionario_GetById_DeveRetornarFuncionario()
        {
            //Arrange
            const int id = 10;

            var cliente = _fixture.Build<Funcionario>()
                .With(c => c.Id, id)
                .With(c => c.Nome, "ciclano teste")
                .Create();

            var clienteDto = _fixture.Build<FuncionarioDto>()
                .With(c => c.Id, id)
                .With(c => c.Nome, "ciclano teste")
                .Create();

            _serviceFuncionarioMock.Setup(x => x.GetById(id)).Returns(cliente);
            _mapperMock.Setup(x => x.MapperEntityToDto(cliente)).Returns(clienteDto);

            var aplicationServiceFuncionario =
                new AplicationServiceFuncionario(_serviceFuncionarioMock.Object, _mapperMock.Object);

            //Act
            var result = aplicationServiceFuncionario.GetById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("ciclano teste", result.Nome);
            Assert.AreEqual(10, result.Id);
            _serviceFuncionarioMock.VerifyAll();
            _mapperMock.VerifyAll();


        }
    }
}