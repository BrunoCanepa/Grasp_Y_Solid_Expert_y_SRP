//--------------------------------------------------------------------------------
// <copyright file="TrainTests.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//--------------------------------------------------------------------------------
using System;
using System.Linq;
using System.Collections;
using Full_GRASP_And_SOLID.Library;
using NUnit.Framework;

namespace Tests
{
    public class BuildingTests
    {
        private static ArrayList supplyCatalog = new ArrayList();
        private static ArrayList toolCatalog = new ArrayList();
        private static void PopulateCatalogs()
        {
            AddProductToCatalog("Cemento", 100);
            AddProductToCatalog("Arena", 200);
            AddProductToCatalog("Tabla", 300);

            AddEquipmentToCatalog("Hormigonera", 1000);
            AddEquipmentToCatalog("Martillo", 2000);
        }

        private static void AddProductToCatalog(string description, double unitCost)
        {
            supplyCatalog.Add(new Supply(description, unitCost));
        }

        private static void AddEquipmentToCatalog(string description, double hourlyCost)
        {
            toolCatalog.Add(new Tool(description, hourlyCost));
        }
        private static Supply GetProduct(string description)
        {
            var query = from Supply product in supplyCatalog where product.Description == description select product;
            return query.FirstOrDefault();
        }

        private static Tool GetEquipment(string description)
        {
            var query = from Tool equipment in toolCatalog where equipment.Description == description select equipment;
            return query.FirstOrDefault();
        }
        /// <summary>
        /// Se testea el método GetBuildingText de Building, que es el mismo que imprime ConsolePrinter
        /// </summary>
        [Test]
        public void ConsolePrinterTest()
        {
            ConsolePrinter consolePrinter = new ConsolePrinter();
            Building tower = new Building("Tower");
            PopulateCatalogs();
            tower.AddTask(new Task(GetProduct("Cemento"), 100, GetEquipment("Hormigonera"), 120));
            tower.AddTask(new Task(GetProduct("Arena"), 200, GetEquipment("Hormigonera"), 120));
            tower.AddTask(new Task(GetProduct("Tabla"), 50, GetEquipment("Martillo"), 15));
            consolePrinter.PrintBuilding(tower);
            string textoImpreso = tower.GetTextToPrint();
            Assert.AreEqual("Edificio Tower:\n"                                     +
                            "100 de 'Cemento' usando 'Hormigonera' durante 120\n"   +
                            "200 de 'Arena' usando 'Hormigonera' durante 120\n"     +
                            "50 de 'Tabla' usando 'Martillo' durante 15\n"          +
                            "Cuesta un total de: $335000", textoImpreso);
        }
        /// <summary>
        /// Se testea si lanza una excepción al estar la lista de tareas vacía
        /// </summary>
        [Test]
        public void ExceptionTest()
        {
            Building castle = new Building("Castle");
            ConsolePrinter consolePrinter = new ConsolePrinter();
            try
            {
                consolePrinter.PrintBuilding(castle);
                Assert.Fail();
            }
            catch(EmptyTasksException)
            {
                Assert.Pass();
            }
        }
    }    
}