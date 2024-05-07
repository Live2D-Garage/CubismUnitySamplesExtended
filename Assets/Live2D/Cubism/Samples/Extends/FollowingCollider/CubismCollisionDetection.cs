/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */


using System.Threading;
using UnityEngine;
using UnityEngine.UI;


namespace Live2D.Cubism.Garage
{
    public class CubismCollisionDetection : MonoBehaviour
    {
        private float _time;
        private int _count = 0;
        
        [SerializeField]
        private Text _text;
        
        void Update()
        {
            _time += Time.deltaTime;
            var position = transform.position;
            position.x = Mathf.Sin(_time) * 0.8f;
            transform.position = position;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _count += 1;
            _text.text = "True";
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if(_count > 0){
                _count -= 1;
            }

            if (_count <= 0)
            {
                _text.text = "False";
            }
        }
    }
}
