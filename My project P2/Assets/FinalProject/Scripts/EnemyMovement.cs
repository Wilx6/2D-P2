using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public GameObject player;

    public GameObject enemy;

    public float speed;

    public float agro;
    private float dis;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        dis = Vector3.Distance(enemy.transform.position, player.transform.position);

        if (dis < agro)
        {
            //Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - transform.position);
            //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 1 * Time.deltaTime);
            //^SmootherTurning,vLocksOnPlayer
            transform.LookAt(player.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
        
    }
}
