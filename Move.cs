// this code is bad on purpose because IDGAD!!!!!!!!!!!!!
// hopefully this translates well to fps movement
// i want this stuff WEIRD!

// sadie g 2024
using System.Text.RegularExpressions;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    public CharacterController body;
    Vector2 inputVec;
    Vector3 vel, directionalVel, inputVel;
    public float grav = -9.81f, jumpVel = 7.5f, walkVel = 7, runAccel = 4;

    bool onGround(){
        return Physics.Raycast(transform.position, -transform.up, transform.localScale.y * 1.1f); // if this raycast hits the ground, you are on the ground
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(walkVel);
        if (Input.GetKey(KeyCode.LeftShift)) walkVel += runAccel * Time.deltaTime;
        else if (walkVel > 7) walkVel -= 3 * runAccel * Time.deltaTime;
        inputVec = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        if (!onGround()) { 
            vel.y += grav * Time.deltaTime; // Only jump if grounded
            walkVel += 4 * runAccel * Time.deltaTime;
        }
        else {
            if (Input.GetKeyDown(KeyCode.Space)) vel.y = jumpVel;
            else vel.y = -0.2f; // Buildup of gravity is not possible
        }
        
        inputVel = (transform.right * inputVec.x + transform.forward * inputVec.y) * walkVel;
        vel = Vector3.Lerp(vel, new Vector3(inputVel.x, vel.y, inputVel.z), (80/(walkVel-5f)) * Time.deltaTime); // accelerate slower as you gain speed
        body.Move(vel * Time.deltaTime);
    }
}
