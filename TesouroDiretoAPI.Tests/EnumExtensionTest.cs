using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using Xunit.Abstractions;
using TesouroDiretoAPI.Common;

namespace TesouroDiretoAPI.Tests
{
    public class EnumExtensionTest
    {
        [Fact]
        public void GetEnumValueFromDescriptionInvalidType()
        {
            Assert.Throws<InvalidOperationException>(() => EnumExtension.GetEnumValueFromDescription<Titulo>(""));
        }

        [Fact]
        public void GetEnumValueFromDescriptionInvalidDescription()
        {
            Assert.Throws<ArgumentException>(() => EnumExtension.GetEnumValueFromDescription<TitulosDisponiveisEnum>("LCI"));
        }

        [Fact]
        public void GetEnumValueFromDescription()
        {
            Assert.True(EnumExtension.GetEnumValueFromDescription<TitulosDisponiveisEnum>("Tesouro IGPM+ com Juros Semestrais 2017") == TitulosDisponiveisEnum.IGPMComJurosSemestrais2017);
        }

        [Fact]
        public void GetDescription()
        {
            Assert.True(TitulosDisponiveisEnum.IGPMComJurosSemestrais2017.GetDescription() == "Tesouro IGPM+ com Juros Semestrais 2017");
        }

        [Fact]
        public void GetDescriptionInvalid()
        {
            Assert.False(TitulosDisponiveisEnum.IGPMComJurosSemestrais2017.GetDescription() == "Tesouro IPCA+ com Juros Semestrais 2017");
        }

        [Fact]
        public void GetVencimento()
        {
            Assert.True(TitulosDisponiveisEnum.IGPMComJurosSemestrais2017.GetVencimento() == "01/07/2017");
        }
    }
}
