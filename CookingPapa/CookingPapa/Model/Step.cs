using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Step : ModelRecipe
    {
#pragma warning disable CS0169 // Le champ 'Step._prepare' n'est jamais utilisé
        private bool _prepare;
#pragma warning restore CS0169 // Le champ 'Step._prepare' n'est jamais utilisé
    }
}
