using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SCMS.Models;

namespace SCMS.DAL
{
    public class SCMSInitializer : DropCreateDatabaseIfModelChanges<SCMSContext>
    {
        protected override void Seed(SCMSContext context)
        {
            var farmers = new List<Farmer>
           {
                new Farmer{FirsName="Abdur",MiddleName="",LastName="Rahim",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-06-01")},
                new Farmer{FirsName="Kamal",MiddleName="Rahaman",LastName="Kollol",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-07-06")},
                new Farmer{FirsName="Khalil",MiddleName="",LastName="Rahman",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-08-07")},
                new Farmer{FirsName="Kamal",MiddleName="",LastName="Ali",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-03-09")},
                new Farmer{FirsName="Jamal",MiddleName="",LastName="Ali",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-04-12")},
                new Farmer{FirsName="Nonodon",MiddleName="",LastName="Das",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-06-20")},
                new Farmer{FirsName="Montu",MiddleName="",LastName="Mia",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-05-25")},
                new Farmer{FirsName="Dhiman",MiddleName="",LastName="Ghosh",Address="Alexander",
                     NationalIdNo="123456789",DateOfBirth =DateTime.Parse("1988-11-27")},
             };
            farmers.ForEach(s => context.Farmers.Add(s));
            context.SaveChanges();
            var cunltivationDetails = new List<CunltivationDetail>
            {
                 new CunltivationDetail{FarmerId=1,LandArea=1050,CaneVariety=CaneVariety.A,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
                 new CunltivationDetail{FarmerId=1,LandArea=4022,CaneVariety=CaneVariety.C,EstimatedTime=10,
                    DateofPlanting =DateTime.Parse("2015-06-01"),PlantRatoon =DateTime.Parse("2015-07-01"),
                    DeliverDate =DateTime.Parse("2016-06-01")},
             };
            cunltivationDetails.ForEach(s => context.CunltivationDetails.Add(s));
            context.SaveChanges();
        }

    }
}
