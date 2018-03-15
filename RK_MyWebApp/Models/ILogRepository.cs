using System.Collections.Generic;
using Microsoft.WindowsAzure.Storage.Table;

namespace RK_MyWebApp.Models
{
    public interface ILogRepository<T> where T : ITableEntity, new()
    {
        void Add(IEnumerable<T> obj);
    }
}