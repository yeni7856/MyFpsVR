using UnityEngine;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        private Animator doorAnim;
        private Collider colliderDoor;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            doorAnim = GetComponent<Animator>();
            colliderDoor = GetComponent<BoxCollider>();
        }

        //마우스를 가져가면 액션 UI를 보여주기
        protected override void DoAction()
        {
            doorAnim.SetBool("IsOpen", true);
            colliderDoor.enabled = false;
            audioSource.Play();
        }
       
    }

}
