using deliverybook.Infra.Extensions;
using FluentAssertions;
using Xunit;

namespace deliverybook.UnitTests.Infra.Extensions
{
    public class PaginacaoEntensionsTests
    {
        private const int _default = 0;
        private const int _fisrt = 1;

        [Fact]
        public void Devera_retornar_offset_default_0_quando_pagina_0()
        {
            //Arrange
            var pagina = 0;

            //Act
            var offset = pagina.CalcularOffset();

            //Assert
            offset.Should().Be(_default);
        }

        [Fact]
        public void Devera_retornar_offset_default_0_quando_pagina_1()
        {
            //Arrange
            var pagina = 1;

            //Act
            var offset = pagina.CalcularOffset();

            //Assert
            offset.Should().Be(_default);
        }

        [Fact]
        public void Devera_retornar_offset_10_quando_pagina_2()
        {
            //Arrange
            var pagina = 2;

            //Act
            var offset = pagina.CalcularOffset();

            //Assert
            offset.Should().Be(10);
        }

        [Fact]
        public void Devera_retornar_pagina_1_quando_offset_default_0()
        {
            //Arrange
            var offset = 0;

            //Act
            var pagina = offset.CalcularPagina();

            //Assert
            pagina.Should().Be(_fisrt);
        }

        [Fact]
        public void Devera_retornar_pagina_1_quando_offset_1()
        {
            //Arrange
            var offset = 1;

            //Act
            var pagina = offset.CalcularPagina();

            //Assert
            pagina.Should().Be(_fisrt);
        }

        [Fact]
        public void Devera_retornar_pagina_2_quando_offset_10()
        {
            //Arrange
            var offset = 10;

            //Act
            var pagina = offset.CalcularPagina();

            //Assert
            pagina.Should().Be(2);
        }
    }
}