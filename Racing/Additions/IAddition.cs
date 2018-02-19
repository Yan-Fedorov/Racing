using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Racing.Additions
{
    public interface IAddition
    {
        bool TryApply(Collision collision);
    }
}
