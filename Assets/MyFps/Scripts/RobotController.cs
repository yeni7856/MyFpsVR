using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyFps
{
    //로봇상태
    public enum RobotState
    {
        R_Idle,
        R_Walk,
        R_Attack,
        R_Death
    }
    //로봇 Enemy 관리 클래스
    public class RobotController : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject thePlayer;

        private Animator Animator;

        //로봇상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float maxHp = 20;
        private float currentHp;
        private bool isDeath = false;

        //이동
        [SerializeField] private float moveSpeed = 5f;

        //공격
        [SerializeField] private float attackRange = 1.5f;  //공격가능 범위
        [SerializeField] private float attackDmg = 5f;      //공격 데미지
        [SerializeField] private float attackTimer = 2f;      //공격 속도
        private float count = 0f;

        public AudioSource bgm01;   //메인씬 1 배경음
        public AudioSource bgm02;   //적 등장 사운드
        #endregion

        private void Start()
        {
            Animator = GetComponent<Animator>();

            //초기화
            isDeath = false;
            currentHp = maxHp;
            count = attackTimer;
            SetState(RobotState.R_Idle);
        }
        private void Update()
        {
            if (isDeath) return;

            //타겟 지정
            Vector3 dir = thePlayer.transform.position - transform.position;
            float distance = Vector3.Distance(thePlayer.transform.position, transform.position);
            if (distance <= attackRange)        
            {
                SetState(RobotState.R_Attack);
            }
            
            //로봇 상태 구현
            switch (currentState)
            {
                case RobotState.R_Idle:
                    break;
                case RobotState.R_Walk:     //플레이어 따라 걷는다(이동)
                    transform.Translate(dir.normalized * moveSpeed * Time.deltaTime, Space.World);
                    transform.LookAt(thePlayer.transform); //나를향해바라보기
                    break;
                case RobotState.R_Attack:
                    if(distance >= attackRange)
                    {
                        SetState(RobotState.R_Walk);
                    }
                    break;
                case RobotState.R_Death:
                    break;
            }
        }
        //공격 2초마다
        /*void AttackOnTimer()
        {
            if(count < 0f)
            {
                //공격
                Attack();

                count = attackTimer;

            }
            count -= Time.deltaTime;
        }*/
        void Attack()
        {
            Debug.Log("플레이어한테 공격");
            PlayerController player = thePlayer.GetComponent<PlayerController>();
            if (player != null)
            {
                player.TakeDmg(attackDmg);
            }
        }

        //로봇의 상태 변경
        public void SetState(RobotState newstate)
        {
            //현재 상태 체크
            if(currentState == newstate) return;

            //이전 상태 저장
            beforeState =currentState;

            //상태 변경
            currentState = newstate;

            //상태 변경에 따른 구현 내용 
            Animator.SetInteger("RobotState", (int)newstate);
        }
        public void TakeDamage(float dmg)
        {
            currentHp -= dmg;
            Debug.Log(currentHp);

            if(currentHp <= 0 && !isDeath)
            {
                Die();
            }
        }
        void Die()
        {
            isDeath = true;
            Debug.Log("Robot Death!!");
            SetState(RobotState.R_Death);

            //배경음 변경
            bgm01.Play();   
            bgm02.Stop();

            //충돌체 제거
            transform.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject,3f);
        }
    }
}