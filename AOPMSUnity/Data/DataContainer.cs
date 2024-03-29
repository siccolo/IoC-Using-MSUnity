﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AOPMSUnity
{
    public class DataContainer:IDataContainer<string>
    {
        public DataContainer()
        {
            Console.WriteLine("DataContainer()");
        }

        private List<string> _List = new List<string>();

        public async Task<bool> Init(IEnumerable<string> list)//async Task<bool>
        {
            if (_List == null)
            {
                _List = new List<string>(list);
            }
            else
            {
                _List.Clear();
                _List.AddRange(list);
            }

            return true;
        }

        public async Task<bool> Put(IEnumerable<string> entries)//async Task<bool> 
        {
            _List.Clear();
            _List.AddRange(entries);
            return true;
        }

        public bool Add(string entry)
        {
            _List.Add(entry.ToString());
            return true;
        }

        public IEnumerable<string> Data
        {
            get
            {
                return _List??new List<string>();
            }
        }
    }
}
