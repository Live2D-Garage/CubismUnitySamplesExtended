/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */


using UnityEngine;

namespace Live2D.Cubism.Garage
{
    public class CubismFollowing : MonoBehaviour
    {
        /// <summary>
        /// Renderer.
        /// </summary>
        private Vector3[] _vertices;

        /// <summary>
        /// Object following mesh.
        /// </summary>
        [SerializeField]
        private Transform _target;

        /// <summary>
        /// Difference between target and mesh coordinates.
        /// </summary>
        [SerializeField]
        private Vector3 _offset;
        
        /// <summary>
        /// Initial value of average position.
        /// </summary>
        private readonly Vector3 _defaultPosition = Vector3.zero;

        /// <summary>
        /// Called by Unity.
        /// </summary>
        private void LateUpdate()
        {
            _vertices = GetComponent<MeshFilter>().mesh.vertices;
            Vector3 averagePos = _defaultPosition;
            
            for(var i = 0;i < _vertices.Length;i++){
                averagePos += _vertices[i];
            } 
            
            averagePos /= _vertices.Length;
            _target.position = averagePos + _offset;
        }
    }
}
