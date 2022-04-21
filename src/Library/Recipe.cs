//-------------------------------------------------------------------------
// <copyright file="Recipe.cs" company="Universidad Católica del Uruguay">
// Copyright (c) Programación II. Derechos reservados.
// </copyright>
//-------------------------------------------------------------------------

using System;
using System.Collections;

namespace Full_GRASP_And_SOLID.Library
{
    public class Recipe
    {
        private ArrayList steps = new ArrayList();

        public Product FinalProduct { get; set; }

        public void AddStep(Step step)
        {
            this.steps.Add(step);
        }

        public void RemoveStep(Step step)
        {
            this.steps.Remove(step);
        }

        public void PrintRecipe()
        {
            Console.WriteLine($"Receta de {this.FinalProduct.Description}:");
            foreach (Step step in this.steps)
            {
                Console.WriteLine($"{step.Quantity} de '{step.Input.Description}' " +
                    $"usando '{step.Equipment.Description}' durante {step.Time}");
            }
        }

        //Costo insumos = Sumatoria de costo unitario de los insumos
        //No me queda claro si step.Quantity se refiere a la cantidad de producto o al costo unitario.
        //Asumo que la cantidad guardada en step.Quantity y en Product.UnitCost ambos se refieren al
        //costo unitario.
        public double CostInsumos()
        {
            double res = 0;
            foreach (Step step in this.steps)
            {
                res = res + step.Input.UnitCost;
            }
            Console.WriteLine($"El costo de insumos es: {res}");
            return res;
        }

        //Costo equipamiento = Sumatoria de tiempo de uso 
        //                     x costo/hora del equipo para todos los pasos de la receta
        //Asumo que el tiempo esta en segundos
        public double CostEquip()
        {
            double res = 0;
            foreach (Step step in this.steps)
            {
                double segundos = step.Time;
                double divisor = 3600;
                double horas = segundos/divisor;
                res = res + (step.Equipment.HourlyCost*horas);
            }
            Console.WriteLine($"El costo de equipamiento es: {res}");
            return res;
        }

        //Costo total = costo insumos + costo equipamiento
        public void CostTotal(double ins, double eq)
        {
            double res = ins + eq;
            Console.WriteLine($"El costo total es: {res}");
        }
    }
}