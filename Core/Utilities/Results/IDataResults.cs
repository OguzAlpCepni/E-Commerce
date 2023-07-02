using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{                                       // bu classı bir data dondurenler icin yapacagım bir list icin
    public interface IDataResults<T>:IResults    // hangi tipi dondurecegini belirt 
    {
        // IResult icerisinde message ve success var ayrı olarak bir data tanımla
        T Data { get; }
    }
}
