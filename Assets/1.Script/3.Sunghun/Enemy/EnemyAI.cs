using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{


    public enum State //������
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        Hit,
        Skill,  //��ų ��� ����
        Stun,  //���ϴ��� ����
        Dead
    }
    public State currentState = State.Idle;  
    public float judgeTime = 0.2f; //�Ǵ�Ÿ��
    public float stunTime = 0.5f; //����Ÿ��


    private WaitForSeconds ws;
    protected EnemyMove move; 
    protected EnemyFOV fov;
    protected EnemyAttack attack;

    public void Awake()
    {
        Debug.Log("���ʹ� Ai�� �ʱ�ȭ��");
        ws = new WaitForSeconds(judgeTime);
        fov = GetComponent<EnemyFOV>();
        move = GetComponent<EnemyMove>();
        attack = GetComponent<EnemyAttack>(); //�̷��� �ϸ� �ڱ����� �´� Attack �� ��������
       
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
                Debug.Log("üũ �׼�");
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

    public void SetStun(float time = 0) //Ai���ٰ� �뽬 �����̸� �ٷ� ���ʹ� �����ϸ� �ǤѤ�������.
    {
        currentState = State.Stun;
        if (time == 0)
            time = stunTime;

        //if (_status != null)
        //    _status.PlayStun(time);

        //���⿡ ���� �ִϸ��̼� ���
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