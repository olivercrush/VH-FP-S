using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ObstacleHelper
{
    public static bool CheckForObstacles(Vector3 pos, Vector3 dir, float maxDist)
    {
        Ray checkRay = new Ray(pos, dir);
        RaycastHit checkRayHit;

        if (Physics.Raycast(checkRay, out checkRayHit, maxDist))
        {
            if (checkRayHit.collider.tag == "Obstacle")
                return false;
        }

        return true;
    }

    public static GameObject ReturnObstacle(Vector3 pos, Vector3 dir, float maxDist)
    {
        Ray checkRay = new Ray(pos, dir);
        RaycastHit checkRayHit;

        if (Physics.Raycast(checkRay, out checkRayHit, maxDist))
        {
            if (checkRayHit.collider.tag == "Obstacle")
                return checkRayHit.collider.gameObject;
        }

        return null;
    }
}
