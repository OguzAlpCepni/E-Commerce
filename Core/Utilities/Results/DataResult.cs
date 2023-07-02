using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResults<T>
    {
        
        public DataResult(T data,bool success,string message):base(success,message)
        {
            // Resulttaki succes message parametreli constructoru tekrar yazmamak için base kullandık
            // base(succes,message( yapısını calistırdın zaman biz data yani alttaki constructoru cagırmazsın  o yüzden datayı setlenem gerek 
            Data = data;
        }
        // don't send message
        public DataResult(T data ,bool success):base(success) 
        {
            Data = data;
        }

        public T Data { get; }

    }
}
