﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public interface IStrategy
    {

		void Behavior(IActor actor, List<IActor> allActors);

    } 
}
