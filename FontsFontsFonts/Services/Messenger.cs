using System;
using System.Collections.Generic;
using System.Text;

namespace FontsFontsFonts.Services
{
    public class Messenger : IMessenger
    {
        private readonly IList<object> _receivers = new List<object>();

        public void Register<T>(Action<T> callback)
        {
            _receivers.Add(callback);
        }
        public void Send<T>(T message)
        {
            if (message == null) throw new ArgumentNullException(nameof(message));

            lock (_receivers)
            {
                var referencesToRemove = new List<object>();

                foreach (var wr in _receivers)
                {
                    if (wr != null)
                    {
                        if (wr is Action<T> a)
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
