using System;

namespace Api.CrossCutting.Transaction
{
    public interface IDbTransaction : IDisposable
    {
        void Rollback();
        void Commit();

    }
}
