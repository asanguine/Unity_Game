using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {



    private LineRenderer ropeLineRenderer;
    private DistanceJoint2D distanceJoint;
    private bool isAttached = false;
    private GameObject player;

    void Start() {
        ropeLineRenderer = GetComponent<LineRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");

        ropeLineRenderer.positionCount = 2;
        ropeLineRenderer.enabled = false;

        distanceJoint = player.AddComponent<DistanceJoint2D>();
        distanceJoint.enabled = false;
    }


    public void startSwinging() {
        if (!isAttached && player != null) {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

            
            ropeLineRenderer.SetPosition(0, transform.position);
            ropeLineRenderer.SetPosition(1, player.transform.position);
            ropeLineRenderer.enabled = true;

            distanceJoint.enabled = true;
            distanceJoint.connectedAnchor = transform.position;
            distanceJoint.distance = distanceToPlayer;



            isAttached = true;
        }
    }

    public void stopSwinging() {
        if (isAttached) {
            ropeLineRenderer.enabled = false;
            distanceJoint.enabled = false;
            isAttached = false;
        }
    }

    void Update() {
        if (isAttached) {
            ropeLineRenderer.SetPosition(1, player.transform.position);
            if (player.transform.position.y > transform.position.y) {
                Vector3 newPosition = player.transform.position;
                newPosition.y = transform.position.y;
                player.transform.position = newPosition;
            }
        }   
    }
}