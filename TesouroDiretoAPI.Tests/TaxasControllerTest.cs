using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using TesouroDiretoAPI.Common;
using TesouroDiretoAPI.Controllers;
using Xunit;

namespace TesouroDiretoAPI.Tests
{
    public class TaxasControllerTest
    {
        [Fact]
        public async System.Threading.Tasks.Task GetPrefixados()
        {
            var titulos = await new TaxasController().Get("Prefixado", null, null);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 9);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPrefixadosComCupom()
        {
            var titulos = await new TaxasController().Get("Prefixado", true, null);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 4);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetPrefixados2021()
        {
            var titulos = await new TaxasController().Get("Prefixado", null, 2021);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetIPCA()
        {
            var titulos = await new TaxasController().Get("IPCA", null, null);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 11);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetIGPM()
        {
            var titulos = await new TaxasController().Get("IGPM", null, null);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 3);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetSelic()
        {
            var titulos = await new TaxasController().Get("Selic", null, null);

            Assert.IsType<JsonResult>(titulos);
            Assert.True(((titulos as JsonResult).Value as IList<Titulo>).Count == 2);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetTodosOsTitulos()
        {
            var todosOsTitulos = await new TaxasController().Get();

            Assert.IsType<JsonResult>(todosOsTitulos);
        }
    }
}
