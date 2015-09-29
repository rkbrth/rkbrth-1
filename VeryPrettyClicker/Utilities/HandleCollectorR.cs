// Decompiled with JetBrains decompiler
// Type: System.Internal.HandleCollector
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// MVID: D4F73B0E-3B8D-4341-A790-516ED5C6F955
// Assembly location: C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Windows.Forms.dll

using System;
using System.Threading;

namespace System.Windows.Forms
{
    internal sealed class HandleCollectorR
    {
        private static object internalSyncObject = new object();
        private static HandleCollectorR.HandleType[] handleTypes;
        private static int handleTypeCount;
        private static int suspendCount;

        internal static event HandleChangeEventHandler HandleAdded;
        internal delegate void HandleChangeEventHandler(string handleType, IntPtr handleValue, int currentHandleCount);

        internal static event HandleChangeEventHandler HandleRemoved;

        internal static IntPtr Add(IntPtr handle, int type)
        {
            HandleCollectorR.handleTypes[type - 1].Add(handle);
            return handle;
        }

        internal static void SuspendCollect()
        {
            lock (HandleCollectorR.internalSyncObject)
                ++HandleCollectorR.suspendCount;
        }

        internal static void ResumeCollect()
        {
            bool flag = false;
            lock (HandleCollectorR.internalSyncObject)
            {
                if (HandleCollectorR.suspendCount > 0)
                    --HandleCollectorR.suspendCount;
                if (HandleCollectorR.suspendCount == 0)
                {
                    for (int local_1 = 0; local_1 < HandleCollectorR.handleTypeCount; ++local_1)
                    {
                        lock (HandleCollectorR.handleTypes[local_1])
                        {
                            if (HandleCollectorR.handleTypes[local_1].NeedCollection())
                                flag = true;
                        }
                    }
                }
            }
            if (!flag)
                return;
            GC.Collect();
        }

        internal static int RegisterType(string typeName, int expense, int initialThreshold)
        {
            lock (HandleCollectorR.internalSyncObject)
            {
                if (HandleCollectorR.handleTypeCount == 0 || HandleCollectorR.handleTypeCount == HandleCollectorR.handleTypes.Length)
                {
                    HandleCollectorR.HandleType[] local_0 = new HandleCollectorR.HandleType[HandleCollectorR.handleTypeCount + 10];
                    if (HandleCollectorR.handleTypes != null)
                        Array.Copy((Array)HandleCollectorR.handleTypes, 0, (Array)local_0, 0, HandleCollectorR.handleTypeCount);
                    HandleCollectorR.handleTypes = local_0;
                }
                HandleCollectorR.handleTypes[HandleCollectorR.handleTypeCount++] = new HandleCollectorR.HandleType(typeName, expense, initialThreshold);
                return HandleCollectorR.handleTypeCount;
            }
        }

        internal static IntPtr Remove(IntPtr handle, int type)
        {
            return HandleCollectorR.handleTypes[type - 1].Remove(handle);
        }

        private class HandleType
        {
            internal readonly string name;
            private int initialThreshHold;
            private int threshHold;
            private int handleCount;
            private readonly int deltaPercent;

            internal HandleType(string name, int expense, int initialThreshHold)
            {
                this.name = name;
                this.initialThreshHold = initialThreshHold;
                this.threshHold = initialThreshHold;
                this.deltaPercent = 100 - expense;
            }

            internal void Add(IntPtr handle)
            {
                if (handle == IntPtr.Zero)
                    return;
                bool flag = false;
                int currentHandleCount = 0;
                lock (this)
                {
                    ++this.handleCount;
                    flag = this.NeedCollection();
                    currentHandleCount = this.handleCount;
                }
                lock (HandleCollectorR.internalSyncObject)
                {
                    if (HandleCollectorR.HandleAdded != null)
                        HandleCollectorR.HandleAdded(this.name, handle, currentHandleCount);
                }
                if (!flag || !flag)
                    return;
                GC.Collect();
                Thread.Sleep((100 - this.deltaPercent) / 4);
            }

            internal int GetHandleCount()
            {
                lock (this)
                    return this.handleCount;
            }

            internal bool NeedCollection()
            {
                if (HandleCollectorR.suspendCount > 0)
                    return false;
                if (this.handleCount > this.threshHold)
                {
                    this.threshHold = this.handleCount + this.handleCount * this.deltaPercent / 100;
                    return true;
                }
                int num = 100 * this.threshHold / (100 + this.deltaPercent);
                if (num >= this.initialThreshHold && this.handleCount < (int)((double)num * 0.899999976158142))
                    this.threshHold = num;
                return false;
            }

            internal IntPtr Remove(IntPtr handle)
            {
                if (handle == IntPtr.Zero)
                    return handle;
                int currentHandleCount = 0;
                lock (this)
                {
                    --this.handleCount;
                    if (this.handleCount < 0)
                        this.handleCount = 0;
                    currentHandleCount = this.handleCount;
                }
                lock (HandleCollectorR.internalSyncObject)
                {
                    if (HandleCollectorR.HandleRemoved != null)
                        HandleCollectorR.HandleRemoved(this.name, handle, currentHandleCount);
                }
                return handle;
            }
        }
    }
}
