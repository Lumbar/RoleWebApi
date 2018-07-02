namespace RoleWebApi.Information.API.Test
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Security.Principal;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using RoleWebApi.Application.Context.PolicyModule.Service;
    using RoleWebApi.Application.Context.PolicyModule.Specifications;
    using RoleWebApi.Application.Context.SecurityModule.Specifications;
    using RoleWebApi.Application.Core.Adapters;
    using RoleWebApi.Infrastructure.Data.Entity.Domain;

    [TestClass]
    public class PolicyTest
    {
        private readonly PolicySpecification _policySpecification;

        public PolicyTest()
        {
            _policySpecification = new PolicySpecification();
        }

        [TestMethod]
        public void ListClients()
        {       
            //ingresar los datos en la instancia
            List<Policy> lstActual = _policySpecification.ListPolicies().ToList();

            //preparar la respuesta esperada
            List<Policy> lstEsperada = new List<Policy>()
            {
                new Policy(){
                    Id = "64cceef9-3a01-49ae-a23b-3761b604800b",
                    AmountInsured = Decimal.Parse("1825.89"),
                    Email = "inesblankenship@quotezart.com",
                    InceptionDate = DateTime.Parse("2016-06-01T03:33:32Z"),
                    InstallmentPayment = true,
                    ClientId = "e8fd159b-57c4-4d36-9bd7-a59ca13057bb"
                }
            };

            ////Comparar los resultados
            Assert.AreEqual(lstEsperada.FirstOrDefault().Id, lstActual.FirstOrDefault().Id, "Error en la prueba");
        }
    }
}
