using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    public class PickUpAmmoBox : Interactive
    {
        #region Variables
        //AmmoBox 아이템 획득시 지급하는 ammo 갯수 
        [SerializeField] private int giveAmmo = 7;
        #endregion

        protected override void DoAction()
        {
            //
            Debug.Log("탄환 7개를 지급했습니다");
            PlayerStats.Instance.AddAmmoCount(giveAmmo);
            //킬
            Destroy(gameObject);
        }
    }
}
