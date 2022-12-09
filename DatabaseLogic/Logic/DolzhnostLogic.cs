﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLogic.Storage;

using DatabaseLogic.BindingModel;
using DatabaseLogic.Model;
using DatabaseLogic.ViewModel;

namespace DatabaseLogic.Logic
{
    public class DolzhnostLogic
    {
        private readonly DolzhnostStorage DolzhnostStorage;

        public DolzhnostLogic()
        {
            DolzhnostStorage = new DolzhnostStorage();
        }
        public void CreateOrUpdate(DolzhnostBindingModel model)
        {
            var element = DolzhnostStorage.GetElement(new DolzhnostBindingModel
            {
                Dol = model.Dol
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть сотрудник с таким id");
            }

            if (model.Id.HasValue)
            {
                DolzhnostStorage.Update(model);
            }
            else
            {
                DolzhnostStorage.Insert(model);
            }
        }
        public void Delete(DolzhnostBindingModel model)
        {
            var element = DolzhnostStorage.GetElement(new DolzhnostBindingModel
            {
                Id = model.Id
            });

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            DolzhnostStorage.Delete(model);
        }

        public List<DolzhnostViewModel> Read(DolzhnostBindingModel model)
        {
            if (model == null)
            {
                return DolzhnostStorage.GetFullList();
            }

            if (model.Id.HasValue)
            {
                return new List<DolzhnostViewModel>()
                {
                    DolzhnostStorage.GetElement(model)
                };
            }
            return DolzhnostStorage.GetFilteredList(model);
        }
    }
}