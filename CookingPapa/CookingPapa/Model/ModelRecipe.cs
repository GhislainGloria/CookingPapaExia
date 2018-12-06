using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookingPapa
{
    abstract class ModelRecipe
    {
        private List<Step> _steps;
        private string _name;

        public string Name { get => _name; set => _name = value; }
        public List<Step> Steps { get => _steps; set => _steps = value; }
    }
}
