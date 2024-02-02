using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject contactListItemPrefab;
    [SerializeField] Transform contactListTransform;

    /// <summary>
    /// Shows the List of contacts.
    /// </summary>
    public void GotoContactsPage()
    {
        AddressBookManager.instance.ReadContacts();
        Invoke("PopulateContactList", 2f);
    }

    /// <summary>
    /// Populates the Contact List with the data.
    /// </summary>
    public void PopulateContactList()
    {
        var contacts = AddressBookManager.instance.contacts;
        for (int iter = 0; iter < contacts.Length && iter < 10; iter++)
        {
            GameObject item = Instantiate(contactListItemPrefab, contactListTransform);
            item.GetComponent<ItemScript>().SetItemVars(
                    contacts[iter].FirstName,
                    contacts[iter].LastName,
                    contacts[iter].PhoneNumbers.Length != 0 ? contacts[iter].PhoneNumbers[0] : "" ,
                    contacts[iter].EmailAddresses.Length != 0 ? contacts[iter].EmailAddresses[0] : ""
                );
        }
    }
}
