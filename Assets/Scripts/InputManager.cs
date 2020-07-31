using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameObject Player;
    public LayerMask Layer;
    PlayerHandler playerHandler;
    Shot shot;
    


    private void Start()
    {
        playerHandler = Player.GetComponent<PlayerHandler>();
        shot = Player.GetComponent<Shot>();
    }
    private void LateUpdate()
    {
        Aimed(Input.mousePosition);

        {
            if (Input.touchCount != 0)
            {
                Aimed(Input.GetTouch(0).position);
                shot.Shoting(playerHandler.PointTransform.position - playerHandler.FireObj.position);
            }
            if (Input.GetMouseButtonDown(0))
            {
                shot.Shoting(playerHandler.PointTransform.position - playerHandler.FireObj.position);
            }
        }
    }

    void Aimed(Vector3 pos)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(pos);
        if (Physics.Raycast(ray, out hit, Layer))
        {
            playerHandler.PointTransform.position = hit.point;
        }
        else
        {
            playerHandler.PointTransform.position = ray.GetPoint(Camera.main.farClipPlane);
        }

        playerHandler.PointTransform.localScale = Vector3.one * (Vector3.Distance(playerHandler.PointTransform.position, Camera.main.transform.position) * playerHandler.PointSize);

    }
}
