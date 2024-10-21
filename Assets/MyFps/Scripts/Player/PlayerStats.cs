using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyFps
{
    //플레이어의 속성 데이터 값을 관리하는 클래스 (싱글톤, DontDestory) 클래스...ammoCount
    public class PlayerStats : PersistentSingleton<PlayerStats> //제네릭
    {
        #region Variables
        [SerializeField] private int ammoCount;
        public int AmmoCount
        {
            get { return ammoCount; }
            set { ammoCount = value; }
        }
        #endregion
        private void Start()
        {
            //속성값/Data 초기화
            AmmoCount = 0;
        }
        public void AddAmmoCount(int ammo)
        {
            AmmoCount += ammo;
        }
        public bool UseAmmo(int ammo) //사용결과 bool 형으로 
        {
            //소지 갯수 체크
            if(AmmoCount < ammo)
            {
                Debug.Log("You need to reload!!");
                return false;   
            }
            AmmoCount -= ammo;  
            return true;
        }
    }
}
