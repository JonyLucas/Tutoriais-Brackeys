using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour {

    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit info;
            if(Physics.Raycast(ray.origin, ray.direction, out info, 100)){
                agent.SetDestination(info.point);
            }
        }
    }
}
