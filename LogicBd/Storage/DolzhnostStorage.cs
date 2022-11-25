using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBd.BindingModel;
using LogicBd.Model;
using LogicBd.ViewModel;

namespace LogicBd.Storage
{
    public class DolzhnostStorage
    {
        public void Delete(DolzhnostBindingModel model)
        {
            using var context = new Database();
            var element = context.Dolzhnosti
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Dolzhnosti.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public DolzhnostViewModel GetElement(DolzhnostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            var Dolzhnost = context.Dolzhnosti
                .FirstOrDefault(rec => rec.Id == model.Id);
            return Dolzhnost != null ? CreateModel(Dolzhnost) : null;
        }
        public List<DolzhnostViewModel> GetFilteredList(DolzhnostBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            return context.Dolzhnosti
                .Where(rec => rec.Id.Equals(model.Id))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<DolzhnostViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Dolzhnosti
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(DolzhnostBindingModel model)
        {
            using var context = new Database();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Dolzhnosti.Add(CreateModel(model, new Dolzhnost()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(DolzhnostBindingModel model)
        {
            using var context = new Database();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Dolzhnosti
                    .FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        private static Dolzhnost CreateModel(DolzhnostBindingModel model, Dolzhnost Dolzhnost)
        {
            Dolzhnost.Dol = model.Dol;
            return Dolzhnost;
        }

        private static DolzhnostViewModel CreateModel(Dolzhnost Dolzhnost)
        {
            return new DolzhnostViewModel
            {
                Id = Dolzhnost.Id,
                Dol = Dolzhnost.Dol
            };
        }
    }
}
