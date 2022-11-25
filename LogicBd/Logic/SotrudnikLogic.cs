using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogicBd.BindingModel;
using LogicBd.Storage;
using LogicBd.ViewModel;

namespace LogicBd.Logic
{
    public class SotrudnikLogic
    {
        private readonly SotrudnikStorage sotrudnikStorage;

        public SotrudnikLogic()
        {
            sotrudnikStorage = new SotrudnikStorage();
        }
        public void CreateOrUpdate(SotrudnikBindingModel model)
        {
            var element = sotrudnikStorage.GetElement(new SotrudnikBindingModel
            {
                Id = model.Id
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с таким id");
            }

            if (model.Id.HasValue)
            {
                sotrudnikStorage.Update(model);
            }
            else
            {
                sotrudnikStorage.Insert(model);
            }
        }

        public void Create(SotrudnikBindingModel model)
        {
            sotrudnikStorage.Insert(model);
        }

        public void Update(SotrudnikBindingModel model)
        {
            var element = sotrudnikStorage.GetElement(model);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            sotrudnikStorage.Update(model);
        }

        public void Delete(SotrudnikBindingModel model)
        {
            var element = sotrudnikStorage.GetElement(new SotrudnikBindingModel
            {
                Id = model.Id
            });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            sotrudnikStorage.Delete(model);
        }

        public List<SotrudnikViewModel> Read(SotrudnikBindingModel model)
        {
            if (model == null)
            {
                return sotrudnikStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<SotrudnikViewModel>()
                {
                    sotrudnikStorage.GetElement(model)
                };
            }
            return sotrudnikStorage.GetFilteredList(model);
        }
    }
}
