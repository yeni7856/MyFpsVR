using UnityEngine;

namespace MyFps
{
    public class PickUpPistol : Interactive
    {
        //Action
        public GameObject realPistol;
        public GameObject arrow;

        public GameObject enemyTrigger;

        public GameObject ammoBox;
        public GameObject ammoUI;

        protected override void DoAction()
        {
            realPistol.SetActive(true);
            arrow.SetActive(false);

            ammoBox.SetActive(true);
            ammoUI.SetActive(true);

            enemyTrigger.SetActive(true);

            Destroy(gameObject);
        }
    }
}
