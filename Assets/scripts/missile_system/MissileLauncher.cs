using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace missile_system
{
    public class MissileLauncher : MonoBehaviour
    {
        [SerializeField] private MissilesConfigContainer _missiles;
        [SerializeField] private Transform _launchPlatform;
        [SerializeField] private int _missileIndex;

        public void SetIndex(int index)
        {
            _missileIndex = index;
        }

        [ContextMenu("Launch")]
        public void Launch()
        {
            if (_missileIndex < 0 || _missileIndex >= _missiles.Missiles.Length)
                return;

            MoverMissile missile = Instantiate(_missiles.Missiles[_missileIndex].Pref, _launchPlatform.position, _launchPlatform.rotation, null).GetComponent<MoverMissile>();
            missile.Fire();
        }
    }
}