﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
  public Camera playerCamera;
  GameObject grabbedBlock;
  bool grabObject = false;
  
  // Start is called before the first frame update
  void Start()
  {
  }

  // Update is called once per frame
  void Update()
  {
  
    if (Input.GetMouseButtonDown(0)) {
      if (grabObject) {
        grabObject = false;
      } else {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit racastResults;
        if (Physics.Raycast(ray, out racastResults) && racastResults.transform.parent) {
          Debug.Log("I am here"); //I don't understand why the debug message is not showing

          string nameOfThingWeClickedOn = racastResults.transform.parent.gameObject.name;
          if (nameOfThingWeClickedOn.Contains("Block")) {
            grabbedBlock = racastResults.transform.parent.gameObject;
            grabObject = true;
            Debug.Log("Grabbed block"); //I don't understand why the debug message is not showing
          }
        }
      }
    }

    if (grabObject) {
      grabbedBlock.transform.position = playerCamera.transform.position + playerCamera.transform.forward * 1;
      grabbedBlock.SendMessage("grabbed");
    }

  }
}
