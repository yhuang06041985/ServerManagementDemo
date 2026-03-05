using Microsoft.AspNetCore.Components.Server;
using Microsoft.Identity.Client;
using ServerManagement.Data;
using ServerManagement.Models;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerManagement.Repository
{
    public class ServerReporsitory
    {
        private Server? deleteServer;

        List<Server> servers = new List<Server>()
        {
            new Server { Id = 1, Name = "Server 1", CityId=1, IsOnline=true},
            new Server { Id = 2, Name = "Server 2", CityId = 1, IsOnline=false },
            new Server { Id = 3, Name = "Server 3", CityId= 1, IsOnline = false},
            new Server { Id = 4, Name = "Server 4", CityId= 1, IsOnline = true},
            new Server { Id = 5, Name = "Server 5", CityId= 2, IsOnline=true},
            new Server { Id = 6, Name = "Server 6", CityId= 2, IsOnline = false},
            new Server { Id = 7, Name = "Server 7", CityId= 2, IsOnline = true},
            new Server { Id = 8, Name = "Server 8", CityId= 3, IsOnline = true},
            new Server { Id = 9, Name = "Server 9", CityId= 3, IsOnline = false},
            new Server { Id = 10, Name = "Server 10", CityId=3, IsOnline = false},
            new Server { Id = 11, Name = "Server 11", CityId= 3, IsOnline = true},
            new Server { Id = 12, Name = "Server 12", CityId= 4, IsOnline = false},
            new Server { Id = 13, Name = "Server 13", CityId= 4, IsOnline = true},
            new Server { Id = 14, Name = "Server 14", CityId= 4, IsOnline = false},
            new Server { Id = 15, Name = "Server 15", CityId= 4, IsOnline = true}

        };

        private readonly ApplicationDbContext _context;
           
        public ServerReporsitory(ApplicationDbContext context)
        {
            _context = context;
        }   
        
        // Made async so we can await BeginTransactionAsync and call CommitAsync/RollbackAsync.
        public async Task TestTransaction(int id, Server server)
        {
            // Await the async begin transaction and use 'await using' to ensure disposal.
            await using var transaction = await _context.Database.BeginTransactionAsync();
            Server? updateServer = servers.FirstOrDefault(u => u.Id == id);
            if (updateServer != null)
            {
                updateServer.Id = id;
                updateServer.Name = server.Name;
                updateServer.IsOnline = server.IsOnline;
                try
                {
                    // Update context and persist changes before committing.
                    _context.Servers.Update(updateServer);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch (Exception)
                {
                    // Rollback the transaction asynchronously and rethrow.
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public List<Server> GetServer()
        {
            var servers = this.servers.ToList();
            return servers;
        }

        public void GetPageNumber(int pageNumber, int pageSize)
        {
            var pagedServers = this.servers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }


        public List<Server> GetServerByCity(string city)
        {
            return this.servers.Where(s => s.Name.Contains(city, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public List<Server> GetServerByName(string filterName)
        {
            return this.servers.Where(s => s.Name.Contains(filterName, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void Delete(int id)
        {
            if (id > 0)
                deleteServer = servers.FirstOrDefault(u => u.Id == id);
            if (deleteServer != null)
                servers.Remove(deleteServer);
        }


        public Server GetServerById(int? id)
        {
            return this.servers?.FirstOrDefault(s => s.Id == id);
        }

        public void AddServer(Server server)
        {
            int maxId = servers.Max(s => s.Id);
            maxId = maxId + 1;
            server.Id = maxId;

            servers.Add(server);

        }

        public void UpdateServer(Server server, int id)
        {
            Server updateServer = servers.FirstOrDefault(u => u.Id == id);
            if (updateServer != null)
            {
                updateServer.Id = id;
                updateServer.Name = server.Name;
                updateServer.IsOnline = server.IsOnline;
            }
        }

    }
}
