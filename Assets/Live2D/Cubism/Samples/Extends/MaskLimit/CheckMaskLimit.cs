/**
 * Copyright(c) Live2D Inc. All rights reserved.
 *
 * Released under the MIT license
 * https://opensource.org/licenses/mit-license.php
 */


using System.Collections.Generic;
using Live2D.Cubism.Rendering.Masking;
using UnityEngine;
using UnityEngine.UI;

namespace Live2D.Cubism.Garage
{
    public class CheckMaskLimit : MonoBehaviour
    {
        [SerializeField]
        private GameObject _clipping;
        private List<GameObject> _clippings = new List<GameObject>();
        private int _prefabCount = 0;
        private int _maskCount = 0;
        private bool _onAddButton = false;
        private bool _onRemoveButton = false;
        private float _time = 0;

        [SerializeField]
        private Text _prefabCounter;

        [SerializeField]
        private Text _maskCounter;
        private CubismMaskController _maskController;  
        private int _modelMask = 0;
        
        [SerializeField]
        private float _size = 1f;

        private void Start()
        {
            _maskController = _clipping.GetComponent<CubismMaskController>();
            _modelMask = ((ICubismMaskTextureCommandSource)_maskController).GetNecessaryTileCount();
        }

        private void Update()
        {
            if (_onAddButton)
            {
                _time += Time.deltaTime;
                if (_time > 0.05f)
                {
                    Add();
                    _time = 0;
                }
            }

            if (_onRemoveButton)
            {
                _time += Time.deltaTime;
                if (_time > 0.05f)
                {
                    Remove();
                    _time = 0;
                }
            }
        }

        private void Add()
        {
            var prefab = Instantiate(_clipping, new Vector3(_prefabCount % 10 - 4.5f, -_prefabCount / 10 + 2f, 0), transform.rotation);
            prefab.transform.localScale *= _size;
            _clippings.Add(prefab);
            _prefabCount += 1;
            _prefabCounter.text = "prefab: " + _prefabCount.ToString();
            _maskCount = _prefabCount * _modelMask;
            _maskCounter.text = "mask: " + _maskCount.ToString();
        }

        private void Remove()
        {
            if (_prefabCount > 0)
            {
                Destroy(_clippings[_prefabCount - 1]);
                _clippings.RemoveAt(_prefabCount - 1);
                _prefabCount -= 1;
                _prefabCounter.text = "prefab: " + _prefabCount.ToString();
                _maskCount = _prefabCount * _modelMask;
                _maskCounter.text = "mask: " + _maskCount.ToString();
            }
        }

        //Called by Event Trigger
        public void OnAddButtonDown()
        {
            Add();
            _onAddButton = true;
        }

        //Called by Event Trigger
        public void OnAddButtonUp()
        {
            _onAddButton = false;
            _time = 0;
        }

        //Called by Event Trigger
        public void OnRemoveButtonDown()
        {
            Remove();
            _onRemoveButton = true;
        }

        //Called by Event Trigger
        public void OnRemoveButtonUp()
        {
            _onRemoveButton = false;
            _time = 0;
        }
    }
}
