using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Bouncy : MonoBehaviour
{
    public Rigidbody playerRig;
    public Vector3 force;
    public float velocityZEqualsWhenZNotNice;
    public float fixedUpdatesToWaitAfterBounce;

    [HideInInspector] public bool bounce;

    private GameObject player;
    private Vector3 playerVelocityOnCollisionEnter;
    private ThirdPersonCharacter characterControlScript;
    private float fixedUpdatesSinceBounce;

    //When this script gets enabled...
    private void OnEnable()
    {
        //Set the player, playerRig, and characterControlScript variables
        player = GameObject.FindGameObjectWithTag("Player");
        playerRig = player.GetComponent<Rigidbody>();
        characterControlScript = player.GetComponent<ThirdPersonCharacter>();
    }

    //When this object detects a collision...
    private void OnCollisionEnter (Collision collision)
    {
        //If it's the player we're colliding with...
        if (collision.gameObject == player)
        {
            bounce = true;
            playerVelocityOnCollisionEnter = collision.relativeVelocity;
            print("Player velocity on enter: " + playerVelocityOnCollisionEnter);
            characterControlScript.enabled = false;

            if (playerVelocityOnCollisionEnter.z >= 0 && playerVelocityOnCollisionEnter.z <= 1)
            {
                playerVelocityOnCollisionEnter.z = velocityZEqualsWhenZNotNice;
                print("Z Velocity Not Nice");
            }
            else
            {
                if (playerVelocityOnCollisionEnter.z >= -1f && playerVelocityOnCollisionEnter.z <= 0)
                {
                    playerVelocityOnCollisionEnter.z = 0 - velocityZEqualsWhenZNotNice;
                    print("Z Velocity Not Nice");
                }
            }

            Vector3 force2Add2Player = new Vector3(0, playerVelocityOnCollisionEnter.y * force.y, playerVelocityOnCollisionEnter.z * force.z);
            print("Force applied to player: " + force2Add2Player);
            playerRig.AddForce(force2Add2Player, ForceMode.VelocityChange);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == player.gameObject)
        {
            print("Player velocity on exit: " + playerVelocityOnCollisionEnter);
        }
    }

    private void FixedUpdate()
    {
        if (bounce)
        {
            fixedUpdatesSinceBounce += 1;
        }
        if (bounce && fixedUpdatesSinceBounce == fixedUpdatesToWaitAfterBounce)
        {
            characterControlScript.enabled = true;
            fixedUpdatesSinceBounce = 0;
            bounce = false;
        }
    }
}
