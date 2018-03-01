using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Racing
{
    public interface ILogic
    {
        Thread backgroundGame { get; set; }
        void Backgroud();
    }
}
