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
    class DAL_XML_imp:Idal
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
        public Dal_XML_imp()
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
                    bankAccounts = new XElement(XElement.Load(BankAccountXml));
                }
                catch
                {
                    throw new Exception("File upload problem");
                }
            }
        }
    }
}
