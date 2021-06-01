using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : MonoBehaviour
{
    //public GameObject player;
// public float distance;
    public Quaternion angle;
    NavMeshAgent nav;
    public float radius = 40;
    //public PlayerManager hero;
   // Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float k = 10.0f;
        float distance = Vector3.Distance(GameObject.Find("PlayerManager(Clone)").GetComponent<PlayerManager>().controller.transform.position, transform.position);

       
         if (distance < radius && distance >= nav.stoppingDistance)
        {
            if (distance > radius - k)
            {
                nav.enabled = true;
                gameObject.GetComponent<Animator>().SetTrigger("Start Active");
            }
            else
            {
                nav.enabled = true;
                gameObject.GetComponent<Animator>().SetTrigger("Walk");
                //nav.SetDestination(player.transform.position);
                //gameObject.GetComponent<Animator>().SetTrigger("Start Active");
            }
        }
        if (distance > radius)
        {
            nav.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Idle");
        }

        if (distance < nav.stoppingDistance)
        {
            nav.enabled = true;
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
            //nav.SetDestination(player.transform.position);
            //gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        /*if (distance <= 5 &&  Vector3.Distance(player.transform.position, transform.position) == 2)
        {
            nav.enabled = true;
            Vector3 dist = player.transform.position + nav.transform.position;
            //nav.SetDestination(player.transform.position);
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        */
    }
}
