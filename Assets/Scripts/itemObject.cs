using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemObject : MonoBehaviour
{
    public inventoryItemData referenceItem;

    public void OnHandlePickupItem()
    {
        inventorySystem.current.Add(referenceItem);
        Destroy(gameObject);
    }

    private void Update()
    {
        if (!useLookAt)
        {
            _targetPosition = _parent.position + _parent.forward * 2f + new Vector3(0f, 2f, 0f); 
        }

        _lookAtTarget.transform.position = Vector3.Lerp(_lookAtTarget.transform.position, _targetPosition, Time.deltaTime * lookSpeed);

        if (Input.GetMouseButtonDown(1))
        {
            if(_lookAtTarget != null && _lookAtTarget.TryGetComponent<itemObject>(out itemObject item))
            {
                item.OnHandlePickupItem();
                itemController.SetTargetPosition(item.transform);
                itemController.Pickup();
            }
        }

    }

    public void OnTriggerEnter(Collider collider)
    {
        if (collider.transform.GetComponent<PointOfInterest>())
        {
            _targetPosition = collider.transform.position;
            useLookAt = true;
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        useLookAt = false;
    }
}
