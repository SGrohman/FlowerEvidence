using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlowerEvidence.Models;

namespace FlowerEvidence.Interfaces
{
    public interface IFlowerManager
    {
        public void Add(Flower flower);
        public void Remove(Flower flower);
        public void Update(Flower flower);
        public Flower GetById(int? id);
        public IList<Flower> GetAll();
    }
}
