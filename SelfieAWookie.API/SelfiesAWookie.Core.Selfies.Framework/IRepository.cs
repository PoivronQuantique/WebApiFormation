using SelfiesAWookie.Core.Selfies.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfieAWookie.Core.Selfies.Framework
{
    public interface IRepository
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
