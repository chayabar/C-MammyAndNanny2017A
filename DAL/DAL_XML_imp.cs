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
            XElement WorkTime = new XElement("WorkTime", c.WorkTime);
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
            XElement Address = new XElement("Address", n.Address);
            XElement NannyD_of_B = new XElement("NannyD_of_B", n.NannyD_of_B);
            XElement IsElevator = new XElement("IsElevator", n.IsElevator);
            XElement YearsOfExperience = new XElement("YearsOfExperience", n.YearsOfExperience);
            XElement MaxKids = new XElement("MaxKids", n.MaxKids);
            XElement MinimunmAge = new XElement("MinimunmAge", n.MinimunmAge);
            XElement MaximumAge = new XElement("MaximumAge", n.MaximumAge);
            XElement RateforHour = new XElement("RateforHour", n.RateforHour);
            XElement RateforMonth = new XElement("RateforMonth", n.RateforMonth);
            XElement AvailableTime = new XElement("AvailableTime", n.AvailableTime);
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
            XElement Address = new XElement("Address", m.Address);
            XElement HomePhone = new XElement("HomePhone", m.HomePhone);
            XElement BabbySitterAdress = new XElement("BabbySitterAdress", m.BabbySitterAdress);
            XElement Workhours = new XElement("Workhours", m.Workhours);
            XElement MonthPayment = new XElement("IsElevator", m.MonthPayment);

            return new XElement("Nanny", FirstName, Lastname, Tel, Address, HomePhone, BabbySitterAdress, Workhours, MonthPayment);
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
            c.WorkTime = Convert.ToInt32(xc.Element("WorkTime").Value);
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
            n.Address = (xn.Element("Address").Value);

            n.NannyD_of_B = Convert.ToDateTime(xn.Element("NannyD_of_B").Value);
            n.IsElevator = Convert.ToBoolean(xn.Element("IsElevator").Value);
            n.YearsOfExperience = Convert.ToInt32(xn.Element("YearsOfExperience").Value);
            n.MaxKids = Convert.ToInt32(xn.Element("MaxKids").Value);
            n.MinimunmAge = Convert.ToInt32(xn.Element("MinimunmAge").Value);
            n.MaximumAge = Convert.ToInt32(xn.Element("MaximumAge").Value);
            n.RateforHour = Convert.ToInt32(xn.Element("RateforHour").Value);
            n.RateforMonth = Convert.ToInt32(xn.Element("RateforMonth").Value);
            n.AvailableTime = (xn.Element("AvailableTime").Value);
            n.IsBasedonTMTorEdu = Convert.ToBoolean(xn.Element("IsBasedonTMTorEdu").Value);
            n.Recommendation = (xn.Element("Recommendation").Value);
            n.NannyBank = (xn.Element("NannyBank").Value);

            return n;
        }

        Mother BuildMother(XElement xn)
        {
            Mother n = new Mother();
            n.ID = (xn.Element("ID").Value);
            n.Lastname = (xn.Element("Lastname").Value);
            n.FirstName = (xn.Element("FirstName").Value);
            n.Tel = (xn.Element("Tel").Value);
            n.Address = (xn.Element("Address").Value);
            n.HomePhone = (xn.Element("HomePhone").Value);
            n.BabbySitterAdress = (xn.Element("BabbySitterAdress").Value);
            n.Workhours = (xn.Element("Workhours").Value);
            n.MonthPayment = Convert.ToBoolean(xn.Element("MonthPayment").Value);
            return n;
        }


        BankAccount BuildBankAccount(XElement xe)
        {
            BankAccount ba = new BankAccount();
            ba.AccountNumber = Convert.ToInt32(xe.Element("AccountNumber").Value);
            ba.BankNumber = Convert.ToInt32(xe.Element("BankNumber").Value);
            ba.BankBranch = Convert.ToInt32(xe.Element("BankBranch").Value);
            ba.BankAdress = xe.Element("BankAdress").Value);
            return ba;
        }

        #endregion

        #region Add Functions
        public void AddContract(Contract c)
        {
            List<Contract> list = this.GetAllContract();
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
            List<Child> list = this.GetAllChild();
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
            foreach (var item in this.GetAllNanny())
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
            foreach (var item in this.GetAllMother())
            {
                if (item.ID == m.ID)
                    throw new Exception("This Mother allready exist !!!");
            }

            Mothers.Add(BuildXelementMother(m));
            Mothers.Save(MotherXml);
        }
        #endregion

        #region Get Functions
        public List<BankAccount> GetAllAcounts()
        {
            return (from v in BankAccounts.Elements()
                    select BuildBankAccount(v)).ToList();
        }

        public List<Contract> GetAllContract()
        {
            return (from v in Contracts.Elements()
                    select BuildContract(v)).ToList();
        }

        public List<Child> GetAllChild()
        {
            return (from v in Childs.Elements()
                    select BuildChild(v)).ToList();
        }

        public List<Mother> GetAllMother()
        {
            return (from v in Mothers.Elements()
                    select BuildMother(v)).ToList();
        }

        public List<Nanny> GetAllNanny()
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
            current.Element("EmployerId").Value = Convert.ToString(c.EmployerId);
            current.Element("EmployeeId").Value = Convert.ToString(c.EmployeeId);
            current.Element("IsInterviewed").Value = Convert.ToString(c.interview);
            current.Element("IsSinged").Value = Convert.ToString(c.signed);
            current.Element("BrutoSalary").Value = Convert.ToString(c.brutoSalary);
            current.Element("NetoSalary").Value = Convert.ToString(c.netoSalary);
            current.Element("Beginnig").Value = Convert.ToString(c.beginning);
            current.Element("Final").Value = Convert.ToString(c.final);
            current.Element("NumberOfHours").Value = Convert.ToString(c.numberOfHours);
            Contracts.Save(ContractXml);

        }

        public void UpdateNanny(Nanny n)
        {
            XElement current = (from x in Nannys.Elements()
                                where x.Element("ID").Value == Convert.ToString(n.ID)
                                select x).FirstOrDefault();
            if (current == null)
                throw new Exception("the current employee doesn't exist");
            current.Element("FirstName").Value = e.firstName;
            current.Element("LastName").Value = e.lastName;
            current.Element("DateBirth").Value = Convert.ToString(e.dateBirth);
            current.Element("PhoneNumber").Value = Convert.ToString(e.phoneNumber);
            current.Element("City").Value = e.city;

            current.Element("Degree").Value = Convert.ToString(e.d);

            current.Element("Experience").Value = Convert.ToString(e.experience);
            current.Element("BankAccount").Element("BankNumber").Value = Convert.ToString(e.details.BankNum);
            current.Element("BankAccount").Element("BankName").Value = e.details.BankName;
            current.Element("BankAccount").Element("Adress").Value = e.details.BankAdress;
            current.Element("BankAccount").Element("BranchNumber").Value = Convert.ToString(e.details.BankBranch);
            current.Element("AccountNumber").Value = Convert.ToString(e.AcountNumber);
            current.Element("Speciality").Value = Convert.ToString(e.SpecializationNumber);
            current.Element("Car").Value = Convert.ToString(e.car);
            current.Element("FoodCard").Value = Convert.ToString(e.foodCard);
            current.Element("HomeWorker").Value = Convert.ToString(e.homeWorker);
            current.Element("Prize").Value = Convert.ToString(e.prize);
            current.Element("Vacation").Value = Convert.ToString(e.vacation);
            current.Element("Hours").Value = Convert.ToString(e.hoursPerMonth);
            employees.Save(EmployeeXml);
        }

        #endregion




    }
}


