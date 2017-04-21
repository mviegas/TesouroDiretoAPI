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
    public class ParseServicesTest
    {
        [Fact]
        public void ParseDadosDoTituloService()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync();

                Assert.NotEmpty(titulos);
            });
        }
    }
}
