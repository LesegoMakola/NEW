// Q.4.1 Create and use database called members_s123456 (replace with your actual student number)
use members_s123456

// Q.4.2 Create members collection and insert the data
db.members.insertMany([
    {
        "Member Name": "Debbie",
        "Member Surname": "Theart",
        "Member DOB": "1980-03-17"
    },
    {
        "Member Name": "Thomas",
        "Member Surname": "Duncan", 
        "Member DOB": "1976-08-12"
    }
])

// Q.4.3 Get a list of all the documents in the collection
db.members.find()

// Q.4.4 Query all documents of members born after 1979-01-12
// Note: Since DOB is stored as string, we can use string comparison for YYYY-MM-DD format
db.members.find({"Member DOB": {$gt: "1979-01-12"}})
