using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResults
    {
        

        public Result(bool success, string message):this(success)// iki parametre gönderen birisi için bu constructoru calistir ama aynı zamanda digerinide çalıştır bu işlemi biz kod tekrarını engellemek için yapıyoruz 
        {
            Message = message;
            
        }
        public Result(bool success)
        {
             Success = success;
        }

        public bool Success { get; }

        public string Message { get; } // readonlydir get constructorda set edilebilr
    }
}
