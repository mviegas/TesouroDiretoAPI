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
        public void ParseTodos()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync();

                Assert.NotEmpty(titulos);
            });
        }

        [Fact]
        public void ParsePrefixados()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync(tipoDoTitulo: "Prefixado");

                Assert.True(titulos.Count() == 9);
            });
        }

        [Fact]
        public void ParsePrefixadosLowercase()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync(tipoDoTitulo: "prefixado");

                Assert.True(titulos.Count() == 9);
            });
        }

        [Fact]
        public void ParsePrefixadosMulticase()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync(tipoDoTitulo: "pRefIxaDo");

                Assert.True(titulos.Count() == 9);
            });
        }

        [Fact]
        public void ParseLFT()
        {
            Task.Factory.StartNew(async () =>
            {
                var titulos = await new ParseDadosDoTituloService().ExecuteAsync(sigla: "LFT");

                Assert.True(titulos.Count() == 2);
            });
        }
    }
}
