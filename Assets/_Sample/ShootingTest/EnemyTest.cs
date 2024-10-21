using MyFps;
using UnityEngine;

namespace MySample
{
    public class EnemyTest : MonoBehaviour,IDamageable
    {
        #region Variables
        //체력
        [SerializeField] private float maxHp = 20;
        private float currentHp;
        private bool isDeath = false;
        #endregion
        private void Start()
        {
            //초기화
            isDeath = false;
            currentHp = maxHp;
        }
        public void TakeDamage(float dmg)
        {
            if (isDeath) return;
            currentHp -= dmg;
            Debug.Log($"currentHealth {currentHp}");

            //데미지 효과

            if(currentHp <= 0 && !isDeath )
            {
                Die();
            }
        }
       void Die()
        {
            isDeath = true;

            //보상, 경험치, 돈

            //효과

            //죽음처리
            Destroy(gameObject,3f);    
        }
    }
}
