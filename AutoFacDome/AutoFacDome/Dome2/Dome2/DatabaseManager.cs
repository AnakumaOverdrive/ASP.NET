﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dome2
{
    public class DatabaseManager
    {
        IDatabase _database;
        User _user;  
       
        public DatabaseManager(IDatabase database)
            : this(database, null)
        {
        }

        public DatabaseManager(IDatabase database, User user)
        {
            _database = database;
            _user = user;
        }

        public bool IsAuthority()
        {
            bool result = _user != null && _user.Id == 1 && _user.Name == "leepy" ? true : false;
            if (!result)
                Console.WriteLine("Not authority!");

            return result;
        }  

        public void Search(string commandText)
        {
            _database.Select(commandText);
        }

        public void Add(string commandText)
        {
            if (IsAuthority())   
                _database.Insert(commandText);
        }

        public void Save(string commandText)
        {
            _database.Update(commandText);
        }

        public void Remove(string commandText)
        {
            _database.Delete(commandText);
        }

    }  
}
