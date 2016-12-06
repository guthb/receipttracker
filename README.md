# Back End Capstone Application  ReceiptTracker

### Summary
Backend capstone for NSS full stack developer course

## Requirements
- Must be a ASP.NET MVC web application.
- Must call at least one API endpoint from eiher a 3rd party or created by the student.
- AngularJS usage is not required but highly encouraged.

### Product Pitch
Point of Sale (POS) devices provide you three choices typically for receipts: email, text or print. Over time we loose the email due to retention policies or accidental delete, texts suffer the same and printouts are easily lost between the store to your home folder if you have one.

Replace the personal email used with those POS with a Receipt Tracker email and send receipts there for storage, classification and reuse for returns when and if needed.

### Description


### Order of Operations
1.User registers for account with app
1.When prompted at POS system enter your new account name with @applicationname.com as the email
1.POS sends Email of receipt to Receipt Store Ingest endpoint 
1.Lambda parses data and stores in database with API built in C#
1.Parser is written local with C# and pulls raw data and stores in values local database
1.User logs into account to see stored receipts, date, etc
1.User can classify each receipt and that classification is stored in database
1.User can administer account i.e. change user name and personal email or delete account and data

### Stretch Goals
- Ingest photo of paper receipt (Parsing (tesseract)
- Text message ingest
- Authentication through Google / FB /GitHub

## Completed ERD and Table Join ![Screenshot](/ERD/receiptTrackerErd.png)

### Setup