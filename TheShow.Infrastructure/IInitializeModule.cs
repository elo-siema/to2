using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TheShow.Infrastructure
{
    public interface IInitializeModule
    {
        Task Initialize();
    }
}
