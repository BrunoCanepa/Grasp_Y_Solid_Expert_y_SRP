//-------------------------------------------------------------------------------
// <copyright file="Step.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------------

namespace Full_GRASP_And_SOLID.Library
{
    public class Task
    {
        public Task(Supply material, double quantity, Tool equipment, int time)
        {
            this.Quantity = quantity;
            this.Material = material;
            this.Time = time;
            this.Equipment = equipment;
        }

        public Supply Material { get; set; }

        public double Quantity { get; set; }

        public int Time { get; set; }

        public Tool Equipment { get; set; }
    }
}