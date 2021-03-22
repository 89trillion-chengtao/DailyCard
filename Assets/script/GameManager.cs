using System;
using UnityEngine;


namespace script
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private GameObject DailyDialog;
        public void onClick()
        {
            DailyDialog.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}