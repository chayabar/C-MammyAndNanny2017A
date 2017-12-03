using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{
    internal static class BEextention
    {
        internal static Nanny NannyDeepClone(this Nanny source)
        {
            return new Nanny
            {
                ID = source.ID,
                Lastname = source.Lastname,
                FirstName = source.FirstName,
                Tel = source.Tel,
                Address = source.Address,
                NannyD_of_B = source.NannyD_of_B,
                IsElevator = source.IsElevator,
                YearsOfExperience = source.YearsOfExperience,
                MaxKids = source.MaxKids,
                MinimunmAge = source.MinimunmAge,
                MaximumAge = source.MaximumAge,
                RateforHour = source.RateforHour,
                RateforMonth = source.RateforMonth,
                AvailableTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>( source.AvailableTime),
                IsBasedonTMTorEdu = source.IsBasedonTMTorEdu,
                Recommendation = source.Recommendation,
                NannyBank = source.NannyBank
            };
        }
        internal static Mother MotherDeepClone(this Mother source)
        {
            return new Mother
            {
                ID = source.ID,
                Lastname = source.Lastname,
                FirstName = source.FirstName,
                Tel = source.Tel,
                Address = source.Address,
                HomePhone = source.HomePhone,
                BabbySitterAdress = source.BabbySitterAdress,
                Workhours = new Dictionary<DayOfWeek, KeyValuePair<int, int>>(source.Workhours),
                WeeklyPayment= source.WeeklyPayment
            };
        }
        internal static Child ChildDeepClone(this Child source)
        {
            return new Child
            {
                ChildID = source.ChildID,
                MotherID = source.MotherID,
                ChildName = source.ChildName,
                DateOfBirth = source.DateOfBirth,
                IsSpacialNeeds = source.IsSpacialNeeds
            };
        }
        internal static Contract ContractDeepClone(this Contract source)
        {
            return new Contract
            {
                NumberOfContract = source.NumberOfContract,
                NunnyID=source.NunnyID,
                MotherID=source.MotherID,
                ChildID = source.ChildID,
                IsInterview = source.IsInterview,
                IsContract = source.IsContract,
                RateforHour = source.RateforHour,
                RateforMonth = source.RateforMonth,
                IsMorechilds = source.IsMorechilds,
                WorkTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>( source.WorkTime),
                DateStart = source.DateStart,
                DateEnd = source.DateEnd,
                HoursOfContractMonth = source.HoursOfContractMonth
            };
        }
    }
}

