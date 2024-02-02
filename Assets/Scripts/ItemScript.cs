using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*  */
public class ItemScript : MonoBehaviour
{
    [SerializeField] TMP_Text nameTxt, phoneNumberTxt, emailAddressTxt;
    [SerializeField] GameObject inviteBtn;

    /// <summary>
    /// Sets the values of Name, Phone and email Text Objects of the Contact List item.
    /// </summary>
    /// <param name="firstName">First name of the contact</param>
    /// <param name="lastName">Last name of the contact</param>
    /// <param name="phoneNumber">Phone number of the contact</param>
    /// <param name="email">Email address of the contact</param>
    public void SetItemVars(string firstName, string lastName, string phoneNumber, string email)
    {
        nameTxt.text = firstName + " " + lastName;
        phoneNumberTxt.text = phoneNumber;
        emailAddressTxt.text = email;

        if (email.Length == 0) inviteBtn.SetActive(false);
    }

    /// <summary>
    /// Sends Invite to the contacts mail address.
    /// </summary>
    public void SendInvite()
    {
        MailComposerManager.instance.SendMail(emailAddressTxt.text);
    }
}
