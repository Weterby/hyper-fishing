using System;
using UnityEngine;

namespace Utils.Triggers
{
    [CreateAssetMenu(menuName = "Events/Create Trigger Event", fileName = "TriggerEvent")]
    public class TriggerEvent : ScriptableObject
    {
        #region Events

        private event Action OnTriggered;

        #endregion

        #region Public Methods

        public void InvokeTrigger()
        {
            OnTriggered?.Invoke();
        }

        public void AddListener(Action callback)
        {
            OnTriggered += callback;
        }

        public void RemoveListener(Action callback)
        {
            OnTriggered -= callback;
        }

        #endregion
    }
}