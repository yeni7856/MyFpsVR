using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyFps
{
    public class PlayerController : MonoBehaviour
    {
        #region Variables
        //체력
        [SerializeField] private float maxHp = 20;
        private float currentHp;
        private bool isDeath = false;

        //데미지 효과
        public GameObject damageFlash;
        //데미지 사운드
        public AudioSource hurt01;
        public AudioSource hurt02;
        public AudioSource hurt03;

        //게임오버 씬
        public SceneFader fader;
        [SerializeField] private string loadToScene = "GameOver";
        #endregion

        void Start ()
        {
            currentHp = maxHp;
        }
        public void TakeDmg(float dmg)
        {
            if (isDeath) return;
            currentHp -= dmg;
            Debug.Log($"player : {currentHp}");

            //데미지 효과
            StartCoroutine(DamageEffect());

            if(currentHp <= 0 && !isDeath)
            {
                Die();
            }
        }
        public void Die()
        {
            //isDeath = true;
            fader.FadeTo(loadToScene);

        }
        //데미지효과
        IEnumerator DamageEffect()
        {
            damageFlash.SetActive(true);

            int randNumber = Random.Range(1, 4);
            if(randNumber == 1 )
            {
                hurt01.Play();
            }
            else if (randNumber == 2 )
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }
            yield return new WaitForSeconds(1f);
            damageFlash.SetActive(false);  
        }
    }
}
