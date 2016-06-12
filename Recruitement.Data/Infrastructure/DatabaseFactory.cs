﻿using Recruitement.Data.Contracts;
using Recruitement.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recruitement.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private RecruitementContext dataContext;
        public RecruitementContext DataContext
        {
            get { return dataContext; }
        }
        public DatabaseFactory()
        {
            dataContext = new RecruitementContext();
        }
        protected override void DisposeCore()
        {
            if (dataContext != null)
                dataContext.Dispose();
        }
    }

}
