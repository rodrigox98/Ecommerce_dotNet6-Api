using Ecommerce.DTOs.VendedorDTO;
using Ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TesteMarktplace
{
    public class VendedorTeste
    {
        [Fact]
        public void GetAllVendedor()
        {
            //Arrange
            List<ReadVendedorDTO> vendedores = new List<ReadVendedorDTO>();

            var mockVendedor = new Mock<ReadVendedorDTO>();
            //Act

            //Assert
        }
    }
}
