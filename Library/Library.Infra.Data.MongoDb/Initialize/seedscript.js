var conn = new Mongo();
var db  = conn.getDB("LibraryDatabase");

db.Student.insert({
	"_id" : 1,
    "Name" : "User Admin",
    "Age" : ISODate("2015-10-20T00:12:16.083Z"),
    "Email" : "user@mail.com",
    "PassWord" : "12345"
});

db.Book.insert({
	 "_id" : 1,
    "Name" : "The Phoenis Project",
    "Author" : "Gene Kim",
    "PublishingHouse" : "Amazon"
});
db.Book.insert({
    "_id" : 2,
    "Name" : "Fundamentals of Computer Programming with C#",
    "Author" : "Svetlin Nakov",
    "PublishingHouse" : "Amazon"
});
db.Book.insert({
 "_id" : 3,
    "Name" : "Complicated Data Structures and Algorithms",
    "Author" : "Svetlin Nakov",
    "PublishingHouse" : "Amazon"
});
db.Book.insert({
	    "_id" : 4,
    "Name" : "More Complicated Concepts in C# Programming",
    "Author" : "Svetlin Nakov",
    "PublishingHouse" : "Amazon"
});
db.Book.insert({
    "_id" : 5,
    "Name" : "First Steps in Programming with C#",
    "Author" : "Svetlin Nakov",
    "PublishingHouse" : "Amazon"
});

