using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InsurranceApi.Controllers;
using InsurranceLogic.Model;

namespace InsurranceApi.Tests.Controllers
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            InsurranceController controller = new InsurranceController();

            Insurrance insurrance = new Insurrance();
            insurrance.cobertura = 51;
            insurrance.descripcion = "Cobertura no apta para tipo riesgo";
            insurrance.tipoRiesgo = 4;
            insurrance.Nombre = "Test";
            insurrance.inicioVigenciaPoliza = DateTime.Now;
            insurrance.periodoCobertura = 12;
            insurrance.precioPoliza = 1200000;
            // Act
            string result = controller.Post(insurrance);

            // Assert
            Assert.AreEqual("Con riesgo alto, no puede tener cobertura mayor al 50%", result);
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange
            InsurranceController controller = new InsurranceController();

            Insurrance insurrance = new Insurrance();
            insurrance.cobertura = 51;
            insurrance.descripcion = "Cobertura no apta para tipo riesgo";
            insurrance.tipoRiesgo = 1;
            insurrance.Nombre = "Test";
            insurrance.inicioVigenciaPoliza = DateTime.Now;
            insurrance.periodoCobertura = 0;
            insurrance.precioPoliza = 1200000;
            // Act
            string result = controller.Post(insurrance);

            // Assert
            Assert.AreEqual("Periodo cobertura no puede ser menor a 1", result);
        }


        [TestMethod]
        public void TestMethod3()
        {
            // Arrange
            InsurranceController controller = new InsurranceController();

            Insurrance insurrance = new Insurrance();
            insurrance.cobertura = 51;
            insurrance.descripcion = "Cobertura no apta para tipo riesgo";
            insurrance.tipoRiesgo = 5;
            insurrance.Nombre = "Test";
            insurrance.inicioVigenciaPoliza = DateTime.Now;
            insurrance.periodoCobertura = 12;
            insurrance.precioPoliza = 1200000;
            // Act
            string result = controller.Post(insurrance);

            // Assert
            Assert.AreEqual("Tipo de riesgo erroneo", result);
        }
    }
}
