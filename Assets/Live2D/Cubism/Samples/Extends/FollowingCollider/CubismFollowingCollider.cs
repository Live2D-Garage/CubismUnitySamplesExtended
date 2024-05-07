/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */


using UnityEngine;
using Live2D.Cubism.Rendering;

namespace Live2D.Cubism.Garage
{
    [RequireComponent(typeof(BoxCollider2D), typeof(CubismRenderer))]
    public class CubismFollowingCollider : MonoBehaviour
    {
        /// <summary>
        /// Collider.
        /// </summary>
        private BoxCollider2D _collider;


        /// <summary>
        /// Renderer.
        /// </summary>
        private CubismRenderer _renderer;


        /// <summary>
        /// Mesh bounds.
        /// </summary>
        private Bounds _bounds;


        /// <summary>
        /// Called by Unity. Assign variables.
        /// </summary>
        private void Start()
        {
            _collider = this.GetComponent<BoxCollider2D>();
            _renderer = this.GetComponent<CubismRenderer>();
        }


        /// <summary>
        /// Called by Unity. Make the collider follow the mesh.
        /// </summary>
        private void LateUpdate()
        {
            _bounds = _renderer.Mesh.bounds;   
            _collider.offset = _bounds.center;
            _collider.size = _bounds.size;
        }
    }
}
