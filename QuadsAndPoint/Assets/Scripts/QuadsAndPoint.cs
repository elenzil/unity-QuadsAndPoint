using UnityEngine;

public static class QuadsAndPoint
{
    // Given triangle ABC and a point,
    // return the barycentric coordinates of the point.
    static public float[] BaryFromTriangleAndPoint(Vector3 P, Vector3 A, Vector3 B, Vector3 C) {
        var ret = new float[3];

        ret[0] = ((B.y - C.y) * (P.x - C.x) + (C.x - B.x) * (P.y - C.y))
                 /
                 ((B.y - C.y) * (A.x - C.x) + (C.x - B.x) * (A.y - C.y));
        
        ret[1] = ((C.y - A.y) * (P.x - C.x) + (A.x - C.x) * (P.y - C.y))
                 /
                 ((B.y - C.y) * (A.x - C.x) + (C.x - B.x) * (A.y - C.y));
        ret[2] = 1 - ret[0] - ret[1];

        return ret;
    }

    // Inverse of BaryFromTriangleAndPoint().
    static public Vector3 PointFromTriangleAndBary(Vector3 A, Vector3 B, Vector3 C, float[] coeffs) {
        return A * coeffs[0] + B * coeffs[1] + C * coeffs[2];
    }
}
