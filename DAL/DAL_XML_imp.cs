using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DAL
{
    class DAL_XML_imp : Idal
    {
        static string ContractXml = @"ContractXml.xml";
        static string ChildXml = @"ChildXml.xml";
        static string MotherXml = @"MotherXml.xml";
        static string NannyXml = @"NannyXml.xml";
        static string BankAccountXml = @"BankAccountXml.xml";
        static XElement Contracts;
        static XElement Childs;
        static XElement Mothers;
        static XElement Nannys;
        static XElement BankAccounts;
        public DAL_XML_imp()
        {
            if (!File.Exists(ContractXml))
            {
                Contracts = new XElement("Contracts");
                Contracts.Save(ContractXml);
            }
            else
            {
                try
                {
                    Contracts = new XElement(XElement.Load(ContractXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(ChildXml))
            {
                Childs = new XElement("Childs");
                Childs.Save(ChildXml);
            }
            else
            {
                try
                {
                    Childs = new XElement(XElement.Load(ChildXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(MotherXml))
            {
                Mothers = new XElement("Mothers");
                Mothers.Save(MotherXml);
            }
            else
            {
                try
                {
                    Mothers = new XElement(XElement.Load(MotherXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(NannyXml))
            {
                Nannys = new XElement("Nannys");
                Nannys.Save(NannyXml);
            }
            else
            {
                try
                {
                    Nannys = new XElement(XElement.Load(NannyXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
            if (!File.Exists(BankAccountXml))
            {
                WebClient wc = new WebClient();
                try
                {
                    string xmlServerPath = @"http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);

                }
                catch (Exception)
                {
                    string xmlServerPath = @"http://www.jct.ac.il/~coshri/atm.xml";
                    wc.DownloadFile(xmlServerPath, BankAccountXml);
                }
                finally
                {
                    wc.Dispose();
                }
            }
            else
            {
                try
                {
                    BankAccounts = new XElement(XElement.Load(BankAccountXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
        }

        #region Build XElement
        XElement BuildXelementContract(Contract c)
        {
            XElement NumberOfContract = new XElement("NumberOfContract", c.NumberOfContract);
            XElement NunnyID = new XElement("NunnyID", c.NunnyID);
            XElement MotherID = new XElement("MotherID", c.MotherID);
            XElement ChildID = new XElement("ChildID", c.ChildID);
            XElement IsInterview = new XElement("IsInterview", c.IsInterview);
            XElement IsContract = new XElement("IsContract", c.IsContract);
            XElement RateforHour = new XElement("RateforHour", c.RateforHour);
            XElement RateforMonth = new XElement("RateforMonth", c.RateforMonth);
            XElement IsMorechilds = new XElement("IsMorechilds", c.IsMorechilds);
            //workTime
            XElement WorkTime = new XElement("WorkTime", 
                from e in c.WorkTime
                select new XElement(e.Key.ToString(),
                            new XElement("start", e.Value.Key),
                            new XElement("end", e.Value.Value)));
 
            XElement DateStart = new XElement("DateStart", c.DateStart);
            XElement DateEnd = new XElement("DateEnd", c.DateEnd);
            XElement HoursOfContractMonth = new XElement("HoursOfContractMonth", c.HoursOfContractMonth);
            return new XElement("Contract", NumberOfContract, NunnyID, MotherID, ChildID, IsInterview, IsContract, RateforHour, RateforMonth, IsMorechilds, WorkTime, DateStart, DateEnd, HoursOfContractMonth);
        }

        XElement BuildXelementChild(Child c)
        {
            XElement ChildID = new XElement("ChildID", c.ChildID);
            XElement MotherID = new XElement("MotherID", c.MotherID);
            XElement ChildName = new XElement("ChildName", c.ChildName);
            XElement DateOfBirth = new XElement("DateOfBirth", c.DateOfBirth);
            XElement IsSpacialNeeds = new XElement("IsSpacialNeeds", c.IsSpacialNeeds);
            return new XElement("Child", ChildID, MotherID, ChildName, DateOfBirth, IsSpacialNeeds);
        }

        XElement BuildXelementNanny(Nanny n)
        {
            XElement Lastname = new XElement("Lastname", n.Lastname);
            XElement FirstName = new XElement("FirstName", n.FirstName);
            XElement Tel = new XElement("Tel", n.Tel);
            //Address
            XElement Number= new XElement("Number", n.Address.Number);
            XElement Street = new XElement("Street", n.Address.Street);
            XElement City = new XElement("City", n.Address.City);
            XElement ZipCode = new XElement("ZipCode", n.Address.ZipCode);
            XElement Country = new XElement("Country", n.Address.Country);
            XElement Address = new XElement("Address", Number, Street, City, ZipCode, Country);
            //
            XElement NannyD_of_B = new XElement("NannyD_of_B", n.NannyD_of_B);
            XElement IsElevator = new XElement("IsElevator", n.IsElevator);
            XElement YearsOfExperience = new XElement("YearsOfExperience", n.YearsOfExperience);
            XElement MaxKids = new XElement("MaxKids", n.MaxKids);
            XElement MinimunmAge = new XElement("MinimunmAge", n.MinimunmAge);
            XElement MaximumAge = new XElement("MaximumAge", n.MaximumAge);
            XElement RateforHour = new XElement("RateforHour", n.RateforHour);
            XElement RateforMonth = new XElement("RateforMonth", n.RateforMonth);
            //availabeTime
            XElement s = new XElement(DayOfWeek.Sunday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Sunday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Sunday].Value));
            XElement m = new XElement(DayOfWeek.Monday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Monday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Monday].Value));
            XElement t = new XElement(DayOfWeek.Tuesday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Tuesday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Tuesday].Value));
            XElement w = new XElement(DayOfWeek.Wednesday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Wednesday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Wednesday].Value));
            XElement th = new XElement(DayOfWeek.Thursday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Thursday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Thursday].Value));
            XElement f = new XElement(DayOfWeek.Friday.ToString(),
                new XElement("start", n.AvailableTime[DayOfWeek.Friday].Key),
                new XElement("end", n.AvailableTime[DayOfWeek.Friday].Value));
            XElement AvailableTime = new XElement("AvailableTime", s, m, t, w, th, f);

            XElement IsBasedonTMTorEdu = new XElement("IsBasedonTMTorEdu", n.IsBasedonTMTorEdu);
            XElement Recommendation = new XElement("Recommendation", n.Recommendation);
            XElement NannyBank = new XElement("NannyBank", n.NannyBank);
            return new XElement("Nanny", FirstName, Lastname, Tel, Address, NannyD_of_B, IsElevator, YearsOfExperience, MaxKids, MinimunmAge, MaximumAge, RateforHour, RateforMonth, AvailableTime, IsBasedonTMTorEdu, Recommendation, NannyBank);
        }

        XElement BuildXelementMother(Mother m)
        {
            XElement Lastname = new XElement("Lastname", m.Lastname);
            XElement FirstName = new XElement("FirstName", m.FirstName);
            XElement Tel = new XElement("Tel", m.Tel);
            //Address
            XElement Number = new XElement("Number", m.Address.Number);
            XElement Street = new XElement("Street", m.Address.Street);
            XElement City = new XElement("City", m.Address.City);
            XElement ZipCode = new XElement("ZipCode", m.Address.ZipCode);
            XElement Country = new XElement("Country", m.Address.Country);
            XElement Address = new XElement("Address", Number, Street, City, ZipCode, Country);
            //
            XElement HomePhone = new XElement("HomePhone", m.HomePhone);
            //BabbySitterAdress
            XElement bNumber = new XElement("BabbySitterNumber", m.Address.Number);
            XElement bStreet = new XElement("BabbySitterStreet", m.Address.Street);
            XElement bCity = new XElement("BabbySitterCity", m.Address.City);
            XElement bZipCode = new XElement("BabbySitterZipCode", m.Address.ZipCode);
            XElement bCountry = new XElement("BabbySitterCountry", m.Address.Country);
            XElement BabbySitterAdress = new XElement("BabbySitterAdress", bNumber, bStreet, bCity, bZipCode, bCountry);
            //workHours
            XElement s = new XElement(DayOfWeek.Sunday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Sunday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Sunday].Value));
            XElement mo = new XElement(DayOfWeek.Monday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Monday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Monday].Value));
            XElement t = new XElement(DayOfWeek.Tuesday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Tuesday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Tuesday].Value));
            XElement w = new XElement(DayOfWeek.Wednesday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Wednesday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Wednesday].Value));
            XElement th = new XElement(DayOfWeek.Thursday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Thursday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Thursday].Value));
            XElement f = new XElement(DayOfWeek.Friday.ToString(),
                new XElement("start", m.Workhours[DayOfWeek.Friday].Key),
                new XElement("end", m.Workhours[DayOfWeek.Friday].Value));
            XElement Workhours = new XElement("Workhours", s, m, t, w, th, f);

            XElement MonthPayment = new XElement("IsElevator", m.MonthPayment);

            return new XElement("Mother", FirstName, Lastname, Tel, Address, HomePhone, BabbySitterAdress, Workhours, MonthPayment);
        }
        #endregion

        #region Build Object
        Contract BuildContract(XElement xc)
        {
            Contract c = new Contract();
            c.NumberOfContract = Convert.ToInt32(xc.Element("NumberOfContract").Value);
            c.NunnyID = (xc.Element("NunnyID").Value);
            c.MotherID = (xc.Element("MotherID").Value);
            c.ChildID = (xc.Element("ChildID").Value);
            c.IsInterview = Convert.ToBoolean(xc.Element("IsInterview").Value);
            c.IsContract = Convert.ToBoolean(xc.Element("IsContract").Value);
            c.RateforHour = Convert.ToInt32(xc.Element("RateforHour").Value);
            c.RateforMonth = Convert.ToInt32(xc.Element("RateforMonth").Value);
            c.IsMorechilds = Convert.ToBoolean(xc.Element("IsMorechilds").Value);
            //c.WorkTime = Convert.ToInt32(xc.Element("WorkTime").Value);
            
            c.WorkTime = new Dictionary<DayOfWeek, KeyValuePair<int, int>>();
            foreach (var e in xc.Element("WorkTime").Elements())
            {
                c.WorkTime[(DayOfWeek)Enum.Parse(typeof (DayOfWeek),e.Name.ToString())] = new KeyValuePair<int, int>(Convert.ToInt32(e.Element("start").Value), Convert.ToInt32(e.Element("end").Value));               
            }


            c.DateStart = Convert.ToDateTime(xc.Element("DateStart").Value);
            c.DateEnd = Convert.ToDateTime(xc.Element("DateEnd").Value);
            c.HoursOfContractMonth = Convert.ToInt32(xc.Element("HoursOfContractMonth").Value);
            return c;
        }
        Child BuildChild(XElement xc)
        {
            Child c = new Child();
            c.ChildID = (xc.Element("ChildID").Value);
            c.MotherID = (xc.Element("MotherID").Value);
            c.ChildName = (xc.Element("ChildName").Value);
            c.DateOfBirth = Convert.ToDateTime(xc.Element("DateOfBirth").Value);
            c.IsSpacialNeeds = Convert.ToBoolean(xc.Element("IsSpacialNeeds").Value);
            return c;
        }
        Nanny BuildNanny(XElement xn)
        {
            Nanny n = new Nanny();
            n.ID = (xn.Element("ID").Value);
            n.Lastname = (xn.Element("Lastname").Value);
            n.FirstName = (xn.Element("FirstName").Value);
            n.Tel = (xn.Element("Tel").Value);
            Address a = new Address();
            //Address
            a.Number = Convert.ToInt32(xn.Element("Number").Value);
            a.Street = xn.Element("Street").Value;
            a.City = xn.Element("City").Value;
            a.ZipCode = xn.Element("ZipCode").Value;
            a.Country = xn.Element("Country").Value;
            n.Address = a;
            //
            n.NannyD_of_B = Convert.ToDateTime(xn.Element("NannyD_of_B").Value);
            n.IsElevator = Convert.ToBoolean(xn.Element("IsElevator").Value);
            n.YearsOfExperience = Convert.ToInt32(xn.Element("YearsOfExperience").Value);
            n.MaxKids = Convert.ToInt32(xn.Element("MaxKids").Value);
            n.MinimunmAge = Convert.ToInt32(xn.Element("MinimunmAge").Value);
            n.MaximumAge = Convert.ToInt32(xn.Element("MaximumAge").Value);
            n.RateforHour = Convert.ToInt32(xn.Element("RateforHour").Value);
            n.RateforMonth = Convert.ToInt32(xn.Element("RateforMonth").Value);
            //n.AvailableTime = (xn.Element("AvailableTime").Value);
            n.IsBasedonTMTorEdu = Convert.ToBoolean(xn.Element("IsBasedonTMTorEdu").Value);
            n.Recommendation = (xn.Element("Recommendation").Value);
            //n.NannyBank = (xn.Element("NannyBank").Value);

            return n;
        }

        Mother BuildMother(XElement xm)
        {
            Mother n = new Mother();
            n.ID = (xm.Element("ID").Value);
            n.Lastname = (xm.Element("Lastname").Value);
            n.FirstName = (xm.Element("FirstName").Value);
            n.Tel = (xm.Element("Tel").Value);
            Address a = new Address();
            //Address
            a.Number = Convert.ToInt32(xm.Element("Number").Value);
            a.Street = xm.Element("Street").Value;
            a.City = xm.Element("City").Value;
            a.ZipCode = xm.Element("ZipCode").Value;
            a.Country = xm.Element("Country").Value;
            n.Address = a;
            //           
            n.HomePhone = (xm.Element("HomePhone").Value);
            Address ab = new Address();
            //Address
            ab.Number = Convert.ToInt32(xm.Element("bNumber").Value);
            ab.Street = xm.Element("bStreet").Value;
            ab.City = xm.Element("bCity").Value;
            ab.ZipCode = xm.Element("bZipCode").Value;
            ab.Country = xm.Element("bCountry").Value;
            n.BabbySitterAdress = ab;
            //
            //n.Workhours = (xn.Element("Workhours").Value);
            n.MonthPayment = Convert.ToBoolean(xm.Element("MonthPayment").Value);
            return n;
        }


        BankAccount BuildBankBranch(XElement xe)
        {
            BankAccount ba = new BankAccount();
            ba.BankNumber = Convert.ToInt32(xe.Element("BankNumber").Value);
            ba.BankName = (xe.Element("BankName").Value);
            ba.BankBranch = Convert.ToInt32(xe.Element("BankBranch").Value);
            Address a = new Address();
            //Address
            a.Number = Convert.ToInt32(xe.Element("Number").Value);
            a.Street = xe.Element("Street").Value;
            a.City = xe.Element("City").Value;
            a.ZipCode = xe.Element("ZipCode").Value;
            a.Country = xe.Element("Country").Value;
            ba.BankAdress = a;
            //            
            return ba;
        }

        #endregion

        #region Add Functions
        public void AddContract(Contract c)
        {
            List<Contract> list = this.GetContract();
            foreach (var item in list)
            {
                if (item.NumberOfContract == c.NumberOfContract)

                {
                    throw new Exception("This contract allready exist !!!");
                }
            }
            if (list.Count == 0)
            {

                c.NumberOfContract = 10000000;

            }
            else
            {
                c.NumberOfContract = list[list.Count() - 1].NumberOfContract + 1;
            }

            Contracts.Add(BuildXelementContract(c));

        }

        public void AddChild(Child c)
        {
            List<Child> list = this.GetChilds();
            foreach (var item in list)
            {
                if (item.ChildID == c.ChildID)

                {
                    throw new Exception("This Child allready exist !!!");
                }
            }
            Childs.Add(BuildXelementChild(c));

        }

        public void AddNanny(Nanny n)
        {
            if (n == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            foreach (var item in this.GetNannys())
            {
                if (item.ID == n.ID)
                    throw new Exception("This Nanny allready exist !!!");
            }

            Nannys.Add(BuildXelementNanny(n));
            Nannys.Save(NannyXml);
        }

        public void AddMother(Mother m)
        {
            if (m == null)
            {
                throw new Exception("ERROR: enter a Variable value!!!");
            }
            foreach (var item in this.GetMothers())
            {
                if (item.ID == m.ID)
                    throw new Exception("This Mother allready exist !!!");
            }

            Mothers.Add(BuildXelementMother(m));
            Mothers.Save(MotherXml);
        }
        #endregion

        #region Get Functions
        public List<BankAccount> GetBankBranchs()
        {
            return (from v in BankAccounts.Elements()
                    select BuildBankBranch(v)).ToList();
        }

        public List<Contract> GetContract()
        {
            return (from v in Contracts.Elements()
                    select BuildContract(v)).ToList();
        }

        public List<Child> GetChilds()
        {
            return (from v in Childs.Elements()
                    select BuildChild(v)).ToList();
        }

        public List<Mother> GetMothers()
        {
            return (from v in Mothers.Elements()
                    select BuildMother(v)).ToList();
        }

        public List<Nanny> GetNannys()
        {
            return (from v in Nannys.Elements()
                    select BuildNanny(v)).ToList();
        }
        #endregion

        #region Remove Functions
        public void DeleteContract(Contract c)
        {
            XElement current = (from x in Contracts.Elements()
                                where Convert.ToInt32(x.Element("NumberOfContract").Value) == c.NumberOfContract
                                select x).FirstOrDefault();
            current.Remove();
            Contracts.Save(ContractXml);
        }

        public void DeleteChild(Child c)
        {
            XElement current = (from x in Childs.Elements()
                                where (x.Element("ChildID").Value) == c.ChildID
                                select x).FirstOrDefault();
            current.Remove();
           Childs.Save(ChildXml);
        }

        public void DeleteNanny(Nanny n)
        {
            XElement current = (from x in Nannys.Elements()
                                where (x.Element("ID").Value) == n.ID
                                select x).FirstOrDefault();
            current.Remove();
            Nannys.Save(NannyXml);
        }

        public void DeleteMother(Mother m)
        {
            XElement current = (from x in Mothers.Elements()
                                where (x.Element("ID").Value) == m.ID
                                select x).FirstOrDefault();
            current.Remove();
            Mothers.Save(MotherXml);
        }
        #endregion
        
        #region Update Functions
        public void UpdateContract(Contract c)
        {
            XElement current = (from x in Contracts.Elements()
                                where x.Element("NumberOfContract").Value == Convert.ToString(c.NumberOfContract)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current contract doesn't exist");
            current.Element("NumberOfContract").Value = Convert.ToString(c.NumberOfContract);
            current.Element("NunnyID").Value = Convert.ToString(c.NunnyID);
            current.Element("MotherID").Value = Convert.ToString(c.MotherID);
            current.Element("ChildID").Value = Convert.ToString(c.ChildID);
            current.Element("IsInterview").Value = Convert.ToString(c.IsInterview);
            current.Element("IsContract").Value = Convert.ToString(c.IsContract);
            current.Element("RateforHour").Value = Convert.ToString(c.RateforHour);
            current.Element("RateforMonth").Value = Convert.ToString(c.RateforMonth);
            current.Element("IsMorechilds").Value = Convert.ToString(c.IsMorechilds);
            current.Element("WorkTime").Value = Convert.ToString(c.WorkTime);
            current.Element("DateStart").Value = Convert.ToString(c.DateStart);
            current.Element("DateEnd").Value = Convert.ToString(c.DateEnd);
            current.Element("HoursOfContractMonth").Value = Convert.ToString(c.HoursOfContractMonth);
            Contracts.Save(ContractXml);

        }

        public void UpdateChild(Child c)
        {
            XElement current = (from x in Contracts.Elements()
                                where x.Element("ChildID").Value == Convert.ToString(c.ChildID)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current child doesn't exist");
            current.Element("ChildID").Value = Convert.ToString(c.ChildID);
            current.Element("MotherID").Value = Convert.ToString(c.MotherID);
            current.Element("ChildName").Value = Convert.ToString(c.ChildName);
            current.Element("DateOfBirth").Value = Convert.ToString(c.DateOfBirth);
            current.Element("IsSpacialNeeds").Value = Convert.ToString(c.IsSpacialNeeds);
            Childs.Save(ChildXml);
        }

        public void UpdateNanny(Nanny n)
        {
            XElement current = (from x in Nannys.Elements()
                                where x.Element("ID").Value == Convert.ToString(n.ID)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employee doesn't exist");
            current.Element("Lastname").Value = n.Lastname;
            current.Element("FirstName").Value = n.FirstName;
            current.Element("Tel").Value = n.Tel;
            current.Element("NannyBank").Element("BankNumber").Value = Convert.ToString(n.NannyBank.BankNumber);
            current.Element("NannyBank").Element("BankName").Value = Convert.ToString(n.NannyBank.BankName);
            current.Element("NannyBank").Element("BankBranch").Value = n.NannyBank.BankName;
            current.Element("NannyBank").Element("BankAdress").Value = Convert.ToString(n.NannyBank.BankBranch);
            XElement a = new XElement(
            //Address
            new XElement("Number").Value= Convert.ToString(n.Address.Number),
            new XElement("Street").Value =(n.Address.Street),
            new XElement("City").Value = (n.Address.City),
            new XElement("ZipCode").Value = (n.Address.ZipCode),
            new XElement("Country").Value = Convert.ToString(n.Address.Country)
            );
            current.Element("Address").ReplaceAll(a);  
            current.Element("NannyD_of_B").Value = Convert.ToString(n.NannyD_of_B);
            current.Element("IsElevator").Value = Convert.ToString(n.IsElevator);
            current.Element("YearsOfExperience").Value = Convert.ToString(n.YearsOfExperience);
            current.Element("MaxKids").Value = Convert.ToString(n.MaxKids);
            current.Element("MinimunmAge").Value = Convert.ToString(n.MinimunmAge);
            current.Element("MaximumAge").Value = Convert.ToString(n.MaximumAge);
            current.Element("RateforHour").Value = Convert.ToString(n.RateforHour);
            current.Element("RateforMonth").Value = Convert.ToString(n.RateforMonth);
            current.Element("AvailableTime").Value = Convert.ToString(n.AvailableTime);
            current.Element("IsBasedonTMTorEdu").Value = Convert.ToString(n.IsBasedonTMTorEdu);
            current.Element("Recommendation").Value = n.Recommendation;

            Nannys.Save(NannyXml);
        }

        public void UpdateMother(Mother m)
        {
            XElement current = (from x in Mothers.Elements()
                                where x.Element("ID").Value == Convert.ToString(m.ID)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employee doesn't exist");
            current.Element("Lastname").Value = m.Lastname;
            current.Element("FirstName").Value = m.FirstName;
            current.Element("Tel").Value = m.Tel;
            current.Element("Address").Value = Convert.ToString(m.Address);
            XElement a = new XElement(
            //Address
            new XElement("Number").Value = Convert.ToString(m.Address.Number),
            new XElement("Street").Value = (m.Address.Street),
            new XElement("City").Value = (m.Address.City),
            new XElement("ZipCode").Value = (m.Address.ZipCode),
            new XElement("Country").Value = Convert.ToString(m.Address.Country)
            );
            current.Element("Address").ReplaceAll(a);
            current.Element("HomePhone").Value = m.HomePhone;
            XElement ba = new XElement(
           //Address
           new XElement("Number").Value = Convert.ToString(m.Address.Number),
           new XElement("Street").Value = (m.Address.Street),
           new XElement("City").Value = (m.Address.City),
           new XElement("ZipCode").Value = (m.Address.ZipCode),
           new XElement("Country").Value = Convert.ToString(m.Address.Country)
           );
            current.Element("BabbySitterAdress").ReplaceAll(ba);
            current.Element("Workhours").Value = Convert.ToString(m.Workhours);
            current.Element("MonthPayment").Value = Convert.ToString(m.MonthPayment);
            Mothers.Save(MotherXml);
        }


        #endregion

        #region get functions

        private void ChildLoadData()
        {
            try
            {
                Childs = XElement.Load(ChildXml);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }
       public List<Child> GetChildsByMother(Mother mother)
        {
            ChildLoadData();
            List<Child> childs;
            try
            {
                childs = (from p in Childs.Elements()
                          where (p.Element("MotherID").Value) == mother.ID
                          select new Child()
                          {
                              ChildID = (p.Element("ChildID").Value),
                              MotherID = (p.Element("MotherID").Value),
                              ChildName = (p.Element("ChildName").Value),
                              DateOfBirth = Convert.ToDateTime(p.Element("DateOfBirth").Value),
                              IsSpacialNeeds = Convert.ToBoolean(p.Element("IsSpacialNeeds").Value)
                          }).ToList();
            }
            catch
            {
                childs = null;
            }
            return childs;
        }

        #endregion

    }
}


