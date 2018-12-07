using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Utensil : ICarriableItem
    {
        private bool _isSmallItem;
        private Step _lastUsedFor;

        public Utensil()
        {
        }

        public bool IsSmallItem { get => _isSmallItem; set => _isSmallItem = value; }
        public Step LastUsedFor { get => _lastUsedFor; set => _lastUsedFor = value; }
    }
}
