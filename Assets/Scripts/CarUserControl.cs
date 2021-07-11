using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Vehicles.Car
{
    [RequireComponent(typeof (CarController))]
    public class CarUserControl : Photon.MonoBehaviour
    {
        private CarController m_Car; // the car controller we want to use

        public PhotonView photonView;
        private void Awake()
        {
            // get the car controller
            m_Car = GetComponent<CarController>();
        }

        private void FixedUpdate()
        {
            if(this.photonView.isMine == true){
                float h = CrossPlatformInputManager.GetAxis("Horizontal");
                float v = CrossPlatformInputManager.GetAxis("Vertical");
                float handbrake = CrossPlatformInputManager.GetAxis("Jump");
                m_Car.Move(h, v, v, handbrake);
                m_Car.Move(h, v, v, 0f);
            }
            else{
                Destroy(m_Car);
            }
        }
    }
}
