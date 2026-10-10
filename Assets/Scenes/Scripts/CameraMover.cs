using UnityEngine;

public class CameraMover : MonoBehaviour
{
    //public int rotation;
    public float damping = 0.1f;
    public float cooldown;
    private bool rotating = false;
    private float startTime;
    public int index = 0;

    Vector3[] rotations = {new Vector3(0,0,0), new Vector3(0,90,0), new Vector3(0,180,0), new Vector3(0,270,0)};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("hello word");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            if(!rotating)
            {
                rotating = true;
                startTime = Time.time;
                index = (index + 1) % 4 ;
            }
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            if(!rotating)
            {
                rotating = true;
                startTime = Time.time;
                index = (index + 3) % 4 ;
            }
        }

        if(rotating){
            //transform.Rotate(0, rotation * Time.deltaTime,0);
            Quaternion currentRot = transform.rotation;
            Quaternion targerRot = Quaternion.Euler(rotations[index]);
            Quaternion smoothRot = Quaternion.Slerp(currentRot, targerRot, Time.deltaTime / damping);
            transform.rotation = smoothRot;

            if(Time.time >= startTime+cooldown)rotating = false;

        }
    }
}
