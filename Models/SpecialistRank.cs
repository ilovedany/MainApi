using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MainAPI
{
    public class SpecialistRank
    {
        public int Id_rank { get; set; }
        
        public string Rank { get; set; }
    
        public int Id { get; set; }

    }
}

    /*CREATE TABLE SpecialistRank(
        Id_rank INT PRIMARY KEY IDENTITY (1,1),
        Rank NVARCHAR(50),      
        Id INT,
        FOREIGN KEY (Id) REFERENCES Users(Id)    
    );
    */
