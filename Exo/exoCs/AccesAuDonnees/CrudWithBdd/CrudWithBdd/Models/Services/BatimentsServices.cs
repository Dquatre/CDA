﻿using CrudWithBdd.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudWithBdd.Models.Services
{
    public class BatimentsServices
    {

        private readonly ComplexDbContext _context;
        public BatimentsServices(ComplexDbContext context)
        {
            _context = context;
        }

        public void AddBatiments(Batiment p)
        {
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            _context.Batiments.Add(p);
            _context.SaveChanges();
        }

        public void DeleteBatiment(Batiment p)
        {
            //si l'objet personne est null, on renvoi une exception
            if (p == null)
            {
                throw new ArgumentNullException(nameof(p));
            }
            // on met à jour le context
            _context.Batiments.Remove(p);
            _context.SaveChanges();
        }

        public IEnumerable<Batiment> GetAllBatiments()
        {
            return _context.Batiments.ToList();
        }

        public Batiment GetBatimentById(int id)
        {
            return _context.Batiments.FirstOrDefault(p => p.IdBatiment == id);
        }

        public void UpdateBatiment(Batiment p)
        {
            _context.SaveChanges();
        }

    }
}
