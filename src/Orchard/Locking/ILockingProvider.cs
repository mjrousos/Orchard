using Orchard.ContentManagement;
using Orchard.Security;
using Orchard.UI.Admin;
using Orchard.DisplayManagement;
using Orchard.Localization;
using Orchard.Services;
using System.Web.Mvc;
using Orchard.Mvc.Filters;
﻿using System;

namespace Orchard.Locking {
    public interface ILockingProvider : IDependency {
        /// <summary>
        /// Handles locking on a given object to execute the desired critical code. Optionally, it is possible
        /// to tell how to manage exceptions, e.g. in a case where some cleanup may be required when the 
        /// critical code fails after having been partially executed.
        /// </summary>
        /// <param name="lockOn">The object upon which the lock will be created.</param>
        /// <param name="criticalCode">The critical code to be executed while holding the lock.</param>
        /// <param name="innerHandler">The (optional) action to be executed to handle exceptions while still
        /// holding the lock.</param>
        /// <param name="outerHandler">The (optional) action to be executed to handle exceptions after the 
        /// lock has been released.</param>
        /// <exception cref="ArgumentNullException">Throws an ArgumentNullException the lockOn parameter is null.</exception>
        /// <remarks>Internally, this method uses System.Threading.Monitor to delimit the execution of the
        /// critical code. Unlike the implementation of lock(obj){}, this implementation allows handling of
        /// exceptions both while holding and after releasing the lock on the object. The default behaviour 
        /// if both the Actions to handle exceptions are null, this method is the same as calling 
        /// lock(obj){criticalCode();}, meaning that it will bubble out the exception while holding the lock, and
        /// only release it afterwards. If an innerHandler is provided, but outerHandler is null, an exception will
        /// bubble out after the lock is released. To prevent exceptions from being thrown, both innerHandler and
        /// outerHandler should be provided.</remarks>
        void Lock(
            object lockOn,
            Action criticalCode,
            Action<Exception> innerHandler = null,
            Action<Exception> outerHandler = null);
        /// Handles locking on a given string to execute the desired critical code. Optionally, it is possible
        /// <param name="lockOn">The string upon which the lock will be created.</param>
            string lockOn,
        /// <returns>true if the current thread acquires the lock; otherwise, false.</returns>
        bool TryLock(
        /// <param name="timeout">A TimeSpan representing the amount of time to wait for the lock. A value 
        /// of –1 millisecond specifies an infinite wait.</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an ArgumentOutOfRangeException if the value of timeout
        /// in milliseconds is negative and is not equal to Infinite (-1 millisecond), or is greater than MaxValue.</exception>
           object lockOn,
           TimeSpan timeout,
           Action criticalCode,
           Action<Exception> innerHandler = null,
           Action<Exception> outerHandler = null);
            TimeSpan timeout,
        /// <param name="millisecondsTimeout">The number of milliseconds to wait for the lock..</param>
        /// <exception cref="ArgumentOutOfRangeException">Throws an ArgumentOutOfRangeException if the value 
        /// of millisecondsTimeout is negative, and not equal to Infinite.</exception>
            int millisecondsTimeout,
    }
}
