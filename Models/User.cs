using System.Xml;

namespace MainAPI
{
    public class User
    {
        
        public int Id{get; set;}

        public string Name{get; set;}
 
        public string Surname{get; set;}
        public int Age{get; set;}

        public string Email{get; set;}
        public string XamlData{get; set;}
    }
}

    /*CREATE TABLE Users (
        Id INT PRIMARY KEY IDENTITY (1,1),
        Name NVARCHAR(50),
        Surname NVARCHAR(50),
        Age INT,
        Email NVARCHAR(50),
    );


    ALTER TABLE users
    ADD COLUMN XamlData xml;
    */
    
    