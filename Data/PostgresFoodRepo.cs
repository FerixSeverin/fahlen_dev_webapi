using System;
using System.Collections.Generic;
using System.Linq;
using fahlen_dev_webapi.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace fahlen_dev_webapi.Data
{
    public class PostgresFoodRepo : ICommanderRepo
    {
        private readonly FoodContext _context;

        public PostgresFoodRepo(FoodContext context)
        {
            _context = context;
        }

        public void CreateAccount(Account acc)
        {
            if (acc == null) {
                throw new ArgumentNullException(nameof(acc));
            }

            _context.Accounts.Add(acc);
        }

        public Account GetAccountById(int id)
        {
            return _context.Accounts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return _context.Accounts.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}