using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

namespace CompleteProject
{
    public class PlayerMovement : MonoBehaviour
    {
        public float speed = 6f;            // The speed that the player will move at.


        Vector3 movement;                   // The vector to store the direction of the player's movement.
        Animator anim;                      // Reference to the animator component.
        Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
#if !MOBILE_INPUT
        int floorMask;                      // A layer mask so that a ray can be cast just at gameobjects on the floor layer.
        float camRayLength = 100f;          // The length of the ray from the camera into the scene.
#endif

        void Awake ()
        {
#if !MOBILE_INPUT
            // Create a layer mask for the floor layer.
            floorMask = LayerMask.GetMask ("Floor");
#endif

            // Set up references.
            anim = GetComponent <Animator> ();
            playerRigidbody = GetComponent <Rigidbody> ();
        }



        public void Turning (Vector2 weizhi)
        {
            if (weizhi.y != 0 || weizhi.x != 0)
            {

                //设置角色的朝向(朝向当前坐标+摇杆偏移量)

                transform.LookAt(new Vector3(transform.position.x + weizhi.x, transform.position.y, transform.position.z + weizhi.y));

            }
        }


        void MoveStart ()
        {
            // Tell the animator whether or not the player is walking.
            anim.SetBool ("IsWalking", true);
        }

        void MoveEnd()
        {
            // Tell the animator whether or not the player is walking.
            anim.SetBool("IsWalking", false);
        }
    }
}