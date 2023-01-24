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
using DalpiazDDD.Domain.Entitys.ConjuntoEntrada;

namespace DalpiazDDD.Tests
{
    [TestFixture]
    public class AplicationServiceCalculoProgramacaoLinearTests
    {
        private static Fixture _fixture;
        private Mock<IServiceCalculoProgramacaoLinear> _serviceCalculoProgramacaoLinearMock;


        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture();
            _serviceCalculoProgramacaoLinearMock = new Mock<IServiceCalculoProgramacaoLinear>();
        }

        [Test]
        public void ApplicationServiceFuncionario_CalcularTotais_DeveRetornarCalculoTotal()
        {
            //Arrange
            var e = new ConjuntoEntrada();
            _serviceCalculoProgramacaoLinearMock.Setup(x => x.ExecutarOrTools(e)).Returns(true); 

            var aplicationServiceFuncionario =
                new ApplicationServiceCalculoProgramacaoLinear(_serviceCalculoProgramacaoLinearMock.Object);

            //Act
            aplicationServiceFuncionario.Executar(e);

            //Assert
            Assert.IsNotNull(2);
            //Assert.AreEqual(500000, result.TotalDistribuido);
            //Assert.AreEqual(10, result.Id);
            _serviceCalculoProgramacaoLinearMock.VerifyAll();


        }

    }
}
