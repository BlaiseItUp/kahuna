using Kahuna.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahuna.MVC.Repositories
{

    public class ClientRepository 
    {
        private KahunaContext _context;

        public IEnumerable<Client> GetAll()
        {
           return _context.Client
                .ToList();            

        }
    }
}
