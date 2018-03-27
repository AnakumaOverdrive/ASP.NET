using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class DBBase
    {
        public IRepository _iRepository;

        public DBBase(IRepository iRepository)
        {
            _iRepository = iRepository;
        }
        
        public void Search(string commandText)
        {
            _iRepository.Get();
        }
    }
}
