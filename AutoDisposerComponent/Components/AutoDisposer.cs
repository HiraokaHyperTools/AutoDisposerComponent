using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace AutoDisposerComponent.Components
{
    public partial class AutoDisposer : Component
    {
        public AutoDisposer()
        {
            InitializeComponent();

            Disposed += (a, b) =>
            {
                while (disposables.Count != 0)
                {
                    var value = disposables.Pop();
                    value.Dispose();
                }
            };
        }

        public AutoDisposer(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        private Stack<IDisposable> disposables = new Stack<IDisposable>();

        public Type AddAndReturn<Type>(Type value) where Type : IDisposable
        {
            if (value != null)
            {
                disposables.Push(value);
            }
            return value;
        }
    }
}
