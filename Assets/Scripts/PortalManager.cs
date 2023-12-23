using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public static PortalManager Instance;
    public bool isToPortal;
    private Portal portal1;
    private Portal portal2;
    private int portalNumber = 1;
    public Color portal1Color = new Color();
    public Color portal2Color = new Color();
    
    private void Awake() => Instance = this;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            isToPortal = !isToPortal;
        }
    }
    
    public bool CanSpawnPortal()
    {
        return true;
    }
    
    public Color SetPortal(Portal portal)
    {
        Portal portall = portalNumber == 1 ? portal1 : portal2;
        portall?.Deactivate();
        
        if (portalNumber == 1) portal1 = portal;
        else portal2 = portal;
        
        portalNumber = portalNumber == 1 ? 2 : 1;
        return portalNumber == 1 ? portal2Color : portal1Color;
    }

    public void Teletransport(GameObject objectToTeletransport, Portal fromPortal)
    {
        if (portal1 is null || portal2 is null) return;
        if (fromPortal == portal1)
        {
            objectToTeletransport.transform.position = portal2.exitPoint.position;
            float portal1Rotation = portal1.transform.rotation.eulerAngles.z;
            float portal2Rotation = portal2.transform.rotation.eulerAngles.z;
            float rotationDiff = Mathf.DeltaAngle(portal1Rotation, portal2Rotation);
            rotationDiff += 180;
            var rb = objectToTeletransport.GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.Euler(0f, 0f, rotationDiff) * rb.velocity;
        }
        else
        {
            objectToTeletransport.transform.position = portal1.exitPoint.position;
            float portal1Rotation = portal1.transform.rotation.eulerAngles.z;
            float portal2Rotation = portal2.transform.rotation.eulerAngles.z;
            float rotationDiff = Mathf.DeltaAngle(portal2Rotation, portal1Rotation);
            rotationDiff += 180;
            var rb = objectToTeletransport.GetComponent<Rigidbody2D>();
            rb.velocity = Quaternion.Euler(0f, 0f, rotationDiff) * rb.velocity;
        }
    }
}
