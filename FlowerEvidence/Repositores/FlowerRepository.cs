using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FlowerEvidence.Database;
using FlowerEvidence.Interfaces;
using FlowerEvidence.Models;

namespace FlowerEvidence.Repositores
{
    public class FlowerRepository : IFlowerRepository
    {
        private readonly FlowerContext _context;

        public FlowerRepository(FlowerContext context)
        {
            _context = context;
        }

        public void Add(Flower flower)
        {
            _context.Add(flower);
            _context.SaveChanges(); //uloží změni do databaze
        }

        public void Delete(Flower flower)
        {
            if(_context.Flowers.Any(f => f.Id == flower.Id))
            {
                return;
            }
            try
            {
                _context.Remove(flower);
                _context.SaveChanges();
            }
            catch
            {
                _context.Entry(flower).State = EntityState.Unchanged; //v případě chyby vrátí změny entity flower
                throw;
            } 
        }

        public Flower? Get(int? id)
        {
            if (id == null)
                throw new Exception("Id must be Inserted");
            return _context.Flowers.Find(id); 
        }

        public IList<Flower> GetAll()
        {
            return _context.Flowers.AsNoTracking().ToList();
        }

        public void Update(Flower flower)
        {
            _context.Entry(flower).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
