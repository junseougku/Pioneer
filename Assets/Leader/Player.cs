using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 targetPosition;
    public Animator animator;
    enum STATE { IDLE, WALK}
    STATE eState = STATE.IDLE;
    // Start is called before the first frame update
    void Start()
    {
        //animator = GetComponent<Animator>();
        targetPosition = Vector3.zero;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   //마우스 좌측 버튼을 누름.
        {
            eState = STATE.WALK;
            animator.SetTrigger("Walk");
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (targetPosition.x < transform.position.x) transform.localScale = new Vector3(-1,1,1);
            else transform.localScale = new Vector3(1, 1, 1);
        }
    }

    void FixedUpdate()
    {
        if(eState == STATE.WALK)
        {
            
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, 1.0f * Time.deltaTime);       //클릭한 지점으로 이동
            float dis = Vector2.Distance(transform.position, targetPosition);
            if (dis <= 0.01f)               //클릭한 지점에 다왔다면
            {
                eState = STATE.IDLE;
                animator.SetTrigger("Idle");
                targetPosition = Vector3.zero;
            }
        }

    }
}
