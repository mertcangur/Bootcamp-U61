using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;
public class gun : MonoBehaviour
{
    // bullet
    public GameObject bullet;

    //bullet Force
    public float shootForce, upWardForce;

    //gun Stats
    public float timeBetweenShooting, spread, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTab;
    public bool allowButtonHold;

    int bulletsLeft, bulletsShot;

    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;

    //Graphics
    public GameObject muzzleFlash, bulletHoleMetal;//,bulletHoleBlood;
    public TextMeshProUGUI ammunitionDisplay;
    public TextMeshProUGUI statTrack;

    //bug Fixing
    public bool allowInvoke = true;

    [SerializeField] AudioSource reloadAudio;
    [SerializeField] AudioSource fireAudio;

    //Animator
    public GameObject animatorr;
    private Animator anim;

    //Recoil
    public float minX, maxX;
    public float minY, maxY;
    public Transform cam;
    private Vector3 rot;

    float speed;
    bool is_sprint;

    private void Awake()
    {
        anim = animatorr.GetComponent<Animator>();
        //Make sure magazine is full
        bulletsLeft = magazineSize;
        readyToShoot = true;

    }

    private void FixedUpdate()
    {
        speed = GameObject.Find("PlayerCapsule").GetComponent<FirstPersonController>()._speed;
        is_sprint = GameObject.Find("PlayerCapsule").GetComponent<StarterAssetsInputs>().sprint;
        anim.SetFloat("speed", speed);
        anim.SetBool("is_sprint", is_sprint);
        MyInput();

        //Set ammo display, if it exist 
        if (ammunitionDisplay != null)
            ammunitionDisplay.SetText(bulletsLeft / bulletsPerTab + " / " + magazineSize / bulletsPerTab);
        statTrack.SetText((bulletsLeft / bulletsPerTab).ToString());


    }
    private void LateUpdate()
    {
        rot = cam.transform.localRotation.eulerAngles;

        if (rot.x != 0 || rot.y != 0)
            cam.transform.localRotation = Quaternion.Slerp(cam.transform.localRotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * 3f);
    }

    private void MyInput()
    {
        //check if allowed to hold down and take corresponding input
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Reload
        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading)
            Reload();

        //Reload automaticlly when trying to shoot with no ammo
        if (readyToShoot && shooting && !reloading && bulletsLeft <= 0)
            Reload();

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = 0;

            Shoot();

        }
    }
    private void Shoot()
    {
       anim.Play("fire", -1, 0f);

        fireAudio.PlayOneShot(fireAudio.clip);

        readyToShoot = false;


        Ray ray = fpsCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        //Check if ray hits someThing
        Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75); // Just a point  far away from the player

        //Calculate direction from attackPoint to targetPoint
        Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        //calculate spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculate new direction with spread
        Vector3 directionWithSpread = directionWithoutSpread + new Vector3(x, y, 0);



        //Instantiate bullet/projectile
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add force the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upWardForce, ForceMode.Impulse);

        //Instantiate muzzle flash if you have one
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);
        if (bulletHoleMetal != null)
            Instantiate(bulletHoleMetal, hit.point, Quaternion.LookRotation(hit.normal));
        //Debug.Log(hit.collider.tag);
        //if (hit.collider.CompareTag("enemy") && bulletHoleBlood != null)
        //    Instantiate(bulletHoleBlood, hit.point, Quaternion.Euler(0, 180, 0));
        //else if(bulletHoleMetal != null) 
        //    Instantiate(bulletHoleMetal, hit.point, Quaternion.Euler(0, 180, 0));

        bulletsLeft--;
        bulletsShot++;

        //Invoke resetShot function ( if not already Invoked)
        if (allowInvoke)
        {
            Invoke("ResetShot", timeBetweenShooting);
            allowInvoke = false;
        }

        //if more than one  bulletsPerTab make sure to repeat shoot function
        if (bulletsShot < bulletsPerTab && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);

        recoil();
    }
    private void ResetShot()
    {
        // Allow shooting andinvoking again
        readyToShoot = true;
        allowInvoke = true;

    }

    private void Reload()
    {

        reloading = true;
        //anim.SetBool("reload", true);
        reloadAudio.PlayOneShot(reloadAudio.clip);
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        //anim.SetBool("reload", false);
        reloading = false;
    }
    private void recoil()
    {
        float recoilX = Random.Range(minX, maxX);
        float recoilY = Random.Range(minY, maxY);
        cam.transform.localRotation = Quaternion.Euler(rot.x - recoilY, rot.y + recoilX, rot.z);

    }
    public void resetPos()
    {
        animatorr.GetComponent<Animator>().Rebind();
    }
}
