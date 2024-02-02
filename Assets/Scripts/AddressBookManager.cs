using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.EssentialKit;
using VoxelBusters.CoreLibrary;

public class AddressBookManager : MonoBehaviour
{
    public static AddressBookManager instance;
    public IAddressBookContact[] contacts;
    AddressBookContactsAccessStatus status;


    private void Awake()
    {
        instance = this;
    }


    public void ReadContacts()
    {
        status = AddressBook.GetContactsAccessStatus();

        if(status == AddressBookContactsAccessStatus.NotDetermined)
        {
            AddressBook.RequestContactsAccess(callback: OnRequestContactsAccessFinish);
        }
        else if(status == AddressBookContactsAccessStatus.Authorized)
        {
            AddressBook.ReadContacts(OnReadContactsFinish);
        }
    }

    private void OnRequestContactsAccessFinish(AddressBookRequestContactsAccessResult result, Error error)
    {
        Debug.Log("Request for contacts access finished.");
        Debug.Log("Address book contacts access status: " + result.AccessStatus);

        if(result.AccessStatus == AddressBookContactsAccessStatus.Authorized) 
        {
            AddressBook.ReadContacts(OnReadContactsFinish);
        }
    }

    private void OnReadContactsFinish(AddressBookReadContactsResult result, Error error)
    {
        if (error == null)
        {
            contacts = result.Contacts;
            
            Debug.Log("Request to read contacts finished successfully.");
            Debug.Log("Total contacts fetched: " + contacts.Length);
            Debug.Log("Below are the contact details (capped to first 10 results only):");

            for (int iter = 0; iter < contacts.Length && iter < 10; iter++)
            {
                Debug.Log(contacts[iter].EmailAddresses);
            }
        }
        else
        {
            Debug.Log("Request to read contacts failed with error. Error: " + error);
        }
    }
}
