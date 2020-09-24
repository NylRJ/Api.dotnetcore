using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Api.Domain
{
    public interface IUnitOfWork
    {
        IDbTransaction CreateTransaction();
        IDbTransaction CreateTransaction(IsolationLevel isolationLevel);
        void Commit();
        void Rollback();

    }
}
