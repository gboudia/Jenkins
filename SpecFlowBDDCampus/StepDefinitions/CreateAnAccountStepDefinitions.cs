using SpecFlowBDDCampus.Data;
using System;
using TechTalk.SpecFlow;

using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SpecFlowBDDCampus.StepDefinitions
{
    [Binding]
    public class CreateAnAccountStepDefinitions
    {
        public IWebDriver Navig; // Déclarer mon driver afin de l'utiliser dans mes méthodes
        IJavaScriptExecutor js; // Déclarer un IJavaScriptExecutor : un objet qui permet d'exécuter du code JavaScript
        ReadData read = new ReadData();
        List<Client> clients;
        public Client client;


        [Given(@"User is in the register page Etu")]
        public void GivenUserIsInTheRegisterPageEtu()
        {
            Navig = new ChromeDriver(@"C:\\Selenium\\chromedriver.exe");
            js = (IJavaScriptExecutor)Navig;
            clients = read.ReadDataFromJson();
            client = clients[0];

            Thread.Sleep(2000);
            Navig.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register"); //Lancer mon navigateur

            //js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("tarteaucitronPersonalize2")));
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("tarteaucitronPersonalize2")).Click();//Accepter cookies


        }

        [When(@"User fills AdresseEtu'([^']*)' and MotDePasseEtu '([^']*)'and ConfirmMotPasseEtu'([^']*)'")]
        public void WhenUserFillsAdresseEtuAndMotDePasseEtuAndConfirmMotPasseEtu(string adresseEmail, string passeword, string confirmPasseword)
        {
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("edit-name")));

            Navig.FindElement(By.XPath("//input[@id=\"edit-name\" and @autocorrect=\"off\"]")).SendKeys(client.Email);
            //Thread.Sleep(2000);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("edit-pass-pass1")));

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-pass-pass1")).SendKeys(client.MotPasse);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-pass-pass2")).SendKeys(client.ConfirmMotPasse);
           

        }

        [When(@"User click on CivilitéEtu'([^']*)'")]
        public void WhenUserClickOnCiviliteEtu(string civilité)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector(".js-form-item-field-civilite:nth-child(1) > .option")).Click();
        }

        [When(@"User fills NomEtu '([^']*)' and PrenomEtu '([^']*)'")]
        public void WhenUserFillsNomEtuAndPrenomEtu(string nom, string prenom)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(client.Nom);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(client.Prénom);

        }


        [When(@"User select on PaysResidenceEtu'([^']*)'")]
        public void WhenUserSelectOnPaysResidenceEtu(string paysResidence)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//*[@id=\"edit-field-pays-concernes-wrapper\"]/div/div/div[1]")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//div[@data-value=169]")).Click();

        }

        [When(@"User fills PaysNationalitéEtu '([^']*)' and CodePostaleEtu'([^']*)' and villeEtu '([^']*)' TelephoneEtu '([^']*)'")]
        public void WhenUserFillsPaysNationaliteEtuAndCodePostaleEtuAndVilleEtuTelephoneEtu(string paysNationalité, string codePostal, string ville, string telephone)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(client.PaysNationnalité);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(client.CodePostal);

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//input[@id=\"edit-field-ville-0-value\"]")).SendKeys(client.Ville);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(client.Telephone);

        }

        [When(@"User clicks on ProfessionEtu ""([^""]*)"" or PorfessionCher ""Chercheurs")]
        public void WhenUserClicksOnProfessionEtuOrPorfessionCherChercheurs(string etudiants)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-publics-cibles > div:nth-child(1)")).Click();
       
        }

        [When(@"User select DomaineEtude'([^']*)' and NiveauEtude '([^']*)'")]
        public void WhenUserSelectDomaineEtudeAndNiveauEtude(string domaineEtudes, string niveauEtudes)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-domaine-etudes-wrapper > div > div > div.selectize-input.items.full.has-options.has-items")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//div[@data-value=327]")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-niveaux-etude-wrapper > div > div > div.selectize-input.items.full.has-options.has-items")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//div[@data-value=507]")).Click();

        }

        [When(@"User clicks on acceptanceEtu and SubmitEtu")]
        public void WhenUserClicksOnAcceptanceEtuAndSubmitEtu()
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div")).Click();
            //Navig.FindElement(By.Id("edit-submit")).Click();

        }

        [Then(@"A message of succes creationEtu is displayed")]
        public void ThenAMessageOfSuccesCreationEtuIsDisplayed()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("J’accepte que mes données soient traitées pour recevoir des communications adaptées, de la part de Campus France.", Navig.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div > label")).Text);

        }

        //Institutionnel
        [Given(@"User is in the register page Inst")]
        public void GivenUserIsInTheRegisterPageInst()
        {
            Navig = new ChromeDriver(@"C:\\Selenium\\chromedriver.exe");
            js = (IJavaScriptExecutor)Navig;
            clients = read.ReadDataFromJson();
            client = clients[1];

            Thread.Sleep(2000);
            Navig.Navigate().GoToUrl("https://www.campusfrance.org/fr/user/register"); //Lancer mon navigateur

            //js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("tarteaucitronPersonalize2")));
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("tarteaucitronPersonalize2")).Click();//Accepter cookies
        }

        [When(@"User fills AdresseInst'([^']*)' and MotDePasseInst'([^']*)'and ConfirmMotPasseInst'([^']*)'")]
        public void WhenUserFillsAdresseInstAndMotDePasseInstandConfirmMotPasseInst(string adresseEmail, string passeword, string confirmPasseword)
        {
            Thread.Sleep(2000);
            js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("edit-name")));

            Navig.FindElement(By.XPath("//input[@id=\"edit-name\" and @autocorrect=\"off\"]")).SendKeys(client.Email);
            //Thread.Sleep(2000);
            //js.ExecuteScript("arguments[0].scrollIntoView(true);", Navig.FindElement(By.Id("edit-pass-pass1")));

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-pass-pass1")).SendKeys(client.MotPasse);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-pass-pass2")).SendKeys(client.ConfirmMotPasse);

        }

        [When(@"User click on civilitéInst '([^']*)'")]
        public void WhenUserClickOnCiviliteInst(string civilité)
        {

            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector(".js-form-item-field-civilite:nth-child(1) > .option")).Click();

        }

        [When(@"User fills NomInst '([^']*)' and PrenomInst '([^']*)'")]
        public void WhenUserFillsNomInstAndPrenomInst(string nom, string prenom)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-nom-0-value")).SendKeys(client.Nom);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-prenom-0-value")).SendKeys(client.Prénom);
        }



        [When(@"User select on PaysResidenceInst '([^']*)'")]
        public void WhenUserSelectOnPaysResidenceInst(string paysResidence)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//*[@id=\"edit-field-pays-concernes-wrapper\"]/div/div/div[1]")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//div[@data-value=169]")).Click();
        }


        [When(@"User fills PaysNationalitéInst '([^']*)' and CodePostaleInst'([^']*)' and villeInst '([^']*)' TelephoneInst '([^']*)'")]
        public void WhenUserFillsPaysNationaliteInstAndCodePostaleInstAndVilleInstTelephoneInst(string paysNationalité, string codePostal, string ville, string telephone)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-nationalite-0-target-id")).SendKeys(client.PaysNationnalité);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-code-postal-0-value")).SendKeys(client.CodePostal);

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//input[@id=\"edit-field-ville-0-value\"]")).SendKeys(client.Ville);

            Thread.Sleep(2000);
            Navig.FindElement(By.Id("edit-field-telephone-0-value")).SendKeys(client.Telephone);
        }

        [When(@"User clicks on ProfessionInst ""([^""]*)""")]
        public void WhenUserClicksOnProfessionInst(string institutionnel)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-publics-cibles > div:nth-child(3)")).Click();
        }


        [When(@"User fills Fonction '([^']*)'")]
        public void WhenUserFillsFonction(string fonction)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//input[@id=\"edit-field-fonction-0-value\"]")).SendKeys(client.Fonction);
        }

        [When(@"User select TypeOrganisme '([^']*)'")]
        public void WhenUserSelectTypeOrganisme(string typeOrganisme)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-type-organisme-wrapper > div > div > div.selectize-input.items.full.has-options.has-items")).Click();

            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//div[@data-value=600]")).Click();

        }

        [When(@"User fillss NomOrganisme '([^']*)'")]
        public void WhenUserFillssNomOrganisme(string NomOrganisme)
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.XPath("//input[@id=\"edit-field-nom-organisme-0-value\"]")).SendKeys(client.NomOrganisme);
        }

        [When(@"User clicks on acceptanceInst and SubmitInst")]
        public void WhenUserClicksOnAcceptanceInstAndSubmitInst()
        {
            Thread.Sleep(2000);
            Navig.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div")).Click();
        }

        [Then(@"A message of succes creationInst is displayed")]
        public void ThenAMessageOfSuccesCreationInstIsDisplayed()
        {
            Thread.Sleep(2000);
            Assert.AreEqual("J’accepte que mes données soient traitées pour recevoir des communications adaptées, de la part de Campus France.", Navig.FindElement(By.CssSelector("#edit-field-accepte-communications-wrapper > div > label")).Text);

        }
    }
}
