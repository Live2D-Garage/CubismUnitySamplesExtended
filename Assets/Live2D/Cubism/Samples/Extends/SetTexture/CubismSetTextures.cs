/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */
 

using UnityEngine;
using Live2D.Cubism.Rendering;
using Live2D.Cubism.Core;

namespace Live2D.Cubism.Garage
{
    [RequireComponent(typeof(CubismModel))]
    public class CubismSetTextures : MonoBehaviour
    {
        /// <summary>
        /// Swap the current texture with the argument texture
        /// </summary>
        public void Set(Texture2D texture2D)
        {
            CubismModel cubismModel = GetComponent<CubismModel>();

            for (var i = 0; i < cubismModel.Drawables.Length; i++)
            {
                cubismModel.Drawables[i].GetComponent<CubismRenderer>().MainTexture = texture2D;
            }
        }
    }
}
