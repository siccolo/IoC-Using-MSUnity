using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOPMSUnity
{
    public class DataManager : IDataManager<string>
    {

        IDataContainer<string> _DataContainer;

        public DataManager(IDataContainer<string>  dataContainer)
        {
            Console.WriteLine("DataManager()");
            _DataContainer = dataContainer;
        }

        
        public async Task<bool> Load()  //async Task<bool>
        {
            var l = new List<string> { "aa", "bb", "cc" };
            var result = await _DataContainer.Init(l);   //await
            return result;
        }

        public IEnumerable<string> Pull()
        {
            return _DataContainer.Data;
        }

        public async Task<bool> Put(IEnumerable<string> list)//async Task<bool> 
        {
            var result = await _DataContainer.Put(list); //await
            return result;
        }
         
        public bool Add(string value)
        {
            return _DataContainer.Add(value);
        }
       
    }
}
