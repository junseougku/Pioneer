using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 targetPosition;
    GameObject player;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        InvokeRepeating("Trace",0,1.0f);        //방향전환1초마다
        MonsterClass.GetInstance().enemys.Add(this);

        animator.SetTrigger("Walk");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
        transform.position += (targetPosition - transform.position).normalized * 0.5f * Time.deltaTime;

    }

    void Trace()
    {
        Vector2 dir = targetPosition - transform.position;
        targetPosition = player.GetComponent<Player>().transform.position;

        Vector3 scale = transform.localScale;
        if (dir.x <= 0)
            scale.x = -Mathf.Abs(scale.x);
        
        else
            scale.x = Mathf.Abs(scale.x);
        
        transform.localScale = scale;
    }
}
