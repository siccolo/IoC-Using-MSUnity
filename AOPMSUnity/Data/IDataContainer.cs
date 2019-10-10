using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AOPMSUnity
{

    public interface IDataContainer<TEntry>
    {
        Task<bool> Init(IEnumerable<TEntry> data);   //Task<bool>

        IEnumerable<TEntry> Data  { get; }

        Task<bool> Put(IEnumerable<TEntry> entries);//Task<bool> 

        bool Add(TEntry entry);
    }
}
