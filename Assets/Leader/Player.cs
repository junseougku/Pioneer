using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 clickPosition;
    public Animator animator;
    enum STATE { IDLE, WALK,ATTACK}
    STATE eState = STATE.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        clickPosition = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   //마우스 좌측 버튼을 누름.
        {
            bool attackStart = false;
            clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            foreach ( var enemy in MonsterClass.GetInstance().enemys)
            {
               
               
                if (Vector2.Distance(enemy.transform.localPosition , clickPosition) < 1.0f)
                {
                   
                    if (Vector2.Distance(enemy.transform.position, transform.position) < 2.0f)
                    {
                        attackStart = true;
                        break;
                    }
                }
            }

            if(attackStart)
            {
                eState = STATE.ATTACK;

                animator.SetTrigger("Attack");
                
            }


            eState = STATE.WALK;

            animator.SetTrigger("Walk");
            if (clickPosition.x < transform.position.x) transform.localScale = new Vector3(-1,1,1);
            else transform.localScale = new Vector3(1, 1, 1);

          
        }
        if (eState == STATE.WALK)
        {
            float dis = Vector2.Distance(transform.position, clickPosition);
            if (dis <= 0.01f)               //클릭한 지점에 다왔다면
            {
                eState = STATE.IDLE;
                animator.SetTrigger("Idle");
                clickPosition = Vector3.zero;
            }
        }
    }

    void FixedUpdate()
    {
        if(eState == STATE.WALK)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, clickPosition, 1.0f * Time.deltaTime);       //클릭한 지점으로 이동
        }

    }

   // GameObject GetNearestEnemy(GameObject source,GameObject[] DestObjects)
   // {
        //float shortDis = Vector2.Distance(source.transform.position,DestObjects)
   // }
}
