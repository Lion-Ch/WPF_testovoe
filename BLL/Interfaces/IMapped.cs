using AutoMapper;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IMapped<theirType,ourType>
    {
        IMapper CreateMap();
        IEnumerable<theirType>  OutMap(IEnumerable<ourType> list);
        IEnumerable<ourType> InMap(IEnumerable<theirType> list);
    }
}
