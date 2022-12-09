using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLogic.BindingModel;
using DatabaseLogic.ViewModel;
using DatabaseLogic.Model;

namespace DatabaseLogic.Storage
{
    public class SotrudnikStorage
    {
        public void Delete(SotrudnikBindingModel model)
        {
            using var context = new Database();
            var element = context.Sotrudniki
                .FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                context.Sotrudniki.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        public SotrudnikViewModel GetElement(SotrudnikBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            var sotrudnik = context.Sotrudniki
                .FirstOrDefault(rec => rec.Id == model.Id);
            return sotrudnik != null ? CreateModel(sotrudnik) : null;
        }
        public List<SotrudnikViewModel> GetFilteredList(SotrudnikBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new Database();
            return context.Sotrudniki
                .Where(rec => rec.Id.Equals(model.Id))
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public List<SotrudnikViewModel> GetFullList()
        {
            using var context = new Database();
            return context.Sotrudniki
                .ToList()
                .Select(CreateModel)
                .ToList();
        }

        public void Insert(SotrudnikBindingModel model)
        {
            using var context = new Database();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                context.Sotrudniki.Add(CreateModel(model, new Sotrudnik()));
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public void Update(SotrudnikBindingModel model)
        {
            using var context = new Database();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Sotrudniki
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

        private static Sotrudnik CreateModel(SotrudnikBindingModel model, Sotrudnik sotrudnik)
        {
            sotrudnik.FIO = model.FIO;
            sotrudnik.Autobiography = model.Autobiography;
            sotrudnik.Dol = model.Dol;
            sotrudnik.dateupkval = model.dateupkval;
            return sotrudnik;
        }

        private static SotrudnikViewModel CreateModel(Sotrudnik sotrudnik)
        {
            return new SotrudnikViewModel
            {
                Id = sotrudnik.Id,
                FIO = sotrudnik.FIO,
                Autobiography = sotrudnik.Autobiography,
                Dol = sotrudnik.Dol,
                dateupkval = sotrudnik.dateupkval
            };
        }
    }
}
