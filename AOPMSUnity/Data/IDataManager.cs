using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOPMSUnity
{
    public interface IDataManager<TEntry>
    {
        //
        Task<bool> Load();//Task<bool>
        //

        //Task<bool> Put(IDataContainer<TEntries> dataContainer);
        Task<bool> Put(IEnumerable<TEntry> list);

        bool Add(TEntry entry);

        IEnumerable<TEntry>  Pull();
    }
}
