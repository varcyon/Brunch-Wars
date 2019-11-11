using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghosting : MonoBehaviour
{
    [SerializeField] GameObject ghost;
    public float ghostDelay;
    public int numOfGhosts;
    public int activeGhosts;

public static Ghosting instance;
    float ghostimer;

    private void Awake() {
        instance = this;
    }
    void Start()
    {
        ghostimer = ghostDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if(SausageLinkShipController.Instance.attackPlayer){return;}
        if(ghostimer > 0){
            ghostimer -= Time.deltaTime;
        }else {
            GameObject ghostOBJ = Instantiate(ghost, transform.position, transform.rotation);
            ghostimer = ghostDelay;

            Destroy(ghostOBJ,ghostDelay*numOfGhosts+1);
        }
    }
}
