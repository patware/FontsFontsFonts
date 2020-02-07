using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public class Messenger : IMessenger
    {
        private readonly IList<WeakReference> _receivers = new List<WeakReference>();

        public void Register<T>(Action<T> callback)
        {
            _receivers.Add(new WeakReference(callback));
        }
        public void Send<T>(T message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            lock (_receivers)
            {
                var referencesToRemove = new List<WeakReference>();

                foreach (var wr in _receivers)
                {
                    if (wr.IsAlive)
                    {
                        if (wr.Target is Action<T> a)
                        {
                            a.Invoke(message);
                        }
                    }
                    else
                    {
                        referencesToRemove.Add(wr);
                    }
                }

                while (referencesToRemove.Count > 0)
                {
                    referencesToRemove.RemoveAt(0);
                }
            }
        }
    }
}
