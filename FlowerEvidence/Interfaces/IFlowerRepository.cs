using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FlowerEvidence.Models;

namespace FlowerEvidence.Interfaces
{
    public interface IFlowerRepository
    {
        public void Add(Flower flower);
        public void Update(Flower flower);
        public void Delete(Flower flower);
        public Flower? Get(int? id);
        public IList<Flower> GetAll();
    }
}
