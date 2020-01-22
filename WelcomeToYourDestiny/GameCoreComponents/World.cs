using System;
using System.Collections.Generic;
using Ruzzie.Common.Types;

namespace WelcomeToYourDestiny.GameCoreComponents
{
    public class World
    {
        readonly Dictionary<Type, object> _evilState = new Dictionary<Type, object>(16);
        public int WrongDirectionCount { get; set; } 
        public int LinesTypedInMessageBox { get; set; }
        public int LinesTypedInCombatBox { get; set; }

        public bool Has<T>()
        {
            return _evilState.ContainsKey(typeof(T));
        }

        public T Get<T>()
        {
            return (T) _evilState[typeof(T)];
        }

        public void Set<T>(T updateOrSet)
        {
            _evilState[typeof(T)] = updateOrSet;
        }

        public Option<T> GetOrNone<T>()
        {
            var key = typeof(T);

            if (!_evilState.ContainsKey(key))
            {
                return Option<T>.None;
            }

            return (T) _evilState[key];
        }
    }
}
