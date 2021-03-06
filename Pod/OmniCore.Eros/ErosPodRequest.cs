﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using OmniCore.Model.Interfaces.Data.Entities;
using OmniCore.Model.Interfaces.Platform;
using OmniCore.Model.Interfaces.Services;

namespace OmniCore.Eros
{
    public class ErosPodRequest : IPodRequest
    {
        public IPodRequestEntity Entity { get; set; }
        public IPod Pod { get; set; }

        public ErosPodRequest()
        {
            CanCancel = true;
        }

        public void Dispose()
        {
        }

        public bool CanCancel { get; private set; }
        public void TryCancel()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenCannotCancel()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenStarted()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenFinished()
        {
            throw new NotImplementedException();
        }

        public IObservable<Exception> WhenFailed()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenCanceled()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenMadeRedundant()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenResultLinked()
        {
            throw new NotImplementedException();
        }

        public IObservable<ITask> WhenRescheduled()
        {
            throw new NotImplementedException();
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}