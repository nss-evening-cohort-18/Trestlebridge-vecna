﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trestleBridge.Actions;
using trestleBridge.Interfaces;

namespace trestleBridge.Models.Facilities
{
    public class NaturalField  : IFields
    {
        public string Name { get; set; } = "naturalfield";
        public static string Names { get; set; } = "naturalfield";
        private List<ISeed> _seeds = new List<ISeed>();
        public int _capacity { get; } = 2;

        public int currentCap { get => _seeds.Count; }

        public void AddResource(ISeed seed, Farm farm)
        {
            if (_capacity - currentCap > 0)
            {
                _seeds.Add(seed);
            }
            else
            {
                Console.WriteLine("**** That facililty is not large enough ***** ***Please choose another one * ***");
                ChooseNaturalField.CollectInput(farm, seed);
            }
        }
        public override string ToString()
        {
            Dictionary<string, int> seedcount = new Dictionary<string, int>();
            StringBuilder output = new StringBuilder();
            output.Append($"Natural Field (");
            this._seeds.ForEach(a =>
            {
                if (seedcount.ContainsKey(a.Name))
                {
                    seedcount[a.Name] += 1;
                }
                else
                {
                    seedcount[a.Name] = 1;
                }
            });
            foreach (KeyValuePair<string, int> kvp in seedcount.OrderByDescending(x => x.Value))
            {
                output.Append($" {kvp.Value.ToString()} {kvp.Key}s, ");
            }
            output.Remove(output.Length - 2, 1);
            output.Append(")");
            return output.ToString();
        }
    }
}