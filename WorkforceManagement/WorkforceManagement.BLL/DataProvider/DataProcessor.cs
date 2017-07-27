﻿using System;
using System.Collections.Generic;
using System.Text;
using WorkforceManagement.DAL.Abstract;

namespace WorkforceManagement.BLL.DataProvider
{
    public class DataProcessor<TModel> : IDataPresenter<TModel> where TModel : class
    {
        IRepository<TModel> _model;

        public DataProcessor(IRepository<TModel> model)
        {
            _model = model;
        }

        public IEnumerable<TModel> DataHolder
        {
            get { return _model.DataPresenter; }
            set { _model.DataPresenter = value; }
        }

        public TModel DataPusher
        {
            set { _model.DataPusherConfig = value; }
        }



    }
}
