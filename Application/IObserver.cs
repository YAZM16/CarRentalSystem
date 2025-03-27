using System;

namespace CarRentalSystem.Application.Interfaces
{
    public interface IObserver<T>
    {
        void OnNext(T value);
        void OnError(Exception error);
        void OnCompleted();
    }
}