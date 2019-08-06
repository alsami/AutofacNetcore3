﻿using System;

namespace Autofac.Multitenant.Test.Stubs
{
    public class StubDisposableDependency : IDisposable
    {
        /* Intentionally a simple (and incorrect) disposable implementation.
         * We need it for testing if Dispose was called, not actually to do
         * the standard Dispose cleanup. */

        public bool IsDisposed { get; set; } = false;

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}
