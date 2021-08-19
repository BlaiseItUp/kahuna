using Kahuna.MVC.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kahuna.MVC.Repositories
{

    public class ClientRepository 
    {
        private KahunaContext _context = new KahunaContext();

        public KahunaContext Context { get; set; }

        public ClientRepository()
        {
            Context = _context;
        }
        
        public IEnumerable<Client> GetAll()
        {
           return _context.Client
                .ToList();            

        }

        public void Add(Client client)
        {
            _context.Add(client);
        }
    }
}
