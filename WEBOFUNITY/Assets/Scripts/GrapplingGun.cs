using UnityEngine;
using UnityEngine.UI;

public class GrapplingGun : MonoBehaviour
{
    private AudioSource spiderWebSlingingAudioSource;
    public AudioClip spiderWebSlingSound;
    public AudioClip spiderWebReelSound;
    
    //followed tutorial https://www.youtube.com/watch?v=Xgh4v1w5DxU
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 150f;
    private SpringJoint joint;
    private GameObject crosshair;

    public float pullTowardsSpeed = 10.0f; //How fast we can move up and down on the web

    private Vector3 gunPositionAdjuster = new Vector3(0, 100, 0);

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        crosshair = GameObject.Find("CrossHair");
        spiderWebSlingingAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!PauseMenu.isPaused && !GameOverScreen.isGameOver && !GameWin.isWin)
        {
            //We want the aim cursor to be at the center of the screen
            transform.position = camera.position + gunPositionAdjuster;
            //We want the grappling coming from the spider's butt
            gunTip.position = player.position;

            //Check if there's anything we can hit. If so, draw cross hair as green
            RaycastHit hit;
            if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
            {
                crosshair.GetComponent<RawImage>().color = Color.green;
            }
            //Else, draw crosshair as black
            else
            {
                crosshair.GetComponent<RawImage>().color = Color.black;
            }


            if (Input.GetMouseButtonDown(0))
            {
                StartGrapple();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                StopGrapple();
            }

            //Check if player is reeling up or down on the web
            if (Input.GetKey(KeyCode.Q))
            {
                if (lr.positionCount > 0)
                {
                    Vector3 direction = (player.transform.position - joint.connectedAnchor).normalized;
                    player.transform.position -= direction * Time.deltaTime * pullTowardsSpeed;
                    if (spiderWebSlingingAudioSource.clip == spiderWebSlingSound)
                        spiderWebSlingingAudioSource.Stop();
                    if (!spiderWebSlingingAudioSource.isPlaying)
                    {
                        spiderWebSlingingAudioSource.clip = spiderWebReelSound;
                        spiderWebSlingingAudioSource.Play();
                    }
                }
            }
        }
    }

    
    void LateUpdate()
    {
        DrawRope();
    }

    
    void StartGrapple()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.5f;

            //Adjust these values to fit your game.
            joint.spring = 2f;
            joint.damper = 7f;
            joint.massScale = 3.5f;

            lr.positionCount = 2;
            
            if (!spiderWebSlingingAudioSource.isPlaying)
            {
                spiderWebSlingingAudioSource.clip = spiderWebSlingSound;
                spiderWebSlingingAudioSource.Play();
            }
        }
    }


    void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
