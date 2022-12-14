//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Full_GRASP_And_SOLID.Library
{
    public class Building
    {
        public ArrayList tasks = new ArrayList();

        public Building(string name)
        {
            this.Description = name;
        }

        public string Description { get; set; }

        public void AddTask(Task task)
        {
            this.tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            this.tasks.Remove(task);
        }
        public string GetBuildingText()
        {
            List<string> StringBuildings = new List<string>();
            StringBuildings.Add($"Edificio {this.Description}:");
            foreach (Task task in this.tasks)
            {
                StringBuildings.Add($"{task.Quantity} de '{task.Material.Description}' " +
                    $"usando '{task.Equipment.Description}' durante {task.Time}");
            }
            StringBuildings.Add($"Cuesta un total de: ${this.GetProductCost()}");
            return String.Join("\n", StringBuildings.ToArray());
        }
        // Para agregar esta responsabilidad utilizo el patrón Expert, ya que le agrego una responsabilidad a la clase
        // experta en información
        public double GetProductCost()
        {
            double costo = 0;
            foreach (Task task in this.tasks)
            {
                costo += (task.Material.UnitCost*task.Quantity) + (task.Equipment.HourlyCost*task.Time);
            }
            return costo;
        }
    }
}