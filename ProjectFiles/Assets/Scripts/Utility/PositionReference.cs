using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionReference : MonoBehaviour
{
        public Transform[] positions;
        private int index = 0;

        public Vector3 GetNextPosition()
        {
            Vector3 result = positions[index].localPosition;
            index = index + 1;
            return result;
        }
    
}
