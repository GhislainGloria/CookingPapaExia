using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ClientSpawner
    {
        private int _intervalle;
        private int _maxGroupSize;
        private int _minGroupSize;

        public int Intervalle { get => _intervalle; set => _intervalle = value; }
        public int MaxGroupSize { get => _maxGroupSize; set => _maxGroupSize = value; }
        public int MinGroupSize { get => _minGroupSize; set => _minGroupSize = value; }
    }
}
