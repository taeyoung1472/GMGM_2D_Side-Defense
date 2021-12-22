using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    public enum State //적상태
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Hit,
        Skill,  //스킬 사용 상태
        Stun,  //스턴당한 상태
        Dead
    }
    public State currentState = State.Idle;  
    public float judgeTime = 0.2f; //판단타임
    public float stunTime = 0.5f; //스턴타임


    private WaitForSeconds ws;
    protected EnemyMove move; 
    protected EnemyFOV fov;
    protected EnemyAttack attack;

    public void Awake()
    {
        Debug.Log("에너미 Ai가 초기화됨");
        ws = new WaitForSeconds(judgeTime);
        fov = GetComponent<EnemyFOV>();
        move = GetComponent<EnemyMove>();
        attack = GetComponent<EnemyAttack>(); //이렇게 하면 자기한테 맞는 Attack 이 가져와져
       
    }

    public void OnEnable()
    {
        StartCoroutine(CheckNextAction());
    }

    IEnumerator CheckNextAction()
    {
        while (true)
        {
            if (GameManager.Player != null)
            {
                CheckState();
                Debug.Log("체크 액션");
                Action();
            }
            yield return ws;

        }
    }

    protected virtual void CheckState()
    {
        if (currentState == State.Hit || currentState == State.Dead || currentState == State.Stun)
        {
            return;
        }

        bool isTrace = fov.IsTracePlayer();
        bool isView = fov.IsViewPlayer();
        bool isAttack = fov.IsAttackPossible();

        if (isAttack && isView && isTrace)
        {
            currentState = State.Attack;
        }
        else if (isTrace && isView)
        {
            currentState = State.Chase;
        }
        else
        {
            currentState = State.Patrol;
        }

    }
    protected virtual void Action()
    {
        switch (currentState)
        {
            case State.Idle:
                break;
            case State.Patrol:
                if (attack != null)
                    attack.isAttack = false;
                move.SetMove();
              
                break;
            case State.Attack:
                move.Stop();
                if (attack != null)
                    attack.isAttack = true;
                break;
            case State.Hit:
                move.Stop();
                if (attack != null)
                    attack.isAttack = false;
                break;
            case State.Dead:
                break;
        }
    }

    public void SetHit()
    {
        currentState = State.Hit;
        move.Stop();
        StartCoroutine(Recover(stunTime));
    }

    public void SetStun(float time = 0) //Ai에다가 대쉬 상태이면 바로 에너미 무브하면 되ㅡㄴㄴ구나.
    {
        currentState = State.Stun;
        if (time == 0)
            time = stunTime;

        //if (_status != null)
        //    _status.PlayStun(time);

        //여기에 스턴 애니메이션 사용
        StartCoroutine(Recover(time));
    }

    private IEnumerator Recover(float time)
    {
        yield return new WaitForSeconds(time);

        currentState = State.Patrol;
    }

    public void SetDead()
    {
        currentState = State.Dead;
        if (attack != null)
            attack.isAttack = false;
        move.Stop();
    }
}