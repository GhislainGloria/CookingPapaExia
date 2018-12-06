﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Order
    {
        private Table _table;
        private List<Dish> _recipes;
        private bool _prepare;

        public bool Prepare { get => _prepare; set => _prepare = value; }
        public Table Table { get => _table; set => _table = value; }
        public List<Dish> Recipes { get => _recipes; set => _recipes = value; }
    }
}