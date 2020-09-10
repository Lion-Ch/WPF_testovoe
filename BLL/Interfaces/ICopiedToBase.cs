using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public interface ICopiedToBase<T> where T: class
    {
        T Copy();
    }
}
