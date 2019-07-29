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

        public AutoDisposer AddAnd(IDisposable value)
        {
            if (value != null)
            {
                disposables.Push(value);
            }
            return this;
        }
    }
}
