﻿using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServicesImplementation : IPersonService
    {
        private MySqlContext _context;

        public PersonServicesImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            try
            {
                _context.Add(person);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return person;
        }

        public void Delete(long id)
        {
            var result = _context.People.SingleOrDefault(p => p.Id.Equals(id));

            if (result != null)
            {
                try
                {
                    _context.People.Remove(result);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public List<Person> FindAll()
        {            
            return _context.People.ToList();
        }

        public Person FindById(long id)
        {
            return _context.People.SingleOrDefault(p => p.Id == id);
        }

        public Person Update(Person person)
        {
            if (!Exists(person.Id)) return new Person();

            var result = _context.People.SingleOrDefault(p => p.Id.Equals(person.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(person);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return person;
        }

        private bool Exists(long id)
        {
            return _context.People.Any(p => p.Id == id);
        }
    }
}
