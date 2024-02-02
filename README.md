# How to 
1. First i visited asset store and added the "Cross Platform Native Plugins: Essential Kit" package to my-assets.
2. Then i created a new project and imported the package. 
3. Then next step was the setup but before that i was getting one error so to solve that error i added "com.unity.nuget.newtonsoft-json": "2.0.0" to the manifest.json file of my project.
4. Then i started with the setup. Opened the "Project Setting" in unity and enabled "Address Book" and "Sharing" services.
5. Then i created a minimal UI for the project. One button to fetch the contacts, scrollable list to display all the contacts and List Item prefab which contains Childrens like Name, Phone, Email and one button for sending the invite to contact's email.
6. Then i wrote 2 Singleton Scripts for fetching the contacts and sending mail. I Wrote AddressBookManager which contacts the method to fetch all the contacts and ask for permission if it is "NotDetermined" and then i wrote MailComposerManager which contains code for sending a mail with predefined message and Subject.
7. After that i wrote another script to use functionalities of these two Singleton scripts. I wrote "UIManager" which handles all the business logic for the Button to display the contacts and to display to contact List itself.
8. And finally i wrote "ItemScript" which does just one thing it takes the input name, phone and email of contact and sets it on the current items text and if there is no email then it hides the invite button.
