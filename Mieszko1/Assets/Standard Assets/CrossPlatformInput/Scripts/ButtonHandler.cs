using System;
using UnityEngine;

namespace UnityStandardAssets.CrossPlatformInput
{
    public class ButtonHandler : MonoBehaviour
    {
        public bool click_attack = false;
        public string Name;

        
        void OnEnable()
        {
            
        }

        public void SetDownState()
        {
            CrossPlatformInputManager.SetButtonDown(Name);
            Debug.Log("klikasz atak");
            click_attack = true;
        }


        public void SetUpState()
        {
            CrossPlatformInputManager.SetButtonUp(Name);
            
            Debug.Log("odklikasz atak");
            click_attack = false;
        }


        public void SetAxisPositiveState()
        {
            CrossPlatformInputManager.SetAxisPositive(Name);
        }


        public void SetAxisNeutralState()
        {
            CrossPlatformInputManager.SetAxisZero(Name);
        }


        public void SetAxisNegativeState()
        {
            CrossPlatformInputManager.SetAxisNegative(Name);
        }

        public void Update()
        {

        }
    }
}
