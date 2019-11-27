using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain : MonoBehaviour
{
    int DNALength = 2;
    public DNA dna;
    public GameObject eyes;
    public bool alive = true;
    bool seeWall = true;

    Vector3 startPosition;
    public float distanceTravelled = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "dead")
        {
            this.distanceTravelled = 0;
            this.alive = false;
        }
    }

    public void Init()
    {
        // initialise DNA
        // 0 forward
        // 1 Angle turn
        this.dna = new DNA(this.DNALength, 360);
        this.startPosition = this.transform.position;
    }

    private void Update()
    {
        if (!this.alive) return;

        Vector3 pos = this.eyes.transform.position;
        Vector3 forward = this.eyes.transform.forward;
        Vector3.Normalize(forward);
        forward = 1.0f * forward;

        Debug.DrawRay(pos, forward, Color.red, 0.01f);

        this.seeWall = false;
        RaycastHit hit;
        if (Physics.SphereCast(pos, this.transform.localScale.x / 2.0f, forward, out hit, forward.magnitude))
        {
            if (hit.collider.gameObject.tag == "wall")
            {
                this.seeWall = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!this.alive) return;

        // read DNA
        float turn = 0;
        float move = this.dna.GetGene(0);

        if (this.seeWall)
        {
            turn = this.dna.GetGene(1);
        }

        this.transform.Translate(0, 0, move * 0.0001f);
        this.transform.Rotate(0, turn, 0);
        this.distanceTravelled = Vector3.Distance(this.startPosition, this.transform.position);
    }
}
