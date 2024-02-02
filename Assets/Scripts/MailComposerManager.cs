using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VoxelBusters.EssentialKit;

public class MailComposerManager : MonoBehaviour
{
    public static MailComposerManager instance;

    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Sends Mail to the email passed as a parameter
    /// </summary>
    /// <param name="email">Email to which the invite will be sent.</param>
    public void SendMail(string email)
    {
        bool canSendMail = MailComposer.CanSendMail();

        if (canSendMail)
        {
            MailComposer composer = MailComposer.CreateInstance();
            composer.SetToRecipients(new string[1] { email });

            composer.SetSubject("VoxelBusters Unity Assignment");
            composer.SetBody("I have Completed the assignment", false);

            composer.SetCompletionCallback((result, error) =>
            {
                Debug.Log("Mail composer was closed. Result code: " + result.ResultCode);
            });

            composer.Show();
        }

    }
}
