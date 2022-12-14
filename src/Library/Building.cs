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
    /// <summary>
    /// Clase de construcciones
    /// </summary>
    public class Building : IStringBuilder
    {
        /// <summary>
        /// Lista de tareas 
        /// </summary>
        /// <returns></returns>
        public ArrayList tasks = new ArrayList();
        /// <summary>
        /// Constructor que le da un nombre al building
        /// </summary>
        /// <param name="name"></param>
        public Building(string name)
        {
            this.Description = name;
        }
        /// <summary>
        /// Descripción del building
        /// </summary>
        /// <value></value>
        public string Description { get; set; }

        public void AddTask(Supply material, double quantity, Tool equipment, int time)
        {
            Task task = new Task(material, quantity, equipment, time);
            this.tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            this.tasks.Remove(task);
        }
        /// <summary>
        /// Devuelve una string de la construcción
        /// </summary>
        /// <returns></returns>
        public string GetTextToPrint()
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
            if (tasks.Count == 0)
            {
                throw new EmptyTasksException("La lista de tareas está vacía");
            }
            double costo = 0;
            foreach (Task task in this.tasks)
            {
                costo += (task.Material.UnitCost*task.Quantity) + (task.Equipment.HourlyCost*task.Time);
            }
            return costo;
        }
    }
}