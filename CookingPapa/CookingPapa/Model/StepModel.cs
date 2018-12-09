using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class StepModel
    {
        private string _utensil;
        private string _ingredient;
        private string _workboard;
        private int _duration;

        public string Utensil { get => _utensil; set => _utensil = value; }
        public string Ingredient { get => _ingredient; set => _ingredient = value; }
        public string Workboard { get => _workboard; set => _workboard = value; }
        public int Duration { get => _duration; set => _duration = value; }
    }
}
