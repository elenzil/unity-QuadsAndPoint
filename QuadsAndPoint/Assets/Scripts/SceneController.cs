using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Demonstration of using barycentric coordinates to map a point from one quadtrilateral to another.
// See https://answers.unity.com/questions/1903115/position-correspondence-of-a-3d-point-between-a-qu.html

[ExecuteInEditMode]
public class SceneController : MonoBehaviour
{
    public Transform[] quadA;
    public Transform[] quadB;
    public Transform   ptA;
    public Transform   ptB;

    private void Update() {

        Vector3 Q = Vector3.zero;

        int N = quadA.Length;
        for (int n = 0; n < N; ++n) {
            var coeffs = QuadsAndPoint.BaryFromTriangleAndPoint(ptA.position,
                quadA[(n + 0) % N].position,
                quadA[(n + 1) % N].position,
                quadA[(n + 2) % N].position);

            Q += QuadsAndPoint.PointFromTriangleAndBary(
                quadB[(n + 0) % N].position,
                quadB[(n + 1) % N].position,
                quadB[(n + 2) % N].position,
                coeffs);
        }

        Q /= (float)N;

        ptB.position = Q;
    }

}
