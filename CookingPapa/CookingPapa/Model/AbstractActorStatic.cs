﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    abstract class AbstractActorStatic : IActor
    {
        private List<ICarriableItem> _items;
        private Position _position;
        private IActor _target;
        private bool _busy;
        private Thread _thread;
        private int _maxInventorySize;

        public bool Busy { get => _busy; set => _busy = value; }
        public Thread Thread { get => _thread; set => _thread = value; }
        public int MaxInventorySize { get => _maxInventorySize; set => _maxInventorySize = value; }
        public List<ICarriableItem> Items { get => _items; set => _items = value; }
        public Position Position { get => _position; set => _position = value; }
        public IActor Target { get => _target; set => _target = value; }

        public void CallStrategy()
        {

        }

        public void Event()
        {
            throw new NotImplementedException();
        }

        public void NextTick()
        {
            throw new NotImplementedException();
        }
    }
}